using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005A RID: 90
	public class AllianceLevelAvatarChange : AvatarChange
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00005D39 File Offset: 0x00003F39
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00005D41 File Offset: 0x00003F41
		public int Level { get; set; }

		// Token: 0x06000263 RID: 611 RVA: 0x00005D4A File Offset: 0x00003F4A
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00005D58 File Offset: 0x00003F58
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00005D66 File Offset: 0x00003F66
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceLevel(this.Level);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00005BFC File Offset: 0x00003DFC
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_LEVEL;
		}

		// Token: 0x0400013D RID: 317
		[CompilerGenerated]
		private int int_0;
	}
}
