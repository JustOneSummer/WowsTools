using System.Collections.Generic;

namespace WowsTools.api
{
    class WowsServer
    {
        public string CodeId { get; }
        public string ServiceApi { get; }
        public string ServerName { get; }

        public static Dictionary<string, WowsServer> SERVER = new Dictionary<string, WowsServer>() {
            {"asia",new WowsServer("asia","https://api.worldofwarships.asia","亚服") },
            {"eu",new WowsServer("eu","https://api.worldofwarships.eu","欧服") },
            {"na",new WowsServer("na","https://api.worldofwarships.com","美服") },
            {"ru",new WowsServer("ru","https://api.worldofwarships.ru","俄服") },
            {"cn",new WowsServer("cn","https://wowsgame.cn/zh-cn/community/accounts/","国服") }
        };

        public const string KEY = "907d9c6bfc0d896a2c156e57194a97cf";

        public WowsServer(string v1, string v2, string v3)
        {
            CodeId = v1;
            ServiceApi = v2;
            ServerName = v3;
        }
    }

}
