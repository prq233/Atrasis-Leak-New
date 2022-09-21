using System;
using System.IO;
using System.Text;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000D2 RID: 210
	public class GZipStream : Stream
	{
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x0000841C File Offset: 0x0000661C
		// (set) Token: 0x0600062B RID: 1579 RVA: 0x00008424 File Offset: 0x00006624
		public string Comment
		{
			get
			{
				return this.m_Comment;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				this.m_Comment = value;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x00008440 File Offset: 0x00006640
		// (set) Token: 0x0600062D RID: 1581 RVA: 0x000102A0 File Offset: 0x0000E4A0
		public string FileName
		{
			get
			{
				return this.m_FileName;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				this.m_FileName = value;
				if (this.m_FileName == null)
				{
					return;
				}
				if (this.m_FileName.IndexOf("/") != -1)
				{
					this.m_FileName = this.m_FileName.Replace("/", "\\");
				}
				if (this.m_FileName.EndsWith("\\"))
				{
					throw new Exception("Illegal filename");
				}
				if (this.m_FileName.IndexOf("\\") != -1)
				{
					this.m_FileName = Path.GetFileName(this.m_FileName);
				}
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00008448 File Offset: 0x00006648
		// (set) Token: 0x0600062F RID: 1583 RVA: 0x00008450 File Offset: 0x00006650
		public int Crc32 { get; private set; }

		// Token: 0x06000630 RID: 1584 RVA: 0x00008459 File Offset: 0x00006659
		public GZipStream(Stream stream, CompressionMode mode) : this(stream, mode, CompressionLevel.Default, false)
		{
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00008465 File Offset: 0x00006665
		public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level) : this(stream, mode, level, false)
		{
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00008471 File Offset: 0x00006671
		public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen) : this(stream, mode, CompressionLevel.Default, leaveOpen)
		{
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0000847D File Offset: 0x0000667D
		public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		{
			this.m_baseStream = new ZLibBaseStream(stream, mode, level, ZlibStreamFlavor.GZIP, leaveOpen);
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x0000849A File Offset: 0x0000669A
		// (set) Token: 0x06000635 RID: 1589 RVA: 0x000084A7 File Offset: 0x000066A7
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
					throw new ObjectDisposedException("GZipStream");
				}
				this.m_baseStream.m_flushMode = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x000084C8 File Offset: 0x000066C8
		// (set) Token: 0x06000637 RID: 1591 RVA: 0x00010340 File Offset: 0x0000E540
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
					throw new ObjectDisposedException("GZipStream");
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

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x000084D5 File Offset: 0x000066D5
		public virtual long TotalIn
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesIn;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x000084E7 File Offset: 0x000066E7
		public virtual long TotalOut
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesOut;
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x000103AC File Offset: 0x0000E5AC
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (!this.m_disposed)
				{
					if (disposing && this.m_baseStream != null)
					{
						this.m_baseStream.Close();
						this.Crc32 = this.m_baseStream.Crc32;
					}
					this.m_disposed = true;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x000084F9 File Offset: 0x000066F9
		public override bool CanRead
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				return this.m_baseStream.m_stream.CanRead;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x0000598D File Offset: 0x00003B8D
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x0000851E File Offset: 0x0000671E
		public override bool CanWrite
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				return this.m_baseStream.m_stream.CanWrite;
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00008543 File Offset: 0x00006743
		public override void Flush()
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			this.m_baseStream.Flush();
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Length
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0001040C File Offset: 0x0000E60C
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Position
		{
			get
			{
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Writer)
				{
					return this.m_baseStream.m_z.TotalBytesOut + (long)this.m_headerByteCount;
				}
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Reader)
				{
					return this.m_baseStream.m_z.TotalBytesIn + (long)this.m_baseStream.m_gzipHeaderByteCount;
				}
				return 0L;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00010474 File Offset: 0x0000E674
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			int result = this.m_baseStream.Read(buffer, offset, count);
			if (!this.m_firstReadDone)
			{
				this.m_firstReadDone = true;
				this.FileName = this.m_baseStream.m_GzipFileName;
				this.Comment = this.m_baseStream.m_GzipComment;
			}
			return result;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x000083CF File Offset: 0x000065CF
		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x000104D4 File Offset: 0x0000E6D4
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Undefined)
			{
				if (!this.m_baseStream.m_wantCompress)
				{
					throw new InvalidOperationException();
				}
				this.m_headerByteCount = this.EmitHeader();
			}
			this.m_baseStream.Write(buffer, offset, count);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00010534 File Offset: 0x0000E734
		private int EmitHeader()
		{
			byte[] array = (this.Comment == null) ? null : GZipStream.iso8859dash1.GetBytes(this.Comment);
			byte[] array2 = (this.FileName == null) ? null : GZipStream.iso8859dash1.GetBytes(this.FileName);
			int num = (this.Comment == null) ? 0 : (array.Length + 1);
			int num2 = (this.FileName == null) ? 0 : (array2.Length + 1);
			byte[] array3 = new byte[10 + num + num2];
			array3[0] = 31;
			array3[1] = 139;
			byte[] array4 = array3;
			int num3 = 2;
			int num4 = 3;
			array4[num3] = 8;
			byte b = 0;
			if (this.Comment != null)
			{
				b ^= 16;
			}
			if (this.FileName != null)
			{
				b ^= 8;
			}
			array3[num4++] = b;
			if (this.LastModified == null)
			{
				this.LastModified = new DateTime?(DateTime.Now);
			}
			Array.Copy(BitConverter.GetBytes((int)(this.LastModified.Value - GZipStream.m_unixEpoch).TotalSeconds), 0, array3, num4, 4);
			num4 += 4;
			array3[num4++] = 0;
			array3[num4++] = byte.MaxValue;
			if (num2 != 0)
			{
				Array.Copy(array2, 0, array3, num4, num2 - 1);
				num4 += num2 - 1;
				array3[num4++] = 0;
			}
			if (num != 0)
			{
				Array.Copy(array, 0, array3, num4, num - 1);
				num4 += num - 1;
				array3[num4++] = 0;
			}
			this.m_baseStream.m_stream.Write(array3, 0, array3.Length);
			return array3.Length;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x000106C8 File Offset: 0x0000E8C8
		public static byte[] CompressString(string s)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressString(s, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00010710 File Offset: 0x0000E910
		public static byte[] CompressBuffer(byte[] b)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressBuffer(b, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00010758 File Offset: 0x0000E958
		public static string UncompressString(byte[] compressed)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressString(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001079C File Offset: 0x0000E99C
		public static byte[] UncompressBuffer(byte[] compressed)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressBuffer(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x040002A9 RID: 681
		public DateTime? LastModified;

		// Token: 0x040002AB RID: 683
		private int m_headerByteCount;

		// Token: 0x040002AC RID: 684
		internal ZLibBaseStream m_baseStream;

		// Token: 0x040002AD RID: 685
		private bool m_disposed;

		// Token: 0x040002AE RID: 686
		private bool m_firstReadDone;

		// Token: 0x040002AF RID: 687
		private string m_FileName;

		// Token: 0x040002B0 RID: 688
		private string m_Comment;

		// Token: 0x040002B1 RID: 689
		internal static readonly DateTime m_unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x040002B2 RID: 690
		internal static readonly Encoding iso8859dash1 = Encoding.GetEncoding("iso-8859-1");
	}
}
