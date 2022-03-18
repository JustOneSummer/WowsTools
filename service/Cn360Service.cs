using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using WowsTools.model;
using WowsTools.utils;

namespace WowsTools.service
{
    class Cn360Service
    {

        /// <summary>
        /// 测试用
        /// </summary>
        /// <returns></returns>
        public static GameAccountInfoData AccountInfo()
        {
            QueryNameUrl("梅露露琳丝·雷蒂·阿鲁兹");
            return null;
        }

        public static long QueryNameUrl(string userName)
        {
            if (userName.Substring(0,1).Equals(":"))
            {
                return -1;
            }
          string url =   "https://wowsgame.cn/zh-cn/community/accounts/search/?search=" + HttpUtility.UrlEncode(userName) + "&pjax=1";
            var htmlWebHomeSelect = new HtmlWeb();
             HtmlDocument htmlDocument = htmlWebHomeSelect.Load(url);
            HtmlNode htmlNodeHomeSelect = htmlDocument.DocumentNode.SelectSingleNode("//link[@rel='canonical']");
            string urlLink = htmlNodeHomeSelect.Attributes["href"].Value;
            string idInfo =  urlLink.Substring(urlLink.LastIndexOf("accounts") + 9);
            string[] id = idInfo.Split('-');
            if(id.Length <= 1)
            {
                return -1;
            }
            return long.Parse(id[0]);
        }

        /// <summary>
        /// 查询账号信息
        /// </summary>
        /// <param name="gameAccountInfoData"></param>
        /// <param name="urlAddress"></param>
        /// <returns></returns>
        public static GameAccountInfoData AccountInfo(GameAccountInfoData gameAccountInfoData)
        {
            //获取用户数据界面 https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/overview/7048302724/
            string urlAddress = "https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/overview/" + gameAccountInfoData.AccountId;
            var htmlWebHomePvpData = new HtmlDocument();
            htmlWebHomePvpData.LoadHtml(GetCn(urlAddress));
            HtmlNodeCollection htmlNodeTableBodys = htmlWebHomePvpData.DocumentNode.SelectNodes("//table[@class='account-table _left']/tbody/tr/td[@class='_value']/span");
            //战斗场次
            string zdcc = htmlNodeTableBodys[0].InnerText;
            string sl = htmlNodeTableBodys[1].InnerText;
            //string chunhuo = htmlNodeTableBodys[2].InnerText;
            string shuchu = htmlNodeTableBodys[4].InnerText;
            gameAccountInfoData.Battles = int.Parse(zdcc);
            gameAccountInfoData.Wins = double.Parse(sl);
            gameAccountInfoData.Damage = long.Parse(shuchu);
            return gameAccountInfoData;
        }

        /// <summary>
        /// 查询战舰信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="urlAddress"></param>
        /// <returns></returns>
        public static GameAccountShipInfoData GameAccountShipInfoData(GameAccountInfoData data)
        {
            string urlAddress = "https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/ships/" + data.AccountId;
            GameAccountShipInfoData gameAccountShipInfo = data.GameAccountShipInfo;
            var htmlWebHomePvpData = new HtmlDocument();
            //https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/ships/7048302724/
            htmlWebHomePvpData.LoadHtml(GetCn(urlAddress));
            HtmlNodeCollection tableBodys = htmlWebHomePvpData.DocumentNode.SelectNodes("//tr[starts-with(@ref,'" + gameAccountShipInfo.ShipId + "')]//td[@class='_value']/span");
            if (tableBodys != null)
            {
                string zdcc = tableBodys[0].InnerText;
                string sl = tableBodys[1].InnerText;
                string chunhuo = tableBodys[2].InnerText;
                string shuchu = tableBodys[3].InnerText;
                string jisha = tableBodys[4].InnerText;
                gameAccountShipInfo.Battles = int.Parse(zdcc);
                gameAccountShipInfo.Wins = double.Parse(sl);
                gameAccountShipInfo.DamageDealt = long.Parse(shuchu);
                gameAccountShipInfo.Frags = int.Parse(jisha);
                gameAccountShipInfo.SurvivedBattles = int.Parse(chunhuo);
                //PR计算
                gameAccountShipInfo.Pr = ShipPrUtils.Pr(gameAccountShipInfo, ShipPrUtils.Get(gameAccountShipInfo.ShipId, false));
            }
            return gameAccountShipInfo;
        }


        public static string GetCn(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "text/html;charset=UTF-8";
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Timeout = 20000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
    }
}
