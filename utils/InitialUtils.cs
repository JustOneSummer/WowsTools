using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text;

namespace WowsTools.utils
{
    /// <summary>
    /// 初始化工具类
    /// </summary>
    class InitialUtils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                if (process.ProcessName.LastIndexOf("WorldOfWarships") == 0)
                {
                    ProcessModule mainModule = process.MainModule;
                    string wows = mainModule.FileName;

                    //获取游戏根目录
                    HOME = wows.Substring(0, wows.LastIndexOf("\\bin\\") + 1);
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
            List<string> list = new List<string>();
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
            sr.Close();
            fs.Close();
            for (int i = list.Count - 1; i > 0; i--)
            {
                string tem = list[i];
                if (tem.Contains("Selected realm"))
                {
                    info = tem.Substring(tem.LastIndexOf("realm") + 6);
                    break;
                }
            }
            return info.Trim();
        }

        /// <summary>
        /// 读取用户replays
        /// </summary>
        /// <returns></returns>
        public static string getReplaysJsonData()
        {
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
                string infoJson = info.ToString();
                string path = System.Environment.CurrentDirectory + "/tempArenaInfo.json";
                using (StreamWriter streamWriter = new StreamWriter(path, false))
                {
                    streamWriter.WriteLine(infoJson);
                }
                return infoJson;
            }
            return null;
        }

        public static string GetCpuID()
        {
            try
            {
                string cpuInfo = "";
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }

            finally { }
        }
    }
}
