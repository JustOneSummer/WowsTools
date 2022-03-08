using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using WowsTools.api;

namespace WowsTools.utils
{
    class HttpUtils
    {
        public static string Get(WowsServer server,string path, Dictionary<string,string> map)
        {
            string url = server.ServiceApi+path+ "?application_id="+WowsServer.KEY;
            foreach(var data in map)
            {
                url += ("&"+ data.Key + "=" + data.Value);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Timeout = 3000;
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
