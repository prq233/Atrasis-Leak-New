using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017E RID: 382
	public class LogicDuelScoreChangedCommand : LogicServerCommand
	{
		// Token: 0x0600162F RID: 5679 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001630 RID: 5680 RVA: 0x0000E82B File Offset: 0x0000CA2B
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x0000E84C File Offset: 0x0000CA4C
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x06001632 RID: 5682 RVA: 0x00055BC0 File Offset: 0x00053DC0
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetDuelScore(playerAvatar.GetDuelScore() + this.int_2);
				switch (this.int_3)
				{
				case 0:
					playerAvatar.SetDuelLoseCount(playerAvatar.GetDuelLoseCount() + 1);
					break;
				case 1:
					playerAvatar.SetDuelWinCount(playerAvatar.GetDuelWinCount() + 1);
					break;
				case 2:
					playerAvatar.SetDuelDrawCount(playerAvatar.GetDuelDrawCount() + 1);
					break;
				}
				level.GetAchievementManager().RefreshStatus();
				LogicAvatarChangeListener homeOwnerAvatarChangeListener = level.GetHomeOwnerAvatarChangeListener();
				if (homeOwnerAvatarChangeListener != null)
				{
					homeOwnerAvatarChangeListener.DuelScoreChanged(playerAvatar.GetAllianceId(), this.int_2, this.int_3, this.bool_0);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x00007139 File Offset: 0x00005339
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DUEL_SCORE_CHANGED;
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x0000E86D File Offset: 0x0000CA6D
		public void SetData(int scoreGain, int resultType, bool attacker)
		{
			this.int_2 = scoreGain;
			this.int_3 = resultType;
			this.bool_0 = attacker;
		}

		// Token: 0x04000C8D RID: 3213
		private int int_2;

		// Token: 0x04000C8E RID: 3214
		private int int_3;

		// Token: 0x04000C8F RID: 3215
		private bool bool_0;
	}
}
