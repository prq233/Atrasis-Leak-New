using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000068 RID: 104
	public class ExpPointsAvatarChange : AvatarChange
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002CE RID: 718 RVA: 0x0000618D File Offset: 0x0000438D
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00006195 File Offset: 0x00004395
		public int Points { get; set; }

		// Token: 0x060002D0 RID: 720 RVA: 0x0000619E File Offset: 0x0000439E
		public override void Decode(ByteStream stream)
		{
			this.Points = stream.ReadVInt();
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000061AC File Offset: 0x000043AC
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Points);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000061BA File Offset: 0x000043BA
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetExpPoints(avatar.GetExpPoints() + this.Points);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000552A File Offset: 0x0000372A
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.EXP_POINTS;
		}

		// Token: 0x04000166 RID: 358
		[CompilerGenerated]
		private int int_0;
	}
}
