using System;
using System.Collections.Generic;
using System.Text;

namespace DeveValheimCharacterVersnuiveraar.GameClasses
{
    public class WorldPlayer
    {
        public int PlayerStats_kills { get; set; }
        public int PlayerStats_deaths { get; set; }
        public int PlayerStats_crafts { get; set; }
        public int PlayerStats_builds { get; set; }

        public string PlayerName { get; set; }
        public long PlayerId { get; set; }
        public string StartSeed { get; set; }


        public Dictionary<long, WorldPlayerData> WorldPlayerData { get; set; } = new Dictionary<long, WorldPlayerData>();

        public Player Player { get; set; }
    }
}
