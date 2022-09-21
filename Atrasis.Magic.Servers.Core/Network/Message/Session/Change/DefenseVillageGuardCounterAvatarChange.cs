using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000064 RID: 100
	public class DefenseVillageGuardCounterAvatarChange : AvatarChange
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00005FF8 File Offset: 0x000041F8
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00006000 File Offset: 0x00004200
		public int Count { get; set; }

		// Token: 0x060002AC RID: 684 RVA: 0x00006009 File Offset: 0x00004209
		public override void Decode(ByteStream stream)
		{
			this.Count = stream.ReadVInt();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00006017 File Offset: 0x00004217
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Count);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00006025 File Offset: 0x00004225
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetDefenseVillageGuardCounter(this.Count);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00006033 File Offset: 0x00004233
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.DEFENSE_VILLAGE_GUARD_COUNTER;
		}

		// Token: 0x04000160 RID: 352
		[CompilerGenerated]
		private int int_0;
	}
}
