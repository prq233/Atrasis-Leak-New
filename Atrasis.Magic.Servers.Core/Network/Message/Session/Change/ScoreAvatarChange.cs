using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006D RID: 109
	public class ScoreAvatarChange : AvatarChange
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000640C File Offset: 0x0000460C
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00006414 File Offset: 0x00004614
		public int ScoreGain { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000641D File Offset: 0x0000461D
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00006425 File Offset: 0x00004625
		public bool Attacker { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0000642E File Offset: 0x0000462E
		// (set) Token: 0x06000305 RID: 773 RVA: 0x00006436 File Offset: 0x00004636
		public LogicLeagueData PrevLeagueData { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000306 RID: 774 RVA: 0x0000643F File Offset: 0x0000463F
		// (set) Token: 0x06000307 RID: 775 RVA: 0x00006447 File Offset: 0x00004647
		public LogicLeagueData LeagueData { get; set; }

		// Token: 0x06000308 RID: 776 RVA: 0x00006450 File Offset: 0x00004650
		public override void Decode(ByteStream stream)
		{
			this.ScoreGain = stream.ReadVInt();
			this.Attacker = stream.ReadBoolean();
			this.PrevLeagueData = (LogicLeagueData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.LEAGUE);
			this.LeagueData = (LogicLeagueData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.LEAGUE);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00006490 File Offset: 0x00004690
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ScoreGain);
			stream.WriteBoolean(this.Attacker);
			ByteStreamHelper.WriteDataReference(stream, this.PrevLeagueData);
			ByteStreamHelper.WriteDataReference(stream, this.LeagueData);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000C824 File Offset: 0x0000AA24
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetScore(LogicMath.Max(avatar.GetScore() + this.ScoreGain, 0));
			avatar.SetLeagueType(this.LeagueData.GetInstanceID());
			if (this.PrevLeagueData != null)
			{
				if (this.Attacker)
				{
					if (this.ScoreGain < 0)
					{
						avatar.SetAttackLoseCount(avatar.GetAttackLoseCount() + 1);
						return;
					}
					avatar.SetAttackWinCount(avatar.GetAttackWinCount() + 1);
					return;
				}
				else
				{
					if (this.ScoreGain < 0)
					{
						avatar.SetDefenseLoseCount(avatar.GetDefenseLoseCount() + 1);
						return;
					}
					avatar.SetDefenseWinCount(avatar.GetDefenseWinCount() + 1);
				}
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000064C2 File Offset: 0x000046C2
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetScore(LogicMath.Max(memberEntry.GetScore() + this.ScoreGain, 0));
			memberEntry.SetLeagueType(this.LeagueData.GetInstanceID());
		}

		// Token: 0x0600030C RID: 780 RVA: 0x000064EE File Offset: 0x000046EE
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.SCORE;
		}

		// Token: 0x04000170 RID: 368
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000171 RID: 369
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000172 RID: 370
		[CompilerGenerated]
		private LogicLeagueData logicLeagueData_0;

		// Token: 0x04000173 RID: 371
		[CompilerGenerated]
		private LogicLeagueData logicLeagueData_1;
	}
}
