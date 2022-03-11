﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using WowsTools.model;

namespace WowsTools.utils
{
    /// <summary>
    /// 初始化工具类
    /// </summary>
    class InitialUtils
    {
        private static string HOME = null;
        
        /// <summary>
        /// 初始化时的加载-获取游戏路径
        /// </summary>
        /// <returns></returns>
        public static string wowsExeHomePath()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName.Contains("World"))
                {
                    ProcessModule mainModule = process.MainModule;
                    string wows = mainModule.FileName;

                    //获取游戏根目录
                    HOME = wows.Substring(0, wows.IndexOf("World_of_Warships") + 18);
                    return HOME;

                }
            }
            return null;
        }

        /// <summary>
        /// 获取replay路径
        /// </summary>
        /// <returns></returns>
        public static string ReplaysPath()
        {
            return HOME + "replays/tempArenaInfo.json";
        }

        /// <summary>
        /// 获取是那个服务器的
        /// </summary>
        /// <returns></returns>
        public static string ServerInfo()
        {
            //读取解析服务器信息
            string log = HOME + "profile/clientrunner.log";
            FileStream fs = new FileStream(log, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            string info = null;
            while (!sr.EndOfStream)
            {
                string tem = sr.ReadLine();
                if (tem.Contains("Selected realm"))
                {
                    info = tem.Substring(tem.LastIndexOf("realm") + 6);
                    break;
                }
            }
            sr.Close();
            fs.Close();
            return info.Trim();
        }

        /// <summary>
        /// 读取用户replays
        /// </summary>
        /// <returns></returns>
        public static List<WowsUserData> getReplaysData()
        {
            List<WowsUserData> dataList = new List<WowsUserData>();
            //检测文件是否存在，游戏开始文件存在，结束则删除
            string jsonFilePath = ReplaysPath();
            if (File.Exists(jsonFilePath))
            {
                FileStream fs = new FileStream(jsonFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                StringBuilder info = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    info.Append(sr.ReadLine());
                }
                sr.Close();
                fs.Close();
                //解析
                JToken token = JsonConvert.DeserializeObject<JToken>(info.ToString());
                int playersPerTeam = token["playersPerTeam"].Value<int>();
                foreach(var jt in token["vehicles"])
                {
                    WowsUserData data = new WowsUserData();
                    data.playersPerTeam = playersPerTeam;
                    data.id = jt["id"].Value<long>();
                    data.relation = jt["relation"].Value<int>();
                    data.userName = jt["name"].Value<string>();
                    data.shipId = jt["shipId"].Value<long>();
                    dataList.Add(data);
                }
            }
            return dataList;
        }
    }
}