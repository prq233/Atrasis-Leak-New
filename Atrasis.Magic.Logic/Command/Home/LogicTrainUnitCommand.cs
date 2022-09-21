using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DA RID: 474
	public sealed class LogicTrainUnitCommand : LogicCommand
	{
		// Token: 0x06001893 RID: 6291 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicTrainUnitCommand()
		{
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x000104EF File Offset: 0x0000E6EF
		public LogicTrainUnitCommand(int count, LogicCombatItemData combatItemData, int gameObjectId, int slotId)
		{
			this.int_2 = count;
			this.logicCombatItemData_0 = combatItemData;
			this.int_3 = gameObjectId;
			this.int_4 = slotId;
			this.int_1 = ((this.logicCombatItemData_0.GetDataType() == LogicDataType.SPELL) ? 1 : 0);
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x0005C420 File Offset: 0x0005A620
		public override void Decode(ByteStream stream)
		{
			this.int_3 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (this.int_1 != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.int_2 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			LogicGlobals globals = LogicDataTables.GetGlobals();
			if (!globals.UseDragInTraining() && !globals.UseDragInTrainingFix() && !globals.UseDragInTrainingFix2())
			{
				this.int_4 = -1;
			}
			base.Decode(stream);
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x0005C4A8 File Offset: 0x0005A6A8
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_1);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_4);
			base.Encode(encoder);
		}

		// Token: 0x06001897 RID: 6295 RVA: 0x0001052D File Offset: 0x0000E72D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRAIN_UNIT;
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x00010534 File Offset: 0x0000E734
		public override void Destruct()
		{
			base.Destruct();
			this.int_3 = 0;
			this.int_1 = 0;
			this.int_4 = 0;
			this.int_2 = 0;
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x0001055F File Offset: 0x0000E75F
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() == 0)
			{
				if (LogicDataTables.GetGlobals().UseNewTraining())
				{
					return this.NewTrainingUnit(level);
				}
				if (this.int_3 == 0)
				{
					return -1;
				}
			}
			return -32;
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x0005C4F8 File Offset: 0x0005A6F8
		public int NewTrainingUnit(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			if (this.int_2 > 100)
			{
				Debugger.Error("LogicTraingUnitCommand - Count is too high");
				return -20;
			}
			LogicUnitProduction logicUnitProduction = (this.int_1 == 1) ? level.GetGameObjectManagerAt(0).GetSpellProduction() : level.GetGameObjectManagerAt(0).GetUnitProduction();
			if (this.int_2 > 0 && this.logicCombatItemData_0 != null)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				bool flag = false;
				int trainingCost = level.GetGameMode().GetCalendar().GetTrainingCost(this.logicCombatItemData_0, playerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0));
				int i = 0;
				while (i < this.int_2)
				{
					if (logicUnitProduction.CanAddUnitToQueue(this.logicCombatItemData_0, false))
					{
						if (playerAvatar.HasEnoughResources(this.logicCombatItemData_0.GetTrainingResource(), trainingCost, true, this, false))
						{
							playerAvatar.CommodityCountChangeHelper(0, this.logicCombatItemData_0.GetTrainingResource(), -trainingCost);
							if (this.int_4 == -1)
							{
								this.int_4 = logicUnitProduction.GetSlotCount();
							}
							logicUnitProduction.AddUnitToQueue(this.logicCombatItemData_0, this.int_4, false);
							flag = true;
							i++;
							continue;
						}
						if (!flag)
						{
							return -30;
						}
					}
					else if (!flag)
					{
						return -40;
					}
					return 0;
				}
				return 0;
			}
			return -50;
		}

		// Token: 0x04000D37 RID: 3383
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000D38 RID: 3384
		private int int_1;

		// Token: 0x04000D39 RID: 3385
		private int int_2;

		// Token: 0x04000D3A RID: 3386
		private int int_3;

		// Token: 0x04000D3B RID: 3387
		private int int_4;
	}
}
