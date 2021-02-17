using System.Numerics;

namespace DeveValheimCharacterVersnuiveraar.GameClasses
{
    public class WorldPlayerData
    {
        // Token: 0x040011A7 RID: 4519
        public Vector3 m_spawnPoint = Vector3.Zero;

        // Token: 0x040011A8 RID: 4520
        public bool m_haveCustomSpawnPoint;

        // Token: 0x040011A9 RID: 4521
        public Vector3 m_logoutPoint = Vector3.Zero;

        // Token: 0x040011AA RID: 4522
        public bool m_haveLogoutPoint;

        // Token: 0x040011AB RID: 4523
        public Vector3 m_deathPoint = Vector3.Zero;

        // Token: 0x040011AC RID: 4524
        public bool m_haveDeathPoint;

        // Token: 0x040011AD RID: 4525
        public Vector3 m_homePoint = Vector3.Zero;

        // Token: 0x040011AE RID: 4526
        public byte[] m_mapData;
    }
}
