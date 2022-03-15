using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using WowsTools.api;
using WowsTools.model;
using WowsTools.utils;

namespace WowsTools.service
{
    /// <summary>
    /// 随机数据信息查询
    /// </summary>
    class PvpService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 解析文件信息
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<GameAccountInfoData> ReadReplays()
        {
            List<GameAccountInfoData> dataList = new List<GameAccountInfoData>();
            string json = InitialUtils.getReplaysJsonData();
            if (string.IsNullOrEmpty(json))
            {
                return dataList;
            }

            //解析
            JToken token = JsonConvert.DeserializeObject<JToken>(json);
            int playersPerTeam = token["playersPerTeam"].Value<int>();
            StringBuilder builder = new StringBuilder();
            foreach (var jt in token["vehicles"])
            {
                GameAccountInfoData data = new GameAccountInfoData();
                GameAccountShipInfoData infoData = new GameAccountShipInfoData();
                data.Id = jt["id"].Value<long>();
                data.Team = jt["relation"].Value<int>() < 2;
                data.AccountName = jt["name"].Value<string>();
                infoData.ShipId = jt["shipId"].Value<long>();
                data.GameAccountShipInfo = infoData;
                dataList.Add(data);
                builder.Append(data.AccountName).Append(",");
            }
            log.Info("对局信息用户名称：" + builder.ToString());
            return dataList;
        }

        /// <summary>
        /// 游戏信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="games"></param>
        /// <returns></returns>
        public static GameAccountInfoData AccountInfo(WowsServer server, GameAccountInfoData games)
        {
            games.AccountId = WowsAccount.QueryName(server, games.AccountName);
            games = WowsAccount.QueryAccountInfo(server, games);
            games.GameAccountShipInfo = WowsAccount.QueryShipInfoData(server, games.AccountId, games.GameAccountShipInfo);
            return games;
        }

        /// <summary>
        /// 对局信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="games"></param>
        /// <returns></returns>
        public static GameInfoData GameInfoData(WowsServer server, List<GameAccountInfoData> games)
        {
            GameInfoData data = new GameInfoData();
            List<GameAccountInfoData> teamOne = new List<GameAccountInfoData>();
            List<GameAccountInfoData> teamTwo = new List<GameAccountInfoData>();
            int oneCount = 0;
            int twoCount = 0;
            double oneWins = 0;
            double twoWins = 0;
            int oneBattle = 0;
            int twoBattle = 0;
            double oneShipWins = 0;
            double twoShipWins = 0;
            int oneShipBattle = 0;
            int twoShipBattle = 0;
            foreach (var item in games)
            {
                ShipUtils shipUtils = ShipUtils.Get(item.GameAccountShipInfo.ShipId, false);
                item.GameAccountShipInfo.ShipName = string.IsNullOrEmpty(shipUtils.ship_name_cn) ? shipUtils.name : shipUtils.ship_name_cn;
                item.GameAccountShipInfo.ShipLevel = shipUtils.tier;
                item.GameAccountShipInfo.ShipType = shipUtils.ship_type;
                item.GameAccountShipInfo.ShipTypeNumber = ShipUtils.ShipType(item.GameAccountShipInfo.ShipType);
                data.WowsServer = server;
                if (item.Team)
                {
                    teamOne.Add(item);
                    if (!item.Hide)
                    {
                        oneCount++;
                        oneWins += item.GameWins();
                        oneBattle += item.Battles;
                        oneShipWins += item.GameAccountShipInfo.GameWins();
                        oneShipBattle += item.GameAccountShipInfo.Battles;
                    }
                }
                else
                {
                    teamTwo.Add(item);
                    if (!item.Hide)
                    {
                        twoCount++;
                        twoBattle += item.Battles;
                        twoWins += item.GameWins();
                        twoShipWins += item.GameAccountShipInfo.GameWins();
                        twoShipBattle += item.GameAccountShipInfo.Battles;
                    }
                }
            }
            data.TeamOneList = teamOne;
            data.TeamOneCount = oneCount;
            data.TeamOneWins = oneWins;
            data.TeamOneBattles = oneBattle;
            data.TeamOneShipWins = oneShipWins;
            data.TeamOneShipBattles = oneShipBattle;

            data.TeamTwoList = teamTwo;
            data.TeamTwoCount = twoCount;
            data.TeamTwoWins = twoWins;
            data.TeamTwoBattles = twoBattle;
            data.TeamTwoShipWins = twoShipWins;
            data.TeamTwoShipBattles = twoShipBattle;
            return data;
        }
    }
}
