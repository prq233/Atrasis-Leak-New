using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000065 RID: 101
	public class DiamondAvatarChange : AvatarChange
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00006037 File Offset: 0x00004237
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x0000603F File Offset: 0x0000423F
		public int Count { get; set; }

		// Token: 0x060002B4 RID: 692 RVA: 0x00006048 File Offset: 0x00004248
		public override void Decode(ByteStream stream)
		{
			this.Count = stream.ReadVInt();
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00006056 File Offset: 0x00004256
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Count);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00006064 File Offset: 0x00004264
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetDiamonds(avatar.GetDiamonds() + this.Count);
			avatar.SetFreeDiamonds(avatar.GetFreeDiamonds() + this.Count);
			if (avatar.GetFreeDiamonds() < 0)
			{
				avatar.SetFreeDiamonds(0);
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000598D File Offset: 0x00003B8D
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.DIAMOND;
		}

		// Token: 0x04000161 RID: 353
		[CompilerGenerated]
		private int int_0;
	}
}
