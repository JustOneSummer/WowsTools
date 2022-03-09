using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
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
        public static long AccountId(WowsServer server,string userName)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("search", userName);
            string v = HttpUtils.Get(server, "/wows/account/list/",map);
            JToken token = JsonConvert.DeserializeObject<JToken>(v);
            //查找
            string status = token["status"].Value<string>();
            if (status.Contains("ok"))
            {
                JToken users = token["data"].Value<JToken>();
                foreach(JToken jt in users)
                {
                    if (jt["nickname"].Value<string>().Contains(userName))
                    {
                        return jt["account_id"].Value<long>();
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 根据用户账户ID查询总战绩信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="accountIds"></param>
        public static WowsUserData[] gameInfo(WowsServer server,long[] accountIds)
        {

        }
    }
}
