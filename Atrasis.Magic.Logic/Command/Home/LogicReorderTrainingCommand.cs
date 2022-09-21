using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B7 RID: 439
	public sealed class LogicReorderTrainingCommand : LogicCommand
	{
		// Token: 0x060017A9 RID: 6057 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicReorderTrainingCommand()
		{
		}

		// Token: 0x060017AA RID: 6058 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
		public LogicReorderTrainingCommand(bool spellProduction, int slotIdx, int dragIdx)
		{
			this.bool_0 = spellProduction;
			this.int_1 = slotIdx;
			this.int_2 = dragIdx;
		}

		// Token: 0x060017AB RID: 6059 RVA: 0x0000F9E5 File Offset: 0x0000DBE5
		public override void Decode(ByteStream stream)
		{
			this.bool_0 = stream.ReadBoolean();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x0000FA12 File Offset: 0x0000DC12
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x0000FA3F File Offset: 0x0000DC3F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REORDER_TRAINING;
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x0005A4C0 File Offset: 0x000586C0
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -50;
			}
			if (!LogicDataTables.GetGlobals().UseDragInTraining() && !LogicDataTables.GetGlobals().UseDragInTrainingFix() && !LogicDataTables.GetGlobals().UseDragInTrainingFix2())
			{
				return -51;
			}
			LogicUnitProduction logicUnitProduction = this.bool_0 ? level.GetGameObjectManager().GetSpellProduction() : level.GetGameObjectManager().GetUnitProduction();
			if (logicUnitProduction.GetSlotCount() <= this.int_1)
			{
				return -1;
			}
			if (logicUnitProduction.GetSlotCount() < this.int_2)
			{
				return -2;
			}
			if (this.int_1 < 0)
			{
				return -3;
			}
			if (this.int_2 < 0)
			{
				return -4;
			}
			if (!logicUnitProduction.DragSlot(this.int_1, this.int_2))
			{
				return -5;
			}
			return 0;
		}

		// Token: 0x04000CF9 RID: 3321
		private bool bool_0;

		// Token: 0x04000CFA RID: 3322
		private int int_1;

		// Token: 0x04000CFB RID: 3323
		private int int_2;
	}
}
