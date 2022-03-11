using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using WowsTools.model;
using WowsTools.utils;

namespace WowsTools.api
{
    /// <summary>
    /// 查询用户数据
    /// </summary>
    class WowsAccount
    {
        /// <summary>
        /// 查询用户游戏ID
        /// </summary>
        /// <param name="server"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static List<WowsQueryAccountInfo> AccountId(WowsServer server, List<WowsUserData> userName)
        {
            return WowsQueryAccountInfo.Info(server,userName);
        }

        /// <summary>
        /// 根据用户账户ID查询总战绩信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="accountIds"></param>
        public static Dictionary<string, WowsUserInfo> GameInfo(WowsServer server, List<WowsQueryAccountInfo> datas)
        {
            Dictionary<string, WowsUserInfo> pairs = new Dictionary<string, WowsUserInfo>();
            List<WowsUserInfo> wowsUserInfos = WowsUserInfo.Info(server, datas);
            foreach(var item in wowsUserInfos)
            {
                pairs.Add(item.AccountInfo.UserName, item);
            }
          return pairs;
        }
    }
}
