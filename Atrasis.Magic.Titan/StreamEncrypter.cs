using System;

namespace Atrasis.Magic.Titan
{
	// Token: 0x02000004 RID: 4
	public class StreamEncrypter
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000042C4 File Offset: 0x000024C4
		public virtual int Decrypt(byte[] input, byte[] output, int length)
		{
			return 0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000042C4 File Offset: 0x000024C4
		public virtual int Encrypt(byte[] input, byte[] output, int length)
		{
			return 0;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000042C4 File Offset: 0x000024C4
		public virtual int GetOverheadEncryption()
		{
			return 0;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000042C7 File Offset: 0x000024C7
		public virtual void Destruct()
		{
		}
	}
}
