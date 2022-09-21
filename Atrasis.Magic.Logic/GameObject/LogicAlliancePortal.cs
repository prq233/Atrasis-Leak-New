using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x0200010C RID: 268
	public sealed class LogicAlliancePortal : LogicGameObject
	{
		// Token: 0x06000CC7 RID: 3271 RVA: 0x0002BCD8 File Offset: 0x00029ED8
		public LogicAlliancePortal(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			LogicBunkerComponent logicBunkerComponent = new LogicBunkerComponent(this, 0);
			logicBunkerComponent.SetComponentMode(0);
			base.AddComponent(logicBunkerComponent);
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000093EE File Offset: 0x000075EE
		public LogicAlliancePortalData GetAlliancePortalData()
		{
			return (LogicAlliancePortalData)this.m_data;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetWidthInTiles()
		{
			return 1;
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetHeightInTiles()
		{
			return 1;
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x000093FB File Offset: 0x000075FB
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			Debugger.Error("LogicAlliancePortal can't be saved");
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x000093FB File Offset: 0x000075FB
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			Debugger.Error("LogicAlliancePortal can't be saved");
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00009407 File Offset: 0x00007607
		public override void Load(LogicJSONObject jsonObject)
		{
			Debugger.Error("LogicAlliancePortal can't be loaded");
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00009407 File Offset: 0x00007607
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			Debugger.Error("LogicAlliancePortal can't be loaded");
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00009413 File Offset: 0x00007613
		public override void LoadingFinished()
		{
			base.LoadingFinished();
			if (this.m_listener != null)
			{
				this.m_listener.LoadedFromJSON();
			}
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x0000942E File Offset: 0x0000762E
		public override bool ShouldDestruct()
		{
			return !this.m_level.IsInCombatState();
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool IsPassable()
		{
			return true;
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x00002BCC File Offset: 0x00000DCC
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.ALLIANCE_PORTAL;
		}
	}
}
