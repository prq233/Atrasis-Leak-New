using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000197 RID: 407
	public sealed class LogicCancelChallengeCommand : LogicCommand
	{
		// Token: 0x060016DB RID: 5851 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060016DC RID: 5852 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060016DD RID: 5853 RVA: 0x0000EF52 File Offset: 0x0000D152
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_CHALLENGE;
		}

		// Token: 0x060016DE RID: 5854 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016DF RID: 5855 RVA: 0x0000EF59 File Offset: 0x0000D159
		public override int Execute(LogicLevel level)
		{
			if (LogicDataTables.GetGlobals().UseVersusBattle())
			{
				level.GetGameListener().CancelFriendlyVersusBattle();
				return 0;
			}
			return -2;
		}
	}
}
