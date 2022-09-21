using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000057 RID: 87
	public class AllianceCastleLevelAvatarChange : AvatarChange
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00005BFF File Offset: 0x00003DFF
		// (set) Token: 0x06000244 RID: 580 RVA: 0x00005C07 File Offset: 0x00003E07
		public int Level { get; set; }

		// Token: 0x06000245 RID: 581 RVA: 0x00005C10 File Offset: 0x00003E10
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00005C1E File Offset: 0x00003E1E
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00005C2C File Offset: 0x00003E2C
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceCastleLevel(this.Level);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00005C3A File Offset: 0x00003E3A
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_CASTLE_LEVEL;
		}

		// Token: 0x04000137 RID: 311
		[CompilerGenerated]
		private int int_0;
	}
}
