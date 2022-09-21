using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006E RID: 110
	public class TownHallLevelAvatarChange : AvatarChange
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000064F2 File Offset: 0x000046F2
		// (set) Token: 0x0600030F RID: 783 RVA: 0x000064FA File Offset: 0x000046FA
		public int Level { get; set; }

		// Token: 0x06000310 RID: 784 RVA: 0x00006503 File Offset: 0x00004703
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00006511 File Offset: 0x00004711
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000651F File Offset: 0x0000471F
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetTownHallLevel(this.Level);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000652D File Offset: 0x0000472D
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.TOWN_HALL_LEVEL;
		}

		// Token: 0x04000174 RID: 372
		[CompilerGenerated]
		private int int_0;
	}
}
