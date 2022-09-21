using System;

namespace Atrasis.Magic.Titan
{
	// Token: 0x02000003 RID: 3
	public class RC4Encrypter : StreamEncrypter
	{
		// Token: 0x06000002 RID: 2 RVA: 0x0000428C File Offset: 0x0000248C
		public RC4Encrypter(string baseKey, string nonce)
		{
			this.InitState(baseKey, nonce);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000429C File Offset: 0x0000249C
		public override void Destruct()
		{
			base.Destruct();
			this.byte_0 = null;
			this.byte_1 = 0;
			this.byte_2 = 0;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000535C File Offset: 0x0000355C
		public void InitState(string baseKey, string nonce)
		{
			string text = baseKey + nonce;
			this.byte_0 = new byte[256];
			this.byte_1 = 0;
			this.byte_2 = 0;
			for (int i = 0; i < 256; i++)
			{
				this.byte_0[i] = (byte)i;
			}
			int j = 0;
			int num = 0;
			while (j < 256)
			{
				num = (int)((byte)(num + (int)this.byte_0[j] + (int)text[j % text.Length]));
				byte b = this.byte_0[j];
				this.byte_0[j] = this.byte_0[num];
				this.byte_0[num] = b;
				j++;
			}
			for (int k = 0; k < text.Length; k++)
			{
				this.byte_1 += 1;
				this.byte_2 += this.byte_0[(int)this.byte_1];
				byte b2 = this.byte_0[(int)this.byte_2];
				this.byte_0[(int)this.byte_2] = this.byte_0[(int)this.byte_1];
				this.byte_0[(int)this.byte_1] = b2;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000042B9 File Offset: 0x000024B9
		public override int Decrypt(byte[] input, byte[] output, int length)
		{
			return this.Encrypt(input, output, length);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00005474 File Offset: 0x00003674
		public override int Encrypt(byte[] input, byte[] output, int length)
		{
			for (int i = 0; i < length; i++)
			{
				this.byte_1 += 1;
				this.byte_2 += this.byte_0[(int)this.byte_1];
				byte b = this.byte_0[(int)this.byte_2];
				this.byte_0[(int)this.byte_2] = this.byte_0[(int)this.byte_1];
				this.byte_0[(int)this.byte_1] = b;
				output[i] = (input[i] ^ this.byte_0[(int)(this.byte_0[(int)this.byte_1] + this.byte_0[(int)this.byte_2])]);
			}
			return 0;
		}

		// Token: 0x04000001 RID: 1
		private byte[] byte_0;

		// Token: 0x04000002 RID: 2
		private byte byte_1;

		// Token: 0x04000003 RID: 3
		private byte byte_2;
	}
}
