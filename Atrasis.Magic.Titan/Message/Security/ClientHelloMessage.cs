using System;

namespace Atrasis.Magic.Titan.Message.Security
{
	// Token: 0x0200000D RID: 13
	public class ClientHelloMessage : PiranhaMessage
	{
		// Token: 0x06000048 RID: 72 RVA: 0x000044F1 File Offset: 0x000026F1
		public ClientHelloMessage() : this(0)
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000044FA File Offset: 0x000026FA
		public ClientHelloMessage(short messageVersion) : base(messageVersion)
		{
			this.string_0 = string.Empty;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00005B14 File Offset: 0x00003D14
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			this.m_stream.WriteStringReference(this.string_0);
			this.m_stream.WriteInt(this.int_5);
			this.m_stream.WriteInt(this.int_6);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005BB0 File Offset: 0x00003DB0
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			this.string_0 = this.m_stream.ReadStringReference(900000);
			this.int_5 = this.m_stream.ReadInt();
			this.int_6 = this.m_stream.ReadInt();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000450E File Offset: 0x0000270E
		public override short GetMessageType()
		{
			return 10100;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000044E6 File Offset: 0x000026E6
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004515 File Offset: 0x00002715
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004524 File Offset: 0x00002724
		public int GetProtocol()
		{
			return this.int_0;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000452C File Offset: 0x0000272C
		public void SetProtocol(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004535 File Offset: 0x00002735
		public int GetKeyVersion()
		{
			return this.int_1;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000453D File Offset: 0x0000273D
		public void SetKeyVersion(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004546 File Offset: 0x00002746
		public int GetMajorVersion()
		{
			return this.int_2;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000454E File Offset: 0x0000274E
		public void SetMajorVersion(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004557 File Offset: 0x00002757
		public int GetMinorVersion()
		{
			return this.int_3;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000455F File Offset: 0x0000275F
		public void SetMinorVersion(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004568 File Offset: 0x00002768
		public int GetBuildVersion()
		{
			return this.int_4;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004570 File Offset: 0x00002770
		public void SetBuildVersion(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004579 File Offset: 0x00002779
		public string GetContentHash()
		{
			return this.string_0;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004581 File Offset: 0x00002781
		public void SetContentHash(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000458A File Offset: 0x0000278A
		public int GetDeviceType()
		{
			return this.int_5;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004592 File Offset: 0x00002792
		public void SetDeviceType(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000459B File Offset: 0x0000279B
		public int GetAppStore()
		{
			return this.int_6;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000045A3 File Offset: 0x000027A3
		public void SetAppStore(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x04000010 RID: 16
		public const int MESSAGE_TYPE = 10100;

		// Token: 0x04000011 RID: 17
		private int int_0;

		// Token: 0x04000012 RID: 18
		private int int_1;

		// Token: 0x04000013 RID: 19
		private int int_2;

		// Token: 0x04000014 RID: 20
		private int int_3;

		// Token: 0x04000015 RID: 21
		private int int_4;

		// Token: 0x04000016 RID: 22
		private int int_5;

		// Token: 0x04000017 RID: 23
		private int int_6;

		// Token: 0x04000018 RID: 24
		private string string_0;
	}
}
