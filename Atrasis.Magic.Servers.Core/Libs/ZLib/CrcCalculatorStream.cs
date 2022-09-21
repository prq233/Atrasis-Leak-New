using System;
using System.IO;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000CB RID: 203
	public class CrcCalculatorStream : Stream, IDisposable
	{
		// Token: 0x060005C6 RID: 1478 RVA: 0x00008000 File Offset: 0x00006200
		public CrcCalculatorStream(Stream stream) : this(true, CrcCalculatorStream.UnsetLengthLimit, stream, null)
		{
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00008010 File Offset: 0x00006210
		public CrcCalculatorStream(Stream stream, bool leaveOpen) : this(leaveOpen, CrcCalculatorStream.UnsetLengthLimit, stream, null)
		{
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00008020 File Offset: 0x00006220
		public CrcCalculatorStream(Stream stream, long length) : this(true, length, stream, null)
		{
			if (length < 0L)
			{
				throw new ArgumentException("length");
			}
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00008043 File Offset: 0x00006243
		public CrcCalculatorStream(Stream stream, long length, bool leaveOpen) : this(leaveOpen, length, stream, null)
		{
			if (length < 0L)
			{
				throw new ArgumentException("length");
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00008066 File Offset: 0x00006266
		public CrcCalculatorStream(Stream stream, long length, bool leaveOpen, CRC32 crc32) : this(leaveOpen, length, stream, crc32)
		{
			if (length < 0L)
			{
				throw new ArgumentException("length");
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0000808A File Offset: 0x0000628A
		private CrcCalculatorStream(bool leaveOpen, long length, Stream stream, CRC32 crc32)
		{
			this.m_innerStream = stream;
			this.m_Crc32 = (crc32 ?? new CRC32());
			this.m_lengthLimit = length;
			this.LeaveOpen = leaveOpen;
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x000080C7 File Offset: 0x000062C7
		public long TotalBytesSlurped
		{
			get
			{
				return this.m_Crc32.TotalBytesRead;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x000080D4 File Offset: 0x000062D4
		public int Crc
		{
			get
			{
				return this.m_Crc32.Crc32Result;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x000080E1 File Offset: 0x000062E1
		// (set) Token: 0x060005CF RID: 1487 RVA: 0x000080E9 File Offset: 0x000062E9
		public bool LeaveOpen { get; set; }

		// Token: 0x060005D0 RID: 1488 RVA: 0x0000DB04 File Offset: 0x0000BD04
		public override int Read(byte[] buffer, int offset, int count)
		{
			int count2 = count;
			if (this.m_lengthLimit != CrcCalculatorStream.UnsetLengthLimit)
			{
				if (this.m_Crc32.TotalBytesRead >= this.m_lengthLimit)
				{
					return 0;
				}
				long num = this.m_lengthLimit - this.m_Crc32.TotalBytesRead;
				if (num < (long)count)
				{
					count2 = (int)num;
				}
			}
			int num2 = this.m_innerStream.Read(buffer, offset, count2);
			if (num2 > 0)
			{
				this.m_Crc32.SlurpBlock(buffer, offset, num2);
			}
			return num2;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000080F2 File Offset: 0x000062F2
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (count > 0)
			{
				this.m_Crc32.SlurpBlock(buffer, offset, count);
			}
			this.m_innerStream.Write(buffer, offset, count);
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00008114 File Offset: 0x00006314
		public override bool CanRead
		{
			get
			{
				return this.m_innerStream.CanRead;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000598D File Offset: 0x00003B8D
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00008121 File Offset: 0x00006321
		public override bool CanWrite
		{
			get
			{
				return this.m_innerStream.CanWrite;
			}
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0000812E File Offset: 0x0000632E
		public override void Flush()
		{
			this.m_innerStream.Flush();
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x0000813B File Offset: 0x0000633B
		public override long Length
		{
			get
			{
				if (this.m_lengthLimit == CrcCalculatorStream.UnsetLengthLimit)
				{
					return this.m_innerStream.Length;
				}
				return this.m_lengthLimit;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x000080C7 File Offset: 0x000062C7
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x0000815C File Offset: 0x0000635C
		public override long Position
		{
			get
			{
				return this.m_Crc32.TotalBytesRead;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0000815C File Offset: 0x0000635C
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0000815C File Offset: 0x0000635C
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00008163 File Offset: 0x00006363
		void IDisposable.Dispose()
		{
			this.Close();
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0000816B File Offset: 0x0000636B
		public override void Close()
		{
			base.Close();
			if (!this.LeaveOpen)
			{
				this.m_innerStream.Close();
			}
		}

		// Token: 0x04000248 RID: 584
		private static readonly long UnsetLengthLimit = -99L;

		// Token: 0x04000249 RID: 585
		internal Stream m_innerStream;

		// Token: 0x0400024A RID: 586
		private readonly CRC32 m_Crc32;

		// Token: 0x0400024B RID: 587
		private readonly long m_lengthLimit = -99L;
	}
}
