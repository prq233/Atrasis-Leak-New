using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018B RID: 395
	public sealed class LogicAllianceLevelSeenCommand : LogicCommand
	{
		// Token: 0x06001687 RID: 5767 RVA: 0x0000EB6E File Offset: 0x0000CD6E
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001688 RID: 5768 RVA: 0x0000EB83 File Offset: 0x0000CD83
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001689 RID: 5769 RVA: 0x0000EB98 File Offset: 0x0000CD98
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_LEVEL_SEEN;
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x0000EB9F File Offset: 0x0000CD9F
		public override int Execute(LogicLevel level)
		{
			level.SetLastAllianceLevel(this.int_1);
			return 0;
		}

		// Token: 0x04000CA4 RID: 3236
		private int int_1;
	}
}
