using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006B RID: 107
	public class NameAvatarChange : AvatarChange
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002EE RID: 750 RVA: 0x0000633F File Offset: 0x0000453F
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00006347 File Offset: 0x00004547
		public string Name { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00006350 File Offset: 0x00004550
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x00006358 File Offset: 0x00004558
		public int NameChangeState { get; set; }

		// Token: 0x060002F2 RID: 754 RVA: 0x00006361 File Offset: 0x00004561
		public override void Decode(ByteStream stream)
		{
			this.Name = stream.ReadString(900000);
			this.NameChangeState = stream.ReadVInt();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00006380 File Offset: 0x00004580
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.Name);
			stream.WriteVInt(this.NameChangeState);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000639A File Offset: 0x0000459A
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetName(this.Name);
			avatar.SetNameSetByUser(true);
			avatar.SetNameChangeState(this.NameChangeState);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000063BB File Offset: 0x000045BB
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetName(this.Name);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000063C9 File Offset: 0x000045C9
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.NAME;
		}

		// Token: 0x0400016D RID: 365
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400016E RID: 366
		[CompilerGenerated]
		private int int_0;
	}
}
