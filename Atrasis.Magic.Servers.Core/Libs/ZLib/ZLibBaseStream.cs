using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000E8 RID: 232
	internal class ZLibBaseStream : Stream
	{
		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x00008872 File Offset: 0x00006A72
		internal int Crc32
		{
			get
			{
				if (this.crc == null)
				{
					return 0;
				}
				return this.crc.Crc32Result;
			}
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00014DB0 File Offset: 0x00012FB0
		public ZLibBaseStream(Stream stream, CompressionMode compressionMode, CompressionLevel level, ZlibStreamFlavor flavor, bool leaveOpen)
		{
			this.m_flushMode = FlushType.None;
			this.m_stream = stream;
			this.m_leaveOpen = leaveOpen;
			this.m_compressionMode = compressionMode;
			this.m_flavor = flavor;
			this.m_level = level;
			if (flavor == ZlibStreamFlavor.GZIP)
			{
				this.crc = new CRC32();
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x00008889 File Offset: 0x00006A89
		protected internal bool m_wantCompress
		{
			get
			{
				return this.m_compressionMode == CompressionMode.Compress;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00014E24 File Offset: 0x00013024
		private ZLibCodec z
		{
			get
			{
				if (this.m_z == null)
				{
					bool flag = this.m_flavor == ZlibStreamFlavor.ZLIB;
					this.m_z = new ZLibCodec();
					if (this.m_compressionMode == CompressionMode.Decompress)
					{
						this.m_z.InitializeInflate(flag);
					}
					else
					{
						this.m_z.Strategy = this.Strategy;
						this.m_z.InitializeDeflate(this.m_level, flag);
					}
				}
				return this.m_z;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060006AA RID: 1706 RVA: 0x00008894 File Offset: 0x00006A94
		private byte[] workingBuffer
		{
			get
			{
				if (this.m_workingBuffer == null)
				{
					this.m_workingBuffer = new byte[this.m_bufferSize];
				}
				return this.m_workingBuffer;
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00014E94 File Offset: 0x00013094
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.crc != null)
			{
				this.crc.SlurpBlock(buffer, offset, count);
			}
			if (this.m_streamMode == ZLibBaseStream.StreamMode.Undefined)
			{
				this.m_streamMode = ZLibBaseStream.StreamMode.Writer;
			}
			else if (this.m_streamMode != ZLibBaseStream.StreamMode.Writer)
			{
				throw new ZLibException("Cannot Write after Reading.");
			}
			if (count == 0)
			{
				return;
			}
			this.z.InputBuffer = buffer;
			this.m_z.NextIn = offset;
			this.m_z.AvailableBytesIn = count;
			for (;;)
			{
				this.m_z.OutputBuffer = this.workingBuffer;
				this.m_z.NextOut = 0;
				this.m_z.AvailableBytesOut = this.m_workingBuffer.Length;
				int num = this.m_wantCompress ? this.m_z.Deflate(this.m_flushMode) : this.m_z.Inflate(this.m_flushMode);
				if (num != 0 && num != 1)
				{
					break;
				}
				this.m_stream.Write(this.m_workingBuffer, 0, this.m_workingBuffer.Length - this.m_z.AvailableBytesOut);
				bool flag = this.m_z.AvailableBytesIn == 0 && this.m_z.AvailableBytesOut != 0;
				if (this.m_flavor == ZlibStreamFlavor.GZIP && !this.m_wantCompress)
				{
					flag = (this.m_z.AvailableBytesIn == 8 && this.m_z.AvailableBytesOut != 0);
				}
				if (flag)
				{
					return;
				}
			}
			throw new ZLibException((this.m_wantCompress ? "de" : "in") + "flating: " + this.m_z.Message);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00015030 File Offset: 0x00013230
		private void finish()
		{
			if (this.m_z == null)
			{
				return;
			}
			if (this.m_streamMode == ZLibBaseStream.StreamMode.Writer)
			{
				bool flag;
				do
				{
					this.m_z.OutputBuffer = this.workingBuffer;
					this.m_z.NextOut = 0;
					this.m_z.AvailableBytesOut = this.m_workingBuffer.Length;
					int num = this.m_wantCompress ? this.m_z.Deflate(FlushType.Finish) : this.m_z.Inflate(FlushType.Finish);
					if (num != 1 && num != 0)
					{
						goto IL_119;
					}
					if (this.m_workingBuffer.Length - this.m_z.AvailableBytesOut > 0)
					{
						this.m_stream.Write(this.m_workingBuffer, 0, this.m_workingBuffer.Length - this.m_z.AvailableBytesOut);
					}
					flag = (this.m_z.AvailableBytesIn == 0 && this.m_z.AvailableBytesOut != 0);
					if (this.m_flavor == ZlibStreamFlavor.GZIP && !this.m_wantCompress)
					{
						flag = (this.m_z.AvailableBytesIn == 8 && this.m_z.AvailableBytesOut != 0);
					}
				}
				while (!flag);
				this.Flush();
				if (this.m_flavor != ZlibStreamFlavor.GZIP)
				{
					return;
				}
				if (this.m_wantCompress)
				{
					int crc32Result = this.crc.Crc32Result;
					this.m_stream.Write(BitConverter.GetBytes(crc32Result), 0, 4);
					int value = (int)(this.crc.TotalBytesRead & 4294967295L);
					this.m_stream.Write(BitConverter.GetBytes(value), 0, 4);
					return;
				}
				throw new ZLibException("Writing with decompression is not supported.");
				IL_119:
				string text = (this.m_wantCompress ? "de" : "in") + "flating";
				if (this.m_z.Message == null)
				{
					int num;
					throw new ZLibException(string.Format("{0}: (rc = {1})", text, num));
				}
				throw new ZLibException(text + ": " + this.m_z.Message);
			}
			else if (this.m_streamMode == ZLibBaseStream.StreamMode.Reader && this.m_flavor == ZlibStreamFlavor.GZIP)
			{
				if (this.m_wantCompress)
				{
					throw new ZLibException("Reading with compression is not supported.");
				}
				if (this.m_z.TotalBytesOut == 0L)
				{
					return;
				}
				byte[] array = new byte[8];
				if (this.m_z.AvailableBytesIn < 8)
				{
					Array.Copy(this.m_z.InputBuffer, this.m_z.NextIn, array, 0, this.m_z.AvailableBytesIn);
					int num2 = 8 - this.m_z.AvailableBytesIn;
					int num3 = this.m_stream.Read(array, this.m_z.AvailableBytesIn, num2);
					if (num2 != num3)
					{
						throw new ZLibException(string.Format("Missing or incomplete GZIP trailer. Expected 8 bytes, got {0}.", this.m_z.AvailableBytesIn + num3));
					}
				}
				else
				{
					Array.Copy(this.m_z.InputBuffer, this.m_z.NextIn, array, 0, array.Length);
				}
				int num4 = BitConverter.ToInt32(array, 0);
				int crc32Result2 = this.crc.Crc32Result;
				int num5 = BitConverter.ToInt32(array, 4);
				int num6 = (int)(this.m_z.TotalBytesOut & 4294967295L);
				if (crc32Result2 != num4)
				{
					throw new ZLibException(string.Format("Bad CRC32 in GZIP trailer. (actual({0:X8})!=expected({1:X8}))", crc32Result2, num4));
				}
				if (num6 != num5)
				{
					throw new ZLibException(string.Format("Bad size in GZIP trailer. (actual({0})!=expected({1}))", num6, num5));
				}
			}
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000088B5 File Offset: 0x00006AB5
		private void end()
		{
			if (this.z == null)
			{
				return;
			}
			if (this.m_wantCompress)
			{
				this.m_z.EndDeflate();
			}
			else
			{
				this.m_z.EndInflate();
			}
			this.m_z = null;
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000153A0 File Offset: 0x000135A0
		public override void Close()
		{
			if (this.m_stream == null)
			{
				return;
			}
			try
			{
				this.finish();
			}
			finally
			{
				this.end();
				if (!this.m_leaveOpen)
				{
					this.m_stream.Close();
				}
				this.m_stream = null;
			}
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000088E9 File Offset: 0x00006AE9
		public override void Flush()
		{
			this.m_stream.Flush();
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x000088F6 File Offset: 0x00006AF6
		public override void SetLength(long value)
		{
			this.m_stream.SetLength(value);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x000153F0 File Offset: 0x000135F0
		private string ReadZeroTerminatedString()
		{
			List<byte> list = new List<byte>();
			bool flag = false;
			while (this.m_stream.Read(this.m_buf1, 0, 1) == 1)
			{
				if (this.m_buf1[0] == 0)
				{
					flag = true;
				}
				else
				{
					list.Add(this.m_buf1[0]);
				}
				if (flag)
				{
					byte[] array = list.ToArray();
					return GZipStream.iso8859dash1.GetString(array, 0, array.Length);
				}
			}
			throw new ZLibException("Unexpected EOF reading GZIP header.");
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00015460 File Offset: 0x00013660
		private int m_ReadAndValidateGzipHeader()
		{
			int num = 0;
			byte[] array = new byte[10];
			int num2 = this.m_stream.Read(array, 0, array.Length);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 != 10)
			{
				throw new ZLibException("Not a valid GZIP stream.");
			}
			if (array[0] == 31 && array[1] == 139)
			{
				if (array[2] == 8)
				{
					int num3 = BitConverter.ToInt32(array, 4);
					this.m_GzipMtime = GZipStream.m_unixEpoch.AddSeconds((double)num3);
					num += num2;
					if ((array[3] & 4) == 4)
					{
						num2 = this.m_stream.Read(array, 0, 2);
						num += num2;
						short num4 = (short)((int)array[0] + (int)array[1] * 256);
						byte[] array2 = new byte[(int)num4];
						num2 = this.m_stream.Read(array2, 0, array2.Length);
						if (num2 != (int)num4)
						{
							throw new ZLibException("Unexpected end-of-file reading GZIP header.");
						}
						num += num2;
					}
					if ((array[3] & 8) == 8)
					{
						this.m_GzipFileName = this.ReadZeroTerminatedString();
					}
					if ((array[3] & 16) == 16)
					{
						this.m_GzipComment = this.ReadZeroTerminatedString();
					}
					if ((array[3] & 2) == 2)
					{
						this.Read(this.m_buf1, 0, 1);
					}
					return num;
				}
			}
			throw new ZLibException("Bad GZIP header.");
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00015588 File Offset: 0x00013788
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.m_streamMode == ZLibBaseStream.StreamMode.Undefined)
			{
				if (!this.m_stream.CanRead)
				{
					throw new ZLibException("The stream is not readable.");
				}
				this.m_streamMode = ZLibBaseStream.StreamMode.Reader;
				this.z.AvailableBytesIn = 0;
				if (this.m_flavor == ZlibStreamFlavor.GZIP)
				{
					this.m_gzipHeaderByteCount = this.m_ReadAndValidateGzipHeader();
					if (this.m_gzipHeaderByteCount == 0)
					{
						return 0;
					}
				}
			}
			if (this.m_streamMode != ZLibBaseStream.StreamMode.Reader)
			{
				throw new ZLibException("Cannot Read after Writing.");
			}
			if (count == 0)
			{
				return 0;
			}
			if (this.nomoreinput && this.m_wantCompress)
			{
				return 0;
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (offset < buffer.GetLowerBound(0))
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (offset + count > buffer.GetLength(0))
			{
				throw new ArgumentOutOfRangeException("count");
			}
			this.m_z.OutputBuffer = buffer;
			this.m_z.NextOut = offset;
			this.m_z.AvailableBytesOut = count;
			this.m_z.InputBuffer = this.workingBuffer;
			int num;
			for (;;)
			{
				if (this.m_z.AvailableBytesIn == 0 && !this.nomoreinput)
				{
					this.m_z.NextIn = 0;
					this.m_z.AvailableBytesIn = this.m_stream.Read(this.m_workingBuffer, 0, this.m_workingBuffer.Length);
					if (this.m_z.AvailableBytesIn == 0)
					{
						this.nomoreinput = true;
					}
				}
				num = (this.m_wantCompress ? this.m_z.Deflate(this.m_flushMode) : this.m_z.Inflate(this.m_flushMode));
				if (this.nomoreinput && num == -5)
				{
					break;
				}
				if (num != 0 && num != 1)
				{
					goto Block_17;
				}
				if (((this.nomoreinput || num == 1) && this.m_z.AvailableBytesOut == count) || this.m_z.AvailableBytesOut <= 0 || this.nomoreinput)
				{
					goto IL_234;
				}
				if (num != 0)
				{
					goto Block_21;
				}
			}
			return 0;
			Block_17:
			throw new ZLibException(string.Format("{0}flating:  rc={1}  msg={2}", this.m_wantCompress ? "de" : "in", num, this.m_z.Message));
			Block_21:
			IL_234:
			if (this.m_z.AvailableBytesOut > 0)
			{
				if (num != 0)
				{
				}
				if (this.nomoreinput && this.m_wantCompress)
				{
					num = this.m_z.Deflate(FlushType.Finish);
					if (num != 0 && num != 1)
					{
						throw new ZLibException(string.Format("Deflating:  rc={0}  msg={1}", num, this.m_z.Message));
					}
				}
			}
			num = count - this.m_z.AvailableBytesOut;
			if (this.crc != null)
			{
				this.crc.SlurpBlock(buffer, offset, num);
			}
			return num;
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x00008904 File Offset: 0x00006B04
		public override bool CanRead
		{
			get
			{
				return this.m_stream.CanRead;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00008911 File Offset: 0x00006B11
		public override bool CanSeek
		{
			get
			{
				return this.m_stream.CanSeek;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x0000891E File Offset: 0x00006B1E
		public override bool CanWrite
		{
			get
			{
				return this.m_stream.CanWrite;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x0000892B File Offset: 0x00006B2B
		public override long Length
		{
			get
			{
				return this.m_stream.Length;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x000083CF File Offset: 0x000065CF
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x000083CF File Offset: 0x000065CF
		public override long Position
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00015844 File Offset: 0x00013A44
		public static void CompressString(string s, Stream compressor)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			try
			{
				compressor.Write(bytes, 0, bytes.Length);
			}
			finally
			{
				if (compressor != null)
				{
					((IDisposable)compressor).Dispose();
				}
			}
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00015888 File Offset: 0x00013A88
		public static void CompressBuffer(byte[] b, Stream compressor)
		{
			try
			{
				compressor.Write(b, 0, b.Length);
			}
			finally
			{
				if (compressor != null)
				{
					((IDisposable)compressor).Dispose();
				}
			}
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000158C0 File Offset: 0x00013AC0
		public static string UncompressString(byte[] compressed, Stream decompressor)
		{
			byte[] array = new byte[1024];
			Encoding utf = Encoding.UTF8;
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				try
				{
					int count;
					while ((count = decompressor.Read(array, 0, array.Length)) != 0)
					{
						memoryStream.Write(array, 0, count);
					}
				}
				finally
				{
					if (decompressor != null)
					{
						((IDisposable)decompressor).Dispose();
					}
				}
				memoryStream.Seek(0L, SeekOrigin.Begin);
				result = new StreamReader(memoryStream, utf).ReadToEnd();
			}
			return result;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00015958 File Offset: 0x00013B58
		public static byte[] UncompressBuffer(byte[] compressed, Stream decompressor)
		{
			byte[] array = new byte[1024];
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				try
				{
					int count;
					while ((count = decompressor.Read(array, 0, array.Length)) != 0)
					{
						memoryStream.Write(array, 0, count);
					}
				}
				finally
				{
					if (decompressor != null)
					{
						((IDisposable)decompressor).Dispose();
					}
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0400039B RID: 923
		protected internal ZLibCodec m_z;

		// Token: 0x0400039C RID: 924
		protected internal ZLibBaseStream.StreamMode m_streamMode = ZLibBaseStream.StreamMode.Undefined;

		// Token: 0x0400039D RID: 925
		protected internal FlushType m_flushMode;

		// Token: 0x0400039E RID: 926
		protected internal ZlibStreamFlavor m_flavor;

		// Token: 0x0400039F RID: 927
		protected internal CompressionMode m_compressionMode;

		// Token: 0x040003A0 RID: 928
		protected internal CompressionLevel m_level;

		// Token: 0x040003A1 RID: 929
		protected internal bool m_leaveOpen;

		// Token: 0x040003A2 RID: 930
		protected internal byte[] m_workingBuffer;

		// Token: 0x040003A3 RID: 931
		protected internal int m_bufferSize = 16384;

		// Token: 0x040003A4 RID: 932
		protected internal byte[] m_buf1 = new byte[1];

		// Token: 0x040003A5 RID: 933
		protected internal Stream m_stream;

		// Token: 0x040003A6 RID: 934
		protected internal CompressionStrategy Strategy;

		// Token: 0x040003A7 RID: 935
		private readonly CRC32 crc;

		// Token: 0x040003A8 RID: 936
		protected internal string m_GzipFileName;

		// Token: 0x040003A9 RID: 937
		protected internal string m_GzipComment;

		// Token: 0x040003AA RID: 938
		protected internal DateTime m_GzipMtime;

		// Token: 0x040003AB RID: 939
		protected internal int m_gzipHeaderByteCount;

		// Token: 0x040003AC RID: 940
		private bool nomoreinput;

		// Token: 0x020000E9 RID: 233
		internal enum StreamMode
		{
			// Token: 0x040003AE RID: 942
			Writer,
			// Token: 0x040003AF RID: 943
			Reader,
			// Token: 0x040003B0 RID: 944
			Undefined
		}
	}
}
