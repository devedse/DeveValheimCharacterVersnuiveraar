using DeveValheimCharacterVersnuiveraar.GameClasses.Enums;
using System.Collections.Generic;
using System.Numerics;

namespace DeveValheimCharacterVersnuiveraar.GameClasses
{
    public class Player
    {
        public float MaxHealth { get; set; }
        public float Health { get; set; }
        public float MaxStamina { get; set; }

        public bool FirstSpawn { get; set; }
        public float TimeSinceDeath { get; set; }

        public string GuardianPower { get; set; }
        public float GuardianPowerCooldown { get; set; }

        public Inventory Inventory { get; set; } = new Inventory();


        // Token: 0x0400013D RID: 317
        public HashSet<string> m_knownRecipes = new HashSet<string>();

        // Token: 0x0400013E RID: 318
        public Dictionary<string, int> m_knownStations = new Dictionary<string, int>();

        // Token: 0x0400013F RID: 319
        public HashSet<string> m_knownMaterial = new HashSet<string>();

        // Token: 0x04000140 RID: 320
        public HashSet<string> m_shownTutorials = new HashSet<string>();

        // Token: 0x04000141 RID: 321
        public HashSet<string> m_uniques = new HashSet<string>();

        // Token: 0x04000142 RID: 322
        public HashSet<string> m_trophies = new HashSet<string>();

        // Token: 0x04000143 RID: 323
        public HashSet<Biome> m_knownBiome = new HashSet<Biome>();

        // Token: 0x04000144 RID: 324
        public Dictionary<string, string> m_knownTexts = new Dictionary<string, string>();

        public List<Food> m_foods = new List<Food>();


        public string Beard { get; set; }
        public string Hair { get; set; }

        public Vector3 SkinColor { get; set; }
        public Vector3 HairColor { get; set; }

        public int PlayerModel { get; set; }


        public Skills Skills { get; set; } = new Skills();
    }
}
