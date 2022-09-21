using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A7 RID: 423
	public sealed class LogicHelpOpenedCommand : LogicCommand
	{
		// Token: 0x06001743 RID: 5955 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x06001744 RID: 5956 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x06001745 RID: 5957 RVA: 0x0000F3A7 File Offset: 0x0000D5A7
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.HELP_OPENED;
		}

		// Token: 0x06001746 RID: 5958 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001747 RID: 5959 RVA: 0x0000F3AE File Offset: 0x0000D5AE
		public override int Execute(LogicLevel level)
		{
			level.SetHelpOpened(true);
			return 0;
		}
	}
}
