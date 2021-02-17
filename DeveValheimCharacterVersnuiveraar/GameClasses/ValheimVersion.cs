namespace DeveValheimCharacterVersnuiveraar.GameClasses
{
    public static class ValheimVersion
    {
        public static int m_playerVersion = 32;

        // Token: 0x04000AF4 RID: 2804
        public static int[] m_compatiblePlayerVersions = new int[]
        {
            31,
            30,
            29,
            28,
            27
        };

        // Token: 0x06000BAE RID: 2990 RVA: 0x00053AA8 File Offset: 0x00051CA8
        public static bool IsPlayerVersionCompatible(int version)
        {
            if (version == ValheimVersion.m_playerVersion)
            {
                return true;
            }
            foreach (int num in ValheimVersion.m_compatiblePlayerVersions)
            {
                if (version == num)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
