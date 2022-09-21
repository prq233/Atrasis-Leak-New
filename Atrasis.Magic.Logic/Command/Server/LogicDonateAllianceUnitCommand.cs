using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017B RID: 379
	public class LogicDonateAllianceUnitCommand : LogicServerCommand
	{
		// Token: 0x0600161A RID: 5658 RVA: 0x0000E6CA File Offset: 0x0000C8CA
		public void SetData(LogicCombatItemData data, LogicLong streamId, bool quickDonate)
		{
			this.logicCombatItemData_0 = data;
			this.logicLong_0 = streamId;
			this.bool_0 = quickDonate;
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x0000E6E1 File Offset: 0x0000C8E1
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x0000E6F7 File Offset: 0x0000C8F7
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (stream.ReadInt() != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x0000E736 File Offset: 0x0000C936
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt((int)this.logicCombatItemData_0.GetCombatItemType());
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x00055040 File Offset: 0x00053240
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar == null || this.logicCombatItemData_0 == null)
			{
				return 0;
			}
			if (this.logicCombatItemData_0.GetVillageType() != 0)
			{
				return -45;
			}
			if (this.logicCombatItemData_0.IsDonationDisabled())
			{
				return -91;
			}
			bool flag = false;
			int unitUpgradeLevel = playerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0);
			LogicUnitProductionComponent logicUnitProductionComponent = null;
			if (this.bool_0)
			{
				int donateCost = this.logicCombatItemData_0.GetDonateCost();
				if (!playerAvatar.HasEnoughDiamonds(donateCost, true, level) || !this.logicCombatItemData_0.IsUnlockedForProductionHouseLevel(level.GetGameObjectManagerAt(0).GetHighestBuildingLevel(this.logicCombatItemData_0.GetProductionHouseData())) || !LogicDataTables.GetGlobals().EnableQuickDonate())
				{
					playerAvatar.GetChangeListener().AllianceUnitDonateFailed(this.logicCombatItemData_0, unitUpgradeLevel, this.logicLong_0, this.bool_0);
					return 0;
				}
			}
			else
			{
				LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(0);
				if (LogicDataTables.GetGlobals().UseNewTraining())
				{
					LogicUnitProduction unitProduction = gameObjectManagerAt.GetUnitProduction();
					LogicUnitProduction spellProduction = gameObjectManagerAt.GetSpellProduction();
					if (unitProduction.GetWaitingForSpaceUnitCount(this.logicCombatItemData_0) > 0 && unitProduction.GetUnitProductionType() == this.logicCombatItemData_0.GetDataType())
					{
						flag = true;
					}
					if (spellProduction.GetWaitingForSpaceUnitCount(this.logicCombatItemData_0) > 0 && spellProduction.GetUnitProductionType() == this.logicCombatItemData_0.GetDataType())
					{
						flag = true;
					}
				}
				else
				{
					int i = 0;
					int numGameObjects = gameObjectManagerAt.GetNumGameObjects();
					while (i < numGameObjects)
					{
						LogicGameObject gameObjectByIndex = gameObjectManagerAt.GetGameObjectByIndex(i);
						if (gameObjectByIndex.GetGameObjectType() == LogicGameObjectType.BUILDING)
						{
							LogicUnitProductionComponent unitProductionComponent = ((LogicBuilding)gameObjectByIndex).GetUnitProductionComponent();
							if (unitProductionComponent != null)
							{
								logicUnitProductionComponent = unitProductionComponent;
								if (unitProductionComponent.ContainsUnit(this.logicCombatItemData_0))
								{
									if (unitProductionComponent.GetRemainingSeconds() == 0 && unitProductionComponent.GetCurrentlyTrainedUnit() == this.logicCombatItemData_0)
									{
										flag = true;
									}
								}
								else
								{
									logicUnitProductionComponent = null;
								}
							}
						}
						i++;
					}
				}
				if (!flag && playerAvatar.GetUnitCount(this.logicCombatItemData_0) <= 0)
				{
					playerAvatar.GetChangeListener().AllianceUnitDonateFailed(this.logicCombatItemData_0, unitUpgradeLevel, this.logicLong_0, this.bool_0);
					return 0;
				}
			}
			if (this.logicCombatItemData_0.GetCombatItemType() != LogicCombatItemType.CHARACTER)
			{
				playerAvatar.XpGainHelper(this.logicCombatItemData_0.GetHousingSpace() * LogicDataTables.GetGlobals().GetDarkSpellDonationXP());
				level.GetAchievementManager().AlianceSpellDonated((LogicSpellData)this.logicCombatItemData_0);
			}
			else
			{
				playerAvatar.XpGainHelper(((LogicCharacterData)this.logicCombatItemData_0).GetDonateXP());
				level.GetAchievementManager().AlianceUnitDonated((LogicCharacterData)this.logicCombatItemData_0);
			}
			playerAvatar.GetChangeListener().AllianceUnitDonateOk(this.logicCombatItemData_0, unitUpgradeLevel, this.logicLong_0, this.bool_0);
			if (this.bool_0)
			{
				int donateCost2 = this.logicCombatItemData_0.GetDonateCost();
				playerAvatar.UseDiamonds(donateCost2);
				playerAvatar.GetChangeListener().DiamondPurchaseMade(12, this.logicCombatItemData_0.GetGlobalID(), 0, donateCost2, level.GetVillageType());
				if ((level.GetState() == 1 || level.GetState() == 3) && this.logicCombatItemData_0.GetCombatItemType() == LogicCombatItemType.CHARACTER)
				{
					level.GetGameObjectManagerAt(0).GetHighestBuilding(this.logicCombatItemData_0.GetProductionHouseData());
				}
				return 0;
			}
			if (!flag)
			{
				playerAvatar.CommodityCountChangeHelper(0, this.logicCombatItemData_0, -1);
			}
			LogicResourceData trainingResource = this.logicCombatItemData_0.GetTrainingResource();
			int trainingCost = level.GetGameMode().GetCalendar().GetTrainingCost(this.logicCombatItemData_0, unitUpgradeLevel);
			int valueA = playerAvatar.GetTroopDonationRefund() * trainingCost / 100;
			playerAvatar.CommodityCountChangeHelper(0, trainingResource, LogicMath.Max(valueA, 0));
			if (level.GetState() == 1 || level.GetState() == 3)
			{
				if (flag)
				{
					if (LogicDataTables.GetGlobals().UseNewTraining())
					{
						LogicGameObjectManager gameObjectManagerAt2 = level.GetGameObjectManagerAt(0);
						((this.logicCombatItemData_0.GetCombatItemType() != LogicCombatItemType.CHARACTER) ? gameObjectManagerAt2.GetSpellProduction() : gameObjectManagerAt2.GetUnitProduction()).RemoveTrainedUnit(this.logicCombatItemData_0);
					}
					if (this.logicCombatItemData_0.GetCombatItemType() == LogicCombatItemType.CHARACTER)
					{
						LogicBuilding logicBuilding = null;
						if (logicUnitProductionComponent != null)
						{
							logicBuilding = (LogicBuilding)logicUnitProductionComponent.GetParent();
						}
						else if (LogicDataTables.GetGlobals().UseTroopWalksOutFromTraining())
						{
							LogicGameObjectManager gameObjectManagerAt3 = level.GetGameObjectManagerAt(0);
							int numGameObjects2 = gameObjectManagerAt3.GetNumGameObjects();
							for (int j = 0; j < numGameObjects2; j++)
							{
								LogicGameObject gameObjectByIndex2 = gameObjectManagerAt3.GetGameObjectByIndex(j);
								if (gameObjectByIndex2 != null && gameObjectByIndex2.GetGameObjectType() == LogicGameObjectType.BUILDING)
								{
									LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByIndex2;
									LogicUnitProductionComponent unitProductionComponent2 = logicBuilding2.GetUnitProductionComponent();
									if (unitProductionComponent2 != null && unitProductionComponent2.GetProductionType() == this.logicCombatItemData_0.GetCombatItemType() && logicBuilding2.GetBuildingData().GetProducesUnitsOfType() == this.logicCombatItemData_0.GetUnitOfType() && !logicBuilding2.IsUpgrading() && !logicBuilding2.IsConstructing() && this.logicCombatItemData_0.IsUnlockedForProductionHouseLevel(logicBuilding2.GetUpgradeLevel()))
									{
										if (logicBuilding != null)
										{
											int expPoints = playerAvatar.GetExpPoints();
											if (logicBuilding2.Rand(expPoints) % 1000 > 750)
											{
												logicBuilding = logicBuilding2;
											}
										}
										else
										{
											logicBuilding = logicBuilding2;
										}
									}
								}
							}
						}
						if (logicBuilding != null)
						{
						}
					}
				}
				else
				{
					LogicArrayList<LogicComponent> components = level.GetComponentManagerAt(0).GetComponents(LogicComponentType.UNIT_STORAGE);
					int k = 0;
					while (k < components.Size())
					{
						LogicUnitStorageComponent logicUnitStorageComponent = (LogicUnitStorageComponent)components[k];
						int unitTypeIndex = logicUnitStorageComponent.GetUnitTypeIndex(this.logicCombatItemData_0);
						if (unitTypeIndex == -1 || logicUnitStorageComponent.GetUnitCount(unitTypeIndex) <= 0)
						{
							k++;
						}
						else
						{
							logicUnitStorageComponent.RemoveUnits(this.logicCombatItemData_0, 1);
							if (LogicDataTables.GetGlobals().UseNewTraining())
							{
								LogicGameObjectManager gameObjectManagerAt4 = level.GetGameObjectManagerAt(0);
								LogicUnitProduction logicUnitProduction = (this.logicCombatItemData_0.GetCombatItemType() != LogicCombatItemType.CHARACTER) ? gameObjectManagerAt4.GetSpellProduction() : gameObjectManagerAt4.GetUnitProduction();
								logicUnitProduction.MergeSlots();
								logicUnitProduction.UnitRemoved();
								break;
							}
							break;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x00002EAE File Offset: 0x000010AE
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DONATE_ALLIANCE_UNIT;
		}

		// Token: 0x04000C82 RID: 3202
		private LogicLong logicLong_0;

		// Token: 0x04000C83 RID: 3203
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000C84 RID: 3204
		private bool bool_0;
	}
}
