using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019B RID: 411
	public sealed class LogicCancelUpgradeUnitCommand : LogicCommand
	{
		// Token: 0x060016F7 RID: 5879 RVA: 0x0000F079 File Offset: 0x0000D279
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016F8 RID: 5880 RVA: 0x0000F08E File Offset: 0x0000D28E
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x0000F0A3 File Offset: 0x0000D2A3
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_UPGRADE_UNIT;
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x0000F0AA File Offset: 0x0000D2AA
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x00002B30 File Offset: 0x00000D30
		public override int Execute(LogicLevel level)
		{
			return -1;
		}

		// Token: 0x04000CC1 RID: 3265
		private int int_1;
	}
}
