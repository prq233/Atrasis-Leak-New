using System;
using System.Text;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Titan.DataStream
{
	// Token: 0x02000025 RID: 37
	public class ByteStream : ChecksumEncoder
	{
		// Token: 0x06000119 RID: 281 RVA: 0x00004DD0 File Offset: 0x00002FD0
		public ByteStream(int capacity)
		{
			this.byte_0 = new byte[capacity];
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004DE4 File Offset: 0x00002FE4
		public ByteStream(byte[] buffer, int length)
		{
			this.int_3 = length;
			this.byte_0 = buffer;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00004DFA File Offset: 0x00002FFA
		public int GetLength()
		{
			if (this.int_4 < this.int_3)
			{
				return this.int_3;
			}
			return this.int_4;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00004E17 File Offset: 0x00003017
		public int GetOffset()
		{
			return this.int_4;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00004E1F File Offset: 0x0000301F
		public bool IsAtEnd()
		{
			return this.int_4 >= this.int_3;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00004E32 File Offset: 0x00003032
		public void Clear(int capacity)
		{
			this.byte_0 = new byte[capacity];
			this.int_4 = 0;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004E47 File Offset: 0x00003047
		public byte[] GetByteArray()
		{
			return this.byte_0;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000070C4 File Offset: 0x000052C4
		public bool ReadBoolean()
		{
			if (this.int_2 == 0)
			{
				this.int_4++;
			}
			bool result = ((int)this.byte_0[this.int_4 - 1] & 1 << this.int_2) != 0;
			this.int_2 = (this.int_2 + 1 & 7);
			return result;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00007118 File Offset: 0x00005318
		public byte ReadByte()
		{
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			return array[num];
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00007144 File Offset: 0x00005344
		public short ReadShort()
		{
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			short num2 = array[num] << 8;
			byte[] array2 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			return num2 | array2[num];
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000718C File Offset: 0x0000538C
		public int ReadInt()
		{
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			int num2 = array[num] << 24;
			byte[] array2 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			int num3 = num2 | array2[num] << 16;
			byte[] array3 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			int num4 = num3 | array3[num] << 8;
			byte[] array4 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			return num4 | array4[num];
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000720C File Offset: 0x0000540C
		public int ReadVInt()
		{
			this.int_2 = 0;
			int num = 0;
			byte[] array = this.byte_0;
			int num2 = this.int_4;
			this.int_4 = num2 + 1;
			byte b = array[num2];
			if ((b & 64) == 0)
			{
				num |= (int)(b & 63);
				if ((b & 128) != 0)
				{
					int num3 = num;
					byte[] array2 = this.byte_0;
					num2 = this.int_4;
					this.int_4 = num2 + 1;
					num = (num3 | (int)((b = array2[num2]) & 127) << 6);
					if ((b & 128) != 0)
					{
						int num4 = num;
						byte[] array3 = this.byte_0;
						num2 = this.int_4;
						this.int_4 = num2 + 1;
						num = (num4 | (int)((b = array3[num2]) & 127) << 13);
						if ((b & 128) != 0)
						{
							int num5 = num;
							byte[] array4 = this.byte_0;
							num2 = this.int_4;
							this.int_4 = num2 + 1;
							num = (num5 | (int)((b = array4[num2]) & 127) << 20);
							if ((b & 128) != 0)
							{
								int num6 = num;
								byte[] array5 = this.byte_0;
								num2 = this.int_4;
								this.int_4 = num2 + 1;
								num = (num6 | (array5[num2] & 127) << 27);
							}
						}
					}
				}
				return num;
			}
			num |= (int)(b & 63);
			if ((b & 128) == 0)
			{
				return (int)((long)num | 4294967232L);
			}
			int num7 = num;
			byte[] array6 = this.byte_0;
			num2 = this.int_4;
			this.int_4 = num2 + 1;
			num = (num7 | (int)((b = array6[num2]) & 127) << 6);
			if ((b & 128) == 0)
			{
				return (int)((long)num | 4294959104L);
			}
			int num8 = num;
			byte[] array7 = this.byte_0;
			num2 = this.int_4;
			this.int_4 = num2 + 1;
			num = (num8 | (int)((b = array7[num2]) & 127) << 13);
			if ((b & 128) == 0)
			{
				return (int)((long)num | 4293918720L);
			}
			int num9 = num;
			byte[] array8 = this.byte_0;
			num2 = this.int_4;
			this.int_4 = num2 + 1;
			num = (num9 | (int)((b = array8[num2]) & 127) << 20);
			if ((b & 128) != 0)
			{
				int num10 = num;
				byte[] array9 = this.byte_0;
				num2 = this.int_4;
				this.int_4 = num2 + 1;
				num = (num10 | (array9[num2] & 127) << 27);
				return (int)((long)num | 2147483648L);
			}
			return (int)((long)num | 4160749568L);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004E4F File Offset: 0x0000304F
		public LogicLong ReadLong()
		{
			LogicLong logicLong = new LogicLong();
			logicLong.Decode(this);
			return logicLong;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004E5D File Offset: 0x0000305D
		public LogicLong ReadLong(LogicLong longValue)
		{
			longValue.Decode(this);
			return longValue;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004E67 File Offset: 0x00003067
		public long ReadLongLong()
		{
			return LogicLong.ToLong(this.ReadInt(), this.ReadInt());
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000718C File Offset: 0x0000538C
		public int ReadBytesLength()
		{
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			int num2 = array[num] << 24;
			byte[] array2 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			int num3 = num2 | array2[num] << 16;
			byte[] array3 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			int num4 = num3 | array3[num] << 8;
			byte[] array4 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			return num4 | array4[num];
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007400 File Offset: 0x00005600
		public byte[] ReadBytes(int length, int maxCapacity)
		{
			this.int_2 = 0;
			if (length <= -1)
			{
				if (length != -1)
				{
					Debugger.Warning("Negative readBytes length encountered.");
				}
				return null;
			}
			if (length <= maxCapacity)
			{
				byte[] array = new byte[length];
				Buffer.BlockCopy(this.byte_0, this.int_4, array, 0, length);
				this.int_4 += length;
				return array;
			}
			Debugger.Warning("readBytes too long array, max " + maxCapacity);
			return null;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00007470 File Offset: 0x00005670
		public string ReadString(int maxCapacity)
		{
			int num = this.ReadBytesLength();
			if (num <= -1)
			{
				if (num != -1)
				{
					Debugger.Warning("Negative String length encountered.");
				}
			}
			else
			{
				if (num <= maxCapacity)
				{
					string @string = Encoding.UTF8.GetString(this.byte_0, this.int_4, num);
					this.int_4 += num;
					return @string;
				}
				Debugger.Warning("Too long String encountered, max " + maxCapacity);
			}
			return null;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000074D8 File Offset: 0x000056D8
		public string ReadStringReference(int maxCapacity)
		{
			int num = this.ReadBytesLength();
			if (num <= -1)
			{
				Debugger.Warning("Negative String length encountered.");
			}
			else
			{
				if (num <= maxCapacity)
				{
					string @string = Encoding.UTF8.GetString(this.byte_0, this.int_4, num);
					this.int_4 += num;
					return @string;
				}
				Debugger.Warning("Too long String encountered, max " + maxCapacity);
			}
			return string.Empty;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00007540 File Offset: 0x00005740
		public override void WriteBoolean(bool value)
		{
			base.WriteBoolean(value);
			if (this.int_2 == 0)
			{
				this.EnsureCapacity(1);
				byte[] array = this.byte_0;
				int num = this.int_4;
				this.int_4 = num + 1;
				array[num] = 0;
			}
			if (value)
			{
				byte[] array2 = this.byte_0;
				int num2 = this.int_4 - 1;
				array2[num2] |= (byte)(1 << this.int_2);
			}
			this.int_2 = (this.int_2 + 1 & 7);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000075B4 File Offset: 0x000057B4
		public override void WriteByte(byte value)
		{
			base.WriteByte(value);
			this.EnsureCapacity(1);
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			array[num] = value;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000075F0 File Offset: 0x000057F0
		public override void WriteShort(short value)
		{
			base.WriteShort(value);
			this.EnsureCapacity(2);
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			array[num] = (byte)(value >> 8);
			byte[] array2 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			array2[num] = (byte)value;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00007648 File Offset: 0x00005848
		public override void WriteInt(int value)
		{
			base.WriteInt(value);
			this.EnsureCapacity(4);
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			array[num] = (byte)(value >> 24);
			byte[] array2 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			array2[num] = (byte)(value >> 16);
			byte[] array3 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			array3[num] = (byte)(value >> 8);
			byte[] array4 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			array4[num] = (byte)value;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000076DC File Offset: 0x000058DC
		public override void WriteVInt(int value)
		{
			base.WriteVInt(value);
			this.EnsureCapacity(5);
			this.int_2 = 0;
			if (value >= 0)
			{
				int num;
				if (value < 64)
				{
					byte[] array = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array[num] = (byte)(value & 63);
					return;
				}
				if (value < 8192)
				{
					byte[] array2 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array2[num] = (byte)((value & 63) | 128);
					byte[] array3 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array3[num] = (byte)(value >> 6 & 127);
					return;
				}
				if (value < 1048576)
				{
					byte[] array4 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array4[num] = (byte)((value & 63) | 128);
					byte[] array5 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array5[num] = (byte)((value >> 6 & 127) | 128);
					byte[] array6 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array6[num] = (byte)(value >> 13 & 127);
					return;
				}
				if (value >= 134217728)
				{
					byte[] array7 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array7[num] = (byte)((value & 63) | 128);
					byte[] array8 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array8[num] = (byte)((value >> 6 & 127) | 128);
					byte[] array9 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array9[num] = (byte)((value >> 13 & 127) | 128);
					byte[] array10 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array10[num] = (byte)((value >> 20 & 127) | 128);
					byte[] array11 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array11[num] = (byte)(value >> 27 & 15);
					return;
				}
				byte[] array12 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array12[num] = (byte)((value & 63) | 128);
				byte[] array13 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array13[num] = (byte)((value >> 6 & 127) | 128);
				byte[] array14 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array14[num] = (byte)((value >> 13 & 127) | 128);
				byte[] array15 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array15[num] = (byte)(value >> 20 & 127);
				return;
			}
			else
			{
				int num;
				if (value > -64)
				{
					byte[] array16 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array16[num] = (byte)((value & 63) | 64);
					return;
				}
				if (value > -8192)
				{
					byte[] array17 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array17[num] = (byte)((value & 63) | 192);
					byte[] array18 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array18[num] = (byte)(value >> 6 & 127);
					return;
				}
				if (value > -1048576)
				{
					byte[] array19 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array19[num] = (byte)((value & 63) | 192);
					byte[] array20 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array20[num] = (byte)((value >> 6 & 127) | 128);
					byte[] array21 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array21[num] = (byte)(value >> 13 & 127);
					return;
				}
				if (value <= -134217728)
				{
					byte[] array22 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array22[num] = (byte)((value & 63) | 192);
					byte[] array23 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array23[num] = (byte)((value >> 6 & 127) | 128);
					byte[] array24 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array24[num] = (byte)((value >> 13 & 127) | 128);
					byte[] array25 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array25[num] = (byte)((value >> 20 & 127) | 128);
					byte[] array26 = this.byte_0;
					num = this.int_4;
					this.int_4 = num + 1;
					array26[num] = (byte)(value >> 27 & 15);
					return;
				}
				byte[] array27 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array27[num] = (byte)((value & 63) | 192);
				byte[] array28 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array28[num] = (byte)((value >> 6 & 127) | 128);
				byte[] array29 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array29[num] = (byte)((value >> 13 & 127) | 128);
				byte[] array30 = this.byte_0;
				num = this.int_4;
				this.int_4 = num + 1;
				array30[num] = (byte)(value >> 20 & 127);
				return;
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00007B78 File Offset: 0x00005D78
		public void WriteIntToByteArray(int value)
		{
			this.EnsureCapacity(4);
			this.int_2 = 0;
			byte[] array = this.byte_0;
			int num = this.int_4;
			this.int_4 = num + 1;
			array[num] = (byte)(value >> 24);
			byte[] array2 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			array2[num] = (byte)(value >> 16);
			byte[] array3 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			array3[num] = (byte)(value >> 8);
			byte[] array4 = this.byte_0;
			num = this.int_4;
			this.int_4 = num + 1;
			array4[num] = (byte)value;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004E7A File Offset: 0x0000307A
		public override void WriteLongLong(long value)
		{
			base.WriteLongLong(value);
			this.WriteIntToByteArray((int)(value >> 32));
			this.WriteIntToByteArray((int)value);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00007C04 File Offset: 0x00005E04
		public override void WriteBytes(byte[] value, int length)
		{
			base.WriteBytes(value, length);
			if (value == null)
			{
				this.WriteIntToByteArray(-1);
				return;
			}
			this.EnsureCapacity(length + 4);
			this.WriteIntToByteArray(length);
			Buffer.BlockCopy(value, 0, this.byte_0, this.int_4, length);
			this.int_4 += length;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004E96 File Offset: 0x00003096
		public void WriteBytesWithoutLength(byte[] value, int length)
		{
			base.WriteBytes(value, length);
			if (value != null)
			{
				this.EnsureCapacity(length);
				Buffer.BlockCopy(value, 0, this.byte_0, this.int_4, length);
				this.int_4 += length;
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00007C58 File Offset: 0x00005E58
		public override void WriteString(string value)
		{
			base.WriteString(value);
			if (value == null)
			{
				this.WriteIntToByteArray(-1);
				return;
			}
			byte[] bytes = LogicStringUtil.GetBytes(value);
			int num = bytes.Length;
			if (num <= 900000)
			{
				this.EnsureCapacity(num + 4);
				this.WriteIntToByteArray(num);
				Buffer.BlockCopy(bytes, 0, this.byte_0, this.int_4, num);
				this.int_4 += num;
				return;
			}
			Debugger.Warning("ByteStream::writeString invalid string length " + num);
			this.WriteIntToByteArray(-1);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00007CDC File Offset: 0x00005EDC
		public override void WriteStringReference(string value)
		{
			base.WriteStringReference(value);
			byte[] bytes = LogicStringUtil.GetBytes(value);
			int num = bytes.Length;
			if (num <= 900000)
			{
				this.EnsureCapacity(num + 4);
				this.WriteIntToByteArray(num);
				Buffer.BlockCopy(bytes, 0, this.byte_0, this.int_4, num);
				this.int_4 += num;
				return;
			}
			Debugger.Warning("ByteStream::writeString invalid string length " + num);
			this.WriteIntToByteArray(-1);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00004ECC File Offset: 0x000030CC
		public void SetByteArray(byte[] buffer, int length)
		{
			this.int_4 = 0;
			this.int_2 = 0;
			this.byte_0 = buffer;
			this.int_3 = length;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00004EEA File Offset: 0x000030EA
		public void ResetOffset()
		{
			this.int_4 = 0;
			this.int_2 = 0;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00004EFA File Offset: 0x000030FA
		public void SetOffset(int offset)
		{
			this.int_4 = offset;
			this.int_2 = 0;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00004F0A File Offset: 0x0000310A
		public byte[] RemoveByteArray()
		{
			byte[] result = this.byte_0;
			this.byte_0 = null;
			return result;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00007D54 File Offset: 0x00005F54
		public void EnsureCapacity(int capacity)
		{
			int num = this.byte_0.Length;
			if (this.int_4 + capacity > num)
			{
				byte[] dst = new byte[num + capacity + 100];
				Buffer.BlockCopy(this.byte_0, 0, dst, 0, num);
				this.byte_0 = dst;
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00004F19 File Offset: 0x00003119
		public void Destruct()
		{
			this.byte_0 = null;
			this.int_2 = 0;
			this.int_3 = 0;
			this.int_4 = 0;
		}

		// Token: 0x0400003D RID: 61
		private int int_2;

		// Token: 0x0400003E RID: 62
		private byte[] byte_0;

		// Token: 0x0400003F RID: 63
		private int int_3;

		// Token: 0x04000040 RID: 64
		private int int_4;
	}
}
