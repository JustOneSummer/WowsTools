using System;

namespace WowsTools.model
{
    class GameAccountShipInfoData
    {
        public long AccountId;
        public long ShipId;
        public string ShipName;
        public int ShipLevel;
        public string ShipType;
        public int ShipTypeNumber;
        public int Battles;
        public long DamageDealt;
        public double Wins;
        public int Frags;
        public int SurvivedBattles;
        public int Pr;


        public double GameWins()
        {
            if (Battles <= 0)
            {
                return 0.0;
            }
            return 100.0 * (Wins / Battles);
        }

        public int GameDamage()
        {
            if (Battles <= 0)
            {
                return 0;
            }
            return (int)Math.Ceiling((DamageDealt + 0.0) / Battles);
        }

        public double GameFrags()
        {
            if (Battles <= 0)
            {
                return 0.0;
            }
            return (Frags + 0.0) / Battles;
        }
    }
}
