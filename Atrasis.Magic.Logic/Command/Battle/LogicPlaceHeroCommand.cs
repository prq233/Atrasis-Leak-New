using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Battle;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EC RID: 492
	public sealed class LogicPlaceHeroCommand : LogicCommand
	{
		// Token: 0x06001916 RID: 6422 RVA: 0x00010A90 File Offset: 0x0000EC90
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicHeroData_0 = (LogicHeroData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.HERO);
			base.Decode(stream);
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x00010AC4 File Offset: 0x0000ECC4
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicHeroData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001918 RID: 6424 RVA: 0x00010AF1 File Offset: 0x0000ECF1
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PLACE_HERO;
		}

		// Token: 0x06001919 RID: 6425 RVA: 0x00010AF8 File Offset: 0x0000ECF8
		public override void Destruct()
		{
			base.Destruct();
			this.logicHeroData_0 = null;
		}

		// Token: 0x0600191A RID: 6426 RVA: 0x0005F724 File Offset: 0x0005D924
		public override int Execute(LogicLevel level)
		{
			if (!level.IsReadyForAttack())
			{
				return -1;
			}
			if (this.logicHeroData_0 == null || level.IsAttackerHeroPlaced(this.logicHeroData_0))
			{
				return -5;
			}
			if (level.GetVillageType() != this.logicHeroData_0.GetVillageType())
			{
				return -23;
			}
			int x = this.int_1 >> 9;
			int y = this.int_2 >> 9;
			if (level.GetTileMap().GetTile(x, y) == null)
			{
				return -3;
			}
			if (!level.GetTileMap().IsPassablePathFinder(this.int_1 >> 8, this.int_2 >> 8))
			{
				return -2;
			}
			if (!level.GetTileMap().IsValidAttackPos(x, y))
			{
				return -4;
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && playerAvatar.IsHeroAvailableForAttack(this.logicHeroData_0))
			{
				if (level.GetBattleLog() != null && !level.GetBattleLog().HasDeployedUnits() && level.GetTotalAttackerHeroPlaced() == 0)
				{
					level.UpdateLastUsedArmy();
				}
				if (level.GetGameMode().IsInAttackPreparationMode())
				{
					level.GetGameMode().EndAttackPreparation();
				}
				int heroHealth = playerAvatar.GetHeroHealth(this.logicHeroData_0);
				int unitUpgradeLevel = playerAvatar.GetUnitUpgradeLevel(this.logicHeroData_0);
				level.SetAttackerHeroPlaced(this.logicHeroData_0, LogicPlaceHeroCommand.PlaceHero(this.logicHeroData_0, level, this.int_1, this.int_2, this.logicHeroData_0.GetHeroHitpoints(heroHealth, unitUpgradeLevel), unitUpgradeLevel));
				return 0;
			}
			return -5;
		}

		// Token: 0x0600191B RID: 6427 RVA: 0x0005F884 File Offset: 0x0005DA84
		public static LogicCharacter PlaceHero(LogicHeroData data, LogicLevel level, int x, int y, int hitpoints, int upgLevel)
		{
			LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(data, level, level.GetVillageType());
			logicCharacter.SetUpgradeLevel(upgLevel);
			logicCharacter.GetHitpointComponent().SetHitpoints(hitpoints);
			logicCharacter.SetInitialPosition(x, y);
			if (data.IsJumper())
			{
				logicCharacter.GetMovementComponent().EnableJump(3600000);
				logicCharacter.GetCombatComponent().RefreshTarget(true);
			}
			level.GetGameObjectManager().AddGameObject(logicCharacter, -1);
			level.GetGameListener().AttackerPlaced(data);
			LogicBattleLog battleLog = level.GetBattleLog();
			if (battleLog != null)
			{
				battleLog.IncrementDeployedAttackerUnits(data, 1);
				battleLog.SetCombatItemLevel(data, upgLevel);
			}
			return logicCharacter;
		}

		// Token: 0x0600191C RID: 6428 RVA: 0x0005F91C File Offset: 0x0005DB1C
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicPlaceHeroCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("d");
			if (jsonnumber != null)
			{
				this.logicHeroData_0 = (LogicHeroData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.HERO);
			}
			if (this.logicHeroData_0 == null)
			{
				Debugger.Error("Replay LogicPlaceHeroCommand load failed! Hero is NULL!");
			}
			this.int_1 = jsonRoot.GetJSONNumber("x").GetIntValue();
			this.int_2 = jsonRoot.GetJSONNumber("y").GetIntValue();
		}

		// Token: 0x0600191D RID: 6429 RVA: 0x0005F9B0 File Offset: 0x0005DBB0
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicHeroData_0 != null)
			{
				logicJSONObject.Put("d", new LogicJSONNumber(this.logicHeroData_0.GetGlobalID()));
			}
			logicJSONObject.Put("x", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("y", new LogicJSONNumber(this.int_2));
			return logicJSONObject;
		}

		// Token: 0x04000D9C RID: 3484
		private int int_1;

		// Token: 0x04000D9D RID: 3485
		private int int_2;

		// Token: 0x04000D9E RID: 3486
		private LogicHeroData logicHeroData_0;
	}
}
