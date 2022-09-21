using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Calendar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D2 RID: 466
	public sealed class LogicSpeedUpVillage2LootTimerCommand : LogicCommand
	{
		// Token: 0x0600185F RID: 6239 RVA: 0x0000EC66 File Offset: 0x0000CE66
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x0000EC6F File Offset: 0x0000CE6F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x0001020E File Offset: 0x0000E40E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_VILLAGE_2_LOOT_TIMER;
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x0005B990 File Offset: 0x00059B90
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar == null)
			{
				return -2;
			}
			if (playerAvatar.GetVariableByName("LootLimitCooldown") != 1)
			{
				return -3;
			}
			LogicConfiguration configuration = level.GetGameMode().GetConfiguration();
			if (configuration == null)
			{
				return -4;
			}
			LogicCalendar calendar = level.GetGameMode().GetCalendar();
			if (calendar == null)
			{
				return -5;
			}
			int remainingLootLimitTime = playerAvatar.GetRemainingLootLimitTime();
			int num = LogicCalendar.GetDuelLootLimitCooldownInMinutes(calendar, configuration) * 60;
			int duelBonusMaxDiamondCostPercent = LogicCalendar.GetDuelBonusMaxDiamondCostPercent(calendar, configuration);
			int count = LogicMath.Max(LogicGamePlayUtil.GetLeagueVillage2(playerAvatar.GetDuelScore()).GetMaxDiamondCost() * duelBonusMaxDiamondCostPercent * remainingLootLimitTime / num / 100, 1);
			if (playerAvatar.HasEnoughDiamonds(count, true, level))
			{
				playerAvatar.UseDiamonds(count);
				playerAvatar.GetChangeListener().DiamondPurchaseMade(18, 0, remainingLootLimitTime, count, level.GetVillageType());
				playerAvatar.FastForwardLootLimit(remainingLootLimitTime);
				return 0;
			}
			return -3;
		}
	}
}
