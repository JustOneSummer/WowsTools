using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using WowsTools.model;

namespace WowsTools.service
{
    class Cn360Service
    {

        public static GameAccountInfoData AccountInfo()
        {
           /* var htmlWebHomeSelect = new  HtmlWeb();
            HtmlDocument htmlDocumentHomeSelect = htmlWebHomeSelect.Load("https://wowsgame.cn/zh-cn/community/accounts/search/?search=%E8%A5%BF%E8%A1%8C%E5%AF%BA%E9%9B%A8%E5%AD%A3&pjax=1");
            //string response =   HttpUtils.Get("https://wowsgame.cn/zh-cn/community/accounts/search/?search=%E8%A5%BF%E8%A1%8C%E5%AF%BA%E9%9B%A8%E5%AD%A3&pjax=1");
            //var doc = new HtmlDocument();
            //doc.Load(response);
            HtmlNode documentNodeHomeSelect = htmlDocumentHomeSelect.DocumentNode;
            HtmlNode htmlNodeHomeSelect = documentNodeHomeSelect.SelectSingleNode("//link[@rel='canonical']");
            string ht = htmlNodeHomeSelect.Attributes["href"].Value;*/
            string ht = "https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/overview/7048302724/";

            GameAccountInfoData game =  new GameAccountInfoData();
            game.AccountId = 7047921442;
            game.AccountName = "丶汐山凉音";
            game.GameAccountShipInfo = new GameAccountShipInfoData();
            game.GameAccountShipInfo.AccountId = 7047921442;
            game.GameAccountShipInfo.ShipId = 427604142410;
            //GameAccountInfoData gameAccountInfoData = AccountInfo2(game, ht);
            GameAccountShipInfoData(game, "https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/ships/7048302724/");
            return null;
        }

        public static string QueryName(string userName)
        {
          string url =   HttpUtility.UrlEncode("https://wowsgame.cn/zh-cn/community/accounts/search/?search=" + userName + "&pjax=1");
            var doc = new HtmlDocument();
            doc.LoadHtml(GetCn(url));
            HtmlNode htmlNodeHomeSelect = doc.DocumentNode.SelectSingleNode("//link[@rel='canonical']");
            return htmlNodeHomeSelect.Attributes["href"].Value;
        }

        /// <summary>
        /// 查询账号信息
        /// </summary>
        /// <param name="gameAccountInfoData"></param>
        /// <param name="urlAddress"></param>
        /// <returns></returns>
        public static GameAccountInfoData AccountInfo2(GameAccountInfoData gameAccountInfoData, string urlAddress)
        {
            //获取用户数据界面 https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/overview/7048302724/
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
        public static GameAccountShipInfoData GameAccountShipInfoData(GameAccountInfoData data,string urlAddress)
        {
            GameAccountShipInfoData gameAccountShipInfo = data.GameAccountShipInfo;
            var htmlWebHomePvpData = new HtmlDocument();
            //https://wowsgame.cn/zh-cn/community/accounts/tab/pvp/ships/7048302724/
            htmlWebHomePvpData.LoadHtml(GetCn(urlAddress));
            //HtmlNode htmlNode = htmlWebHomePvpData.DocumentNode.SelectSingleNode("//tr[@ref='" + gameAccountShipInfo.ShipId + "']");
            HtmlNodeCollection tableBodys = htmlWebHomePvpData.DocumentNode.SelectNodes("//tr[@ref='" + gameAccountShipInfo.ShipId + "']//td[@class='_value']/span");
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
