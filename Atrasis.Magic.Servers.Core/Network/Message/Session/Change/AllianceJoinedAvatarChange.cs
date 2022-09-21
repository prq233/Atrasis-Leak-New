using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000058 RID: 88
	public class AllianceJoinedAvatarChange : AvatarChange
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00005C46 File Offset: 0x00003E46
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00005C4E File Offset: 0x00003E4E
		public LogicLong AllianceId { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00005C57 File Offset: 0x00003E57
		// (set) Token: 0x0600024E RID: 590 RVA: 0x00005C5F File Offset: 0x00003E5F
		public string AllianceName { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00005C68 File Offset: 0x00003E68
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00005C70 File Offset: 0x00003E70
		public int AllianceBadgeId { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00005C79 File Offset: 0x00003E79
		// (set) Token: 0x06000252 RID: 594 RVA: 0x00005C81 File Offset: 0x00003E81
		public int AllianceExpLevel { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00005C8A File Offset: 0x00003E8A
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00005C92 File Offset: 0x00003E92
		public LogicAvatarAllianceRole AllianceRole { get; set; }

		// Token: 0x06000255 RID: 597 RVA: 0x0000C4D8 File Offset: 0x0000A6D8
		public override void Decode(ByteStream stream)
		{
			this.AllianceId = stream.ReadLong();
			this.AllianceName = stream.ReadString(900000);
			this.AllianceBadgeId = stream.ReadVInt();
			this.AllianceExpLevel = stream.ReadVInt();
			this.AllianceRole = (LogicAvatarAllianceRole)stream.ReadVInt();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00005C9B File Offset: 0x00003E9B
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AllianceId);
			stream.WriteString(this.AllianceName);
			stream.WriteVInt(this.AllianceBadgeId);
			stream.WriteVInt(this.AllianceExpLevel);
			stream.WriteVInt((int)this.AllianceRole);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00005CD9 File Offset: 0x00003ED9
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceId(this.AllianceId);
			avatar.SetAllianceName(this.AllianceName);
			avatar.SetAllianceBadgeId(this.AllianceBadgeId);
			avatar.SetAllianceLevel(this.AllianceExpLevel);
			avatar.SetAllianceRole(this.AllianceRole);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00005924 File Offset: 0x00003B24
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_JOINED;
		}

		// Token: 0x04000138 RID: 312
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000139 RID: 313
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400013A RID: 314
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400013B RID: 315
		[CompilerGenerated]
		private int int_1;

		// Token: 0x0400013C RID: 316
		[CompilerGenerated]
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;
	}
}
