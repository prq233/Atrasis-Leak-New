using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CE RID: 462
	public sealed class LogicSpeedUpTrainingCommand : LogicCommand
	{
		// Token: 0x06001844 RID: 6212 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSpeedUpTrainingCommand()
		{
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x00010133 File Offset: 0x0000E333
		public LogicSpeedUpTrainingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x00010142 File Offset: 0x0000E342
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x00010163 File Offset: 0x0000E363
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x00010184 File Offset: 0x0000E384
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_TRAINING;
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x0001018B File Offset: 0x0000E38B
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 0)
			{
				return -32;
			}
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				throw new NotImplementedException();
			}
			return this.SpeedUpNewTrainingUnit(level);
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x0005B718 File Offset: 0x00059918
		public int SpeedUpNewTrainingUnit(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			LogicUnitProduction logicUnitProduction = this.bool_0 ? level.GetGameObjectManager().GetSpellProduction() : level.GetGameObjectManager().GetUnitProduction();
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			int num = LogicGamePlayUtil.GetSpeedUpCost(logicUnitProduction.GetTotalRemainingSeconds(), this.bool_0 ? 1 : 4, level.GetVillageType());
			if (!level.GetMissionManager().IsTutorialFinished() && num > 0 && LogicDataTables.GetGlobals().GetTutorialTrainingSpeedUpCost() >= 0)
			{
				num = LogicDataTables.GetGlobals().GetTutorialTrainingSpeedUpCost();
			}
			if (playerAvatar.HasEnoughDiamonds(num, true, level))
			{
				playerAvatar.UseDiamonds(num);
				logicUnitProduction.SpeedUp();
				playerAvatar.GetChangeListener().DiamondPurchaseMade((logicUnitProduction.GetUnitProductionType() == LogicDataType.CHARACTER) ? 2 : 7, 0, 0, num, level.GetVillageType());
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D24 RID: 3364
		private int int_1;

		// Token: 0x04000D25 RID: 3365
		private bool bool_0;
	}
}
