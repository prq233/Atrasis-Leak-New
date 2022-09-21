using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000067 RID: 103
	public class ExpLevelAvatarChange : AvatarChange
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00006134 File Offset: 0x00004334
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x0000613C File Offset: 0x0000433C
		public int Points { get; set; }

		// Token: 0x060002C8 RID: 712 RVA: 0x00006145 File Offset: 0x00004345
		public override void Decode(ByteStream stream)
		{
			this.Points = stream.ReadVInt();
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00006153 File Offset: 0x00004353
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Points);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00006161 File Offset: 0x00004361
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetExpPoints(this.Points);
			avatar.SetExpLevel(avatar.GetExpLevel() + 1);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000617D File Offset: 0x0000437D
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetExpLevel(memberEntry.GetExpLevel() + 1);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00005816 File Offset: 0x00003A16
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.EXP_LEVEL;
		}

		// Token: 0x04000165 RID: 357
		[CompilerGenerated]
		private int int_0;
	}
}
