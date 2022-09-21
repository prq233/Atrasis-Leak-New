using System;
using System.IO;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000EC RID: 236
	public class ZLibStream : Stream
	{
		// Token: 0x060006D6 RID: 1750 RVA: 0x00008B2F File Offset: 0x00006D2F
		public ZLibStream(Stream stream, CompressionMode mode) : this(stream, mode, CompressionLevel.Default, false)
		{
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00008B3B File Offset: 0x00006D3B
		public ZLibStream(Stream stream, CompressionMode mode, CompressionLevel level) : this(stream, mode, level, false)
		{
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00008B47 File Offset: 0x00006D47
		public ZLibStream(Stream stream, CompressionMode mode, bool leaveOpen) : this(stream, mode, CompressionLevel.Default, leaveOpen)
		{
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00008B53 File Offset: 0x00006D53
		public ZLibStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		{
			this.m_baseStream = new ZLibBaseStream(stream, mode, level, ZlibStreamFlavor.ZLIB, leaveOpen);
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x00008B70 File Offset: 0x00006D70
		// (set) Token: 0x060006DB RID: 1755 RVA: 0x00008B7D File Offset: 0x00006D7D
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
					throw new ObjectDisposedException("ZLibStream");
				}
				this.m_baseStream.m_flushMode = value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x00008B9E File Offset: 0x00006D9E
		// (set) Token: 0x060006DD RID: 1757 RVA: 0x00015C6C File Offset: 0x00013E6C
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
					throw new ObjectDisposedException("ZLibStream");
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

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x00008BAB File Offset: 0x00006DAB
		public virtual long TotalIn
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesIn;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00008BBD File Offset: 0x00006DBD
		public virtual long TotalOut
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesOut;
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00015CD8 File Offset: 0x00013ED8
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

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x00008BCF File Offset: 0x00006DCF
		public override bool CanRead
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("ZLibStream");
				}
				return this.m_baseStream.m_stream.CanRead;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060006E2 RID: 1762 RVA: 0x0000598D File Offset: 0x00003B8D
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x00008BF4 File Offset: 0x00006DF4
		public override bool CanWrite
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("ZLibStream");
				}
				return this.m_baseStream.m_stream.CanWrite;
			}
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00008C19 File Offset: 0x00006E19
		public override void Flush()
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("ZLibStream");
			}
			this.m_baseStream.Flush();
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x0000815C File Offset: 0x0000635C
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060006E6 RID: 1766 RVA: 0x00015D24 File Offset: 0x00013F24
		// (set) Token: 0x060006E7 RID: 1767 RVA: 0x0000815C File Offset: 0x0000635C
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
				throw new NotSupportedException();
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00008C39 File Offset: 0x00006E39
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("ZLibStream");
			}
			return this.m_baseStream.Read(buffer, offset, count);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0000815C File Offset: 0x0000635C
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0000815C File Offset: 0x0000635C
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00008C5C File Offset: 0x00006E5C
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("ZLibStream");
			}
			this.m_baseStream.Write(buffer, offset, count);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00015D78 File Offset: 0x00013F78
		public static byte[] CompressString(string s)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new ZLibStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressString(s, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00015DC0 File Offset: 0x00013FC0
		public static byte[] CompressBuffer(byte[] b, CompressionLevel level)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new ZLibStream(memoryStream, CompressionMode.Compress, level);
				ZLibBaseStream.CompressBuffer(b, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00015E08 File Offset: 0x00014008
		public static string UncompressString(byte[] compressed)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new ZLibStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressString(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00015E4C File Offset: 0x0001404C
		public static byte[] UncompressBuffer(byte[] compressed)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new ZLibStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressBuffer(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x040003CA RID: 970
		internal ZLibBaseStream m_baseStream;

		// Token: 0x040003CB RID: 971
		private bool m_disposed;
	}
}
