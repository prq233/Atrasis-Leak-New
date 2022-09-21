using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000D7 RID: 215
	internal sealed class InflateManager
	{
		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x0000861F File Offset: 0x0000681F
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x00008627 File Offset: 0x00006827
		internal bool HandleRfc1950HeaderBytes { get; set; } = true;

		// Token: 0x0600065B RID: 1627 RVA: 0x00008630 File Offset: 0x00006830
		public InflateManager()
		{
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0000863F File Offset: 0x0000683F
		public InflateManager(bool expectRfc1950HeaderBytes)
		{
			this.HandleRfc1950HeaderBytes = expectRfc1950HeaderBytes;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00012AE4 File Offset: 0x00010CE4
		internal int Reset()
		{
			ZLibCodec codec = this.m_codec;
			this.m_codec.TotalBytesOut = 0L;
			codec.TotalBytesIn = 0L;
			this.m_codec.Message = null;
			this.mode = (this.HandleRfc1950HeaderBytes ? InflateManager.InflateManagerMode.METHOD : InflateManager.InflateManagerMode.BLOCKS);
			this.blocks.Reset();
			return 0;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00008655 File Offset: 0x00006855
		internal int End()
		{
			if (this.blocks != null)
			{
				this.blocks.Free();
			}
			this.blocks = null;
			return 0;
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00012B44 File Offset: 0x00010D44
		internal int Initialize(ZLibCodec codec, int w)
		{
			this.m_codec = codec;
			this.m_codec.Message = null;
			this.blocks = null;
			if (w >= 8 && w <= 15)
			{
				this.wbits = w;
				this.blocks = new InflateBlocks(codec, this.HandleRfc1950HeaderBytes ? this : null, 1 << w);
				this.Reset();
				return 0;
			}
			this.End();
			throw new ZLibException("Bad window size.");
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00012BB8 File Offset: 0x00010DB8
		internal int Inflate(FlushType flush)
		{
			if (this.m_codec.InputBuffer == null)
			{
				throw new ZLibException("InputBuffer is null. ");
			}
			int num = 0;
			int num2 = -5;
			int nextIn;
			for (;;)
			{
				switch (this.mode)
				{
				case InflateManager.InflateManagerMode.METHOD:
				{
					if (this.m_codec.AvailableBytesIn == 0)
					{
						return num2;
					}
					num2 = num;
					this.m_codec.AvailableBytesIn--;
					this.m_codec.TotalBytesIn += 1L;
					byte[] inputBuffer = this.m_codec.InputBuffer;
					ZLibCodec codec = this.m_codec;
					nextIn = codec.NextIn;
					codec.NextIn = nextIn + 1;
					if (((this.method = inputBuffer[nextIn]) & 15) != 8)
					{
						this.mode = InflateManager.InflateManagerMode.BAD;
						this.m_codec.Message = string.Format("unknown compression method (0x{0:X2})", this.method);
						this.marker = 5;
						continue;
					}
					if ((this.method >> 4) + 8 > this.wbits)
					{
						this.mode = InflateManager.InflateManagerMode.BAD;
						this.m_codec.Message = string.Format("invalid window size ({0})", (this.method >> 4) + 8);
						this.marker = 5;
						continue;
					}
					this.mode = InflateManager.InflateManagerMode.FLAG;
					continue;
				}
				case InflateManager.InflateManagerMode.FLAG:
				{
					if (this.m_codec.AvailableBytesIn == 0)
					{
						return num2;
					}
					num2 = num;
					this.m_codec.AvailableBytesIn--;
					this.m_codec.TotalBytesIn += 1L;
					byte[] inputBuffer2 = this.m_codec.InputBuffer;
					ZLibCodec codec2 = this.m_codec;
					nextIn = codec2.NextIn;
					codec2.NextIn = nextIn + 1;
					int num3 = inputBuffer2[nextIn] & 255;
					if (((this.method << 8) + num3) % 31 != 0)
					{
						this.mode = InflateManager.InflateManagerMode.BAD;
						this.m_codec.Message = "incorrect header check";
						this.marker = 5;
						continue;
					}
					this.mode = (((num3 & 32) == 0) ? InflateManager.InflateManagerMode.BLOCKS : InflateManager.InflateManagerMode.DICT4);
					continue;
				}
				case InflateManager.InflateManagerMode.DICT4:
					if (this.m_codec.AvailableBytesIn != 0)
					{
						num2 = num;
						this.m_codec.AvailableBytesIn--;
						this.m_codec.TotalBytesIn += 1L;
						byte[] inputBuffer3 = this.m_codec.InputBuffer;
						ZLibCodec codec3 = this.m_codec;
						nextIn = codec3.NextIn;
						codec3.NextIn = nextIn + 1;
						this.expectedCheck = (uint)(inputBuffer3[nextIn] << 24 & 4278190080L);
						this.mode = InflateManager.InflateManagerMode.DICT3;
						continue;
					}
					return num2;
				case InflateManager.InflateManagerMode.DICT3:
					if (this.m_codec.AvailableBytesIn != 0)
					{
						num2 = num;
						this.m_codec.AvailableBytesIn--;
						this.m_codec.TotalBytesIn += 1L;
						uint num4 = this.expectedCheck;
						byte[] inputBuffer4 = this.m_codec.InputBuffer;
						ZLibCodec codec4 = this.m_codec;
						nextIn = codec4.NextIn;
						codec4.NextIn = nextIn + 1;
						this.expectedCheck = num4 + (inputBuffer4[nextIn] << 16 & 16711680U);
						this.mode = InflateManager.InflateManagerMode.DICT2;
						continue;
					}
					return num2;
				case InflateManager.InflateManagerMode.DICT2:
					if (this.m_codec.AvailableBytesIn != 0)
					{
						num2 = num;
						this.m_codec.AvailableBytesIn--;
						this.m_codec.TotalBytesIn += 1L;
						uint num5 = this.expectedCheck;
						byte[] inputBuffer5 = this.m_codec.InputBuffer;
						ZLibCodec codec5 = this.m_codec;
						nextIn = codec5.NextIn;
						codec5.NextIn = nextIn + 1;
						this.expectedCheck = num5 + (inputBuffer5[nextIn] << 8 & 65280U);
						this.mode = InflateManager.InflateManagerMode.DICT1;
						continue;
					}
					return num2;
				case InflateManager.InflateManagerMode.DICT1:
					goto IL_659;
				case InflateManager.InflateManagerMode.DICT0:
					goto IL_6EA;
				case InflateManager.InflateManagerMode.BLOCKS:
					num2 = this.blocks.Process(num2);
					if (num2 == -3)
					{
						this.mode = InflateManager.InflateManagerMode.BAD;
						this.marker = 0;
						continue;
					}
					if (num2 == 0)
					{
						num2 = num;
					}
					if (num2 != 1)
					{
						return num2;
					}
					num2 = num;
					this.computedCheck = this.blocks.Reset();
					if (this.HandleRfc1950HeaderBytes)
					{
						this.mode = InflateManager.InflateManagerMode.CHECK4;
						continue;
					}
					goto IL_70E;
				case InflateManager.InflateManagerMode.CHECK4:
					if (this.m_codec.AvailableBytesIn != 0)
					{
						num2 = num;
						this.m_codec.AvailableBytesIn--;
						this.m_codec.TotalBytesIn += 1L;
						byte[] inputBuffer6 = this.m_codec.InputBuffer;
						ZLibCodec codec6 = this.m_codec;
						nextIn = codec6.NextIn;
						codec6.NextIn = nextIn + 1;
						this.expectedCheck = (uint)(inputBuffer6[nextIn] << 24 & 4278190080L);
						this.mode = InflateManager.InflateManagerMode.CHECK3;
						continue;
					}
					return num2;
				case InflateManager.InflateManagerMode.CHECK3:
					if (this.m_codec.AvailableBytesIn != 0)
					{
						num2 = num;
						this.m_codec.AvailableBytesIn--;
						this.m_codec.TotalBytesIn += 1L;
						uint num6 = this.expectedCheck;
						byte[] inputBuffer7 = this.m_codec.InputBuffer;
						ZLibCodec codec7 = this.m_codec;
						nextIn = codec7.NextIn;
						codec7.NextIn = nextIn + 1;
						this.expectedCheck = num6 + (inputBuffer7[nextIn] << 16 & 16711680U);
						this.mode = InflateManager.InflateManagerMode.CHECK2;
						continue;
					}
					return num2;
				case InflateManager.InflateManagerMode.CHECK2:
					if (this.m_codec.AvailableBytesIn != 0)
					{
						num2 = num;
						this.m_codec.AvailableBytesIn--;
						this.m_codec.TotalBytesIn += 1L;
						uint num7 = this.expectedCheck;
						byte[] inputBuffer8 = this.m_codec.InputBuffer;
						ZLibCodec codec8 = this.m_codec;
						nextIn = codec8.NextIn;
						codec8.NextIn = nextIn + 1;
						this.expectedCheck = num7 + (inputBuffer8[nextIn] << 8 & 65280U);
						this.mode = InflateManager.InflateManagerMode.CHECK1;
						continue;
					}
					return num2;
				case InflateManager.InflateManagerMode.CHECK1:
				{
					if (this.m_codec.AvailableBytesIn == 0)
					{
						return num2;
					}
					num2 = num;
					this.m_codec.AvailableBytesIn--;
					this.m_codec.TotalBytesIn += 1L;
					uint num8 = this.expectedCheck;
					byte[] inputBuffer9 = this.m_codec.InputBuffer;
					ZLibCodec codec9 = this.m_codec;
					nextIn = codec9.NextIn;
					codec9.NextIn = nextIn + 1;
					this.expectedCheck = num8 + (inputBuffer9[nextIn] & 255U);
					if (this.computedCheck != this.expectedCheck)
					{
						this.mode = InflateManager.InflateManagerMode.BAD;
						this.m_codec.Message = "incorrect data check";
						this.marker = 5;
						continue;
					}
					goto IL_720;
				}
				case InflateManager.InflateManagerMode.DONE:
					return 1;
				case InflateManager.InflateManagerMode.BAD:
					goto IL_72A;
				}
				goto Block_20;
			}
			return num2;
			Block_20:
			throw new ZLibException("Stream error.");
			IL_659:
			if (this.m_codec.AvailableBytesIn == 0)
			{
				return num2;
			}
			this.m_codec.AvailableBytesIn--;
			this.m_codec.TotalBytesIn += 1L;
			uint num9 = this.expectedCheck;
			byte[] inputBuffer10 = this.m_codec.InputBuffer;
			ZLibCodec codec10 = this.m_codec;
			nextIn = codec10.NextIn;
			codec10.NextIn = nextIn + 1;
			this.expectedCheck = num9 + (inputBuffer10[nextIn] & 255U);
			this.m_codec.m_Adler32 = this.expectedCheck;
			this.mode = InflateManager.InflateManagerMode.DICT0;
			return 2;
			IL_6EA:
			this.mode = InflateManager.InflateManagerMode.BAD;
			this.m_codec.Message = "need dictionary";
			this.marker = 0;
			return -2;
			IL_70E:
			this.mode = InflateManager.InflateManagerMode.DONE;
			return 1;
			IL_720:
			this.mode = InflateManager.InflateManagerMode.DONE;
			return 1;
			IL_72A:
			throw new ZLibException(string.Format("Bad state ({0})", this.m_codec.Message));
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001330C File Offset: 0x0001150C
		internal int SetDictionary(byte[] dictionary)
		{
			int start = 0;
			int num = dictionary.Length;
			if (this.mode != InflateManager.InflateManagerMode.DICT0)
			{
				throw new ZLibException("Stream error.");
			}
			if (Adler.Adler32(1U, dictionary, 0, dictionary.Length) != this.m_codec.m_Adler32)
			{
				return -3;
			}
			this.m_codec.m_Adler32 = Adler.Adler32(0U, null, 0, 0);
			if (num >= 1 << this.wbits)
			{
				num = (1 << this.wbits) - 1;
				start = dictionary.Length - num;
			}
			this.blocks.SetDictionary(dictionary, start, num);
			this.mode = InflateManager.InflateManagerMode.BLOCKS;
			return 0;
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0001339C File Offset: 0x0001159C
		internal int Sync()
		{
			if (this.mode != InflateManager.InflateManagerMode.BAD)
			{
				this.mode = InflateManager.InflateManagerMode.BAD;
				this.marker = 0;
			}
			int num;
			if ((num = this.m_codec.AvailableBytesIn) == 0)
			{
				return -5;
			}
			int num2 = this.m_codec.NextIn;
			int num3 = this.marker;
			while (num != 0 && num3 < 4)
			{
				if (this.m_codec.InputBuffer[num2] == InflateManager.mark[num3])
				{
					num3++;
				}
				else if (this.m_codec.InputBuffer[num2] != 0)
				{
					num3 = 0;
				}
				else
				{
					num3 = 4 - num3;
				}
				num2++;
				num--;
			}
			this.m_codec.TotalBytesIn += (long)(num2 - this.m_codec.NextIn);
			this.m_codec.NextIn = num2;
			this.m_codec.AvailableBytesIn = num;
			this.marker = num3;
			if (num3 != 4)
			{
				return -3;
			}
			long totalBytesIn = this.m_codec.TotalBytesIn;
			long totalBytesOut = this.m_codec.TotalBytesOut;
			this.Reset();
			this.m_codec.TotalBytesIn = totalBytesIn;
			this.m_codec.TotalBytesOut = totalBytesOut;
			this.mode = InflateManager.InflateManagerMode.BLOCKS;
			return 0;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00008672 File Offset: 0x00006872
		internal int SyncPoint(ZLibCodec z)
		{
			return this.blocks.SyncPoint();
		}

		// Token: 0x040002ED RID: 749
		private const int PRESET_DICT = 32;

		// Token: 0x040002EE RID: 750
		private const int Z_DEFLATED = 8;

		// Token: 0x040002EF RID: 751
		private InflateManager.InflateManagerMode mode;

		// Token: 0x040002F0 RID: 752
		internal ZLibCodec m_codec;

		// Token: 0x040002F1 RID: 753
		internal int method;

		// Token: 0x040002F2 RID: 754
		internal uint computedCheck;

		// Token: 0x040002F3 RID: 755
		internal uint expectedCheck;

		// Token: 0x040002F4 RID: 756
		internal int marker;

		// Token: 0x040002F6 RID: 758
		internal int wbits;

		// Token: 0x040002F7 RID: 759
		internal InflateBlocks blocks;

		// Token: 0x040002F8 RID: 760
		private static readonly byte[] mark = new byte[]
		{
			0,
			0,
			byte.MaxValue,
			byte.MaxValue
		};

		// Token: 0x020000D8 RID: 216
		private enum InflateManagerMode
		{
			// Token: 0x040002FA RID: 762
			METHOD,
			// Token: 0x040002FB RID: 763
			FLAG,
			// Token: 0x040002FC RID: 764
			DICT4,
			// Token: 0x040002FD RID: 765
			DICT3,
			// Token: 0x040002FE RID: 766
			DICT2,
			// Token: 0x040002FF RID: 767
			DICT1,
			// Token: 0x04000300 RID: 768
			DICT0,
			// Token: 0x04000301 RID: 769
			BLOCKS,
			// Token: 0x04000302 RID: 770
			CHECK4,
			// Token: 0x04000303 RID: 771
			CHECK3,
			// Token: 0x04000304 RID: 772
			CHECK2,
			// Token: 0x04000305 RID: 773
			CHECK1,
			// Token: 0x04000306 RID: 774
			DONE,
			// Token: 0x04000307 RID: 775
			BAD
		}
	}
}
