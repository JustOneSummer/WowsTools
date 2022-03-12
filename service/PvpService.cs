using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
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
            }
            return dataList;
        }

        public static GameAccountInfoData AccountInfo(WowsServer server,GameAccountInfoData games)
        {
            games.AccountId =  WowsAccount.QueryName(server,games.AccountName);
            games = WowsAccount.QueryAccountInfo(server, games);
            games.GameAccountShipInfo = WowsAccount.QueryShipInfoData(server, games.AccountId, games.GameAccountShipInfo);
            return games;
        }

        public static GameInfoData GameInfoData(WowsServer server, List<GameAccountInfoData> games)
        {
            GameInfoData data = new GameInfoData();
            List<GameAccountInfoData> teamOne = new List<GameAccountInfoData>();
            List<GameAccountInfoData> teamTwo = new List<GameAccountInfoData>();
            int oneCount = 0;
            int twoCount = 0;
            double oneWins = 0;
            double twoWins = 0;
            foreach(var item in games)
            {
                if (item.Team)
                {
                    teamOne.Add(item);
                    if (!item.Hide)
                    {
                        oneCount++;
                        oneWins += item.GameWins();
                    }
                }
                else
                {
                    teamTwo.Add(item);
                    if (!item.Hide)
                    {
                        twoCount++;
                        twoWins += item.GameWins();
                    }
                }
            }
            data.WowsServer = server;
            data.TeamOneList = teamOne;
            data.TeamOneCount = oneCount;
            data.TeamOneWins = oneWins;

            data.TeamTwoList = teamTwo;
            data.TeamTwoCount = twoCount;
            data.TeamTwoWins = twoWins;
            return data;
        }
    }
}
