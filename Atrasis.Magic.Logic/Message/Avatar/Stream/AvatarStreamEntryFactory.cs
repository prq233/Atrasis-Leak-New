using System;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000096 RID: 150
	public class AvatarStreamEntryFactory
	{
		// Token: 0x06000670 RID: 1648 RVA: 0x0001E6CC File Offset: 0x0001C8CC
		public static AvatarStreamEntry CreateStreamEntryByType(AvatarStreamEntryType type)
		{
			switch (type)
			{
			case AvatarStreamEntryType.DEFENDER_BATTLE_REPORT:
				return new BattleReportStreamEntry(AvatarStreamEntryType.DEFENDER_BATTLE_REPORT);
			case AvatarStreamEntryType.JOIN_ALLIANCE_RESPONSE:
				return new JoinAllianceResponseAvatarStreamEntry();
			case AvatarStreamEntryType.ALLIANCE_INVITATION:
				return new AllianceInvitationAvatarStreamEntry();
			case AvatarStreamEntryType.ALLIANCE_KICKOUT:
				return new AllianceKickOutStreamEntry();
			case AvatarStreamEntryType.ALLIANCE_MAIL:
				return new AllianceMailAvatarStreamEntry();
			case AvatarStreamEntryType.ATTACKER_BATTLE_REPORT:
				return new BattleReportStreamEntry(AvatarStreamEntryType.ATTACKER_BATTLE_REPORT);
			case AvatarStreamEntryType.ADMIN_MESSAGE:
				return new AdminMessageAvatarStreamEntry();
			}
			return null;
		}
	}
}
