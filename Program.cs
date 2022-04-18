using System;
using System.Management;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WowsTools
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string OS_VERSION = string.Empty;
        public static bool OS_VERSION_WIN7 = false;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Cn360Service.AccountInfo();
            try
            {
                OS_Version();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new WowsMain());
            }
            catch (Exception ex)
            {
                string str = GetExceptionMsg(ex, string.Empty);
                log.Error(str);
                MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("【请截图发给作者解决 QQ：262749113】");
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }

       public static void OS_Version()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            //create object searcher
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);
            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();
            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                OS_VERSION = m["Caption"].ToString();
            }
            if (OS_VERSION != string.Empty)
            {
                if (OS_VERSION.Contains("Microsoft Windows 7"))
                {
                    OS_VERSION_WIN7 = true;
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons*/
                }
            }
        }
    }
}
