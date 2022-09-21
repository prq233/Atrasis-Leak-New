using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200005F RID: 95
	public class VisitFailedMessage : PiranhaMessage
	{
		// Token: 0x0600044E RID: 1102 RVA: 0x00004880 File Offset: 0x00002A80
		public VisitFailedMessage() : this(0)
		{
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000328C File Offset: 0x0000148C
		public VisitFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00004889 File Offset: 0x00002A89
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x000048A2 File Offset: 0x00002AA2
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x000048BB File Offset: 0x00002ABB
		public override short GetMessageType()
		{
			return 24122;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000048C2 File Offset: 0x00002AC2
		public int GetReason()
		{
			return this.int_0;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000048CA File Offset: 0x00002ACA
		public void SetReason(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040001A5 RID: 421
		public const int MESSAGE_TYPE = 24122;

		// Token: 0x040001A6 RID: 422
		private int int_0;
	}
}
