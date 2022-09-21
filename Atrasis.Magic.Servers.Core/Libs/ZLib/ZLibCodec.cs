using System;
using System.Runtime.InteropServices;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000EA RID: 234
	[Guid("ebc25cf6-9120-4283-b972-0e5520d0000D")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public sealed class ZLibCodec
	{
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x00008938 File Offset: 0x00006B38
		public int Adler32
		{
			get
			{
				return (int)this.m_Adler32;
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00008940 File Offset: 0x00006B40
		public ZLibCodec()
		{
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000159D4 File Offset: 0x00013BD4
		public ZLibCodec(CompressionMode mode)
		{
			if (mode == CompressionMode.Compress)
			{
				if (this.InitializeDeflate() != 0)
				{
					throw new ZLibException("Cannot initialize for deflate.");
				}
			}
			else
			{
				if (mode != CompressionMode.Decompress)
				{
					throw new ZLibException("Invalid ZlibStreamFlavor.");
				}
				if (this.InitializeInflate() != 0)
				{
					throw new ZLibException("Cannot initialize for inflate.");
				}
			}
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00008957 File Offset: 0x00006B57
		public int InitializeInflate()
		{
			return this.InitializeInflate(this.WindowBits);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00008965 File Offset: 0x00006B65
		public int InitializeInflate(bool expectRfc1950Header)
		{
			return this.InitializeInflate(this.WindowBits, expectRfc1950Header);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00008974 File Offset: 0x00006B74
		public int InitializeInflate(int windowBits)
		{
			this.WindowBits = windowBits;
			return this.InitializeInflate(windowBits, true);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00008985 File Offset: 0x00006B85
		public int InitializeInflate(int windowBits, bool expectRfc1950Header)
		{
			this.WindowBits = windowBits;
			if (this.dstate != null)
			{
				throw new ZLibException("You may not call InitializeInflate() after calling InitializeDeflate().");
			}
			this.istate = new InflateManager(expectRfc1950Header);
			return this.istate.Initialize(this, windowBits);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x000089BA File Offset: 0x00006BBA
		public int Inflate(FlushType flush)
		{
			if (this.istate == null)
			{
				throw new ZLibException("No Inflate State!");
			}
			return this.istate.Inflate(flush);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x000089DB File Offset: 0x00006BDB
		public int EndInflate()
		{
			if (this.istate == null)
			{
				throw new ZLibException("No Inflate State!");
			}
			int result = this.istate.End();
			this.istate = null;
			return result;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00008A02 File Offset: 0x00006C02
		public int SyncInflate()
		{
			if (this.istate == null)
			{
				throw new ZLibException("No Inflate State!");
			}
			return this.istate.Sync();
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00008A22 File Offset: 0x00006C22
		public int InitializeDeflate()
		{
			return this.m_InternalInitializeDeflate(true);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00008A2B File Offset: 0x00006C2B
		public int InitializeDeflate(CompressionLevel level)
		{
			this.CompressLevel = level;
			return this.m_InternalInitializeDeflate(true);
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00008A3B File Offset: 0x00006C3B
		public int InitializeDeflate(CompressionLevel level, bool wantRfc1950Header)
		{
			this.CompressLevel = level;
			return this.m_InternalInitializeDeflate(wantRfc1950Header);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00008A4B File Offset: 0x00006C4B
		public int InitializeDeflate(CompressionLevel level, int bits)
		{
			this.CompressLevel = level;
			this.WindowBits = bits;
			return this.m_InternalInitializeDeflate(true);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00008A62 File Offset: 0x00006C62
		public int InitializeDeflate(CompressionLevel level, int bits, bool wantRfc1950Header)
		{
			this.CompressLevel = level;
			this.WindowBits = bits;
			return this.m_InternalInitializeDeflate(wantRfc1950Header);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00015A30 File Offset: 0x00013C30
		private int m_InternalInitializeDeflate(bool wantRfc1950Header)
		{
			if (this.istate != null)
			{
				throw new ZLibException("You may not call InitializeDeflate() after calling InitializeInflate().");
			}
			this.dstate = new DeflateManager();
			this.dstate.WantRfc1950HeaderBytes = wantRfc1950Header;
			return this.dstate.Initialize(this, this.CompressLevel, this.WindowBits, this.Strategy);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00008A79 File Offset: 0x00006C79
		public int Deflate(FlushType flush)
		{
			if (this.dstate == null)
			{
				throw new ZLibException("No Deflate State!");
			}
			return this.dstate.Deflate(flush);
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00008A9A File Offset: 0x00006C9A
		public int EndDeflate()
		{
			if (this.dstate == null)
			{
				throw new ZLibException("No Deflate State!");
			}
			this.dstate = null;
			return 0;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00008AB7 File Offset: 0x00006CB7
		public void ResetDeflate()
		{
			if (this.dstate == null)
			{
				throw new ZLibException("No Deflate State!");
			}
			this.dstate.Reset();
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00008AD7 File Offset: 0x00006CD7
		public int SetDeflateParams(CompressionLevel level, CompressionStrategy strategy)
		{
			if (this.dstate == null)
			{
				throw new ZLibException("No Deflate State!");
			}
			return this.dstate.SetParams(level, strategy);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00008AF9 File Offset: 0x00006CF9
		public int SetDictionary(byte[] dictionary)
		{
			if (this.istate != null)
			{
				return this.istate.SetDictionary(dictionary);
			}
			if (this.dstate == null)
			{
				throw new ZLibException("No Inflate or Deflate state!");
			}
			return this.dstate.SetDictionary(dictionary);
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00015A88 File Offset: 0x00013C88
		internal void flush_pending()
		{
			int num = this.dstate.pendingCount;
			if (num > this.AvailableBytesOut)
			{
				num = this.AvailableBytesOut;
			}
			if (num == 0)
			{
				return;
			}
			if (this.dstate.pending.Length > this.dstate.nextPending && this.OutputBuffer.Length > this.NextOut && this.dstate.pending.Length >= this.dstate.nextPending + num && this.OutputBuffer.Length >= this.NextOut + num)
			{
				Array.Copy(this.dstate.pending, this.dstate.nextPending, this.OutputBuffer, this.NextOut, num);
				this.NextOut += num;
				this.dstate.nextPending += num;
				this.TotalBytesOut += (long)num;
				this.AvailableBytesOut -= num;
				this.dstate.pendingCount -= num;
				if (this.dstate.pendingCount == 0)
				{
					this.dstate.nextPending = 0;
				}
				return;
			}
			throw new ZLibException(string.Format("Invalid State. (pending.Length={0}, pendingCount={1})", this.dstate.pending.Length, this.dstate.pendingCount));
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00015BE0 File Offset: 0x00013DE0
		internal int read_buf(byte[] buf, int start, int size)
		{
			int num = this.AvailableBytesIn;
			if (num > size)
			{
				num = size;
			}
			if (num == 0)
			{
				return 0;
			}
			this.AvailableBytesIn -= num;
			if (this.dstate.WantRfc1950HeaderBytes)
			{
				this.m_Adler32 = Adler.Adler32(this.m_Adler32, this.InputBuffer, this.NextIn, num);
			}
			Array.Copy(this.InputBuffer, this.NextIn, buf, start, num);
			this.NextIn += num;
			this.TotalBytesIn += (long)num;
			return num;
		}

		// Token: 0x040003B1 RID: 945
		public byte[] InputBuffer;

		// Token: 0x040003B2 RID: 946
		public int NextIn;

		// Token: 0x040003B3 RID: 947
		public int AvailableBytesIn;

		// Token: 0x040003B4 RID: 948
		public long TotalBytesIn;

		// Token: 0x040003B5 RID: 949
		public byte[] OutputBuffer;

		// Token: 0x040003B6 RID: 950
		public int NextOut;

		// Token: 0x040003B7 RID: 951
		public int AvailableBytesOut;

		// Token: 0x040003B8 RID: 952
		public long TotalBytesOut;

		// Token: 0x040003B9 RID: 953
		public string Message;

		// Token: 0x040003BA RID: 954
		internal DeflateManager dstate;

		// Token: 0x040003BB RID: 955
		internal InflateManager istate;

		// Token: 0x040003BC RID: 956
		internal uint m_Adler32;

		// Token: 0x040003BD RID: 957
		public CompressionLevel CompressLevel = CompressionLevel.Default;

		// Token: 0x040003BE RID: 958
		public int WindowBits = 15;

		// Token: 0x040003BF RID: 959
		public CompressionStrategy Strategy;
	}
}
