using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A3 RID: 419
	public sealed class LogicEventSeenCommand : LogicCommand
	{
		// Token: 0x0600172B RID: 5931 RVA: 0x0000F268 File Offset: 0x0000D468
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600172C RID: 5932 RVA: 0x0000F27D File Offset: 0x0000D47D
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600172D RID: 5933 RVA: 0x0000F292 File Offset: 0x0000D492
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.EVENT_SEEN;
		}

		// Token: 0x0600172E RID: 5934 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x0000F299 File Offset: 0x0000D499
		public override int Execute(LogicLevel level)
		{
			level.GetGameMode().GetCalendar().SetEventSeenTime(this.int_1);
			return 0;
		}

		// Token: 0x04000CCF RID: 3279
		private int int_1;
	}
}
