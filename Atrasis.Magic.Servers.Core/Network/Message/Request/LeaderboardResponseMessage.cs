using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000084 RID: 132
	public class LeaderboardResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00006B43 File Offset: 0x00004D43
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00006B4B File Offset: 0x00004D4B
		public LogicArrayList<AvatarRankingEntry> MainLeaderboard { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00006B54 File Offset: 0x00004D54
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00006B5C File Offset: 0x00004D5C
		public LogicArrayList<AvatarDuelRankingEntry> SecondaryLeaderboard { get; set; }

		// Token: 0x060003BA RID: 954 RVA: 0x0000CC30 File Offset: 0x0000AE30
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt(this.MainLeaderboard.Size());
				for (int i = 0; i < this.MainLeaderboard.Size(); i++)
				{
					this.MainLeaderboard[i].Encode(stream);
				}
				stream.WriteVInt(this.SecondaryLeaderboard.Size());
				for (int j = 0; j < this.SecondaryLeaderboard.Size(); j++)
				{
					this.SecondaryLeaderboard[j].Encode(stream);
				}
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000CCB8 File Offset: 0x0000AEB8
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.MainLeaderboard = new LogicArrayList<AvatarRankingEntry>();
				this.SecondaryLeaderboard = new LogicArrayList<AvatarDuelRankingEntry>();
				for (int i = stream.ReadVInt(); i > 0; i--)
				{
					AvatarRankingEntry avatarRankingEntry = new AvatarRankingEntry();
					avatarRankingEntry.Decode(stream);
					this.MainLeaderboard.Add(avatarRankingEntry);
				}
				for (int j = stream.ReadVInt(); j > 0; j--)
				{
					AvatarDuelRankingEntry avatarDuelRankingEntry = new AvatarDuelRankingEntry();
					avatarDuelRankingEntry.Decode(stream);
					this.SecondaryLeaderboard.Add(avatarDuelRankingEntry);
				}
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00006B65 File Offset: 0x00004D65
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LEADERBOARD_RESPONSE;
		}

		// Token: 0x040001BB RID: 443
		[CompilerGenerated]
		private LogicArrayList<AvatarRankingEntry> logicArrayList_0;

		// Token: 0x040001BC RID: 444
		[CompilerGenerated]
		private LogicArrayList<AvatarDuelRankingEntry> logicArrayList_1;
	}
}
