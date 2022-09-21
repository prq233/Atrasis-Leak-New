using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A1 RID: 417
	public sealed class LogicEditModeShownCommand : LogicCommand
	{
		// Token: 0x0600171F RID: 5919 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x06001721 RID: 5921 RVA: 0x0000F1D4 File Offset: 0x0000D3D4
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.EDIT_MODE_SHOWN;
		}

		// Token: 0x06001722 RID: 5922 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001723 RID: 5923 RVA: 0x0000F1DB File Offset: 0x0000D3DB
		public override int Execute(LogicLevel level)
		{
			level.SetEditModeShown();
			return 0;
		}
	}
}
