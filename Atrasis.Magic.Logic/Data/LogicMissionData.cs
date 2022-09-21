using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015A RID: 346
	public class LogicMissionData : LogicData
	{
		// Token: 0x06001430 RID: 5168 RVA: 0x0000D502 File Offset: 0x0000B702
		public LogicMissionData(CSVRow row, LogicDataTable table) : base(row, table)
		{
			this.int_0 = -1;
			this.logicArrayList_0 = new LogicArrayList<LogicMissionData>();
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x00050E08 File Offset: 0x0004F008
		public override void CreateReferences()
		{
			base.CreateReferences();
			for (int i = 0; i < base.GetArraySize("Dependencies"); i++)
			{
				LogicMissionData missionByName = LogicDataTables.GetMissionByName(base.GetValue("Dependencies", i), this);
				if (missionByName != null)
				{
					this.logicArrayList_0.Add(missionByName);
				}
			}
			this.string_0 = base.GetValue("Action", 0);
			this.bool_10 = base.GetBooleanValue("Deprecated", 0);
			this.int_1 = base.GetIntegerValue("MissionCategory", 0);
			this.logicVillageObjectData_0 = LogicDataTables.GetVillageObjectByName(base.GetValue("FixVillageObject", 0), this);
			if (this.logicVillageObjectData_0 != null)
			{
				this.int_3 = base.GetIntegerValue("BuildBuildingLevel", 0);
				this.int_0 = 13;
			}
			if (string.Equals(this.string_0, "travel"))
			{
				this.int_0 = 14;
			}
			else if (string.Equals(this.string_0, "upgrade2"))
			{
				this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(base.GetValue("Character", 0), this);
				this.int_0 = 17;
			}
			else if (string.Equals(this.string_0, "duel"))
			{
				this.logicNpcData_1 = LogicDataTables.GetNpcByName(base.GetValue("AttackNPC", 0), this);
				this.int_0 = 18;
			}
			else if (string.Equals(this.string_0, "duel_end"))
			{
				this.logicNpcData_1 = LogicDataTables.GetNpcByName(base.GetValue("AttackNPC", 0), this);
				this.int_0 = 19;
			}
			else if (string.Equals(this.string_0, "duel_end2"))
			{
				this.int_0 = 20;
			}
			else if (string.Equals(this.string_0, "show_builder_menu"))
			{
				this.int_0 = 21;
			}
			this.logicBuildingData_0 = LogicDataTables.GetBuildingByName(base.GetValue("BuildBuilding", 0), this);
			if (this.logicBuildingData_0 != null)
			{
				this.int_2 = base.GetIntegerValue("BuildBuildingCount", 0);
				this.int_3 = base.GetIntegerValue("BuildBuildingLevel", 0) - 1;
				this.int_0 = (string.Equals(this.string_0, "unlock") ? 15 : 5);
				if (this.int_2 < 0)
				{
					Debugger.Error("missions.csv: BuildBuildingCount is invalid!");
				}
			}
			else if (this.int_0 == -1)
			{
				this.bool_0 = base.GetBooleanValue("OpenAchievements", 0);
				if (this.bool_0)
				{
					this.int_0 = 7;
				}
				else
				{
					this.logicNpcData_0 = LogicDataTables.GetNpcByName(base.GetValue("DefendNPC", 0), this);
					if (this.logicNpcData_0 != null)
					{
						this.int_0 = 1;
					}
					else
					{
						this.logicNpcData_1 = LogicDataTables.GetNpcByName(base.GetValue("AttackNPC", 0), this);
						if (this.logicNpcData_1 != null)
						{
							this.int_0 = 2;
							this.bool_1 = base.GetBooleanValue("ShowMap", 0);
						}
						else
						{
							this.bool_2 = base.GetBooleanValue("ChangeName", 0);
							if (this.bool_2)
							{
								this.int_0 = 6;
							}
							else
							{
								this.int_4 = base.GetIntegerValue("TrainTroops", 0);
								if (this.int_4 > 0)
								{
									this.int_0 = 4;
								}
								else
								{
									this.bool_3 = base.GetBooleanValue("SwitchSides", 0);
									if (this.bool_3)
									{
										this.int_0 = 8;
									}
									else
									{
										this.bool_4 = base.GetBooleanValue("ShowWarBase", 0);
										if (this.bool_4)
										{
											this.int_0 = 9;
										}
										else
										{
											this.bool_6 = base.GetBooleanValue("OpenInfo", 0);
											if (this.bool_6)
											{
												this.int_0 = 11;
											}
											else
											{
												this.bool_7 = base.GetBooleanValue("ShowDonate", 0);
												if (this.bool_7)
												{
													this.int_0 = 10;
												}
												else
												{
													this.bool_5 = base.GetBooleanValue("WarStates", 0);
													if (this.bool_5)
													{
														this.int_0 = 12;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			this.int_5 = base.GetIntegerValue("Villagers", 0);
			if (this.int_5 > 0)
			{
				this.int_0 = 16;
			}
			this.bool_9 = base.GetBooleanValue("ForceCamera", 0);
			if (this.int_0 == -1)
			{
				Debugger.Error(string.Format("missions.csv: invalid mission ({0})", base.GetName()));
			}
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("RewardResource", 0), this);
			this.int_6 = base.GetIntegerValue("RewardResourceCount", 0);
			if (this.logicResourceData_0 != null)
			{
				if (this.int_6 != 0)
				{
					if (this.int_6 < 0)
					{
						Debugger.Error("missions.csv: RewardResourceCount is negative!");
						this.logicResourceData_0 = null;
						this.int_6 = 0;
					}
				}
				else
				{
					this.logicResourceData_0 = null;
				}
			}
			else if (this.int_6 != 0)
			{
				Debugger.Warning("missions.csv: RewardResourceCount defined but RewardResource is not!");
				this.int_6 = 0;
			}
			this.int_7 = base.GetIntegerValue("CustomData", 0);
			this.int_8 = base.GetIntegerValue("RewardXP", 0);
			if (this.int_8 < 0)
			{
				Debugger.Warning("missions.csv: RewardXP is negative!");
				this.int_8 = 0;
			}
			this.logicCharacterData_1 = LogicDataTables.GetCharacterByName(base.GetValue("RewardTroop", 0), this);
			this.int_9 = base.GetIntegerValue("RewardTroopCount", 0);
			if (this.logicCharacterData_1 != null)
			{
				if (this.int_9 != 0)
				{
					if (this.int_9 < 0)
					{
						Debugger.Error("missions.csv: RewardTroopCount is negative!");
						this.logicCharacterData_1 = null;
						this.int_9 = 0;
					}
				}
				else
				{
					this.logicCharacterData_1 = null;
				}
			}
			else if (this.int_9 != 0)
			{
				Debugger.Warning("missions.csv: RewardTroopCount defined but RewardTroop is not!");
				this.int_9 = 0;
			}
			this.int_10 = base.GetIntegerValue("Delay", 0);
			this.int_11 = base.GetIntegerValue("VillageType", 0);
			this.bool_11 = base.GetBooleanValue("FirstStep", 0);
			this.string_1 = base.GetValue("TutorialText", 0);
			int length = this.string_1.Length;
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x000513B8 File Offset: 0x0004F5B8
		public bool IsOpenForAvatar(LogicClientAvatar avatar)
		{
			if (!avatar.IsMissionCompleted(this))
			{
				if (avatar.GetExpLevel() >= 10 && this.int_1 - 1 > 1)
				{
					return false;
				}
				if (!this.bool_10)
				{
					for (int i = 0; i < this.logicArrayList_0.Size(); i++)
					{
						if (!avatar.IsMissionCompleted(this.logicArrayList_0[i]))
						{
							return false;
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x0000D51E File Offset: 0x0000B71E
		public int GetMissionType()
		{
			return this.int_0;
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x0000D526 File Offset: 0x0000B726
		public int GetCustomData()
		{
			return this.int_7;
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x0000D52E File Offset: 0x0000B72E
		public LogicCharacterData GetCharacterData()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x06001436 RID: 5174 RVA: 0x0000D536 File Offset: 0x0000B736
		public LogicCharacterData GetRewardCharacterData()
		{
			return this.logicCharacterData_1;
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x0000D53E File Offset: 0x0000B73E
		public LogicVillageObjectData GetFixVillageObjectData()
		{
			return this.logicVillageObjectData_0;
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x0000D546 File Offset: 0x0000B746
		public LogicBuildingData GetBuildBuildingData()
		{
			return this.logicBuildingData_0;
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x0000D54E File Offset: 0x0000B74E
		public LogicResourceData GetRewardResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x0000D556 File Offset: 0x0000B756
		public LogicNpcData GetAttackNpcData()
		{
			return this.logicNpcData_1;
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x0000D55E File Offset: 0x0000B75E
		public LogicNpcData GetDefendNpcData()
		{
			return this.logicNpcData_0;
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x0000D566 File Offset: 0x0000B766
		public int GetRewardResourceCount()
		{
			return this.int_6;
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x0000D56E File Offset: 0x0000B76E
		public int GetRewardCharacterCount()
		{
			return this.int_9;
		}

		// Token: 0x0600143E RID: 5182 RVA: 0x0000D576 File Offset: 0x0000B776
		public int GetRewardXp()
		{
			return this.int_8;
		}

		// Token: 0x0600143F RID: 5183 RVA: 0x0000D57E File Offset: 0x0000B77E
		public int GetBuildBuildingLevel()
		{
			return this.int_3;
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x0000D586 File Offset: 0x0000B786
		public int GetBuildBuildingCount()
		{
			return this.int_2;
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x0000D58E File Offset: 0x0000B78E
		public int GetTrainTroopCount()
		{
			return this.int_4;
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x0000D596 File Offset: 0x0000B796
		public int GetMissionCategory()
		{
			return this.int_1;
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x0000D59E File Offset: 0x0000B79E
		public int GetVillageType()
		{
			return this.int_11;
		}

		// Token: 0x04000A73 RID: 2675
		private int int_0;

		// Token: 0x04000A74 RID: 2676
		private int int_1;

		// Token: 0x04000A75 RID: 2677
		private int int_2;

		// Token: 0x04000A76 RID: 2678
		private int int_3;

		// Token: 0x04000A77 RID: 2679
		private int int_4;

		// Token: 0x04000A78 RID: 2680
		private int int_5;

		// Token: 0x04000A79 RID: 2681
		private int int_6;

		// Token: 0x04000A7A RID: 2682
		private int int_7;

		// Token: 0x04000A7B RID: 2683
		private int int_8;

		// Token: 0x04000A7C RID: 2684
		private int int_9;

		// Token: 0x04000A7D RID: 2685
		private int int_10;

		// Token: 0x04000A7E RID: 2686
		private int int_11;

		// Token: 0x04000A7F RID: 2687
		private bool bool_0;

		// Token: 0x04000A80 RID: 2688
		private bool bool_1;

		// Token: 0x04000A81 RID: 2689
		private bool bool_2;

		// Token: 0x04000A82 RID: 2690
		private bool bool_3;

		// Token: 0x04000A83 RID: 2691
		private bool bool_4;

		// Token: 0x04000A84 RID: 2692
		private bool bool_5;

		// Token: 0x04000A85 RID: 2693
		private bool bool_6;

		// Token: 0x04000A86 RID: 2694
		private bool bool_7;

		// Token: 0x04000A87 RID: 2695
		private bool bool_8;

		// Token: 0x04000A88 RID: 2696
		private bool bool_9;

		// Token: 0x04000A89 RID: 2697
		private bool bool_10;

		// Token: 0x04000A8A RID: 2698
		private bool bool_11;

		// Token: 0x04000A8B RID: 2699
		private string string_0;

		// Token: 0x04000A8C RID: 2700
		private string string_1;

		// Token: 0x04000A8D RID: 2701
		private LogicNpcData logicNpcData_0;

		// Token: 0x04000A8E RID: 2702
		private LogicNpcData logicNpcData_1;

		// Token: 0x04000A8F RID: 2703
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000A90 RID: 2704
		private LogicBuildingData logicBuildingData_0;

		// Token: 0x04000A91 RID: 2705
		private LogicVillageObjectData logicVillageObjectData_0;

		// Token: 0x04000A92 RID: 2706
		private LogicCharacterData logicCharacterData_1;

		// Token: 0x04000A93 RID: 2707
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000A94 RID: 2708
		private readonly LogicArrayList<LogicMissionData> logicArrayList_0;
	}
}
