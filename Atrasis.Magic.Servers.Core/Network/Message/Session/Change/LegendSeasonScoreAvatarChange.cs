using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.League.Entry;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006A RID: 106
	public class LegendSeasonScoreAvatarChange : AvatarChange
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00006256 File Offset: 0x00004456
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x0000625E File Offset: 0x0000445E
		public LogicAvatarTournamentEntry Entry { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00006267 File Offset: 0x00004467
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x0000626F File Offset: 0x0000446F
		public int ScoreChange { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00006278 File Offset: 0x00004478
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00006280 File Offset: 0x00004480
		public bool BestSeason { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00006289 File Offset: 0x00004489
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00006291 File Offset: 0x00004491
		public int VillageType { get; set; }

		// Token: 0x060002E8 RID: 744 RVA: 0x0000629A File Offset: 0x0000449A
		public override void Decode(ByteStream stream)
		{
			this.Entry = new LogicAvatarTournamentEntry();
			this.Entry.Decode(stream);
			this.ScoreChange = stream.ReadVInt();
			this.BestSeason = stream.ReadBoolean();
			this.VillageType = stream.ReadVInt();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x000062D7 File Offset: 0x000044D7
		public override void Encode(ByteStream stream)
		{
			this.Entry.Encode(stream);
			stream.WriteVInt(this.ScoreChange);
			stream.WriteBoolean(this.BestSeason);
			stream.WriteVInt(this.VillageType);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000C6EC File Offset: 0x0000A8EC
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			LogicAvatarTournamentEntry logicAvatarTournamentEntry = (this.VillageType == 1) ? avatar.GetLegendSeasonEntryVillage2() : avatar.GetLegendSeasonEntry();
			if (logicAvatarTournamentEntry.GetLastSeasonState() != this.Entry.GetLastSeasonState())
			{
				if (this.VillageType == 1)
				{
					avatar.SetDuelScore(avatar.GetDuelScore() - this.ScoreChange);
					avatar.SetLegendaryScore(avatar.GetLegendaryScoreVillage2() + this.ScoreChange);
				}
				else
				{
					avatar.SetScore(avatar.GetScore() - this.ScoreChange);
					avatar.SetLegendaryScore(avatar.GetLegendaryScore() + this.ScoreChange);
				}
				logicAvatarTournamentEntry.SetLastSeasonState(this.Entry.GetLastSeasonState());
				logicAvatarTournamentEntry.SetLastSeasonDate(this.Entry.GetLastSeasonYear(), this.Entry.GetLastSeasonMonth());
				logicAvatarTournamentEntry.SetLastSeasonRank(this.Entry.GetLastSeasonRank());
				logicAvatarTournamentEntry.SetLastSeasonScore(this.Entry.GetLastSeasonScore());
				if (this.BestSeason)
				{
					logicAvatarTournamentEntry.SetBestSeasonState(this.Entry.GetBestSeasonState());
					logicAvatarTournamentEntry.SetBestSeasonDate(this.Entry.GetBestSeasonYear(), this.Entry.GetBestSeasonMonth());
					logicAvatarTournamentEntry.SetBestSeasonRank(this.Entry.GetBestSeasonRank());
					logicAvatarTournamentEntry.SetBestSeasonScore(this.Entry.GetBestSeasonScore());
				}
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00006309 File Offset: 0x00004509
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			if (this.VillageType == 1)
			{
				memberEntry.SetDuelScore(memberEntry.GetDuelScore() - this.ScoreChange);
				return;
			}
			memberEntry.SetScore(memberEntry.GetScore() - this.ScoreChange);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000633B File Offset: 0x0000453B
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.LEGEND_SEASON_SCORE;
		}

		// Token: 0x04000169 RID: 361
		[CompilerGenerated]
		private LogicAvatarTournamentEntry logicAvatarTournamentEntry_0;

		// Token: 0x0400016A RID: 362
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400016B RID: 363
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400016C RID: 364
		[CompilerGenerated]
		private int int_1;
	}
}
