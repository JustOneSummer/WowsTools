using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WowsTools.model;

namespace WowsTools.utils
{
    class ShipPrUtils
    {
        private static Dictionary<long, ShipPrUtils> PR_MAP = new Dictionary<long, ShipPrUtils>();

        public long shipId;
        public double winRate;
        public double averageDamageDealt;
        public double averageFrags;


        public static ShipPrUtils Get(long shipId, bool update)
        {
            string path = System.Environment.CurrentDirectory + "/pr.json";
            if (PR_MAP.Count <= 0 || update)
            {
                //检测文件时间是否超过一天，一天更新一次
                FileInfo fileInfo = new FileInfo(path);
                DateTime lastWriteTimeUtc = fileInfo.LastWriteTimeUtc;
                if (!DateTime.Equals(lastWriteTimeUtc, DateTime.UtcNow))
                {
                    string jsonData = HttpUtils.Get("http://public.wows.shinoaki.com:7152/public/ship/pr/list");
                    using (StreamWriter streamWriter = new StreamWriter(path, false))
                    {
                        streamWriter.WriteLine(jsonData);
                    }
                }
                PR_MAP.Clear();
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
                    ShipPrUtils shipUtils = new ShipPrUtils();
                    shipUtils.shipId = item.Value<long>("idCode");
                    shipUtils.winRate = item.Value<double>("winRate");
                    shipUtils.averageDamageDealt = item.Value<double>("averageDamageDealt");
                    shipUtils.averageFrags = item.Value<double>("averageFrags");
                    PR_MAP.Add(shipUtils.shipId, shipUtils);
                }
            }
            ShipPrUtils ship;
            PR_MAP.TryGetValue(shipId, out ship);
            return ship;
        }

        public static int Pr(WowsShipData ship,ShipPrUtils pr)
        {
            if(ship.Battles <=0 || pr == null || pr.winRate <= 0 || pr.averageDamageDealt <= 0 || pr.averageFrags <= 0)
            {
                return 0;
            }
            double nd = nDmg(ship.GameDamage(), pr.averageDamageDealt);
            double nf = nFrags(ship.GameFrags(), pr.averageFrags);
            double nw = nWins(ship.GameWins(), pr.winRate);
            return result(nd, nf, nw);
        }

        private static int result(double nDamage, double nFrags, double ngWins)
        {
            return (int)Math.Ceiling(700 * nDamage + 300 * nFrags + 150 * ngWins);
        }

        private static double nDmg(double actualDmg, double expectedDmg)
        {
            double nDmg = expectedDmg * 0.4;
            if (actualDmg > nDmg)
            {
                return (actualDmg - nDmg) / (expectedDmg * 0.6);
            }
            return 0;
        }

        private static double nWins(double actualWins, double expectedWins)
        {
            double nWins = expectedWins * 0.7;
            if (actualWins > nWins)
            {
                return (actualWins - nWins) / (expectedWins * 0.3);
            }
            return 0;
        }

        private static double nFrags(double actualFrags, double expectedFrags)
        {
            double nFrags = actualFrags * 0.1;
            if (actualFrags > nFrags)
            {
                return (actualFrags - nFrags) / (expectedFrags * 0.9);
            }
            return 0;
        }
    }
}
