using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018F RID: 399
	public sealed class LogicBreakShieldCommand : LogicCommand
	{
		// Token: 0x060016A6 RID: 5798 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060016A7 RID: 5799 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060016A8 RID: 5800 RVA: 0x0000EC78 File Offset: 0x0000CE78
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BREAK_SHIELD;
		}

		// Token: 0x060016A9 RID: 5801 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016AA RID: 5802 RVA: 0x00056BE0 File Offset: 0x00054DE0
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() == 0)
			{
				LogicGameMode gameMode = level.GetGameMode();
				if (gameMode.GetShieldRemainingSeconds() <= 0)
				{
					gameMode.SetShieldRemainingSeconds(0);
					gameMode.SetGuardRemainingSeconds(0);
					gameMode.GetLevel().GetHome().GetChangeListener().ShieldActivated(0, 0);
				}
				else
				{
					int guardRemainingSeconds = gameMode.GetGuardRemainingSeconds();
					gameMode.SetShieldRemainingSeconds(0);
					gameMode.SetGuardRemainingSeconds(guardRemainingSeconds);
					gameMode.SetPersonalBreakCooldownSeconds(LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds());
					level.GetHome().GetChangeListener().ShieldActivated(0, guardRemainingSeconds);
				}
				return 0;
			}
			return -32;
		}
	}
}
