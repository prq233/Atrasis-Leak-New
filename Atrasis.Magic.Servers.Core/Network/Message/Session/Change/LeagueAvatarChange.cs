using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000069 RID: 105
	public class LeagueAvatarChange : AvatarChange
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x000061CF File Offset: 0x000043CF
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x000061D7 File Offset: 0x000043D7
		public int LeagueType { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x000061E0 File Offset: 0x000043E0
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x000061E8 File Offset: 0x000043E8
		public LogicLong LeagueInstanceId { get; set; }

		// Token: 0x060002DA RID: 730 RVA: 0x000061F1 File Offset: 0x000043F1
		public override void Decode(ByteStream stream)
		{
			this.LeagueType = stream.ReadVInt();
			if (stream.ReadBoolean())
			{
				this.LeagueInstanceId = stream.ReadLong();
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00006213 File Offset: 0x00004413
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.LeagueType);
			if (this.LeagueInstanceId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.LeagueInstanceId);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000C698 File Offset: 0x0000A898
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetLeagueType(this.LeagueType);
			if (this.LeagueType != 0)
			{
				avatar.SetLeagueInstanceId(this.LeagueInstanceId);
				return;
			}
			avatar.SetLeagueInstanceId(null);
			avatar.SetAttackWinCount(0);
			avatar.SetAttackLoseCount(0);
			avatar.SetDefenseWinCount(0);
			avatar.SetDefenseLoseCount(0);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00006244 File Offset: 0x00004444
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetLeagueType(this.LeagueType);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00006252 File Offset: 0x00004452
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.LEAGUE;
		}

		// Token: 0x04000167 RID: 359
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000168 RID: 360
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
