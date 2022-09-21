using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006F RID: 111
	public class TownHallV2LevelAvatarChange : AvatarChange
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00006531 File Offset: 0x00004731
		// (set) Token: 0x06000317 RID: 791 RVA: 0x00006539 File Offset: 0x00004739
		public int Level { get; set; }

		// Token: 0x06000318 RID: 792 RVA: 0x00006542 File Offset: 0x00004742
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00006550 File Offset: 0x00004750
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000655E File Offset: 0x0000475E
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetVillage2TownHallLevel(this.Level);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000656C File Offset: 0x0000476C
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.TOWN_HALL_V2_LEVEL;
		}

		// Token: 0x04000175 RID: 373
		[CompilerGenerated]
		private int int_0;
	}
}
