using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018E RID: 398
	public sealed class LogicBoostTrainingCommand : LogicCommand
	{
		// Token: 0x0600169F RID: 5791 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicBoostTrainingCommand()
		{
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x0000EC26 File Offset: 0x0000CE26
		public LogicBoostTrainingCommand(int productionType)
		{
			this.int_1 = productionType;
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x0000EC35 File Offset: 0x0000CE35
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016A2 RID: 5794 RVA: 0x0000EC4A File Offset: 0x0000CE4A
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060016A3 RID: 5795 RVA: 0x0000EC5F File Offset: 0x0000CE5F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BOOST_TRAINING;
		}

		// Token: 0x060016A4 RID: 5796 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016A5 RID: 5797 RVA: 0x00056B48 File Offset: 0x00054D48
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			if (level.GetVillageType() != 0)
			{
				return -32;
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			LogicUnitProduction logicUnitProduction = (this.int_1 == 1) ? level.GetGameObjectManagerAt(0).GetSpellProduction() : level.GetGameObjectManagerAt(0).GetUnitProduction();
			if (!logicUnitProduction.CanBeBoosted())
			{
				return -1;
			}
			int boostCost = logicUnitProduction.GetBoostCost();
			if (playerAvatar.HasEnoughDiamonds(boostCost, true, level))
			{
				playerAvatar.UseDiamonds(boostCost);
				playerAvatar.GetChangeListener().DiamondPurchaseMade(15, 0, 0, boostCost, level.GetVillageType());
				logicUnitProduction.Boost();
				return 0;
			}
			return -2;
		}

		// Token: 0x04000CA8 RID: 3240
		private int int_1;
	}
}
