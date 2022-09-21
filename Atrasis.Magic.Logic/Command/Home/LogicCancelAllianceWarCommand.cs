using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000196 RID: 406
	public sealed class LogicCancelAllianceWarCommand : LogicCommand
	{
		// Token: 0x060016D5 RID: 5845 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060016D6 RID: 5846 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060016D7 RID: 5847 RVA: 0x0000EF38 File Offset: 0x0000D138
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_ALLIANCE_WAR;
		}

		// Token: 0x060016D8 RID: 5848 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0000EF3F File Offset: 0x0000D13F
		public override int Execute(LogicLevel level)
		{
			level.GetHomeOwnerAvatar().GetChangeListener().CancelWar();
			return 0;
		}
	}
}
