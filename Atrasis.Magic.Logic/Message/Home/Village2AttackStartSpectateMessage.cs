using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200005D RID: 93
	public class Village2AttackStartSpectateMessage : PiranhaMessage
	{
		// Token: 0x06000432 RID: 1074 RVA: 0x0000477D File Offset: 0x0000297D
		public Village2AttackStartSpectateMessage() : this(0)
		{
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000328C File Offset: 0x0000148C
		public Village2AttackStartSpectateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00004786 File Offset: 0x00002986
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000479F File Offset: 0x0000299F
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000047B8 File Offset: 0x000029B8
		public override short GetMessageType()
		{
			return 15110;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x000047BF File Offset: 0x000029BF
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000047CE File Offset: 0x000029CE
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000047D6 File Offset: 0x000029D6
		public void SetStreamId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0400019C RID: 412
		public const int MESSAGE_TYPE = 15110;

		// Token: 0x0400019D RID: 413
		private LogicLong logicLong_0;
	}
}
