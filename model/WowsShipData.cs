using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using WowsTools.api;
using WowsTools.utils;

namespace WowsTools.model
{
    class WowsShipData
    {
        public long AccountId;
        public long shipId;
        public int Battles;
        public long DamageDealt;
        public double Wins;
        public int Frags;
        public int SurvivedBattles;

        public double GameWins()
        {
            if (Battles <= 0)
            {
                return 0.0;
            }
            return 100.0 * (Wins / Battles);
        }

        public int GameDamage()
        {
            if (Battles <= 0)
            {
                return 0;
            }
            return (int)Math.Ceiling((DamageDealt + 0.0) / Battles);
        }

        public double GameFrags()
        {
            if (Battles <= 0)
            {
                return 0.0;
            }
            return (Frags + 0.0) / Battles;
        }


        public static WowsShipData Info(WowsServer server, WowsUserData info)
        {
            WowsShipData shipData = new WowsShipData();
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("fields", "pvp.xp,pvp.main_battery,pvp.battles,pvp.wins,pvp.survived_battles,pvp.damage_dealt,pvp.frags,last_battle_time,account_id,ship_id");

            shipData.AccountId = info.accountId;
            shipData.shipId = info.shipId;

            map.Add("account_id", info.accountId.ToString());
            map.Add("ship_id", info.shipId.ToString());

            string v = HttpUtils.PostFrom(server, "/wows/ships/stats/", map);
            WowsJsonData wowsJsonData = HttpUtils.WowsJson(v);
            if (wowsJsonData.status)
            {
                JToken data = wowsJsonData.jToken["data"];
                int BattlesTem = -1;
                long DamageDealtTem = 0;
                double WinsTem = 0;
                int FragsTem = 0;
                int SurvivedBattlesTem = 0;
                if (data.ToList().Count >=1 )
                {
                    JToken list = data.Value<JToken>(info.accountId.ToString()).ToList().ElementAt(0);
                    JToken pvp = list.Value<JToken>("pvp");
                    BattlesTem = pvp.Value<int>("battles");
                    DamageDealtTem = pvp.Value<long>("damage_dealt");
                    WinsTem = pvp.Value<double>("wins");
                    FragsTem = pvp.Value<int>("frags");
                    SurvivedBattlesTem = pvp.Value<int>("survived_battles");
                }
                shipData.Battles = BattlesTem;
                shipData.DamageDealt = DamageDealtTem;
                shipData.Wins = WinsTem;
                shipData.Frags = FragsTem;
                shipData.SurvivedBattles = SurvivedBattlesTem;
            }
            return shipData;
        }
    }
}
