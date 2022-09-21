using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Titan.Message
{
	// Token: 0x02000009 RID: 9
	public class PiranhaMessage
	{
		// Token: 0x06000024 RID: 36 RVA: 0x000043A9 File Offset: 0x000025A9
		public PiranhaMessage(short messageVersion)
		{
			this.m_stream = new ByteStream(10);
			this.m_version = (int)messageVersion;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000042C7 File Offset: 0x000024C7
		public virtual void Decode()
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000042C7 File Offset: 0x000024C7
		public virtual void Encode()
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000042C4 File Offset: 0x000024C4
		public virtual short GetMessageType()
		{
			return 0;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000043C5 File Offset: 0x000025C5
		public virtual void Destruct()
		{
			this.m_stream.Destruct();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000043D2 File Offset: 0x000025D2
		public virtual int GetServiceNodeType()
		{
			return -1;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000043D5 File Offset: 0x000025D5
		public int GetMessageVersion()
		{
			return this.m_version;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000043DD File Offset: 0x000025DD
		public void SetMessageVersion(int version)
		{
			this.m_version = version;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000043E6 File Offset: 0x000025E6
		public bool IsServerToClientMessage()
		{
			return this.GetMessageType() >= 20000;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000043F8 File Offset: 0x000025F8
		public byte[] GetMessageBytes()
		{
			return this.m_stream.GetByteArray();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004405 File Offset: 0x00002605
		public int GetEncodingLength()
		{
			return this.m_stream.GetLength();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004412 File Offset: 0x00002612
		public ByteStream GetByteStream()
		{
			return this.m_stream;
		}

		// Token: 0x04000008 RID: 8
		protected ByteStream m_stream;

		// Token: 0x04000009 RID: 9
		protected int m_version;
	}
}
