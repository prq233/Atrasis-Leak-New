using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200005A RID: 90
	public class ScoutFriendlyBattleMessage : PiranhaMessage
	{
		// Token: 0x06000415 RID: 1045 RVA: 0x00004699 File Offset: 0x00002899
		public ScoutFriendlyBattleMessage() : this(0)
		{
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000328C File Offset: 0x0000148C
		public ScoutFriendlyBattleMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000046A2 File Offset: 0x000028A2
		public override void Decode()
		{
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000046B5 File Offset: 0x000028B5
		public override void Encode()
		{
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000046C8 File Offset: 0x000028C8
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000046D0 File Offset: 0x000028D0
		public void SetStreamId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000046D9 File Offset: 0x000028D9
		public override short GetMessageType()
		{
			return 14111;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000195 RID: 405
		public const int MESSAGE_TYPE = 14111;

		// Token: 0x04000196 RID: 406
		private LogicLong logicLong_0;
	}
}
