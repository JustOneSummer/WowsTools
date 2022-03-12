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
        public int TeamOneCount;
        /// <summary>
        /// B队伍总胜率
        /// </summary>
        public double TeamTwoWins;
        public int TeamTwoCount;
        /// <summary>
        /// 用户账号数据
        /// </summary>
        public List<GameAccountInfoData> TeamOneList;
        public List<GameAccountInfoData> TeamTwoList;
    }
}
