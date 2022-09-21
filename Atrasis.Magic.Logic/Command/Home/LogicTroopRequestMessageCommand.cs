using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DD RID: 477
	public sealed class LogicTroopRequestMessageCommand : LogicCommand
	{
		// Token: 0x060018A8 RID: 6312 RVA: 0x0001064F File Offset: 0x0000E84F
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x00010669 File Offset: 0x0000E869
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x0001067E File Offset: 0x0000E87E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TROOP_REQUEST_MESSAGE;
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x00010685 File Offset: 0x0000E885
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x00010694 File Offset: 0x0000E894
		public override int Execute(LogicLevel level)
		{
			level.SetTroopRequestMessage(this.string_0);
			return 0;
		}

		// Token: 0x04000D3F RID: 3391
		private string string_0;
	}
}
