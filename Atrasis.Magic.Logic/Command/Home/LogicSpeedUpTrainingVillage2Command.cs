using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CF RID: 463
	public sealed class LogicSpeedUpTrainingVillage2Command : LogicCommand
	{
		// Token: 0x0600184C RID: 6220 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x000101B1 File Offset: 0x0000E3B1
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_TRAINING_VILLAGE_2;
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x0005B7E4 File Offset: 0x000599E4
		public override int Execute(LogicLevel level)
		{
			LogicArrayList<LogicComponent> components = level.GetComponentManager().GetComponents(LogicComponentType.VILLAGE2_UNIT);
			int num = 0;
			for (int i = 0; i < components.Size(); i++)
			{
				num += ((LogicVillage2UnitComponent)components[i]).GetRemainingSecs();
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(num, 4, 1);
			if (!playerAvatar.HasEnoughDiamonds(speedUpCost, true, level))
			{
				return -1;
			}
			playerAvatar.UseDiamonds(speedUpCost);
			for (int j = 0; j < components.Size(); j++)
			{
				LogicVillage2UnitComponent logicVillage2UnitComponent = (LogicVillage2UnitComponent)components[j];
				if (logicVillage2UnitComponent.GetCurrentlyTrainedUnit() != null && logicVillage2UnitComponent.GetRemainingSecs() > 0)
				{
					logicVillage2UnitComponent.ProductionCompleted();
				}
			}
			playerAvatar.GetChangeListener().DiamondPurchaseMade(16, 0, 0, speedUpCost, 1);
			return 0;
		}
	}
}
