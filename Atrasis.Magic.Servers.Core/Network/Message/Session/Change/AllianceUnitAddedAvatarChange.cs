using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005B RID: 91
	public class AllianceUnitAddedAvatarChange : AvatarChange
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00005D74 File Offset: 0x00003F74
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00005D7C File Offset: 0x00003F7C
		public LogicCombatItemData Data { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00005D85 File Offset: 0x00003F85
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00005D8D File Offset: 0x00003F8D
		public int UpgradeLevel { get; set; }

		// Token: 0x0600026D RID: 621 RVA: 0x00005D96 File Offset: 0x00003F96
		public override void Decode(ByteStream stream)
		{
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00005DB5 File Offset: 0x00003FB5
		public override void Encode(ByteStream stream)
		{
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00005DCF File Offset: 0x00003FCF
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.AddAllianceUnit(this.Data, this.UpgradeLevel);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00005DE3 File Offset: 0x00003FE3
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_UNIT_ADDED;
		}

		// Token: 0x0400013E RID: 318
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x0400013F RID: 319
		[CompilerGenerated]
		private int int_0;
	}
}
