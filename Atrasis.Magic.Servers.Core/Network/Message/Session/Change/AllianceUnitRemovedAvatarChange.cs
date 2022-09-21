using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005D RID: 93
	public class AllianceUnitRemovedAvatarChange : AvatarChange
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00005E85 File Offset: 0x00004085
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00005E8D File Offset: 0x0000408D
		public LogicCombatItemData Data { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00005E96 File Offset: 0x00004096
		// (set) Token: 0x06000282 RID: 642 RVA: 0x00005E9E File Offset: 0x0000409E
		public int UpgradeLevel { get; set; }

		// Token: 0x06000283 RID: 643 RVA: 0x00005EA7 File Offset: 0x000040A7
		public override void Decode(ByteStream stream)
		{
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00005EC6 File Offset: 0x000040C6
		public override void Encode(ByteStream stream)
		{
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00005EE0 File Offset: 0x000040E0
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.RemoveAllianceUnit(this.Data, this.UpgradeLevel);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00005EF4 File Offset: 0x000040F4
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_UNIT_REMOVED;
		}

		// Token: 0x04000143 RID: 323
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000144 RID: 324
		[CompilerGenerated]
		private int int_0;
	}
}
