using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Titan.DataStream
{
	// Token: 0x02000026 RID: 38
	public class ChecksumEncoder
	{
		// Token: 0x0600013D RID: 317 RVA: 0x00004F37 File Offset: 0x00003137
		public ChecksumEncoder()
		{
			this.bool_0 = true;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00007D98 File Offset: 0x00005F98
		public void EnableCheckSum(bool enable)
		{
			if (!this.bool_0 || enable)
			{
				if (!this.bool_0 && enable)
				{
					this.int_0 = this.int_1;
				}
				this.bool_0 = enable;
				return;
			}
			this.int_1 = this.int_0;
			this.bool_0 = false;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00004F46 File Offset: 0x00003146
		public void ResetCheckSum()
		{
			this.int_0 = 0;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004F4F File Offset: 0x0000314F
		public virtual void WriteBoolean(bool value)
		{
			this.int_0 = (value ? 13 : 7) + this.method_0(this.int_0, 31);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00004F6E File Offset: 0x0000316E
		public virtual void WriteByte(byte value)
		{
			this.int_0 = (int)value + this.method_0(this.int_0, 31) + 11;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00004F89 File Offset: 0x00003189
		public virtual void WriteShort(short value)
		{
			this.int_0 = (int)value + this.method_0(this.int_0, 31) + 19;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004FA4 File Offset: 0x000031A4
		public virtual void WriteInt(int value)
		{
			this.int_0 = value + this.method_0(this.int_0, 31) + 9;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004FBF File Offset: 0x000031BF
		public virtual void WriteVInt(int value)
		{
			this.int_0 = value + this.method_0(this.int_0, 31) + 33;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004FDA File Offset: 0x000031DA
		public virtual void WriteLong(LogicLong value)
		{
			value.Encode(this);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00007DE8 File Offset: 0x00005FE8
		public virtual void WriteLongLong(long value)
		{
			int num = (int)(value >> 32);
			int num2 = (int)value;
			this.int_0 = num + this.method_0(num2 + this.method_0(this.int_0, 31) + 67, 31) + 91;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004FE3 File Offset: 0x000031E3
		public virtual void WriteBytes(byte[] value, int length)
		{
			this.int_0 = (((value != null) ? (length + 28) : 27) + (this.int_0 >> 31) | this.int_0 << 1);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005009 File Offset: 0x00003209
		public virtual void WriteString(string value)
		{
			this.int_0 = ((value != null) ? (value.Length + 28) : 27) + this.method_0(this.int_0, 31);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005030 File Offset: 0x00003230
		public virtual void WriteStringReference(string value)
		{
			this.int_0 = value.Length + this.method_0(this.int_0, 31) + 38;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005050 File Offset: 0x00003250
		public bool IsCheckSumEnabled()
		{
			return this.bool_0;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000044E6 File Offset: 0x000026E6
		public virtual bool IsCheckSumOnlyMode()
		{
			return true;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00007E24 File Offset: 0x00006024
		public bool Equals(ChecksumEncoder encoder)
		{
			if (encoder != null)
			{
				int num = encoder.int_0;
				int num2 = this.int_0;
				if (!encoder.bool_0)
				{
					num = encoder.int_1;
				}
				if (!this.bool_0)
				{
					num2 = this.int_1;
				}
				return num == num2;
			}
			return false;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005058 File Offset: 0x00003258
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int method_0(int int_2, int int_3)
		{
			return int_2 >> int_3 | int_2 << 32 - int_3;
		}

		// Token: 0x04000041 RID: 65
		private int int_0;

		// Token: 0x04000042 RID: 66
		private int int_1;

		// Token: 0x04000043 RID: 67
		private bool bool_0;
	}
}
