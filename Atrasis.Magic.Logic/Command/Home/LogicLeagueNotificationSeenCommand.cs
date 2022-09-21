using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A8 RID: 424
	public sealed class LogicLeagueNotificationSeenCommand : LogicCommand
	{
		// Token: 0x06001749 RID: 5961 RVA: 0x0000F3B8 File Offset: 0x0000D5B8
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0000F3D9 File Offset: 0x0000D5D9
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x0000F3FA File Offset: 0x0000D5FA
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.LEAGUE_NOTIFICATION_SEEN;
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x0000F401 File Offset: 0x0000D601
		public override int Execute(LogicLevel level)
		{
			level.SetLastLeagueRank(this.int_1);
			level.SetLastLeagueShuffle(false);
			level.SetLastSeasonSeen(this.int_2);
			return 0;
		}

		// Token: 0x04000CD3 RID: 3283
		private int int_1;

		// Token: 0x04000CD4 RID: 3284
		private int int_2;
	}
}
