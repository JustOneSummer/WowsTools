using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using WowsTools.model;
using WowsTools.utils;

namespace WowsTools.api
{
    /// <summary>
    /// 查询用户数据
    /// </summary>
    class WowsAccount
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 根据用户名查询AccountId
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public static long QueryName(WowsServer Server, string AccountName)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("search", AccountName);
            try
            {
                string v = HttpUtils.Get(Server, "/wows/account/list/", map);
                if (!string.IsNullOrEmpty(v))
                {
                    WowsJsonData jsonData = HttpUtils.WowsJson(v);
                    if (jsonData.status)
                    {
                        JToken users = jsonData.jToken["data"].Value<JToken>();
                        foreach (JToken jt in users)
                        {
                            if (jt["nickname"].Value<string>().ToUpper().Equals(AccountName.ToUpper()))
                            {
                                return jt["account_id"].Value<long>();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("查询用户名请求异常！" + e.Message);
            }
            return 0;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static GameAccountInfoData QueryAccountInfo(WowsServer server, GameAccountInfoData game)
        {
            game.Hide = true;
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("fields", "last_battle_time,nickname,statistics.pvp.xp,statistics.pvp.main_battery,statistics.pvp.battles,statistics.pvp.wins,statistics.pvp.survived_battles,statistics.pvp.damage_dealt,statistics.pvp.frags");
            map.Add("account_id", game.AccountId.ToString());
            string v = HttpUtils.PostFrom(server, "/wows/account/info/", map);
            log.Info(game.AccountId + " 游戏用户信息：" + v);
            if (!string.IsNullOrEmpty(v))
            {
                WowsJsonData wowsJsonData = HttpUtils.WowsJson(v);
                if (game.AccountId > 0 && wowsJsonData.status)
                {
                    JToken data = wowsJsonData.jToken["data"];
                    int battles = 0;
                    long damage = 0;
                    double wins = 0;
                    JToken userToken = data.Value<JToken>(game.AccountId.ToString());
                    if (userToken != null && userToken.Type != JTokenType.Null)
                    {
                        JToken statistics = userToken.Value<JToken>("statistics");
                        if (statistics.Type != JTokenType.Null)
                        {
                            JToken pvp = statistics.Value<JToken>("pvp");
                            battles = pvp.Value<int>("battles");
                            damage = pvp.Value<long>("damage_dealt");
                            wins = pvp.Value<double>("wins");
                            game.Hide = false;
                        }
                    }
                    game.Battles = battles;
                    game.Damage = damage;
                    game.Wins = wins;
                }
            }
            return game;
        }


        public static GameAccountShipInfoData QueryShipInfoData(WowsServer server, long accountId, GameAccountShipInfoData shipInfoData)
        {
            shipInfoData.AccountId = accountId;
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("fields", "pvp.xp,pvp.main_battery,pvp.battles,pvp.wins,pvp.survived_battles,pvp.damage_dealt,pvp.frags,last_battle_time,account_id,ship_id");
            map.Add("account_id", accountId.ToString());
            map.Add("ship_id", shipInfoData.ShipId.ToString());

            string v = HttpUtils.PostFrom(server, "/wows/ships/stats/", map);
            log.Info("游戏用户船只信息：" + v);
            if (!string.IsNullOrEmpty(v))
            {
                WowsJsonData wowsJsonData = HttpUtils.WowsJson(v);
                if (accountId > 0 && wowsJsonData.status)
                {
                    JToken data = wowsJsonData.jToken["data"];
                    int BattlesTem = 0;
                    long DamageDealtTem = 0;
                    double WinsTem = 0;
                    int FragsTem = 0;
                    int SurvivedBattlesTem = 0;
                    if (data.ToList().Count >= 1)
                    {
                        JToken item = data.Value<JToken>(accountId.ToString());
                        if (item.Type != JTokenType.Null)
                        {
                            JToken list = item.ToList().ElementAt(0);
                            JToken pvp = list.Value<JToken>("pvp");
                            BattlesTem = pvp.Value<int>("battles");
                            DamageDealtTem = pvp.Value<long>("damage_dealt");
                            WinsTem = pvp.Value<double>("wins");
                            FragsTem = pvp.Value<int>("frags");
                            SurvivedBattlesTem = pvp.Value<int>("survived_battles");
                        }
                    }
                    shipInfoData.Battles = BattlesTem;
                    shipInfoData.DamageDealt = DamageDealtTem;
                    shipInfoData.Wins = WinsTem;
                    shipInfoData.Frags = FragsTem;
                    shipInfoData.SurvivedBattles = SurvivedBattlesTem;
                }
                //PR计算
                shipInfoData.Pr = ShipPrUtils.Pr(shipInfoData, ShipPrUtils.Get(shipInfoData.ShipId, false));
            }
            return shipInfoData;
        }
    }
}
