using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200003A RID: 58
	public class AvatarRankingListMessage : PiranhaMessage
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x000039C9 File Offset: 0x00001BC9
		public AvatarRankingListMessage() : this(0)
		{
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0001B8F0 File Offset: 0x00019AF0
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
			int num2 = this.m_stream.ReadInt();
			if (num2 > -1)
			{
				this.logicArrayList_1 = new LogicArrayList<AvatarRankingEntry>(num2);
				for (int j = 0; j < num2; j++)
				{
					AvatarRankingEntry avatarRankingEntry2 = new AvatarRankingEntry();
					avatarRankingEntry2.Decode(this.m_stream);
					this.logicArrayList_1.Add(avatarRankingEntry2);
				}
			}
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0001B9EC File Offset: 0x00019BEC
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
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			if (this.logicArrayList_1 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_1.Size());
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					this.logicArrayList_1[j].Encode(this.m_stream);
				}
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000039D2 File Offset: 0x00001BD2
		public override short GetMessageType()
		{
			return 24403;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000329C File Offset: 0x0000149C
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000039D9 File Offset: 0x00001BD9
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
			this.logicArrayList_1 = null;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000039EF File Offset: 0x00001BEF
		public LogicArrayList<AvatarRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x000039FE File Offset: 0x00001BFE
		public LogicArrayList<AvatarRankingEntry> RemoveLastSeasonAvatarRankingList()
		{
			LogicArrayList<AvatarRankingEntry> result = this.logicArrayList_1;
			this.logicArrayList_1 = null;
			return result;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00003A0D File Offset: 0x00001C0D
		public void SetAvatarRankingList(LogicArrayList<AvatarRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00003A16 File Offset: 0x00001C16
		public void SetLastSeasonAvatarRankingList(LogicArrayList<AvatarRankingEntry> list)
		{
			this.logicArrayList_1 = list;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00003A1F File Offset: 0x00001C1F
		public int GetNextEndTimeSeconds()
		{
			return this.int_0;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00003A27 File Offset: 0x00001C27
		public void SetNextEndTimeSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00003A30 File Offset: 0x00001C30
		public int GetSeasonYear()
		{
			return this.int_1;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00003A38 File Offset: 0x00001C38
		public void SetSeasonYear(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00003A41 File Offset: 0x00001C41
		public int GetSeasonMonth()
		{
			return this.int_2;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00003A49 File Offset: 0x00001C49
		public void SetSeasonMonth(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00003A52 File Offset: 0x00001C52
		public int GetLastSeasonYear()
		{
			return this.int_3;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00003A5A File Offset: 0x00001C5A
		public void SetLastSeasonYear(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00003A63 File Offset: 0x00001C63
		public int GetLastSeasonMonth()
		{
			return this.int_4;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00003A6B File Offset: 0x00001C6B
		public void SetLastSeasonMonth(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x04000101 RID: 257
		public const int MESSAGE_TYPE = 24403;

		// Token: 0x04000102 RID: 258
		private int int_0;

		// Token: 0x04000103 RID: 259
		private int int_1;

		// Token: 0x04000104 RID: 260
		private int int_2;

		// Token: 0x04000105 RID: 261
		private int int_3;

		// Token: 0x04000106 RID: 262
		private int int_4;

		// Token: 0x04000107 RID: 263
		private LogicArrayList<AvatarRankingEntry> logicArrayList_0;

		// Token: 0x04000108 RID: 264
		private LogicArrayList<AvatarRankingEntry> logicArrayList_1;
	}
}
