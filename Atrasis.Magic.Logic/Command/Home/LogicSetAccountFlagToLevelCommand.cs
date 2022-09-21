using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C1 RID: 449
	public sealed class LogicSetAccountFlagToLevelCommand : LogicCommand
	{
		// Token: 0x060017EC RID: 6124 RVA: 0x0000FCC3 File Offset: 0x0000DEC3
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x0000FCE4 File Offset: 0x0000DEE4
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x0000FD05 File Offset: 0x0000DF05
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_ACCOUNT_FLAG_TO_LEVEL;
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x0005B274 File Offset: 0x00059474
		public override int Execute(LogicLevel level)
		{
			switch (this.int_1)
			{
			case 0:
				level.SetHelpOpened(this.bool_0);
				break;
			case 1:
				level.SetEditModeShown();
				break;
			case 2:
				level.SetShieldCostPopupShown(this.bool_0);
				break;
			case 3:
				break;
			default:
				return -1;
			}
			return 0;
		}

		// Token: 0x04000D0E RID: 3342
		private int int_1;

		// Token: 0x04000D0F RID: 3343
		private bool bool_0;
	}
}
