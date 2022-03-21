using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using WowsTools.Properties;

namespace WowsTools.utils
{
    /// <summary>
    /// 初始化工具类
    /// </summary>
    class InitialUtils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static object lockObject = new object();
        private static string HOME = null;
        private static string REPLAY_PATH = null;
        private static string VERSION_BIN_NUMBER = null;

        public static string GetHome()
        {
            if (string.IsNullOrEmpty(HOME))
            {
                WowsExeHomePath();
            }
            return HOME;
        }

        public static string GetReplayPath()
        {
            if (string.IsNullOrEmpty(REPLAY_PATH))
            {
                ReplaysPath();
            }
            return REPLAY_PATH;
        }

        public static void InitExe()
        {
            WowsExeHomePath();
            ReplaysPath();
        }

        /// <summary>
        /// 读取用户replays
        /// </summary>
        /// <returns></returns>
        public static string getReplaysJsonData()
        {
            //检测文件是否存在，游戏开始文件存在，结束则删除
            if (File.Exists(REPLAY_PATH))
            {
                FileStream fs = new FileStream(REPLAY_PATH, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
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

        /// <summary>
        /// 获取是那个服务器的
        /// </summary>
        /// <returns></returns>
        public static string ServerInfo()
        {
            //读取解析服务器信息
            string log = GetHome() + "profile/clientrunner.log";
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


        public static void Director(string dir, List<FileInfo> list)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileInfo[] files = d.GetFiles("*.json");
            DirectoryInfo[] directs = d.GetDirectories();
            foreach (FileInfo f in files)
            {
                list.Add(f);
            }
            //获取子文件夹内的文件列表，递归遍历  
            foreach (DirectoryInfo dd in directs)
            {
                Director(dd.FullName, list);
            }
        }
        private static void WowsExeHomePath()
        {
            lock (lockObject)
            {
                //为空时判断之前的历史设置
                string settings = Settings.Default.GameHomePath;
                if (Directory.Exists(settings + "replays"))
                {
                    HOME = settings;
                }
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName.ToLower().Equals("WorldOfWarships64".ToLower()))
                    {
                        string wows = null;
                        if (IsAdmin())
                        {
                            log.Info("管理员模式加载...");
                            ProcessModule mainModule = process.MainModule;
                            wows = mainModule.FileName;
                        }
                        else
                        {
                            log.Info("非管理员模式加载...");
                            wows = GetProcessFullPath(process.Id);
                        }
                        if (!string.IsNullOrEmpty(wows))
                        {
                            //获取游戏根目录
                            log.Info("游戏进程路径=" + wows);
                            HOME = pathHome(wows);
                            Settings.Default.GameHomePath = HOME;
                            Settings.Default.GameVersionHome = pathHomeBin(HOME) + "\\";
                            Settings.Default.Save();
                            return;
                        }
                    }
                }
            }
        }

        private static void ReplaysPath()
        {
            if (!string.IsNullOrEmpty(HOME))
            {
                string replays = "replays";
                string jsonFile = "tempArenaInfo.json";
                FileInfo info = null;
                List<FileInfo> fileInfos = new List<FileInfo>();
                Director(GetHome() + replays, fileInfos);
                foreach (FileInfo file in fileInfos)
                {
                    if (file.Name.Contains(jsonFile))
                    {
                        if (info == null || file.LastWriteTimeUtc.CompareTo(info.LastWriteTimeUtc) >= 1)
                        {
                            info = file;
                        }
                    }
                }
                if (info != null && File.Exists(info.FullName))
                {
                    REPLAY_PATH = info.FullName;
                    return;
                }
            }

            REPLAY_PATH = null;
        }

        public static bool IsAdmin()
        {
            bool isAdmin;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            return isAdmin;
        }

        public static string GetProcessFullPath(int id)
        {
            const int PROCESS_ALL_ACCESS = 0x1F0FFF;
            const int PROCESS_VM_READ = 0x0010;
            const int PROCESS_VM_WRITE = 0x0020;
            uint Ucapacity = 1024;
            int capacity = 1024;
            StringBuilder builder = new StringBuilder(capacity);
            IntPtr handle = OpenProcess(PROCESS_ALL_ACCESS, false, id);
            QueryFullProcessImageName(handle, 0, builder, ref Ucapacity);
            return builder.ToString();
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpExeName, ref uint lpdwSize);

        private static string pathHome(string wows)
        {
           return wows.Substring(0, wows.LastIndexOf("\\bin\\") + 1);
        }

        private static string pathHomeBin(string home)
        {
            string path = home + "\\bin";
            DirectoryInfo d = new DirectoryInfo(path);
            DirectoryInfo[] directs = d.GetDirectories();
            List<int> list = new List<int>();
            foreach (DirectoryInfo direct in directs)
            {
                if(Regex.IsMatch(direct.Name, "$\\d*"))
                {
                    list.Add(Int32.Parse(direct.Name));
                }
            }
            list.Sort();
            list.Reverse();
            return path+"\\"+list[0];
        }
    }
}
