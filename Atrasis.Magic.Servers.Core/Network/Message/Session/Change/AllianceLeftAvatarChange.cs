using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000059 RID: 89
	public class AllianceLeftAvatarChange : AvatarChange
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00005D17 File Offset: 0x00003F17
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceId(null);
			avatar.SetAllianceName(string.Empty);
			avatar.SetAllianceBadgeId(-1);
			avatar.SetAllianceLevel(-1);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000058B2 File Offset: 0x00003AB2
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_LEFT;
		}
	}
}
