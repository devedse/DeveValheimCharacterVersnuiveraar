using DeveValheimCharacterVersnuiveraar.GameClasses;

namespace DeveValheimCharacterVersnuiveraar.ReaderWriters
{
    public static class InventoryReaderWriter
    {
        // Token: 0x060006AF RID: 1711 RVA: 0x0003769C File Offset: 0x0003589C
        public static void Save(ZPackage pkg, Inventory inventory)
        {
            pkg.Write(inventory.currentVersion);
            pkg.Write(inventory.m_inventory.Count);
            foreach (var itemData in inventory.m_inventory)
            {
                pkg.Write(itemData.prefabName);

                pkg.Write(itemData.m_stack);
                pkg.Write(itemData.m_durability);
                pkg.Write(itemData.m_gridPos);
                pkg.Write(itemData.m_equiped);
                pkg.Write(itemData.m_quality);
                pkg.Write(itemData.m_variant);
                pkg.Write(itemData.m_crafterID);
                pkg.Write(itemData.m_crafterName);
            }
        }

        // Token: 0x060006B0 RID: 1712 RVA: 0x000377B4 File Offset: 0x000359B4
        public static Inventory Load(ZPackage pkg)
        {
            var inventory = new Inventory();

            int num = pkg.ReadInt();
            int num2 = pkg.ReadInt();
            inventory.m_inventory.Clear();
            for (int i = 0; i < num2; i++)
            {
                string text = pkg.ReadString();
                int stack = pkg.ReadInt();
                float durability = pkg.ReadSingle();
                Vector2i pos = pkg.ReadVector2i();
                bool equiped = pkg.ReadBool();
                int quality = 1;
                if (num >= 101)
                {
                    quality = pkg.ReadInt();
                }
                int variant = 0;
                if (num >= 102)
                {
                    variant = pkg.ReadInt();
                }
                long crafterID = 0L;
                string crafterName = "";
                if (num >= 103)
                {
                    crafterID = pkg.ReadLong();
                    crafterName = pkg.ReadString();
                }
                if (text != "")
                {
                    var item = new InventoryItem()
                    {
                        prefabName = text,
                        m_stack = stack,
                        m_durability = durability,
                        m_gridPos = pos,
                        m_equiped = equiped,
                        m_quality = quality,
                        m_variant = variant,
                        m_crafterID = crafterID,
                        m_crafterName = crafterName
                    };
                    inventory.m_inventory.Add(item);
                }
            }

            return inventory;
        }
    }
}
