using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000193 RID: 403
	public sealed class LogicBuyShieldCommand : LogicCommand
	{
		// Token: 0x060016C1 RID: 5825 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicBuyShieldCommand()
		{
		}

		// Token: 0x060016C2 RID: 5826 RVA: 0x0000EE26 File Offset: 0x0000D026
		public LogicBuyShieldCommand(LogicShieldData data)
		{
			this.logicShieldData_0 = data;
		}

		// Token: 0x060016C3 RID: 5827 RVA: 0x0000EE35 File Offset: 0x0000D035
		public override void Decode(ByteStream stream)
		{
			this.logicShieldData_0 = (LogicShieldData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.SHIELD);
			base.Decode(stream);
		}

		// Token: 0x060016C4 RID: 5828 RVA: 0x0000EE51 File Offset: 0x0000D051
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicShieldData_0);
			base.Encode(encoder);
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x0000EE66 File Offset: 0x0000D066
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_SHIELD;
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x0000EE6D File Offset: 0x0000D06D
		public override void Destruct()
		{
			base.Destruct();
			this.logicShieldData_0 = null;
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x000572F0 File Offset: 0x000554F0
		public override int Execute(LogicLevel level)
		{
			if (this.logicShieldData_0 != null && level.GetCooldownManager().GetCooldownSeconds(this.logicShieldData_0.GetGlobalID()) <= 0)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if ((this.logicShieldData_0.GetScoreLimit() > playerAvatar.GetScore() || this.logicShieldData_0.GetScoreLimit() <= 0) && playerAvatar.HasEnoughDiamonds(this.logicShieldData_0.GetDiamondsCost(), true, level))
				{
					LogicGameMode gameMode = level.GetGameMode();
					playerAvatar.UseDiamonds(this.logicShieldData_0.GetDiamondsCost());
					playerAvatar.GetChangeListener().DiamondPurchaseMade(6, this.logicShieldData_0.GetGlobalID(), this.logicShieldData_0.GetTimeHours() * 3600, this.logicShieldData_0.GetDiamondsCost(), level.GetVillageType());
					int num = gameMode.GetShieldRemainingSeconds() + this.logicShieldData_0.GetTimeHours() * 3600;
					int num2 = gameMode.GetGuardRemainingSeconds();
					if (this.logicShieldData_0.GetTimeHours() <= 0)
					{
						if (num > 0)
						{
							return -2;
						}
						num2 += this.logicShieldData_0.GetGuardTimeHours() * 3600;
					}
					else
					{
						LogicLeagueData leagueTypeData = playerAvatar.GetLeagueTypeData();
						if (playerAvatar.GetAttackShieldReduceCounter() != 0)
						{
							playerAvatar.SetAttackShieldReduceCounter(0);
							playerAvatar.GetChangeListener().AttackShieldReduceCounterChanged(0);
						}
						if (playerAvatar.GetDefenseVillageGuardCounter() != 0)
						{
							playerAvatar.SetDefenseVillageGuardCounter(0);
							playerAvatar.GetChangeListener().DefenseVillageGuardCounterChanged(0);
						}
						num2 += leagueTypeData.GetVillageGuardInMins() * 60;
					}
					int personalBreakCooldownSeconds;
					if (num <= 0)
					{
						personalBreakCooldownSeconds = LogicMath.Min(LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds() + this.logicShieldData_0.GetGuardTimeHours() * 3600, gameMode.GetPersonalBreakCooldownSeconds() + this.logicShieldData_0.GetGuardTimeHours() * 3600);
					}
					else
					{
						personalBreakCooldownSeconds = num + LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds();
					}
					gameMode.SetPersonalBreakCooldownSeconds(personalBreakCooldownSeconds);
					gameMode.SetShieldRemainingSeconds(num);
					gameMode.SetGuardRemainingSeconds(num2);
					level.GetHome().GetChangeListener().ShieldActivated(num, num2);
					level.GetCooldownManager().AddCooldown(this.logicShieldData_0.GetGlobalID(), this.logicShieldData_0.GetCooldownSecs());
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CB4 RID: 3252
		private LogicShieldData logicShieldData_0;
	}
}
