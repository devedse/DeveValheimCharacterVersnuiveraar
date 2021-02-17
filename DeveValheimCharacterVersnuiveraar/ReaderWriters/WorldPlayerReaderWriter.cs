using DeveValheimCharacterVersnuiveraar.GameClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeveValheimCharacterVersnuiveraar.ReaderWriters
{
    public class WorldPlayerReaderWriter
    {
        public static void Save(string path, WorldPlayer worldPlayer)
        {
            var allBytes = ToBytes(worldPlayer);
            File.WriteAllBytes(path, allBytes);
        }

        public static WorldPlayer Load(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                BinaryReader binaryReader = new BinaryReader(fs);
                int num = binaryReader.ReadInt32();
                var data = binaryReader.ReadBytes(num);
                int num2 = binaryReader.ReadInt32();
                binaryReader.ReadBytes(num2);

                var pkg = new ZPackage(data);
                var worldPlayer = Load(pkg);
                return worldPlayer;
            }      
        }


        public static byte[] ToBytes(WorldPlayer worldPlayer)
        {
            ZPackage zpackage = new ZPackage();
            zpackage.Write(ValheimVersion.m_playerVersion);
            zpackage.Write(worldPlayer.PlayerStats_kills);
            zpackage.Write(worldPlayer.PlayerStats_deaths);
            zpackage.Write(worldPlayer.PlayerStats_crafts);
            zpackage.Write(worldPlayer.PlayerStats_builds);
            zpackage.Write(worldPlayer.WorldPlayerData.Count);
            foreach (var keyValuePair in worldPlayer.WorldPlayerData)
            {
                zpackage.Write(keyValuePair.Key);
                zpackage.Write(keyValuePair.Value.m_haveCustomSpawnPoint);
                zpackage.Write(keyValuePair.Value.m_spawnPoint);
                zpackage.Write(keyValuePair.Value.m_haveLogoutPoint);
                zpackage.Write(keyValuePair.Value.m_logoutPoint);
                zpackage.Write(keyValuePair.Value.m_haveDeathPoint);
                zpackage.Write(keyValuePair.Value.m_deathPoint);
                zpackage.Write(keyValuePair.Value.m_homePoint);
                zpackage.Write(keyValuePair.Value.m_mapData != null);
                if (keyValuePair.Value.m_mapData != null)
                {
                    zpackage.Write(keyValuePair.Value.m_mapData);
                }
            }
            zpackage.Write(worldPlayer.PlayerName);
            zpackage.Write(worldPlayer.PlayerId);
            zpackage.Write(worldPlayer.StartSeed);
            if (worldPlayer.Player != null)
            {
                var playerPkg = new ZPackage();
                PlayerReaderWriter.Save(playerPkg, worldPlayer.Player);
                var playerData = playerPkg.GetArray();

                zpackage.Write(true);
                zpackage.Write(playerData);
            }
            else
            {
                zpackage.Write(false);
            }
            byte[] array = zpackage.GenerateHash();
            byte[] array2 = zpackage.GetArray();




            var memStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memStream);
            binaryWriter.Write(array2.Length);
            binaryWriter.Write(array2);
            binaryWriter.Write(array.Length);
            binaryWriter.Write(array);
            binaryWriter.Flush();
            memStream.Flush();

            var bytes = memStream.ToArray();

            return bytes;
        }


        public static WorldPlayer Load(ZPackage pkg)
        {
            var worldPlayer = new WorldPlayer();

            int num = pkg.ReadInt();
            if (!ValheimVersion.IsPlayerVersionCompatible(num))
            {
                return null;
            }
            if (num >= 28)
            {
                worldPlayer.PlayerStats_kills = pkg.ReadInt();
                worldPlayer.PlayerStats_deaths = pkg.ReadInt();
                worldPlayer.PlayerStats_crafts = pkg.ReadInt();
                worldPlayer.PlayerStats_builds = pkg.ReadInt();
            }
            worldPlayer.WorldPlayerData.Clear();
            int num2 = pkg.ReadInt();
            for (int i = 0; i < num2; i++)
            {
                long key = pkg.ReadLong();
                var worldPlayerData = new WorldPlayerData();
                worldPlayerData.m_haveCustomSpawnPoint = pkg.ReadBool();
                worldPlayerData.m_spawnPoint = pkg.ReadVector3();
                worldPlayerData.m_haveLogoutPoint = pkg.ReadBool();
                worldPlayerData.m_logoutPoint = pkg.ReadVector3();
                if (num >= 30)
                {
                    worldPlayerData.m_haveDeathPoint = pkg.ReadBool();
                    worldPlayerData.m_deathPoint = pkg.ReadVector3();
                }
                worldPlayerData.m_homePoint = pkg.ReadVector3();
                if (num >= 29 && pkg.ReadBool())
                {
                    worldPlayerData.m_mapData = pkg.ReadByteArray();
                }
                worldPlayer.WorldPlayerData.Add(key, worldPlayerData);
            }
            worldPlayer.PlayerName = pkg.ReadString();
            worldPlayer.PlayerId = pkg.ReadLong();
            worldPlayer.StartSeed = pkg.ReadString();
            if (pkg.ReadBool())
            {
                var byteArray = pkg.ReadByteArray();

                var playerPkg = new ZPackage(byteArray);

                worldPlayer.Player = PlayerReaderWriter.Load(playerPkg);
            }
            else
            {
                worldPlayer.Player = null;
            }
            return worldPlayer;
        }
    }
}
