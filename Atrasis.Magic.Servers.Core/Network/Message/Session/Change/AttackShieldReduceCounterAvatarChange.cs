using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005E RID: 94
	public class AttackShieldReduceCounterAvatarChange : AvatarChange
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00005EF7 File Offset: 0x000040F7
		// (set) Token: 0x0600028A RID: 650 RVA: 0x00005EFF File Offset: 0x000040FF
		public int Count { get; set; }

		// Token: 0x0600028B RID: 651 RVA: 0x00005F08 File Offset: 0x00004108
		public override void Decode(ByteStream stream)
		{
			this.Count = stream.ReadVInt();
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00005F16 File Offset: 0x00004116
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Count);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00005F24 File Offset: 0x00004124
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAttackShieldReduceCounter(this.Count);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00005F32 File Offset: 0x00004132
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ATTACK_SHIELD_REDUCE_COUNTER;
		}

		// Token: 0x04000145 RID: 325
		[CompilerGenerated]
		private int int_0;
	}
}
