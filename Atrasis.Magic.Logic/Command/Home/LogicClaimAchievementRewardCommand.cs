using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019D RID: 413
	public sealed class LogicClaimAchievementRewardCommand : LogicCommand
	{
		// Token: 0x06001704 RID: 5892 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicClaimAchievementRewardCommand()
		{
		}

		// Token: 0x06001705 RID: 5893 RVA: 0x0000F0C0 File Offset: 0x0000D2C0
		public LogicClaimAchievementRewardCommand(LogicAchievementData achievementData)
		{
			this.logicAchievementData_0 = achievementData;
		}

		// Token: 0x06001706 RID: 5894 RVA: 0x0000F0CF File Offset: 0x0000D2CF
		public override void Decode(ByteStream stream)
		{
			this.logicAchievementData_0 = (LogicAchievementData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.ACHIEVEMENT);
			base.Decode(stream);
		}

		// Token: 0x06001707 RID: 5895 RVA: 0x0000F0EB File Offset: 0x0000D2EB
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicAchievementData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001708 RID: 5896 RVA: 0x0000F100 File Offset: 0x0000D300
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CLAIM_ACHIEVEMENT_REWARD;
		}

		// Token: 0x06001709 RID: 5897 RVA: 0x0000F107 File Offset: 0x0000D307
		public override void Destruct()
		{
			base.Destruct();
			this.logicAchievementData_0 = null;
		}

		// Token: 0x0600170A RID: 5898 RVA: 0x0005820C File Offset: 0x0005640C
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && this.logicAchievementData_0 != null && playerAvatar.IsAchievementCompleted(this.logicAchievementData_0) && !playerAvatar.IsAchievementRewardClaimed(this.logicAchievementData_0))
			{
				playerAvatar.XpGainHelper(this.logicAchievementData_0.GetExpReward());
				if (this.logicAchievementData_0.GetDiamondReward() > 0)
				{
					int diamondReward = this.logicAchievementData_0.GetDiamondReward();
					playerAvatar.SetDiamonds(playerAvatar.GetDiamonds() + diamondReward);
					playerAvatar.SetFreeDiamonds(playerAvatar.GetFreeDiamonds() + diamondReward);
					playerAvatar.GetChangeListener().FreeDiamondsAdded(diamondReward, 4);
				}
				playerAvatar.SetAchievementRewardClaimed(this.logicAchievementData_0, true);
				playerAvatar.GetChangeListener().CommodityCountChanged(1, this.logicAchievementData_0, 1);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CC8 RID: 3272
		private LogicAchievementData logicAchievementData_0;
	}
}
