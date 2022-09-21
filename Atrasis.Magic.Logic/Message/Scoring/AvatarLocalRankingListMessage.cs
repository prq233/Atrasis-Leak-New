using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000038 RID: 56
	public class AvatarLocalRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000282 RID: 642 RVA: 0x000038C8 File Offset: 0x00001AC8
		public AvatarLocalRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarLocalRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0001B47C File Offset: 0x0001967C
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num > -1)
			{
				this.logicArrayList_0 = new LogicArrayList<AvatarRankingEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AvatarRankingEntry avatarRankingEntry = new AvatarRankingEntry();
					avatarRankingEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(avatarRankingEntry);
				}
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001B4D8 File Offset: 0x000196D8
		public override void Encode()
		{
			base.Encode();
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

		// Token: 0x06000286 RID: 646 RVA: 0x000038D1 File Offset: 0x00001AD1
		public override short GetMessageType()
		{
			return 24404;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000038D8 File Offset: 0x00001AD8
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000038E7 File Offset: 0x00001AE7
		public LogicArrayList<AvatarRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000038F6 File Offset: 0x00001AF6
		public void SetAvatarRankingList(LogicArrayList<AvatarRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x040000EA RID: 234
		public const int MESSAGE_TYPE = 24404;

		// Token: 0x040000EB RID: 235
		private LogicArrayList<AvatarRankingEntry> logicArrayList_0;
	}
}
