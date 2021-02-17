using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace DeveValheimCharacterVersnuiveraar
{
    // Token: 0x02000088 RID: 136
    public class ZPackage
    {
        // Token: 0x060008B1 RID: 2225 RVA: 0x00041D88 File Offset: 0x0003FF88
        public ZPackage()
        {
            this.m_writer = new BinaryWriter(this.m_stream);
            this.m_reader = new BinaryReader(this.m_stream);
        }

        // Token: 0x060008B2 RID: 2226 RVA: 0x00041DC0 File Offset: 0x0003FFC0
        public ZPackage(string base64String)
        {
            this.m_writer = new BinaryWriter(this.m_stream);
            this.m_reader = new BinaryReader(this.m_stream);
            if (string.IsNullOrEmpty(base64String))
            {
                return;
            }
            byte[] array = Convert.FromBase64String(base64String);
            this.m_stream.Write(array, 0, array.Length);
            this.m_stream.Position = 0L;
        }

        // Token: 0x060008B3 RID: 2227 RVA: 0x00041E30 File Offset: 0x00040030
        public ZPackage(byte[] data)
        {
            this.m_writer = new BinaryWriter(this.m_stream);
            this.m_reader = new BinaryReader(this.m_stream);
            this.m_stream.Write(data, 0, data.Length);
            this.m_stream.Position = 0L;
        }

        // Token: 0x060008B4 RID: 2228 RVA: 0x00041E90 File Offset: 0x00040090
        public ZPackage(byte[] data, int dataSize)
        {
            this.m_writer = new BinaryWriter(this.m_stream);
            this.m_reader = new BinaryReader(this.m_stream);
            this.m_stream.Write(data, 0, dataSize);
            this.m_stream.Position = 0L;
        }

        // Token: 0x060008B5 RID: 2229 RVA: 0x00041EEB File Offset: 0x000400EB
        public void Load(byte[] data)
        {
            this.Clear();
            this.m_stream.Write(data, 0, data.Length);
            this.m_stream.Position = 0L;
        }

        // Token: 0x060008B6 RID: 2230 RVA: 0x00041F10 File Offset: 0x00040110
        public void Write(ZPackage pkg)
        {
            byte[] array = pkg.GetArray();
            this.m_writer.Write(array.Length);
            this.m_writer.Write(array);
        }

        // Token: 0x060008B7 RID: 2231 RVA: 0x00041F3E File Offset: 0x0004013E
        public void Write(byte[] array)
        {
            this.m_writer.Write(array.Length);
            this.m_writer.Write(array);
        }

        // Token: 0x060008B8 RID: 2232 RVA: 0x00041F5A File Offset: 0x0004015A
        public void Write(byte data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008B9 RID: 2233 RVA: 0x00041F68 File Offset: 0x00040168
        public void Write(sbyte data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008BA RID: 2234 RVA: 0x00041F76 File Offset: 0x00040176
        public void Write(char data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008BB RID: 2235 RVA: 0x00041F84 File Offset: 0x00040184
        public void Write(bool data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008BC RID: 2236 RVA: 0x00041F92 File Offset: 0x00040192
        public void Write(int data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008BD RID: 2237 RVA: 0x00041FA0 File Offset: 0x000401A0
        public void Write(uint data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008BE RID: 2238 RVA: 0x00041FAE File Offset: 0x000401AE
        public void Write(ulong data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008BF RID: 2239 RVA: 0x00041FBC File Offset: 0x000401BC
        public void Write(long data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008C0 RID: 2240 RVA: 0x00041FCA File Offset: 0x000401CA
        public void Write(float data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008C1 RID: 2241 RVA: 0x00041FD8 File Offset: 0x000401D8
        public void Write(double data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008C2 RID: 2242 RVA: 0x00041FE6 File Offset: 0x000401E6
        public void Write(string data)
        {
            this.m_writer.Write(data);
        }

        // Token: 0x060008C3 RID: 2243 RVA: 0x00041FF4 File Offset: 0x000401F4
        public void Write(ZDOID id)
        {
            this.m_writer.Write(id.userID);
            this.m_writer.Write(id.id);
        }

        // Token: 0x060008C4 RID: 2244 RVA: 0x0004201A File Offset: 0x0004021A
        public void Write(Vector3 v3)
        {
            this.m_writer.Write(v3.X);
            this.m_writer.Write(v3.Y);
            this.m_writer.Write(v3.Z);
        }

        // Token: 0x060008C5 RID: 2245 RVA: 0x0004204F File Offset: 0x0004024F
        public void Write(Vector2i v2)
        {
            this.m_writer.Write(v2.X);
            this.m_writer.Write(v2.Y);
        }

        // Token: 0x060008C6 RID: 2246 RVA: 0x00042074 File Offset: 0x00040274
        public void Write(Quaternion q)
        {
            this.m_writer.Write(q.X);
            this.m_writer.Write(q.Y);
            this.m_writer.Write(q.Z);
            this.m_writer.Write(q.W);
        }

        // Token: 0x060008C7 RID: 2247 RVA: 0x000420C5 File Offset: 0x000402C5
        public ZDOID ReadZDOID()
        {
            return new ZDOID(this.m_reader.ReadInt64(), this.m_reader.ReadUInt32());
        }

        // Token: 0x060008C8 RID: 2248 RVA: 0x000420E2 File Offset: 0x000402E2
        public bool ReadBool()
        {
            return this.m_reader.ReadBoolean();
        }

        // Token: 0x060008C9 RID: 2249 RVA: 0x000420EF File Offset: 0x000402EF
        public char ReadChar()
        {
            return this.m_reader.ReadChar();
        }

        // Token: 0x060008CA RID: 2250 RVA: 0x000420FC File Offset: 0x000402FC
        public byte ReadByte()
        {
            return this.m_reader.ReadByte();
        }

        // Token: 0x060008CB RID: 2251 RVA: 0x00042109 File Offset: 0x00040309
        public sbyte ReadSByte()
        {
            return this.m_reader.ReadSByte();
        }

        // Token: 0x060008CC RID: 2252 RVA: 0x00042116 File Offset: 0x00040316
        public int ReadInt()
        {
            return this.m_reader.ReadInt32();
        }

        // Token: 0x060008CD RID: 2253 RVA: 0x00042123 File Offset: 0x00040323
        public uint ReadUInt()
        {
            return this.m_reader.ReadUInt32();
        }

        // Token: 0x060008CE RID: 2254 RVA: 0x00042130 File Offset: 0x00040330
        public long ReadLong()
        {
            return this.m_reader.ReadInt64();
        }

        // Token: 0x060008CF RID: 2255 RVA: 0x0004213D File Offset: 0x0004033D
        public ulong ReadULong()
        {
            return this.m_reader.ReadUInt64();
        }

        // Token: 0x060008D0 RID: 2256 RVA: 0x0004214A File Offset: 0x0004034A
        public float ReadSingle()
        {
            return this.m_reader.ReadSingle();
        }

        // Token: 0x060008D1 RID: 2257 RVA: 0x00042157 File Offset: 0x00040357
        public double ReadDouble()
        {
            return this.m_reader.ReadDouble();
        }

        // Token: 0x060008D2 RID: 2258 RVA: 0x00042164 File Offset: 0x00040364
        public string ReadString()
        {
            return this.m_reader.ReadString();
        }

        // Token: 0x060008D3 RID: 2259 RVA: 0x00042174 File Offset: 0x00040374
        public Vector3 ReadVector3()
        {
            return new Vector3
            {
                X = this.m_reader.ReadSingle(),
                Y = this.m_reader.ReadSingle(),
                Z = this.m_reader.ReadSingle()
            };
        }

        // Token: 0x060008D4 RID: 2260 RVA: 0x000421C0 File Offset: 0x000403C0
        public Vector2i ReadVector2i()
        {
            return new Vector2i
            {
                X = this.m_reader.ReadInt32(),
                Y = this.m_reader.ReadInt32()
            };
        }

        // Token: 0x060008D5 RID: 2261 RVA: 0x000421FC File Offset: 0x000403FC
        public Quaternion ReadQuaternion()
        {
            return new Quaternion
            {
                X = this.m_reader.ReadSingle(),
                Y = this.m_reader.ReadSingle(),
                Z = this.m_reader.ReadSingle(),
                W = this.m_reader.ReadSingle()
            };
        }

        // Token: 0x060008D6 RID: 2262 RVA: 0x0004225C File Offset: 0x0004045C
        public ZPackage ReadPackage()
        {
            int count = this.m_reader.ReadInt32();
            return new ZPackage(this.m_reader.ReadBytes(count));
        }

        // Token: 0x060008D7 RID: 2263 RVA: 0x00042288 File Offset: 0x00040488
        public void ReadPackage(ref ZPackage pkg)
        {
            int count = this.m_reader.ReadInt32();
            byte[] array = this.m_reader.ReadBytes(count);
            pkg.Clear();
            pkg.m_stream.Write(array, 0, array.Length);
            pkg.m_stream.Position = 0L;
        }

        // Token: 0x060008D8 RID: 2264 RVA: 0x000422D4 File Offset: 0x000404D4
        public byte[] ReadByteArray()
        {
            int count = this.m_reader.ReadInt32();
            return this.m_reader.ReadBytes(count);
        }

        // Token: 0x060008D9 RID: 2265 RVA: 0x000422F9 File Offset: 0x000404F9
        public string GetBase64()
        {
            return Convert.ToBase64String(this.GetArray());
        }

        // Token: 0x060008DA RID: 2266 RVA: 0x00042306 File Offset: 0x00040506
        public byte[] GetArray()
        {
            this.m_writer.Flush();
            this.m_stream.Flush();
            return this.m_stream.ToArray();
        }

        // Token: 0x060008DB RID: 2267 RVA: 0x00042329 File Offset: 0x00040529
        public void SetPos(int pos)
        {
            this.m_stream.Position = (long)pos;
        }

        // Token: 0x060008DC RID: 2268 RVA: 0x00042338 File Offset: 0x00040538
        public int GetPos()
        {
            return (int)this.m_stream.Position;
        }

        // Token: 0x060008DD RID: 2269 RVA: 0x00042346 File Offset: 0x00040546
        public int Size()
        {
            this.m_writer.Flush();
            this.m_stream.Flush();
            return (int)this.m_stream.Length;
        }

        // Token: 0x060008DE RID: 2270 RVA: 0x0004236A File Offset: 0x0004056A
        public void Clear()
        {
            this.m_writer.Flush();
            this.m_stream.SetLength(0L);
            this.m_stream.Position = 0L;
        }

        // Token: 0x060008DF RID: 2271 RVA: 0x00042394 File Offset: 0x00040594
        public byte[] GenerateHash()
        {
            byte[] array = this.GetArray();
            return SHA512.Create().ComputeHash(array);
        }

        // Token: 0x0400084B RID: 2123
        private MemoryStream m_stream = new MemoryStream();

        // Token: 0x0400084C RID: 2124
        private BinaryWriter m_writer;

        // Token: 0x0400084D RID: 2125
        private BinaryReader m_reader;
    }

}
