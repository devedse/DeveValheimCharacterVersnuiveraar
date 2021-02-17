using System;
using System.IO;

namespace DeveValheimCharacterVersnuiveraar
{
	public struct ZDOID : IEquatable<ZDOID>
	{
		// Token: 0x06000799 RID: 1945 RVA: 0x0003BFBE File Offset: 0x0003A1BE
		public ZDOID(BinaryReader reader)
		{
			this.m_userID = reader.ReadInt64();
			this.m_id = reader.ReadUInt32();
			this.m_hash = 0;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0003BFDF File Offset: 0x0003A1DF
		public ZDOID(long userID, uint id)
		{
			this.m_userID = userID;
			this.m_id = id;
			this.m_hash = 0;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0003BFF6 File Offset: 0x0003A1F6
		public ZDOID(ZDOID other)
		{
			this.m_userID = other.m_userID;
			this.m_id = other.m_id;
			this.m_hash = other.m_hash;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0003C01C File Offset: 0x0003A21C
		public override string ToString()
		{
			return this.m_userID.ToString() + ":" + this.m_id.ToString();
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0003C03E File Offset: 0x0003A23E
		public static bool operator ==(ZDOID a, ZDOID b)
		{
			return a.m_userID == b.m_userID && a.m_id == b.m_id;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0003C05E File Offset: 0x0003A25E
		public static bool operator !=(ZDOID a, ZDOID b)
		{
			return a.m_userID != b.m_userID || a.m_id != b.m_id;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0003C081 File Offset: 0x0003A281
		public bool Equals(ZDOID other)
		{
			return other.m_userID == this.m_userID && other.m_id == this.m_id;
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0003C0A4 File Offset: 0x0003A2A4
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is ZDOID)
			{
				ZDOID zdoid = (ZDOID)obj;
				return zdoid.m_userID == this.m_userID && zdoid.m_id == this.m_id;
			}
			return false;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0003C0E5 File Offset: 0x0003A2E5
		public override int GetHashCode()
		{
			if (this.m_hash == 0)
			{
				this.m_hash = (this.m_userID.GetHashCode() ^ this.m_id.GetHashCode());
			}
			return this.m_hash;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0003C112 File Offset: 0x0003A312
		public bool IsNone()
		{
			return this.m_userID == 0L && this.m_id == 0U;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0003C127 File Offset: 0x0003A327
		public long userID
		{
			get
			{
				return this.m_userID;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0003C12F File Offset: 0x0003A32F
		public uint id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x040007CC RID: 1996
		public static ZDOID None = new ZDOID(0L, 0U);

		// Token: 0x040007CD RID: 1997
		private long m_userID;

		// Token: 0x040007CE RID: 1998
		private uint m_id;

		// Token: 0x040007CF RID: 1999
		private int m_hash;
	}
}