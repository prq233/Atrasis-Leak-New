using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005C RID: 92
	public class AllianceUnitCountAvatarChange : AvatarChange
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00005DE7 File Offset: 0x00003FE7
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00005DEF File Offset: 0x00003FEF
		public LogicCombatItemData Data { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00005DF8 File Offset: 0x00003FF8
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00005E00 File Offset: 0x00004000
		public int UpgradeLevel { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00005E09 File Offset: 0x00004009
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00005E11 File Offset: 0x00004011
		public int Count { get; set; }

		// Token: 0x06000279 RID: 633 RVA: 0x00005E1A File Offset: 0x0000401A
		public override void Decode(ByteStream stream)
		{
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
			this.Count = stream.ReadVInt();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00005E45 File Offset: 0x00004045
		public override void Encode(ByteStream stream)
		{
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
			stream.WriteVInt(this.Count);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00005E6B File Offset: 0x0000406B
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceUnitCount(this.Data, this.UpgradeLevel, this.Count);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00005B1D File Offset: 0x00003D1D
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_UNIT_COUNT;
		}

		// Token: 0x04000140 RID: 320
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000141 RID: 321
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000142 RID: 322
		[CompilerGenerated]
		private int int_1;
	}
}
