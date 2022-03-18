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
            return  (TeamOneWins / TeamOneCount).ToString("f2") + "%";
        }
        public string OneShipWins()
        {
            return  (TeamOneShipWins / TeamOneCount).ToString("f2") + "%";
        }
        public int OneBattles()
        {
            return TeamOneBattles / TeamOneCount;
        }
        public int OneShipBattles()
        {
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
            return  (TeamTwoWins / TeamTwoCount).ToString("f2") + "%";
        }
        public string TwoShipWins()
        {
            return  (TeamTwoShipWins / TeamTwoCount).ToString("f2") + "%";
        }
        public int TwoBattles()
        {
            return TeamTwoBattles / TeamOneCount;
        }
        public int TwoShipBattles()
        {
            return TeamTwoShipBattles / TeamOneCount;
        }
        /// <summary>
        /// 用户账号数据
        /// </summary>
        public List<GameAccountInfoData> TeamOneList;
        public List<GameAccountInfoData> TeamTwoList;
    }
}
