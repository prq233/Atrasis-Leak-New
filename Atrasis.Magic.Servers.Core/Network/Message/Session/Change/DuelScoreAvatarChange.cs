using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000066 RID: 102
	public class DuelScoreAvatarChange : AvatarChange
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000609C File Offset: 0x0000429C
		// (set) Token: 0x060002BB RID: 699 RVA: 0x000060A4 File Offset: 0x000042A4
		public int DuelScoreGain { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002BC RID: 700 RVA: 0x000060AD File Offset: 0x000042AD
		// (set) Token: 0x060002BD RID: 701 RVA: 0x000060B5 File Offset: 0x000042B5
		public int ResultType { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002BE RID: 702 RVA: 0x000060BE File Offset: 0x000042BE
		// (set) Token: 0x060002BF RID: 703 RVA: 0x000060C6 File Offset: 0x000042C6
		public bool Attacker { get; set; }

		// Token: 0x060002C0 RID: 704 RVA: 0x000060CF File Offset: 0x000042CF
		public override void Decode(ByteStream stream)
		{
			this.DuelScoreGain = stream.ReadVInt();
			this.ResultType = stream.ReadVInt();
			this.Attacker = stream.ReadBoolean();
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000060F5 File Offset: 0x000042F5
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.DuelScoreGain);
			stream.WriteVInt(this.ResultType);
			stream.WriteBoolean(this.Attacker);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000C630 File Offset: 0x0000A830
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetDuelScore(avatar.GetDuelScore() + this.DuelScoreGain);
			switch (this.ResultType)
			{
			case 0:
				avatar.SetDuelLoseCount(avatar.GetDuelLoseCount() + 1);
				return;
			case 1:
				avatar.SetDuelWinCount(avatar.GetDuelWinCount() + 1);
				return;
			case 2:
				avatar.SetDuelDrawCount(avatar.GetDuelDrawCount() + 1);
				return;
			default:
				return;
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000611B File Offset: 0x0000431B
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetDuelScore(memberEntry.GetDuelScore() + this.DuelScoreGain);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00006130 File Offset: 0x00004330
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.DUEL_SCORE;
		}

		// Token: 0x04000162 RID: 354
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000163 RID: 355
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04000164 RID: 356
		[CompilerGenerated]
		private bool bool_0;
	}
}
