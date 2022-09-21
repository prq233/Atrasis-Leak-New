using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000051 RID: 81
	public class HomeBattleReplayMessage : PiranhaMessage
	{
		// Token: 0x060003A7 RID: 935 RVA: 0x0000431F File Offset: 0x0000251F
		public HomeBattleReplayMessage() : this(0)
		{
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000328C File Offset: 0x0000148C
		public HomeBattleReplayMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00004328 File Offset: 0x00002528
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00004352 File Offset: 0x00002552
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000437C File Offset: 0x0000257C
		public int GetReplayShardId()
		{
			return this.int_0;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00004384 File Offset: 0x00002584
		public void SetReplayShardId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000438D File Offset: 0x0000258D
		public LogicLong GetReplayId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00004395 File Offset: 0x00002595
		public void SetReplayId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000439E File Offset: 0x0000259E
		public override short GetMessageType()
		{
			return 14114;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400016C RID: 364
		public const int MESSAGE_TYPE = 14114;

		// Token: 0x0400016D RID: 365
		private int int_0;

		// Token: 0x0400016E RID: 366
		private LogicLong logicLong_0;
	}
}
