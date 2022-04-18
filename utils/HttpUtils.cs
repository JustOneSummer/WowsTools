using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using WowsTools.api;
using WowsTools.model;

namespace WowsTools.utils
{
    class HttpUtils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string URL = "http://proxy.wows.shinoaki.com:7152";
        public static string GetVersion()
        {
            try
            {
                Get(URL + "/public/upload?info=" + InitialUtils.GetCpuID());
                return Get(URL + "/public/version");
            }
            catch (Exception e)
            {
                log.Error("版本相关信息获取异常 : ", e);
            }
            return "0.0.1";
        }

        public static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Timeout = 20000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        public static string Get(WowsServer server, string path, Dictionary<string, string> map)
        {
            string url = server.ServiceApi + path + "?application_id=" + WowsServer.KEY;
            foreach (var data in map)
            {
                url += ("&" + data.Key + "=" + data.Value);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Timeout = 20000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        public static string PostFrom(WowsServer server, string path, Dictionary<string, string> map)
        {
            string url = server.ServiceApi + path;
            map.Add("application_id", WowsServer.KEY);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.Timeout = 20000;

            NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
            foreach (var item in map)
            {
                outgoingQueryString.Add(item.Key, item.Value);
            }
            string fromData = outgoingQueryString.ToString();
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //string json = JsonConvert.SerializeObject(map);
                //streamWriter.Write(json);
                streamWriter.Write(fromData, 0, fromData.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        public static WowsJsonData WowsJson(string data)
        {
            WowsJsonData jsonData = new WowsJsonData();
            jsonData.status = false;
            JToken token = JToken.Parse(data);
            //查找
            string status = token["status"].Value<string>();
            if (status.Contains("ok"))
            {
                jsonData.status = true;
                jsonData.jToken = token;
            }
            return jsonData;
        }
    }
}
