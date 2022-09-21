using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019A RID: 410
	public sealed class LogicCancelUnitProductionCommand : LogicCommand
	{
		// Token: 0x060016EF RID: 5871 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicCancelUnitProductionCommand()
		{
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x0000EFF6 File Offset: 0x0000D1F6
		public LogicCancelUnitProductionCommand(int count, LogicCombatItemData combatItemData, int gameObjectId, int slotId)
		{
			this.int_1 = count;
			this.logicCombatItemData_0 = combatItemData;
			this.int_2 = gameObjectId;
			this.int_3 = slotId;
			this.logicCombatItemType_0 = this.logicCombatItemData_0.GetCombatItemType();
		}

		// Token: 0x060016F1 RID: 5873 RVA: 0x00057C30 File Offset: 0x00055E30
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.logicCombatItemType_0 = (LogicCombatItemType)stream.ReadInt();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (this.logicCombatItemType_0 != LogicCombatItemType.CHARACTER) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.int_1 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016F2 RID: 5874 RVA: 0x00057C94 File Offset: 0x00055E94
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt((int)this.logicCombatItemType_0);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x060016F3 RID: 5875 RVA: 0x0000F02C File Offset: 0x0000D22C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_UNIT_PRODUCTION;
		}

		// Token: 0x060016F4 RID: 5876 RVA: 0x0000F033 File Offset: 0x0000D233
		public override void Destruct()
		{
			base.Destruct();
			this.int_2 = 0;
			this.logicCombatItemType_0 = LogicCombatItemType.CHARACTER;
			this.int_3 = 0;
			this.int_1 = 0;
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x060016F5 RID: 5877 RVA: 0x0000F05E File Offset: 0x0000D25E
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				throw new NotImplementedException();
			}
			return this.NewTrainingUnit(level);
		}

		// Token: 0x060016F6 RID: 5878 RVA: 0x00057CE4 File Offset: 0x00055EE4
		public int NewTrainingUnit(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			if (this.logicCombatItemData_0 == null)
			{
				return -1;
			}
			LogicUnitProduction logicUnitProduction = (this.logicCombatItemData_0.GetCombatItemType() == LogicCombatItemType.SPELL) ? level.GetGameObjectManager().GetSpellProduction() : level.GetGameObjectManager().GetUnitProduction();
			if (logicUnitProduction.IsLocked())
			{
				return -23;
			}
			if (this.int_1 > 0 && this.logicCombatItemData_0.GetDataType() == logicUnitProduction.GetUnitProductionType())
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				LogicResourceData trainingResource = this.logicCombatItemData_0.GetTrainingResource();
				int count = LogicMath.Max(level.GetGameMode().GetCalendar().GetTrainingCost(this.logicCombatItemData_0, playerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0)) * ((this.logicCombatItemData_0.GetDataType() != LogicDataType.CHARACTER) ? LogicDataTables.GetGlobals().GetSpellCancelMultiplier() : LogicDataTables.GetGlobals().GetTrainCancelMultiplier()) / 100, 0);
				while (logicUnitProduction.RemoveUnit(this.logicCombatItemData_0, this.int_3))
				{
					playerAvatar.CommodityCountChangeHelper(0, trainingResource, count);
					int num = this.int_1 - 1;
					this.int_1 = num;
					if (num <= 0)
					{
						break;
					}
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CBC RID: 3260
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000CBD RID: 3261
		private LogicCombatItemType logicCombatItemType_0;

		// Token: 0x04000CBE RID: 3262
		private int int_1;

		// Token: 0x04000CBF RID: 3263
		private int int_2;

		// Token: 0x04000CC0 RID: 3264
		private int int_3;
	}
}
