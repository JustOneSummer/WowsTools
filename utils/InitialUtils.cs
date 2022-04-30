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
        //游戏跟路径
        private static string HOME = null;
        //replay的json文件
        private static string REPLAY_PATH = null;

        public static int CpuProcessCount()
        {
            return (Environment.ProcessorCount / 2) + 1;
        }

        public static string GetHome()
        {
            if (string.IsNullOrEmpty(HOME))
            {
                WowsExeHomePath();
            }
            return HOME;
        }

        public static void HomeToNull()
        {
            HOME = null;
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
                log.Info(IsAdmin() ? "管理员模式加载..." : "非管理员模式加载...");
                if (!GamePathProcess(OwnerProcessPath()))
                {
                    GamePathProcess(ProcessPath());
                }
            }
        }

        private static bool GamePathProcess(string v)
        {
            if (!string.IsNullOrEmpty(v))
            {
                //获取游戏根目录
                log.Info("游戏进程路径=" + v);
                HOME = pathHome(v);
                Settings.Default.GameHomePath = HOME;
                Settings.Default.GameVersionHome = pathHomeBin(HOME) + "\\";
                Settings.Default.Save();
                return true;
            }
            return false;

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

        public static bool IsWowsGameProcess(string name)
        {
            return Regex.IsMatch(name, "^WorldOfWarships\\d\\d\\.exe$");
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

        /// <summary>
        /// 根路径
        /// </summary>
        /// <param name="wows"></param>
        /// <returns></returns>
        private static string pathHome(string wows)
        {
            return wows.Substring(0, wows.LastIndexOf("\\bin\\") + 1);
        }

        /// <summary>
        /// 游戏bin路径
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
        private static string pathHomeBin(string home)
        {
            string path = home + "bin";
            DirectoryInfo d = new DirectoryInfo(path);
            DirectoryInfo[] directs = d.GetDirectories();
            List<int> list = new List<int>();
            foreach (DirectoryInfo direct in directs)
            {
                if (Regex.IsMatch(direct.Name, @"^[0-9]+$"))
                {
                    list.Add(Int32.Parse(direct.Name));
                }
            }
            list.Sort();
            list.Reverse();
            return path + "\\" + list[0];
        }


        /// <summary>
        /// 可能需要提权操作
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static string ProcessPath()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    if (IsWowsGameProcess(process.ProcessName))
                    {
                        ProcessModule mainModule = process.MainModule;
                        return mainModule.FileName;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取程序路径异常！" + ex);
                    return GetProcessFullPath(process.Id);
                }
            }
            return "";
        }

        public static string OwnerProcessPath()
        {
            try
            {
                using (var mc = new ManagementClass("Win32_Process"))
                using (var moc = mc.GetInstances())
                {
                    foreach (ManagementObject mo in moc)
                        using (mo)
                        {
                            try
                            {
                                //var outParams = mo.InvokeMethod("GetOwner", null, null);
                                //ProcessId
                                string process = mo["Name"].ToString();
                                if (IsWowsGameProcess(process))
                                {
                                    return mo["ExecutablePath"].ToString();
                                }
                            }
                            catch (Exception e)
                            {
                                log.Error("获取进程路径发生异常;" + e);
                                break;
                            }
                        }
                }
            }
            catch (Exception e)
            {
                log.Error("获取进程信息发生异常;" + e);
            }
            return "";
        }

        /// <summary>
        /// 进程ID获取路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
    }
}
