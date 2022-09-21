using System;
using System.IO;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000D1 RID: 209
	public class DeflateStream : Stream
	{
		// Token: 0x0600060E RID: 1550 RVA: 0x00008290 File Offset: 0x00006490
		public DeflateStream(Stream stream, CompressionMode mode) : this(stream, mode, CompressionLevel.Default, false)
		{
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0000829C File Offset: 0x0000649C
		public DeflateStream(Stream stream, CompressionMode mode, CompressionLevel level) : this(stream, mode, level, false)
		{
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x000082A8 File Offset: 0x000064A8
		public DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen) : this(stream, mode, CompressionLevel.Default, leaveOpen)
		{
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x000082B4 File Offset: 0x000064B4
		public DeflateStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		{
			this.m_innerStream = stream;
			this.m_baseStream = new ZLibBaseStream(stream, mode, level, ZlibStreamFlavor.DEFLATE, leaveOpen);
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x000082D8 File Offset: 0x000064D8
		// (set) Token: 0x06000613 RID: 1555 RVA: 0x000082E5 File Offset: 0x000064E5
		public virtual FlushType FlushMode
		{
			get
			{
				return this.m_baseStream.m_flushMode;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("DeflateStream");
				}
				this.m_baseStream.m_flushMode = value;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x00008306 File Offset: 0x00006506
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x0001007C File Offset: 0x0000E27C
		public int BufferSize
		{
			get
			{
				return this.m_baseStream.m_bufferSize;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("DeflateStream");
				}
				if (this.m_baseStream.m_workingBuffer != null)
				{
					throw new ZLibException("The working buffer is already set.");
				}
				if (value < 1024)
				{
					throw new ZLibException(string.Format("Don't be silly. {0} bytes?? Use a bigger buffer, at least {1}.", value, 1024));
				}
				this.m_baseStream.m_bufferSize = value;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x00008313 File Offset: 0x00006513
		// (set) Token: 0x06000617 RID: 1559 RVA: 0x00008320 File Offset: 0x00006520
		public CompressionStrategy Strategy
		{
			get
			{
				return this.m_baseStream.Strategy;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("DeflateStream");
				}
				this.m_baseStream.Strategy = value;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x00008341 File Offset: 0x00006541
		public virtual long TotalIn
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesIn;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x00008353 File Offset: 0x00006553
		public virtual long TotalOut
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesOut;
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x000100E8 File Offset: 0x0000E2E8
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (!this.m_disposed)
				{
					if (disposing && this.m_baseStream != null)
					{
						this.m_baseStream.Close();
					}
					this.m_disposed = true;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x00008365 File Offset: 0x00006565
		public override bool CanRead
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("DeflateStream");
				}
				return this.m_baseStream.m_stream.CanRead;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600061C RID: 1564 RVA: 0x0000598D File Offset: 0x00003B8D
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x0000838A File Offset: 0x0000658A
		public override bool CanWrite
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("DeflateStream");
				}
				return this.m_baseStream.m_stream.CanWrite;
			}
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x000083AF File Offset: 0x000065AF
		public override void Flush()
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("DeflateStream");
			}
			this.m_baseStream.Flush();
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Length
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x00010134 File Offset: 0x0000E334
		// (set) Token: 0x06000621 RID: 1569 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Position
		{
			get
			{
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Writer)
				{
					return this.m_baseStream.m_z.TotalBytesOut;
				}
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Reader)
				{
					return this.m_baseStream.m_z.TotalBytesIn;
				}
				return 0L;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x000083D6 File Offset: 0x000065D6
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("DeflateStream");
			}
			return this.m_baseStream.Read(buffer, offset, count);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x000083CF File Offset: 0x000065CF
		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x000083F9 File Offset: 0x000065F9
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("DeflateStream");
			}
			this.m_baseStream.Write(buffer, offset, count);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00010188 File Offset: 0x0000E388
		public static byte[] CompressString(string s)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new DeflateStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressString(s, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000101D0 File Offset: 0x0000E3D0
		public static byte[] CompressBuffer(byte[] b)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new DeflateStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressBuffer(b, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00010218 File Offset: 0x0000E418
		public static string UncompressString(byte[] compressed)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new DeflateStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressString(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001025C File Offset: 0x0000E45C
		public static byte[] UncompressBuffer(byte[] compressed)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new DeflateStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressBuffer(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x040002A6 RID: 678
		internal ZLibBaseStream m_baseStream;

		// Token: 0x040002A7 RID: 679
		internal Stream m_innerStream;

		// Token: 0x040002A8 RID: 680
		private bool m_disposed;
	}
}
