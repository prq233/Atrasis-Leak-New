using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000173 RID: 371
	public class LogicChallengeUpdatedCommand : LogicServerCommand
	{
		// Token: 0x060015E4 RID: 5604 RVA: 0x0000E452 File Offset: 0x0000C652
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.logicLong_1 = null;
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x0000E468 File Offset: 0x0000C668
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.int_2 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_1 = stream.ReadLong();
			}
			base.Decode(stream);
		}

		// Token: 0x060015E6 RID: 5606 RVA: 0x00054B38 File Offset: 0x00052D38
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.logicLong_1 != null);
			if (this.logicLong_1 != null)
			{
				encoder.WriteLong(this.logicLong_1);
			}
			base.Encode(encoder);
		}

		// Token: 0x060015E7 RID: 5607 RVA: 0x00054B88 File Offset: 0x00052D88
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetChallengeId(this.logicLong_0);
				playerAvatar.SetChallengeState(this.int_2);
				level.GetGameListener().ChallengeStateChanged(this.logicLong_0, this.logicLong_1, this.int_2);
				return 0;
			}
			return -1;
		}

		// Token: 0x060015E8 RID: 5608 RVA: 0x00007713 File Offset: 0x00005913
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHALLENGE_UPDATED;
		}

		// Token: 0x04000C6D RID: 3181
		private LogicLong logicLong_0;

		// Token: 0x04000C6E RID: 3182
		private LogicLong logicLong_1;

		// Token: 0x04000C6F RID: 3183
		private int int_2;
	}
}
