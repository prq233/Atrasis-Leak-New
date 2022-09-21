using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Achievement
{
	// Token: 0x02000204 RID: 516
	public class LogicAchievementManager
	{
		// Token: 0x06001B55 RID: 6997 RVA: 0x00011BCE File Offset: 0x0000FDCE
		public LogicAchievementManager(LogicLevel level)
		{
			this.logicLevel_0 = level;
		}

		// Token: 0x06001B56 RID: 6998 RVA: 0x00011BDD File Offset: 0x0000FDDD
		public void Destruct()
		{
			this.logicLevel_0 = null;
		}

		// Token: 0x06001B57 RID: 6999 RVA: 0x00069178 File Offset: 0x00067378
		public void ObstacleCleared()
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
			if (homeOwnerAvatar != null && homeOwnerAvatar.IsClientAvatar())
			{
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)homeOwnerAvatar;
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
					if (logicAchievementData.GetActionType() == LogicAchievementActionType.CLEAR_OBSTACLES)
					{
						this.RefreshAchievementProgress(logicClientAvatar, logicAchievementData, logicClientAvatar.GetAchievementProgress(logicAchievementData) + 1);
					}
				}
			}
		}

		// Token: 0x06001B58 RID: 7000 RVA: 0x000691E8 File Offset: 0x000673E8
		public void RefreshStatus()
		{
			if (this.logicLevel_0.GetState() == 1)
			{
				LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
				int i = 0;
				int value = 0;
				while (i < table.GetItemCount())
				{
					LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
					LogicAchievementActionType actionType = logicAchievementData.GetActionType();
					switch (actionType)
					{
					case LogicAchievementActionType.NPC_STARS:
						value = playerAvatar.GetTotalNpcStars();
						break;
					case LogicAchievementActionType.UPGRADE:
						value = this.logicLevel_0.GetGameObjectManager().GetHighestBuildingLevel(logicAchievementData.GetBuildingData()) + 1;
						break;
					case LogicAchievementActionType.VICTORY_POINTS:
						value = playerAvatar.GetScore();
						break;
					case LogicAchievementActionType.UNIT_UNLOCK:
						value = (logicAchievementData.GetCharacterData().IsUnlockedForBarrackLevel(LogicMath.Max(this.logicLevel_0.GetComponentManagerAt(logicAchievementData.GetVillageType()).GetMaxBarrackLevel(), 0)) ? 1 : 0);
						break;
					default:
						switch (actionType)
						{
						case LogicAchievementActionType.LEAGUE:
							value = playerAvatar.GetLeagueType();
							break;
						case LogicAchievementActionType.ACCOUNT_BOUND:
							value = (playerAvatar.IsAccountBound() ? 1 : 0);
							break;
						case LogicAchievementActionType.VERSUS_BATTLE_TROPHIES:
							value = playerAvatar.GetDuelScore();
							break;
						case LogicAchievementActionType.GEAR_UP:
							value = this.logicLevel_0.GetGameObjectManager().GetGearUpBuildingCount();
							break;
						case LogicAchievementActionType.REPAIR_BUILDING:
						{
							LogicArrayList<LogicAchievementData> achievementLevels = logicAchievementData.GetAchievementLevels();
							if (achievementLevels.Size() > 0)
							{
								for (int j = 0; j < achievementLevels.Size(); j++)
								{
									if (!this.IsBuildingUnlocked(achievementLevels[j].GetBuildingData()))
									{
										break;
									}
									if (achievementLevels[j] == logicAchievementData)
									{
										value = 1;
										break;
									}
								}
							}
							break;
						}
						}
						break;
					}
					this.RefreshAchievementProgress(playerAvatar, logicAchievementData, value);
					i++;
					value = 0;
				}
			}
		}

		// Token: 0x06001B59 RID: 7001 RVA: 0x00069394 File Offset: 0x00067594
		public void RefreshAchievementProgress(LogicClientAvatar avatar, LogicAchievementData data, int value)
		{
			if (this.logicLevel_0.GetState() != 5)
			{
				int achievementProgress = avatar.GetAchievementProgress(data);
				int num = LogicMath.Min(value, 2000000000);
				if (achievementProgress < num)
				{
					avatar.SetAchievementProgress(data, value);
					avatar.GetChangeListener().CommodityCountChanged(0, data, num);
				}
				int num2 = LogicMath.Min(num, data.GetActionCount());
				if (achievementProgress < num2 && this.logicLevel_0.GetPlayerAvatar() == avatar)
				{
					if (num2 == data.GetActionCount())
					{
						this.logicLevel_0.GetGameListener().AchievementCompleted(data);
						return;
					}
					this.logicLevel_0.GetGameListener().AchievementProgress(data);
				}
			}
		}

		// Token: 0x06001B5A RID: 7002 RVA: 0x00069428 File Offset: 0x00067628
		public void AlianceUnitDonated(LogicCharacterData data)
		{
			if (data != null)
			{
				LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
					if (logicAchievementData.GetActionType() == LogicAchievementActionType.DONATE_UNITS)
					{
						this.RefreshAchievementProgress(playerAvatar, logicAchievementData, playerAvatar.GetAchievementProgress(logicAchievementData) + data.GetHousingSpace());
					}
				}
			}
		}

		// Token: 0x06001B5B RID: 7003 RVA: 0x0006948C File Offset: 0x0006768C
		public void AlianceSpellDonated(LogicSpellData data)
		{
			if (data != null)
			{
				LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
					if (logicAchievementData.GetActionType() == LogicAchievementActionType.DONATE_SPELLS)
					{
						this.RefreshAchievementProgress(playerAvatar, logicAchievementData, playerAvatar.GetAchievementProgress(logicAchievementData) + data.GetHousingSpace());
					}
				}
			}
		}

		// Token: 0x06001B5C RID: 7004 RVA: 0x000694F0 File Offset: 0x000676F0
		public void PvpAttackWon()
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
				if (logicAchievementData.GetActionType() == LogicAchievementActionType.WIN_PVP_ATTACK)
				{
					this.RefreshAchievementProgress(playerAvatar, logicAchievementData, playerAvatar.GetAchievementProgress(logicAchievementData) + 1);
				}
			}
		}

		// Token: 0x06001B5D RID: 7005 RVA: 0x0006954C File Offset: 0x0006774C
		public void PvpDefenseWon()
		{
			if (this.logicLevel_0.GetHomeOwnerAvatar().IsClientAvatar())
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.logicLevel_0.GetHomeOwnerAvatar();
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
					if (logicAchievementData.GetActionType() == LogicAchievementActionType.WIN_PVP_DEFENSE)
					{
						this.RefreshAchievementProgress(logicClientAvatar, logicAchievementData, logicClientAvatar.GetAchievementProgress(logicAchievementData) + 1);
					}
				}
			}
		}

		// Token: 0x06001B5E RID: 7006 RVA: 0x000695C0 File Offset: 0x000677C0
		public void IncreaseWarStars(int stars)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
				if (logicAchievementData.GetActionType() == LogicAchievementActionType.WAR_STARS)
				{
					this.RefreshAchievementProgress(playerAvatar, logicAchievementData, playerAvatar.GetAchievementProgress(logicAchievementData) + stars);
				}
			}
		}

		// Token: 0x06001B5F RID: 7007 RVA: 0x0006961C File Offset: 0x0006781C
		public void IncreaseLoot(LogicResourceData resourceData, int count)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
				if (logicAchievementData.GetActionType() == LogicAchievementActionType.LOOT && logicAchievementData.GetResourceData() == resourceData)
				{
					this.RefreshAchievementProgress(playerAvatar, logicAchievementData, playerAvatar.GetAchievementProgress(logicAchievementData) + count);
				}
			}
		}

		// Token: 0x06001B60 RID: 7008 RVA: 0x00069680 File Offset: 0x00067880
		public void IncreaseWarGoldResourceLoot(int count)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
				if (logicAchievementData.GetActionType() == LogicAchievementActionType.WAR_LOOT)
				{
					this.RefreshAchievementProgress(playerAvatar, logicAchievementData, playerAvatar.GetAchievementProgress(logicAchievementData) + count);
				}
			}
		}

		// Token: 0x06001B61 RID: 7009 RVA: 0x000696DC File Offset: 0x000678DC
		public void BuildingDestroyedInPvP(LogicBuildingData buildingData)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
				if (logicAchievementData.GetActionType() == LogicAchievementActionType.DESTROY && logicAchievementData.GetBuildingData() == buildingData)
				{
					this.RefreshAchievementProgress(playerAvatar, logicAchievementData, playerAvatar.GetAchievementProgress(logicAchievementData) + 1);
				}
			}
		}

		// Token: 0x06001B62 RID: 7010 RVA: 0x00069740 File Offset: 0x00067940
		public bool IsBuildingUnlocked(LogicBuildingData buildingData)
		{
			LogicArrayList<LogicGameObject> gameObjects = this.logicLevel_0.GetGameObjectManagerAt(buildingData.GetVillageType()).GetGameObjects(LogicGameObjectType.BUILDING);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
				if (logicBuilding.GetData() == buildingData && !logicBuilding.IsLocked())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001B63 RID: 7011 RVA: 0x00002463 File Offset: 0x00000663
		public void Tick()
		{
		}

		// Token: 0x04000E6E RID: 3694
		private LogicLevel logicLevel_0;
	}
}
