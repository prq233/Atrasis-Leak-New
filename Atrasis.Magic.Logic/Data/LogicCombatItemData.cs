using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000144 RID: 324
	public abstract class LogicCombatItemData : LogicGameObjectData
	{
		// Token: 0x06001206 RID: 4614 RVA: 0x0000B4F2 File Offset: 0x000096F2
		protected LogicCombatItemData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x0004D500 File Offset: 0x0004B700
		public override void CreateReferences()
		{
			base.CreateReferences();
			int num = this.m_upgradeLevelCount = this.m_row.GetBiggestArraySize();
			this.int_5 = new int[num];
			this.int_0 = new int[num];
			this.int_1 = new int[num];
			this.int_2 = new int[num];
			this.int_3 = new int[num];
			this.int_4 = new int[num];
			this.logicResourceData_0 = new LogicResourceData[num];
			for (int i = 0; i < num; i++)
			{
				this.int_5[i] = base.GetClampedIntegerValue("UpgradeLevelByTH", i);
				this.int_0[i] = 3600 * base.GetClampedIntegerValue("UpgradeTimeH", i) + 60 * base.GetClampedIntegerValue("UpgradeTimeM", i);
				this.int_1[i] = base.GetClampedIntegerValue("UpgradeCost", i);
				this.int_2[i] = base.GetClampedIntegerValue("TrainingTime", i);
				this.int_3[i] = base.GetClampedIntegerValue("TrainingCost", i);
				this.int_4[i] = base.GetClampedIntegerValue("LaboratoryLevel", i) - 1;
				this.logicResourceData_0[i] = LogicDataTables.GetResourceByName(base.GetClampedValue("UpgradeResource", i), this);
				if (this.logicResourceData_0[i] == null && this.GetCombatItemType() != LogicCombatItemType.HERO)
				{
					Debugger.Error("UpgradeResource is not defined for " + base.GetName());
				}
			}
			if (base.GetName().Equals("Barbarian2") && this.int_0[0] == 0)
			{
				this.int_0[0] = 30;
			}
			this.logicResourceData_1 = LogicDataTables.GetResourceByName(base.GetValue("TrainingResource", 0), this);
			this.int_6 = base.GetIntegerValue("HousingSpace", 0);
			this.bool_0 = !base.GetBooleanValue("DisableProduction", 0);
			this.bool_1 = base.GetBooleanValue("EnabledByCalendar", 0);
			this.int_7 = base.GetIntegerValue("UnitOfType", 0);
			this.int_8 = base.GetIntegerValue("DonateCost", 0);
			if (this.logicResourceData_1 == null && this.GetCombatItemType() != LogicCombatItemType.HERO)
			{
				Debugger.Error("TrainingResource is not defined for " + base.GetName());
			}
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsDonationDisabled()
		{
			return false;
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x0000C148 File Offset: 0x0000A348
		public int GetDonateCost()
		{
			return this.int_8;
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x0000C150 File Offset: 0x0000A350
		public int GetUpgradeLevelCount()
		{
			return this.m_upgradeLevelCount;
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x0000C158 File Offset: 0x0000A358
		public int GetUpgradeTime(int idx)
		{
			return this.int_0[idx];
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x0000C162 File Offset: 0x0000A362
		public LogicResourceData GetUpgradeResource(int idx)
		{
			return this.logicResourceData_0[idx];
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x0000C16C File Offset: 0x0000A36C
		public int GetUpgradeCost(int idx)
		{
			return this.int_1[idx];
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x0000C176 File Offset: 0x0000A376
		public LogicResourceData GetTrainingResource()
		{
			return this.logicResourceData_1;
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x0000C17E File Offset: 0x0000A37E
		public int GetTrainingCost(int idx)
		{
			return this.int_3[idx];
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x0000C188 File Offset: 0x0000A388
		public int GetUnitOfType()
		{
			return this.int_7;
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x0000C190 File Offset: 0x0000A390
		public int GetRequiredLaboratoryLevel(int idx)
		{
			return this.int_4[idx];
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int GetRequiredProductionHouseLevel()
		{
			return 0;
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsUnlockedForProductionHouseLevel(int level)
		{
			return false;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x00002B33 File Offset: 0x00000D33
		public virtual LogicBuildingData GetProductionHouseData()
		{
			return null;
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsUnderground()
		{
			return false;
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x0000C19A File Offset: 0x0000A39A
		public int GetHousingSpace()
		{
			return this.int_6;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x0004D724 File Offset: 0x0004B924
		public int GetUpgradeLevelByTownHall(int townHallLevel)
		{
			int num = this.m_upgradeLevelCount;
			if (num >= 2)
			{
				int num2 = 1;
				while (townHallLevel + 1 >= this.int_5[num2])
				{
					if (++num2 >= num)
					{
						return num - 1;
					}
				}
				num = num2;
			}
			return num - 1;
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x0000C1A2 File Offset: 0x0000A3A2
		public bool UseUpgradeLevelByTownHall()
		{
			return this.int_5[0] > 0;
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x0004D760 File Offset: 0x0004B960
		public int GetTrainingTime(int index, LogicLevel level, int additionalBarrackCount)
		{
			int num = this.int_2[index];
			if (LogicDataTables.GetGlobals().UseNewTraining() && base.GetVillageType() != 1 && this.GetCombatItemType() == LogicCombatItemType.CHARACTER)
			{
				if (level != null)
				{
					LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(0);
					int num2 = this.int_7;
					if (num2 != 1)
					{
						if (num2 != 2)
						{
							Debugger.Error("invalid type for unit");
						}
						else
						{
							int num3 = gameObjectManagerAt.GetDarkBarrackCount();
							int requiredProductionHouseLevel = this.GetRequiredProductionHouseLevel();
							int num4 = 0;
							for (int i = 0; i < num3; i++)
							{
								LogicBuilding logicBuilding = (LogicBuilding)gameObjectManagerAt.GetDarkBarrack(i);
								if (logicBuilding != null && logicBuilding.GetBuildingData().GetProducesUnitsOfType() == this.GetUnitOfType() && logicBuilding.GetUpgradeLevel() >= requiredProductionHouseLevel && !logicBuilding.IsConstructing())
								{
									num4++;
								}
							}
							if (num4 + additionalBarrackCount <= 0)
							{
								return num;
							}
							int[] darkBarrackReduceTrainingDevisor = LogicDataTables.GetGlobals().GetDarkBarrackReduceTrainingDevisor();
							int num5 = darkBarrackReduceTrainingDevisor[LogicMath.Min(darkBarrackReduceTrainingDevisor.Length - 1, num4 + additionalBarrackCount - 1)];
							if (num5 > 0)
							{
								return num / num5;
							}
							return num;
						}
					}
					else
					{
						int num3 = gameObjectManagerAt.GetBarrackCount();
						int requiredProductionHouseLevel = this.GetRequiredProductionHouseLevel();
						int num4 = 0;
						for (int j = 0; j < num3; j++)
						{
							LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectManagerAt.GetBarrack(j);
							if (logicBuilding2 != null && logicBuilding2.GetBuildingData().GetProducesUnitsOfType() == this.GetUnitOfType() && logicBuilding2.GetUpgradeLevel() >= requiredProductionHouseLevel && !logicBuilding2.IsConstructing())
							{
								num4++;
							}
						}
						if (num4 + additionalBarrackCount <= 0)
						{
							return num;
						}
						int[] barrackReduceTrainingDevisor = LogicDataTables.GetGlobals().GetBarrackReduceTrainingDevisor();
						int num5 = barrackReduceTrainingDevisor[LogicMath.Min(barrackReduceTrainingDevisor.Length - 1, num4 + additionalBarrackCount - 1)];
						if (num5 > 0)
						{
							return num / num5;
						}
						return num;
					}
				}
				else
				{
					Debugger.Error("level was null in getTrainingTime()");
				}
			}
			return num;
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x0000C1AF File Offset: 0x0000A3AF
		public bool IsProductionEnabled()
		{
			return this.bool_0;
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x0000C1B7 File Offset: 0x0000A3B7
		public override bool IsEnableByCalendar()
		{
			return this.bool_1;
		}

		// Token: 0x0600121C RID: 4636
		public abstract LogicCombatItemType GetCombatItemType();

		// Token: 0x04000866 RID: 2150
		private LogicResourceData[] logicResourceData_0;

		// Token: 0x04000867 RID: 2151
		private LogicResourceData logicResourceData_1;

		// Token: 0x04000868 RID: 2152
		protected int m_upgradeLevelCount;

		// Token: 0x04000869 RID: 2153
		private int[] int_0;

		// Token: 0x0400086A RID: 2154
		private int[] int_1;

		// Token: 0x0400086B RID: 2155
		private int[] int_2;

		// Token: 0x0400086C RID: 2156
		private int[] int_3;

		// Token: 0x0400086D RID: 2157
		private int[] int_4;

		// Token: 0x0400086E RID: 2158
		private int[] int_5;

		// Token: 0x0400086F RID: 2159
		private int int_6;

		// Token: 0x04000870 RID: 2160
		private int int_7;

		// Token: 0x04000871 RID: 2161
		private int int_8;

		// Token: 0x04000872 RID: 2162
		private bool bool_0;

		// Token: 0x04000873 RID: 2163
		private bool bool_1;
	}
}
