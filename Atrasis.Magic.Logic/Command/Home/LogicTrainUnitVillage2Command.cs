using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DB RID: 475
	public sealed class LogicTrainUnitVillage2Command : LogicCommand
	{
		// Token: 0x0600189B RID: 6299 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicTrainUnitVillage2Command()
		{
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x00010589 File Offset: 0x0000E789
		public LogicTrainUnitVillage2Command(int gameObjectId, LogicCombatItemData combatItemData)
		{
			this.int_2 = gameObjectId;
			this.logicCombatItemData_0 = combatItemData;
			this.int_1 = ((this.logicCombatItemData_0.GetDataType() == LogicDataType.SPELL) ? 1 : 0);
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x000105B8 File Offset: 0x0000E7B8
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (this.int_1 != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			base.Decode(stream);
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x000105F7 File Offset: 0x0000E7F7
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_1);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			base.Encode(encoder);
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x00010624 File Offset: 0x0000E824
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRAIN_UNIT_VILLAGE_2;
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x0001062B File Offset: 0x0000E82B
		public override void Destruct()
		{
			base.Destruct();
			this.int_2 = 0;
			this.int_1 = 0;
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x0005C624 File Offset: 0x0005A824
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 1)
			{
				return -10;
			}
			if (this.int_2 != 0)
			{
				LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(1);
				LogicGameObject gameObjectByID = gameObjectManagerAt.GetGameObjectByID(this.int_2);
				if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (this.logicCombatItemData_0 != null && level.GetGameMode().GetCalendar().IsProductionEnabled(this.logicCombatItemData_0))
					{
						if (this.logicCombatItemData_0.GetVillageType() != 1)
						{
							return -8;
						}
						LogicVillage2UnitComponent village2UnitComponent = logicBuilding.GetVillage2UnitComponent();
						if (village2UnitComponent == null)
						{
							return -4;
						}
						if (this.logicCombatItemData_0.IsUnlockedForProductionHouseLevel(gameObjectManagerAt.GetHighestBuildingLevel(this.logicCombatItemData_0.GetProductionHouseData(), true)))
						{
							LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
							LogicResourceData trainingResource = this.logicCombatItemData_0.GetTrainingResource();
							int trainingCost = this.logicCombatItemData_0.GetTrainingCost(playerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0));
							if (playerAvatar.HasEnoughResources(trainingResource, trainingCost, true, this, false))
							{
								village2UnitComponent.TrainUnit(this.logicCombatItemData_0);
								playerAvatar.CommodityCountChangeHelper(0, trainingResource, -trainingCost);
							}
							return 0;
						}
						return -7;
					}
				}
				return -5;
			}
			return -1;
		}

		// Token: 0x04000D3C RID: 3388
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000D3D RID: 3389
		private int int_1;

		// Token: 0x04000D3E RID: 3390
		private int int_2;
	}
}
