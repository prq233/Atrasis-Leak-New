using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001F0 RID: 496
	public sealed class LogicMatchmakeVillage2Command : LogicCommand
	{
		// Token: 0x06001939 RID: 6457 RVA: 0x00010C7A File Offset: 0x0000EE7A
		public override void Decode(ByteStream stream)
		{
			this.logicResourceData_0 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			this.int_1 = stream.ReadVInt();
			base.Decode(stream);
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x00010CA1 File Offset: 0x0000EEA1
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_0);
			encoder.WriteVInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x00010CC2 File Offset: 0x0000EEC2
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MATCHMAKE_VILLAGE2;
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x00010CC9 File Offset: 0x0000EEC9
		public override void Destruct()
		{
			base.Destruct();
			this.logicResourceData_0 = null;
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x0005FF5C File Offset: 0x0005E15C
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 1)
			{
				return -32;
			}
			if (!level.IsUnitsTrainedVillage2())
			{
				return -24;
			}
			if (level.GetState() == 1)
			{
				if (this.int_1 > 0)
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					if (playerAvatar.GetUnusedResourceCap(LogicDataTables.GetGold2Data()) < this.int_1)
					{
						return -1;
					}
					int resourceDiamondCost = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, LogicDataTables.GetGold2Data());
					if (playerAvatar.HasEnoughDiamonds(resourceDiamondCost, true, level))
					{
						return -2;
					}
					playerAvatar.UseDiamonds(resourceDiamondCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(5, LogicDataTables.GetGold2Data().GetGlobalID(), this.int_1, resourceDiamondCost, level.GetVillageType());
					playerAvatar.CommodityCountChangeHelper(0, LogicDataTables.GetGold2Data(), this.int_1);
				}
				level.GetGameListener().MatchmakingVillage2CommandExecuted();
				return 0;
			}
			return -3;
		}

		// Token: 0x04000DA6 RID: 3494
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000DA7 RID: 3495
		private int int_1;
	}
}
