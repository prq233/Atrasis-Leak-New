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
	// Token: 0x020001E6 RID: 486
	public sealed class LogicCastSpellCommand : LogicCommand
	{
		// Token: 0x060018E6 RID: 6374 RVA: 0x0005EAC8 File Offset: 0x0005CCC8
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicSpellData_0 = (LogicSpellData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.SPELL);
			this.bool_0 = stream.ReadBoolean();
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060018E7 RID: 6375 RVA: 0x0005EB20 File Offset: 0x0005CD20
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicSpellData_0);
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x060018E8 RID: 6376 RVA: 0x000108D9 File Offset: 0x0000EAD9
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CAST_SPELL;
		}

		// Token: 0x060018E9 RID: 6377 RVA: 0x000108E0 File Offset: 0x0000EAE0
		public override void Destruct()
		{
			base.Destruct();
			this.logicSpellData_0 = null;
		}

		// Token: 0x060018EA RID: 6378 RVA: 0x0005EB70 File Offset: 0x0005CD70
		public override int Execute(LogicLevel level)
		{
			if (!level.IsReadyForAttack())
			{
				return -1;
			}
			int x = this.int_1 >> 9;
			int y = this.int_2 >> 9;
			if (level.GetTileMap().GetTile(x, y) == null)
			{
				return -3;
			}
			if (level.GetVillageType() != 0)
			{
				Debugger.Error("not available for village");
				return -23;
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && (this.bool_0 ? playerAvatar.GetAllianceUnitCount(this.logicSpellData_0, this.int_3) : playerAvatar.GetUnitCount(this.logicSpellData_0)) > 0)
			{
				if (level.GetBattleLog() != null && !level.GetBattleLog().HasDeployedUnits() && level.GetTotalAttackerHeroPlaced() == 0)
				{
					level.UpdateLastUsedArmy();
				}
				if (level.GetGameMode().IsInAttackPreparationMode())
				{
					level.GetGameMode().EndAttackPreparation();
				}
				LogicCastSpellCommand.CastSpell(playerAvatar, this.logicSpellData_0, this.bool_0, this.int_3, level, this.int_1, this.int_2);
				return 0;
			}
			return -3;
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x0005EC68 File Offset: 0x0005CE68
		public static LogicSpell CastSpell(LogicAvatar avatar, LogicSpellData spellData, bool allianceSpell, int upgLevel, LogicLevel level, int x, int y)
		{
			if (allianceSpell)
			{
				avatar.RemoveAllianceUnit(spellData, upgLevel);
			}
			else
			{
				avatar.CommodityCountChangeHelper(0, spellData, -1);
			}
			if (!allianceSpell)
			{
				upgLevel = avatar.GetUnitUpgradeLevel(spellData);
			}
			LogicSpell logicSpell = (LogicSpell)LogicGameObjectFactory.CreateGameObject(spellData, level, level.GetVillageType());
			logicSpell.SetUpgradeLevel(upgLevel);
			logicSpell.SetInitialPosition(x, y);
			level.GetGameObjectManager().AddGameObject(logicSpell, -1);
			level.GetGameListener().AttackerPlaced(spellData);
			LogicBattleLog battleLog = level.GetBattleLog();
			if (battleLog != null)
			{
				battleLog.IncrementCastedSpells(spellData, 1);
				battleLog.SetCombatItemLevel(spellData, upgLevel);
			}
			return logicSpell;
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x0005ECF4 File Offset: 0x0005CEF4
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicCastSpellCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("d");
			if (jsonnumber != null)
			{
				this.logicSpellData_0 = (LogicSpellData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.SPELL);
			}
			if (this.logicSpellData_0 == null)
			{
				Debugger.Error("Replay LogicCastSpellCommand load failed! Data is NULL!");
			}
			this.int_1 = jsonRoot.GetJSONNumber("x").GetIntValue();
			this.int_2 = jsonRoot.GetJSONNumber("y").GetIntValue();
			LogicJSONNumber jsonnumber2 = jsonRoot.GetJSONNumber("dl");
			if (jsonnumber2 != null)
			{
				this.bool_0 = true;
				this.int_3 = jsonnumber2.GetIntValue();
			}
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x0005EDA8 File Offset: 0x0005CFA8
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicSpellData_0 != null)
			{
				logicJSONObject.Put("d", new LogicJSONNumber(this.logicSpellData_0.GetGlobalID()));
			}
			logicJSONObject.Put("x", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("y", new LogicJSONNumber(this.int_2));
			if (this.bool_0)
			{
				logicJSONObject.Put("dl", new LogicJSONNumber(this.int_3));
			}
			return logicJSONObject;
		}

		// Token: 0x04000D8F RID: 3471
		private int int_1;

		// Token: 0x04000D90 RID: 3472
		private int int_2;

		// Token: 0x04000D91 RID: 3473
		private int int_3;

		// Token: 0x04000D92 RID: 3474
		private bool bool_0;

		// Token: 0x04000D93 RID: 3475
		private LogicSpellData logicSpellData_0;
	}
}
