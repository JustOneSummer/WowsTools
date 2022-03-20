using System.Collections.Generic;
using WowsTools.api;

namespace WowsTools.model
{
    /// <summary>
    /// 游戏总数据信息
    /// </summary>
    class GameInfoData
    {
        /// <summary>
        /// 所属服务器
        /// </summary>
        public WowsServer WowsServer;
        /// <summary>
        /// A队伍总胜率
        /// </summary>
        public double TeamOneWins;
        public int TeamOneBattles;
        public double TeamOneShipWins;
        public int TeamOneShipBattles;
        public int TeamOneCount;
        public string OneWins()
        {
            if (TeamOneWins <= 0 || TeamOneCount <= 0)
            {
                return "0%";
            }
            return (TeamOneWins / TeamOneCount).ToString("f2") + "%";
        }
        public string OneShipWins()
        {
            if (TeamOneShipWins <= 0 || TeamOneCount <= 0)
            {
                return "0%";
            }
            return (TeamOneShipWins / TeamOneCount).ToString("f2") + "%";
        }
        public int OneBattles()
        {
            if (TeamOneBattles <= 0 || TeamOneCount <= 0)
            {
                return 0;
            }
            return TeamOneBattles / TeamOneCount;
        }
        public int OneShipBattles()
        {
            if (TeamOneShipBattles <= 0 || TeamOneCount <= 0)
            {
                return 0;
            }
            return TeamOneShipBattles / TeamOneCount;
        }
        /// <summary>
        /// B队伍总胜率
        /// </summary>
        public double TeamTwoWins;
        public int TeamTwoBattles;
        public double TeamTwoShipWins;
        public int TeamTwoShipBattles;
        public int TeamTwoCount;
        public string TwoWins()
        {
            if (TeamTwoWins <= 0 || TeamTwoCount <= 0)
            {
                return "0%";
            }
            return (TeamTwoWins / TeamTwoCount).ToString("f2") + "%";
        }
        public string TwoShipWins()
        {
            if (TeamTwoShipWins <= 0 || TeamTwoCount <= 0)
            {
                return "0%";
            }
            return (TeamTwoShipWins / TeamTwoCount).ToString("f2") + "%";
        }
        public int TwoBattles()
        {
            if (TeamTwoBattles <= 0 || TeamTwoCount <= 0)
            {
                return 0;
            }
            return TeamTwoBattles / TeamTwoCount;
        }
        public int TwoShipBattles()
        {
            if (TeamTwoShipBattles <= 0 || TeamTwoCount <= 0)
            {
                return 0;
            }
            return TeamTwoShipBattles / TeamTwoCount;
        }
        /// <summary>
        /// 用户账号数据
        /// </summary>
        public List<GameAccountInfoData> TeamOneList;
        public List<GameAccountInfoData> TeamTwoList;
    }
}
