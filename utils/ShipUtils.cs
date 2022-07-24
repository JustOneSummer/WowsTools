using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WowsTools.utils
{
    class ShipUtils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static Dictionary<long, ShipUtils> SHIP_MAP = new Dictionary<long, ShipUtils>();

        public long shipId;
        public string ship_name_cn;
        public string name;
        public int tier;
        public string ship_type;

        public static ShipUtils Get(long shipId, bool update)
        {
            string path = System.Environment.CurrentDirectory + "/ship.json";
            if (SHIP_MAP.Count <= 0 || update)
            {
                //检测文件时间是否超过一天，一天更新一次
                FileInfo fileInfo = new FileInfo(path);
                DateTime lastWriteTimeUtc = fileInfo.LastWriteTimeUtc;
                string lastDate = lastWriteTimeUtc.ToString("yyyy-MM-dd");
                string dayDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                if (!lastDate.Equals(dayDate))
                {
                    try
                    {
                        string jsonData = HttpUtils.Get("https://api.wows.shinoaki.com/public/wows/encyclopedia/ship/search");
                        using (StreamWriter streamWriter = new StreamWriter(path, false))
                        {
                            streamWriter.WriteLine(jsonData);
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error("请求船只数据出错！", e);
                    }
                }
                SHIP_MAP.Clear();
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
                StringBuilder info = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    info.Append(sr.ReadLine());
                }
                sr.Close();
                fs.Close();
                JToken token = JToken.Parse(info.ToString()).Value<JToken>("data");
                foreach (var item in token.ToList())
                {
                    ShipUtils shipUtils = new ShipUtils();
                    shipUtils.shipId = item.Value<long>("id");
                    shipUtils.ship_name_cn = item.Value<string>("shipNameCn");
                    shipUtils.name = item.Value<string>("name");
                    shipUtils.tier = item.Value<int>("tier");
                    shipUtils.ship_type = item.Value<string>("shipType");
                    SHIP_MAP.Add(shipUtils.shipId, shipUtils);
                }
            }
            ShipUtils ship;
            SHIP_MAP.TryGetValue(shipId, out ship);
            if (ship == null)
            {
                ship = new ShipUtils();
                ship.shipId = shipId;
                ship.ship_name_cn = "未知战舰";
                ship.ship_type = "Destroyer";
                ship.tier = 8;
                ship.name = "未知战舰";
            }
            return ship;
        }

        public static string LevelInfo(int level)
        {
            switch (level)
            {
                case 1:
                    return "Ⅰ";
                case 2:
                    return "Ⅱ";
                case 3:
                    return "Ⅲ";
                case 4:
                    return "Ⅳ";
                case 5:
                    return "Ⅴ";
                case 6:
                    return "Ⅵ";
                case 7:
                    return "Ⅶ";
                case 8:
                    return "Ⅷ";
                case 9:
                    return "Ⅸ";
                case 10:
                    return "Ⅹ";
                case 11:
                    return "★";
                default:
                    return "" + level;
            }
        }

        /// <summary>
        /// 越大越低
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int ShipType(string type)
        {
            switch (type)
            {
                case "AirCarrier":
                    return 0;
                case "Battleship":
                    return 1;
                case "Cruiser":
                    return 2;
                case "Destroyer":
                    return 3;
                case "Submarines":
                    return 4;
                default:
                    return 10;
            }
        }
    }
}
