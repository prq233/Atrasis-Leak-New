using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B2 RID: 434
	public sealed class LogicNewsSeenCommand : LogicCommand
	{
		// Token: 0x0600178A RID: 6026 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicNewsSeenCommand()
		{
		}

		// Token: 0x0600178B RID: 6027 RVA: 0x0000F7DE File Offset: 0x0000D9DE
		public LogicNewsSeenCommand(int lastSeenNews)
		{
			this.int_1 = lastSeenNews;
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x0000F7ED File Offset: 0x0000D9ED
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x0000F802 File Offset: 0x0000DA02
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600178E RID: 6030 RVA: 0x0000F817 File Offset: 0x0000DA17
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.NEWS_SEEN;
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x0000F81E File Offset: 0x0000DA1E
		public override int Execute(LogicLevel level)
		{
			level.SetLastSeenNews(this.int_1);
			return 0;
		}

		// Token: 0x04000CED RID: 3309
		private int int_1;
	}
}
