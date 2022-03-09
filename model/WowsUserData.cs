namespace WowsTools.model
{
    class WowsUserData
    {
        public int playersPerTeam;
        public long accountId;
        public long id;
        public string userName;
        /// <summary>
        /// 1和0是自己的人 2是敌人
        /// </summary>
        public int relation;
        /// <summary>
        /// 船只ID
        /// </summary>
        public long shipId;
        /// <summary>
        /// 总胜率
        /// </summary>
        public string wins = "N/A";

        /// <summary>
        /// 船只名称
        /// </summary>
        public string shipName = "N/A";

        /// <summary>
        /// 船只PR评分
        /// </summary>
        public int shipPr = -1;

        /// <summary>
        /// 船只等级
        /// </summary>
        public string shipLevel = "N/A";

        /// <summary>
        /// 船只场次
        /// </summary>
        public int shipBattles = 0;
        /// <summary>
        /// 船只胜率
        /// </summary>
        public string shipWins = "N/A";
        /// <summary>
        /// 船只场均
        /// </summary>
        public int shipDamage = -1;
    }
}
