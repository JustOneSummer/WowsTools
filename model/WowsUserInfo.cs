using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowsTools.api;
using WowsTools.utils;

namespace WowsTools.model
{
    class WowsUserInfo
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public WowsQueryAccountInfo AccountInfo;
        public int Battles;
        public long DamageDealt;
        public double wins;

        public double GameWins()
        {
            if(Battles <= 0)
            {
                return 0.0;
            }
            return 100.0 * (wins / Battles);
        }


        /// <summary>
        /// 根据用户账户ID查询总战绩信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="accountIds"></param>
        public static List<WowsUserInfo> Info(WowsServer server, List<WowsQueryAccountInfo> infos)
        {
            List<WowsUserInfo> info = new List<WowsUserInfo>();            
            Dictionary<string, string> map = new Dictionary<string, string>();
            //map.Add("extra", "statistics.pvp_div2,statistics.pvp_div3,statistics.pvp_solo");
            //map.Add("fields", "last_battle_time,nickname,statistics.pvp_solo.xp,statistics.pvp_solo.main_battery,statistics.pvp_solo.battles,statistics.pvp_solo.wins,statistics.pvp_solo.survived_battles,statistics.pvp_solo.damage_dealt,statistics.pvp_solo.frags,statistics.pvp_div3.xp,statistics.pvp_div3.main_battery,statistics.pvp_div3.battles,statistics.pvp_div3.wins,statistics.pvp_div3.survived_battles,statistics.pvp_div3.damage_dealt,statistics.pvp_div3.frags,statistics.pvp_div2.xp,statistics.pvp_div2.main_battery,statistics.pvp_div2.battles,statistics.pvp_div2.wins,statistics.pvp_div2.survived_battles,statistics.pvp_div2.damage_dealt,statistics.pvp_div2.frags,statistics.pvp.xp,statistics.pvp.main_battery,statistics.pvp.battles,statistics.pvp.wins,statistics.pvp.survived_battles,statistics.pvp.damage_dealt,statistics.pvp.frags");
            map.Add("fields", "last_battle_time,nickname,statistics.pvp.xp,statistics.pvp.main_battery,statistics.pvp.battles,statistics.pvp.wins,statistics.pvp.survived_battles,statistics.pvp.damage_dealt,statistics.pvp.frags");

            StringBuilder builder = new StringBuilder();
            foreach (var item in infos)
            {
                WowsUserInfo userInfo = new WowsUserInfo();
                userInfo.AccountInfo = item;
                info.Add(userInfo);
                builder.Append(item.AccountId).Append(",");
            }
            string accINfo = builder.ToString();
            log.Info("查询用户账号信息："+ accINfo);
            map.Add("account_id", accINfo.Substring(0,builder.Length-1));
            string v = HttpUtils.PostFrom(server, "/wows/account/info/", map);
            log.Info("游戏用户信息：" + v);
            WowsJsonData wowsJsonData = HttpUtils.WowsJson(v);
            if (wowsJsonData.status)
            {
                JToken data = wowsJsonData.jToken["data"];
                foreach (var item in info)
                {
                    JToken userToken =  data.Value<JToken>(item.AccountInfo.AccountId.ToString());
                    JToken statistics = userToken.Value<JToken>("statistics");
                    int battles = -1;
                    long dd = -1;
                    double wins = 0;
                    if (statistics.Type != JTokenType.Null)
                    {
                        JToken pvp = statistics.Value<JToken>("pvp");
                        battles = pvp.Value<int>("battles");
                        dd = pvp.Value<long>("damage_dealt");
                        wins = pvp.Value<double>("wins");
                    }
                    item.Battles = battles;
                    item.DamageDealt = dd;
                    item.wins = wins;
                }
            }
            return info;
        }
    }
}
