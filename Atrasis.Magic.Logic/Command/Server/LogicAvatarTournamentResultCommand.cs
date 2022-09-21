using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.League.Entry;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000172 RID: 370
	public class LogicAvatarTournamentResultCommand : LogicServerCommand
	{
		// Token: 0x060015DD RID: 5597 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x000548D4 File Offset: 0x00052AD4
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x0005493C File Offset: 0x00052B3C
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_6);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(this.int_7);
			encoder.WriteInt(this.int_8);
			base.Encode(encoder);
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x000549A4 File Offset: 0x00052BA4
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				LogicAvatarTournamentEntry logicAvatarTournamentEntry;
				if (this.int_8 == 1)
				{
					logicAvatarTournamentEntry = playerAvatar.GetLegendSeasonEntryVillage2();
				}
				else
				{
					if (this.int_8 != 0)
					{
						return -2;
					}
					logicAvatarTournamentEntry = playerAvatar.GetLegendSeasonEntry();
				}
				if (logicAvatarTournamentEntry.GetLastSeasonState() != this.int_2)
				{
					if (this.int_8 == 1)
					{
						playerAvatar.SetDuelScore(playerAvatar.GetDuelScore() - this.int_7);
						playerAvatar.SetLegendaryScore(playerAvatar.GetLegendaryScoreVillage2() + this.int_7);
					}
					else
					{
						playerAvatar.SetScore(playerAvatar.GetScore() - this.int_7);
						playerAvatar.SetLegendaryScore(playerAvatar.GetLegendaryScore() + this.int_7);
					}
					logicAvatarTournamentEntry.SetLastSeasonState(this.int_2);
					logicAvatarTournamentEntry.SetLastSeasonDate(this.int_3, this.int_4);
					logicAvatarTournamentEntry.SetLastSeasonRank(this.int_5);
					logicAvatarTournamentEntry.SetLastSeasonScore(this.int_6);
					bool bestSeason = false;
					if (logicAvatarTournamentEntry.GetBestSeasonState() == 0 || this.int_5 < logicAvatarTournamentEntry.GetBestSeasonRank() || (this.int_5 == logicAvatarTournamentEntry.GetBestSeasonRank() && this.int_6 > logicAvatarTournamentEntry.GetBestSeasonScore()))
					{
						logicAvatarTournamentEntry.SetBestSeasonState(this.int_2);
						logicAvatarTournamentEntry.SetBestSeasonDate(this.int_3, this.int_4);
						logicAvatarTournamentEntry.SetBestSeasonRank(this.int_5);
						logicAvatarTournamentEntry.SetBestSeasonScore(this.int_6);
						bestSeason = true;
					}
					playerAvatar.GetChangeListener().LegendSeasonScoreChanged(this.int_2, this.int_6, this.int_7, bestSeason, this.int_8);
					level.GetGameListener().LegendSeasonScoreChanged(this.int_2, this.int_6, this.int_7, bestSeason, this.int_8);
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x0000E417 File Offset: 0x0000C617
		public void SetDatas(int seasonState, int seasonYear, int seasonMonth, int seasonRank, int seasonScore, int scoreChange, int villageType)
		{
			this.int_2 = seasonState;
			this.int_3 = seasonYear;
			this.int_4 = seasonMonth;
			this.int_5 = seasonRank;
			this.int_6 = seasonScore;
			this.int_7 = scoreChange;
			this.int_8 = villageType;
		}

		// Token: 0x060015E2 RID: 5602 RVA: 0x0000E44E File Offset: 0x0000C64E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.AVATAR_TOURNAMENT_RESULT;
		}

		// Token: 0x04000C66 RID: 3174
		private int int_2;

		// Token: 0x04000C67 RID: 3175
		private int int_3;

		// Token: 0x04000C68 RID: 3176
		private int int_4;

		// Token: 0x04000C69 RID: 3177
		private int int_5;

		// Token: 0x04000C6A RID: 3178
		private int int_6;

		// Token: 0x04000C6B RID: 3179
		private int int_7;

		// Token: 0x04000C6C RID: 3180
		private int int_8;
	}
}
