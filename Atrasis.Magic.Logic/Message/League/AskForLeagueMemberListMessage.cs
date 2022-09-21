using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.League
{
	// Token: 0x0200003C RID: 60
	public class AskForLeagueMemberListMessage : PiranhaMessage
	{
		// Token: 0x060002CA RID: 714 RVA: 0x00003B07 File Offset: 0x00001D07
		public AskForLeagueMemberListMessage() : this(0)
		{
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForLeagueMemberListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00003B10 File Offset: 0x00001D10
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00003B36 File Offset: 0x00001D36
		public override void Encode()
		{
			base.Encode();
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00003B70 File Offset: 0x00001D70
		public override short GetMessageType()
		{
			return 14503;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00003B77 File Offset: 0x00001D77
		public override int GetServiceNodeType()
		{
			return 13;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00003B7B File Offset: 0x00001D7B
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00003B8A File Offset: 0x00001D8A
		public LogicLong GetLeagueInstanceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00003B92 File Offset: 0x00001D92
		public void SetLeagueInstanceId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x04000113 RID: 275
		public const int MESSAGE_TYPE = 14503;

		// Token: 0x04000114 RID: 276
		private LogicLong logicLong_0;
	}
}
