using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001E9 RID: 489
	public sealed class LogicEndCombatCommand : LogicCommand
	{
		// Token: 0x060018FF RID: 6399 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x00010979 File Offset: 0x0000EB79
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.END_COMBAT;
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001903 RID: 6403 RVA: 0x00010980 File Offset: 0x0000EB80
		public override int Execute(LogicLevel level)
		{
			if (level.GetBattleLog().GetBattleStarted())
			{
				level.EndBattle();
				level.GetGameListener().BattleEndedByPlayer();
				return 0;
			}
			return -1;
		}
	}
}
