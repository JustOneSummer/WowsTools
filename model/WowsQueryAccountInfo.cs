using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using WowsTools.api;
using WowsTools.utils;

namespace WowsTools.model
{
    /// <summary>
    /// 玩家ID信息列表
    /// </summary>
    class WowsQueryAccountInfo
    {
        public long AccountId;
        public string UserName;

        /// <summary>
        /// 查询用户游戏ID
        /// </summary>
        /// <param name="server"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static List<WowsQueryAccountInfo> Info(WowsServer server, List<WowsUserData> userName)
        {
            List<WowsQueryAccountInfo> info = new List<WowsQueryAccountInfo>();
            foreach (var item in userName)
            {
                WowsQueryAccountInfo accountInfo = new WowsQueryAccountInfo();
                accountInfo.UserName = item.userName;
                Dictionary<string, string> map = new Dictionary<string, string>();
                map.Add("search", item.userName);
                string v = HttpUtils.Get(server, "/wows/account/list/", map);
                WowsJsonData jsonData = HttpUtils.WowsJson(v);
                if (jsonData.status)
                {
                    JToken users = jsonData.jToken["data"].Value<JToken>();
                    foreach (JToken jt in users)
                    {
                        if (jt["nickname"].Value<string>().Contains(item.userName))
                        {
                            accountInfo.AccountId = jt["account_id"].Value<long>();
                        }
                    }
                }
                info.Add(accountInfo);
            }

            return info;
        }
    }
}
