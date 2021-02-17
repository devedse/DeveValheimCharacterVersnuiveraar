using DeveValheimCharacterVersnuiveraar.GameClasses;
using DeveValheimCharacterVersnuiveraar.GameClasses.Enums;
using DeveValheimCharacterVersnuiveraar.ReaderWriters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace DeveValheimCharacterVersnuiveraar
{
    public static class PlayerReaderWriter
    {
        public static void Save(string path, Player player)
        {
            var pkg = new ZPackage();
            Save(pkg, player);
            var allBytes = pkg.ReadByteArray();
            File.WriteAllBytes(path, allBytes);
        }

        public static Player Load(string path)
        {
            var allBytes = File.ReadAllBytes(path);
            var pkg = new ZPackage(allBytes);
            var player = Load(pkg);
            return player;
        }


        // Token: 0x060001C4 RID: 452 RVA: 0x0000EEEC File Offset: 0x0000D0EC
        public static void Save(ZPackage pkg, Player player)
        {
            pkg.Write(24);
            pkg.Write(player.MaxHealth);
            pkg.Write(player.Health);
            pkg.Write(player.MaxStamina);
            pkg.Write(player.FirstSpawn);
            pkg.Write(player.TimeSinceDeath);
            pkg.Write(player.GuardianPower);
            pkg.Write(player.GuardianPowerCooldown);
            InventoryReaderWriter.Save(pkg, player.Inventory);
            pkg.Write(player.m_knownRecipes.Count);
            foreach (string data in player.m_knownRecipes)
            {
                pkg.Write(data);
            }
            pkg.Write(player.m_knownStations.Count);
            foreach (KeyValuePair<string, int> keyValuePair in player.m_knownStations)
            {
                pkg.Write(keyValuePair.Key);
                pkg.Write(keyValuePair.Value);
            }
            pkg.Write(player.m_knownMaterial.Count);
            foreach (string data2 in player.m_knownMaterial)
            {
                pkg.Write(data2);
            }
            pkg.Write(player.m_shownTutorials.Count);
            foreach (string data3 in player.m_shownTutorials)
            {
                pkg.Write(data3);
            }
            pkg.Write(player.m_uniques.Count);
            foreach (string data4 in player.m_uniques)
            {
                pkg.Write(data4);
            }
            pkg.Write(player.m_trophies.Count);
            foreach (string data5 in player.m_trophies)
            {
                pkg.Write(data5);
            }
            pkg.Write(player.m_knownBiome.Count);
            foreach (Biome data6 in player.m_knownBiome)
            {
                pkg.Write((int)data6);
            }
            pkg.Write(player.m_knownTexts.Count);
            foreach (KeyValuePair<string, string> keyValuePair2 in player.m_knownTexts)
            {
                pkg.Write(keyValuePair2.Key);
                pkg.Write(keyValuePair2.Value);
            }
            pkg.Write(player.Beard);
            pkg.Write(player.Hair);
            pkg.Write(player.SkinColor);
            pkg.Write(player.HairColor);
            pkg.Write(player.PlayerModel);
            pkg.Write(player.m_foods.Count);
            foreach (Food food in player.m_foods)
            {
                pkg.Write(food.m_name);
                pkg.Write(food.m_health);
                pkg.Write(food.m_stamina);
            }
            SkillsReaderWriter.Save(pkg, player.Skills);
        }

        // Token: 0x060001C5 RID: 453 RVA: 0x0000F2F0 File Offset: 0x0000D4F0
        public static Player Load(ZPackage pkg)
        {
            var player = new Player();

            int num = pkg.ReadInt();
            if (num >= 7)
            {
                player.MaxHealth = pkg.ReadSingle();
            }
            player.Health = pkg.ReadSingle();
            if (num >= 10)
            {
                player.MaxStamina = pkg.ReadSingle();
            }
            if (num >= 8)
            {
                player.FirstSpawn = pkg.ReadBool();
            }
            if (num >= 20)
            {
                player.TimeSinceDeath = pkg.ReadSingle();
            }
            if (num >= 23)
            {
                player.GuardianPower = pkg.ReadString();
            }
            if (num >= 24)
            {
                player.GuardianPowerCooldown = pkg.ReadSingle();
            }
            if (num == 2)
            {
                pkg.ReadZDOID();
            }
            player.Inventory = InventoryReaderWriter.Load(pkg);
            int num3 = pkg.ReadInt();
            for (int i = 0; i < num3; i++)
            {
                string item = pkg.ReadString();
                player.m_knownRecipes.Add(item);
            }
            if (num < 15)
            {
                int num4 = pkg.ReadInt();
                for (int j = 0; j < num4; j++)
                {
                    pkg.ReadString();
                }
            }
            else
            {
                int num5 = pkg.ReadInt();
                for (int k = 0; k < num5; k++)
                {
                    string key = pkg.ReadString();
                    int value = pkg.ReadInt();
                    player.m_knownStations.Add(key, value);
                }
            }
            int num6 = pkg.ReadInt();
            for (int l = 0; l < num6; l++)
            {
                string item2 = pkg.ReadString();
                player.m_knownMaterial.Add(item2);
            }
            if (num < 19 || num >= 21)
            {
                int num7 = pkg.ReadInt();
                for (int m = 0; m < num7; m++)
                {
                    string item3 = pkg.ReadString();
                    player.m_shownTutorials.Add(item3);
                }
            }
            if (num >= 6)
            {
                int num8 = pkg.ReadInt();
                for (int n = 0; n < num8; n++)
                {
                    string item4 = pkg.ReadString();
                    player.m_uniques.Add(item4);
                }
            }
            if (num >= 9)
            {
                int num9 = pkg.ReadInt();
                for (int num10 = 0; num10 < num9; num10++)
                {
                    string item5 = pkg.ReadString();
                    player.m_trophies.Add(item5);
                }
            }
            if (num >= 18)
            {
                int num11 = pkg.ReadInt();
                for (int num12 = 0; num12 < num11; num12++)
                {
                    Biome item6 = (Biome)pkg.ReadInt();
                    player.m_knownBiome.Add(item6);
                }
            }
            if (num >= 22)
            {
                int num13 = pkg.ReadInt();
                for (int num14 = 0; num14 < num13; num14++)
                {
                    string key2 = pkg.ReadString();
                    string value2 = pkg.ReadString();
                    player.m_knownTexts.Add(key2, value2);
                }
            }
            if (num >= 4)
            {
                string beard = pkg.ReadString();
                string hair = pkg.ReadString();
                player.Beard = beard;
                player.Hair = hair;
            }
            if (num >= 5)
            {
                Vector3 skinColor = pkg.ReadVector3();
                Vector3 hairColor = pkg.ReadVector3();
                player.SkinColor = skinColor;
                player.HairColor = hairColor;
            }
            if (num >= 11)
            {
                int playerModel = pkg.ReadInt();
                player.PlayerModel = playerModel;
            }
            if (num >= 12)
            {
                player.m_foods.Clear();
                int num15 = pkg.ReadInt();
                for (int num16 = 0; num16 < num15; num16++)
                {
                    if (num >= 14)
                    {
                        var food = new Food();
                        food.m_name = pkg.ReadString();
                        food.m_health = pkg.ReadSingle();
                        if (num >= 16)
                        {
                            food.m_stamina = pkg.ReadSingle();
                        }
                        player.m_foods.Add(food);
                    }
                    else
                    {
                        pkg.ReadString();
                        pkg.ReadSingle();
                        pkg.ReadSingle();
                        pkg.ReadSingle();
                        pkg.ReadSingle();
                        pkg.ReadSingle();
                        pkg.ReadSingle();
                        if (num >= 13)
                        {
                            pkg.ReadSingle();
                        }
                    }
                }
            }
            if (num >= 17)
            {
                player.Skills = SkillsReaderWriter.Load(pkg);
            }

            return player;
        }
    }
}
