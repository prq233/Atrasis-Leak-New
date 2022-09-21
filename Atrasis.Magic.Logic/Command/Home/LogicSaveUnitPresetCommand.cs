using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BD RID: 445
	public sealed class LogicSaveUnitPresetCommand : LogicCommand
	{
		// Token: 0x060017D0 RID: 6096 RVA: 0x0000FB8B File Offset: 0x0000DD8B
		public LogicSaveUnitPresetCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicDataSlot>();
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x0005AC74 File Offset: 0x00058E74
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				LogicDataSlot logicDataSlot = new LogicDataSlot(null, 0);
				logicDataSlot.Decode(stream);
				this.logicArrayList_0.Add(logicDataSlot);
				i++;
			}
			base.Decode(stream);
		}

		// Token: 0x060017D2 RID: 6098 RVA: 0x0005ACC4 File Offset: 0x00058EC4
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].Encode(encoder);
			}
			base.Encode(encoder);
		}

		// Token: 0x060017D3 RID: 6099 RVA: 0x0000FB9E File Offset: 0x0000DD9E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SAVE_UNIT_PRESET;
		}

		// Token: 0x060017D4 RID: 6100 RVA: 0x0000FBA5 File Offset: 0x0000DDA5
		public override void Destruct()
		{
			base.Destruct();
			while (this.logicArrayList_0.Size() > 0)
			{
				this.logicArrayList_0[0].Destruct();
				this.logicArrayList_0.Remove(0);
			}
			this.logicLevel_0 = null;
		}

		// Token: 0x060017D5 RID: 6101 RVA: 0x0005AD20 File Offset: 0x00058F20
		public override int Execute(LogicLevel level)
		{
			this.logicLevel_0 = level;
			if (!LogicDataTables.GetGlobals().EnablePresets() || level.GetHomeOwnerAvatar().GetTownHallLevel() < LogicDataTables.GetGlobals().GetEnablePresetsTownHallLevel())
			{
				return -1;
			}
			if (this.int_1 <= 3)
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
				LogicComponentManager componentManager = level.GetComponentManager();
				int totalMaxHousing = componentManager.GetTotalMaxHousing(LogicCombatItemType.CHARACTER);
				int i = 0;
				int num = 0;
				while (i < table.GetItemCount())
				{
					LogicCharacterData logicCharacterData = (LogicCharacterData)table.GetItemAt(i);
					if (level.GetGameMode().GetCalendar().IsProductionEnabled(logicCharacterData) && !logicCharacterData.IsSecondaryTroop())
					{
						int num2 = 0;
						if (this.logicArrayList_0.Size() > 0)
						{
							for (int j = 0; j < this.logicArrayList_0.Size(); j++)
							{
								if (this.logicArrayList_0[j].GetData() == logicCharacterData)
								{
									num2 = this.logicArrayList_0[j].GetCount();
									break;
								}
							}
						}
						num += num2 * logicCharacterData.GetHousingSpace();
						if (num <= totalMaxHousing && this.IsUnlocked(logicCharacterData))
						{
							this.SetUnitPresetCount(logicCharacterData, num2);
						}
						else
						{
							this.SetUnitPresetCount(logicCharacterData, 0);
						}
					}
					i++;
				}
				table = LogicDataTables.GetTable(LogicDataType.SPELL);
				totalMaxHousing = componentManager.GetTotalMaxHousing(LogicCombatItemType.CHARACTER);
				int k = 0;
				int num3 = 0;
				while (k < table.GetItemCount())
				{
					LogicSpellData logicSpellData = (LogicSpellData)table.GetItemAt(k);
					if (level.GetGameMode().GetCalendar().IsProductionEnabled(logicSpellData))
					{
						int num4 = 0;
						if (this.logicArrayList_0.Size() > 0)
						{
							for (int l = 0; l < this.logicArrayList_0.Size(); l++)
							{
								if (this.logicArrayList_0[l].GetData() == logicSpellData)
								{
									num4 = this.logicArrayList_0[l].GetCount();
									break;
								}
							}
						}
						num3 += num4 * logicSpellData.GetHousingSpace();
						if (num3 <= totalMaxHousing && this.IsUnlocked(logicSpellData))
						{
							this.SetUnitPresetCount(logicSpellData, num4);
						}
						else
						{
							this.SetUnitPresetCount(logicSpellData, 0);
						}
					}
					k++;
				}
				return 0;
			}
			return -2;
		}

		// Token: 0x060017D6 RID: 6102 RVA: 0x0000FBE1 File Offset: 0x0000DDE1
		public bool IsUnlocked(LogicCombatItemData data)
		{
			return data.IsUnlockedForProductionHouseLevel(this.logicLevel_0.GetGameObjectManager().GetHighestBuildingLevel(data.GetProductionHouseData()));
		}

		// Token: 0x060017D7 RID: 6103 RVA: 0x0005AF3C File Offset: 0x0005913C
		public void SetUnitPresetCount(LogicCombatItemData data, int count)
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			if (homeOwnerAvatar.GetUnitPresetCount(data, this.int_1) != count)
			{
				homeOwnerAvatar.SetUnitPresetCount(data, this.int_1, count);
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(3, data, count);
			}
		}

		// Token: 0x04000D07 RID: 3335
		private int int_1;

		// Token: 0x04000D08 RID: 3336
		private LogicLevel logicLevel_0;

		// Token: 0x04000D09 RID: 3337
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_0;
	}
}
