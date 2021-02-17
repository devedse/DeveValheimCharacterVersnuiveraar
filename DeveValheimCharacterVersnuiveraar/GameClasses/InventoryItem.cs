using System;
using System.Collections.Generic;
using System.Text;

namespace DeveValheimCharacterVersnuiveraar.GameClasses
{
    public class InventoryItem
    {
        public string prefabName;

        // Token: 0x04001124 RID: 4388
        public int m_stack = 1;

        // Token: 0x04001125 RID: 4389
        public float m_durability = 100f;

        // Token: 0x04001126 RID: 4390
        public int m_quality = 1;

        // Token: 0x04001127 RID: 4391
        public int m_variant;



        // Token: 0x04001129 RID: 4393
        [NonSerialized]
        public long m_crafterID;

        // Token: 0x0400112A RID: 4394
        [NonSerialized]
        public string m_crafterName = "";

        // Token: 0x0400112B RID: 4395
        [NonSerialized]
        public Vector2i m_gridPos = new Vector2i() { X = 0, Y = 0 };

        // Token: 0x0400112C RID: 4396
        [NonSerialized]
        public bool m_equiped;


    }
}
