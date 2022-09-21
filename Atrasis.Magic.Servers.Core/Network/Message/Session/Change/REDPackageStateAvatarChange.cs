using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006C RID: 108
	public class REDPackageStateAvatarChange : AvatarChange
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x000063CD File Offset: 0x000045CD
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x000063D5 File Offset: 0x000045D5
		public int State { get; set; }

		// Token: 0x060002FA RID: 762 RVA: 0x000063DE File Offset: 0x000045DE
		public override void Decode(ByteStream stream)
		{
			this.State = stream.ReadVInt();
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000063EC File Offset: 0x000045EC
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.State);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000063FA File Offset: 0x000045FA
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetRedPackageState(this.State);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00006408 File Offset: 0x00004608
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.RED_PACKAGE_STATE_CHANGED;
		}

		// Token: 0x0400016F RID: 367
		[CompilerGenerated]
		private int int_0;
	}
}
