using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000CA RID: 202
	[Guid("ebc25cf6-9120-4283-b972-0e5520d0000C")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class CRC32
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00007F79 File Offset: 0x00006179
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x00007F81 File Offset: 0x00006181
		public long TotalBytesRead { get; private set; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00007F8A File Offset: 0x0000618A
		public int Crc32Result
		{
			get
			{
				return (int)(~(int)this.m_register);
			}
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00007F93 File Offset: 0x00006193
		public int GetCrc32(Stream input)
		{
			return this.GetCrc32AndCopy(input, null);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0000D6D8 File Offset: 0x0000B8D8
		public int GetCrc32AndCopy(Stream input, Stream output)
		{
			if (input == null)
			{
				throw new Exception("The input stream must not be null.");
			}
			byte[] array = new byte[8192];
			int count = 8192;
			this.TotalBytesRead = 0L;
			int i = input.Read(array, 0, 8192);
			if (output != null)
			{
				output.Write(array, 0, i);
			}
			this.TotalBytesRead += (long)i;
			while (i > 0)
			{
				this.SlurpBlock(array, 0, i);
				i = input.Read(array, 0, count);
				if (output != null)
				{
					output.Write(array, 0, i);
				}
				this.TotalBytesRead += (long)i;
			}
			return (int)(~(int)this.m_register);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00007F9D File Offset: 0x0000619D
		public int ComputeCrc32(int W, byte B)
		{
			return this.m_InternalComputeCrc32((uint)W, B);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00007FA7 File Offset: 0x000061A7
		internal int m_InternalComputeCrc32(uint W, byte B)
		{
			return (int)(this.crc32Table[(int)((W ^ (uint)B) & 255U)] ^ W >> 8);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0000D778 File Offset: 0x0000B978
		public void SlurpBlock(byte[] block, int offset, int count)
		{
			if (block == null)
			{
				throw new Exception("The data buffer must not be null.");
			}
			for (int i = 0; i < count; i++)
			{
				int num = offset + i;
				byte b = block[num];
				if (this.reverseBits)
				{
					uint num2 = this.m_register >> 24 ^ (uint)b;
					this.m_register = (this.m_register << 8 ^ this.crc32Table[(int)num2]);
				}
				else
				{
					uint num3 = (this.m_register & 255U) ^ (uint)b;
					this.m_register = (this.m_register >> 8 ^ this.crc32Table[(int)num3]);
				}
			}
			this.TotalBytesRead += (long)count;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0000D80C File Offset: 0x0000BA0C
		public void UpdateCRC(byte b)
		{
			if (this.reverseBits)
			{
				uint num = this.m_register >> 24 ^ (uint)b;
				this.m_register = (this.m_register << 8 ^ this.crc32Table[(int)num]);
				return;
			}
			uint num2 = (this.m_register & 255U) ^ (uint)b;
			this.m_register = (this.m_register >> 8 ^ this.crc32Table[(int)num2]);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0000D86C File Offset: 0x0000BA6C
		public void UpdateCRC(byte b, int n)
		{
			while (n-- > 0)
			{
				if (this.reverseBits)
				{
					uint num = this.m_register >> 24 ^ (uint)b;
					this.m_register = (this.m_register << 8 ^ this.crc32Table[(int)num]);
				}
				else
				{
					uint num2 = (this.m_register & 255U) ^ (uint)b;
					this.m_register = (this.m_register >> 8 ^ this.crc32Table[(int)num2]);
				}
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0000D8D8 File Offset: 0x0000BAD8
		private static uint ReverseBits(uint data)
		{
			uint num = (data & 1431655765U) << 1 | (data >> 1 & 1431655765U);
			num = ((num & 858993459U) << 2 | (num >> 2 & 858993459U));
			num = ((num & 252645135U) << 4 | (num >> 4 & 252645135U));
			return num << 24 | (num & 65280U) << 8 | (num >> 8 & 65280U) | num >> 24;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0000D944 File Offset: 0x0000BB44
		private static byte ReverseBits(byte data)
		{
			int num = (int)data * 131586;
			uint num2 = (uint)(num & 17055760);
			uint num3 = (uint)(num << 2 & 34111520);
			return (byte)(16781313U * (num2 + num3) >> 24);
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0000D978 File Offset: 0x0000BB78
		private void GenerateLookupTable()
		{
			this.crc32Table = new uint[256];
			byte b = 0;
			do
			{
				uint num = (uint)b;
				for (byte b2 = 8; b2 > 0; b2 -= 1)
				{
					if ((num & 1U) == 1U)
					{
						num = (num >> 1 ^ this.dwPolynomial);
					}
					else
					{
						num >>= 1;
					}
				}
				if (this.reverseBits)
				{
					this.crc32Table[(int)CRC32.ReverseBits(b)] = CRC32.ReverseBits(num);
				}
				else
				{
					this.crc32Table[(int)b] = num;
				}
				b += 1;
			}
			while (b != 0);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0000D9F0 File Offset: 0x0000BBF0
		private uint gf2_matrix_times(uint[] matrix, uint vec)
		{
			uint num = 0U;
			int num2 = 0;
			while (vec != 0U)
			{
				if ((vec & 1U) == 1U)
				{
					num ^= matrix[num2];
				}
				vec >>= 1;
				num2++;
			}
			return num;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0000DA1C File Offset: 0x0000BC1C
		private void gf2_matrix_square(uint[] square, uint[] mat)
		{
			for (int i = 0; i < 32; i++)
			{
				square[i] = this.gf2_matrix_times(mat, mat[i]);
			}
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0000DA44 File Offset: 0x0000BC44
		public void Combine(int crc, int length)
		{
			uint[] array = new uint[32];
			uint[] array2 = new uint[32];
			if (length == 0)
			{
				return;
			}
			uint num = ~this.m_register;
			array2[0] = this.dwPolynomial;
			uint num2 = 1U;
			for (int i = 1; i < 32; i++)
			{
				array2[i] = num2;
				num2 <<= 1;
			}
			this.gf2_matrix_square(array, array2);
			this.gf2_matrix_square(array2, array);
			uint num3 = (uint)length;
			do
			{
				this.gf2_matrix_square(array, array2);
				if ((num3 & 1U) == 1U)
				{
					num = this.gf2_matrix_times(array, num);
				}
				num3 >>= 1;
				if (num3 == 0U)
				{
					break;
				}
				this.gf2_matrix_square(array2, array);
				if ((num3 & 1U) == 1U)
				{
					num = this.gf2_matrix_times(array2, num);
				}
				num3 >>= 1;
			}
			while (num3 != 0U);
			num ^= (uint)crc;
			this.m_register = ~num;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00007FBD File Offset: 0x000061BD
		public CRC32() : this(false)
		{
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00007FC6 File Offset: 0x000061C6
		public CRC32(bool reverseBits) : this(-306674912, reverseBits)
		{
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00007FD4 File Offset: 0x000061D4
		public CRC32(int polynomial, bool reverseBits)
		{
			this.reverseBits = reverseBits;
			this.dwPolynomial = (uint)polynomial;
			this.GenerateLookupTable();
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00007FF7 File Offset: 0x000061F7
		public void Reset()
		{
			this.m_register = uint.MaxValue;
		}

		// Token: 0x04000243 RID: 579
		private readonly uint dwPolynomial;

		// Token: 0x04000244 RID: 580
		private readonly bool reverseBits;

		// Token: 0x04000245 RID: 581
		private uint[] crc32Table;

		// Token: 0x04000246 RID: 582
		private const int BUFFER_SIZE = 8192;

		// Token: 0x04000247 RID: 583
		private uint m_register = uint.MaxValue;
	}
}
