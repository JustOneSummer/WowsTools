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
        public double wins;
        /// <summary>
        /// 船只PR评分
        /// </summary>
        public int shipPr;
        /// <summary>
        /// 船只场次
        /// </summary>
        public int shipBattles;
        /// <summary>
        /// 船只胜率
        /// </summary>
        public int shipWins;
        /// <summary>
        /// 船只场均
        /// </summary>
        public int shipDamage;
    }
}
