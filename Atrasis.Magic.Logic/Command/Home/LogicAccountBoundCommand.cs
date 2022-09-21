using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018A RID: 394
	public sealed class LogicAccountBoundCommand : LogicCommand
	{
		// Token: 0x06001681 RID: 5761 RVA: 0x0000EB14 File Offset: 0x0000CD14
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001682 RID: 5762 RVA: 0x0000EB29 File Offset: 0x0000CD29
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001683 RID: 5763 RVA: 0x0000EB3E File Offset: 0x0000CD3E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ACCOUNT_BOUND;
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x0000EB4D File Offset: 0x0000CD4D
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().SetAccountBound();
			level.GetAchievementManager().RefreshStatus();
			return 0;
		}

		// Token: 0x04000CA3 RID: 3235
		private int int_1;
	}
}
