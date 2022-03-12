namespace WowsTools.model
{
    class GameAccountInfoData
    {
        /// <summary>
        /// 游戏给出的ID信息
        /// </summary>
        public long Id;
        /// <summary>
        /// 是否友方
        /// </summary>
        public bool Team;
        /// <summary>
        /// 游戏账号名称
        /// </summary>
        public string AccountName;

        /// <summary>
        /// 是否隐藏了战绩
        /// </summary>
        public bool Hide = false;
        /// <summary>
        /// 用户账号ID
        /// </summary>
        public long AccountId;

        /// <summary>
        /// 胜场次
        /// </summary>
        public double Wins;

        /// <summary>
        /// 场次
        /// </summary>
        public int Battles;

        /// <summary>
        /// 输出
        /// </summary>
        public long Damage;

        /// <summary>
        /// 船只数据
        /// </summary>
        public GameAccountShipInfoData GameAccountShipInfo;

        public double GameWins()
        {
            if (Battles <= 0)
            {
                return 0.0;
            }
            return 100.0 * (Wins / Battles);
        }
    }
}
