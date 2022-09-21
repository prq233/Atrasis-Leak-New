using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.League
{
	// Token: 0x0200003E RID: 62
	public class LeagueMemberListMessage : PiranhaMessage
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x00003C98 File Offset: 0x00001E98
		public LeagueMemberListMessage() : this(0)
		{
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000328C File Offset: 0x0000148C
		public LeagueMemberListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0001BE54 File Offset: 0x0001A054
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			int num = this.m_stream.ReadInt();
			if (num > -1)
			{
				this.logicArrayList_0 = new LogicArrayList<LeagueMemberEntry>(num);
				for (int i = 0; i < num; i++)
				{
					LeagueMemberEntry leagueMemberEntry = new LeagueMemberEntry();
					leagueMemberEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(leagueMemberEntry);
				}
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0001BEC0 File Offset: 0x0001A0C0
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00003CA1 File Offset: 0x00001EA1
		public override short GetMessageType()
		{
			return 24503;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00003B77 File Offset: 0x00001D77
		public override int GetServiceNodeType()
		{
			return 13;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00003CA8 File Offset: 0x00001EA8
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00003CB7 File Offset: 0x00001EB7
		public LogicArrayList<LeagueMemberEntry> GetMemberList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00003CBF File Offset: 0x00001EBF
		public void SetMemberList(LogicArrayList<LeagueMemberEntry> entry)
		{
			this.logicArrayList_0 = entry;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public int GetRemainingSeasonTime()
		{
			return this.int_0;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00003CD0 File Offset: 0x00001ED0
		public void SetRemainingSeasonTime(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000123 RID: 291
		public const int MESSAGE_TYPE = 24503;

		// Token: 0x04000124 RID: 292
		private int int_0;

		// Token: 0x04000125 RID: 293
		private LogicArrayList<LeagueMemberEntry> logicArrayList_0;
	}
}
