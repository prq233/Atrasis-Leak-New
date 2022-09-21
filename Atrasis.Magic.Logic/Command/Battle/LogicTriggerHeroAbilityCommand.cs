using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EE RID: 494
	public sealed class LogicTriggerHeroAbilityCommand : LogicCommand
	{
		// Token: 0x06001928 RID: 6440 RVA: 0x00010B9D File Offset: 0x0000ED9D
		public override void Decode(ByteStream stream)
		{
			this.logicHeroData_0 = (LogicHeroData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.HERO);
			base.Decode(stream);
		}

		// Token: 0x06001929 RID: 6441 RVA: 0x00010BB9 File Offset: 0x0000EDB9
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicHeroData_0);
			base.Encode(encoder);
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x00010BCE File Offset: 0x0000EDCE
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRIGGER_HERO_ABILITY;
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x00010BD5 File Offset: 0x0000EDD5
		public override void Destruct()
		{
			base.Destruct();
			this.logicHeroData_0 = null;
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x0005FC08 File Offset: 0x0005DE08
		public override int Execute(LogicLevel level)
		{
			LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
				if (logicCharacter.GetHitpointComponent().GetTeam() == 0 && logicCharacter.IsHero() && logicCharacter.GetData() == this.logicHeroData_0 && logicCharacter.GetHitpointComponent().GetHitpoints() > 0 && this.logicHeroData_0.HasAbility(logicCharacter.GetUpgradeLevel()) && ((!this.logicHeroData_0.HasOnceAbility() && logicCharacter.GetAbilityCooldown() == 0) || (this.logicHeroData_0.HasOnceAbility() && !logicCharacter.IsAbilityUsed())))
				{
					logicCharacter.StartAbility();
				}
			}
			return 0;
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x0005FCBC File Offset: 0x0005DEBC
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicTriggerHeroAbility load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("d");
			if (jsonnumber != null)
			{
				this.logicHeroData_0 = (LogicHeroData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.HERO);
			}
			if (this.logicHeroData_0 == null)
			{
				Debugger.Error("Replay LogicTriggerHeroAbility load failed! Hero is NULL!");
			}
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x0005FD24 File Offset: 0x0005DF24
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicHeroData_0 != null)
			{
				logicJSONObject.Put("d", new LogicJSONNumber(this.logicHeroData_0.GetGlobalID()));
			}
			return logicJSONObject;
		}

		// Token: 0x04000DA2 RID: 3490
		private LogicHeroData logicHeroData_0;
	}
}
