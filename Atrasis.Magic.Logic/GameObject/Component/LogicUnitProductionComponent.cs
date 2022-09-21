using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200012D RID: 301
	public class LogicUnitProductionComponent : LogicComponent
	{
		// Token: 0x06001047 RID: 4167 RVA: 0x0000B008 File Offset: 0x00009208
		public LogicUnitProductionComponent(LogicGameObject gameObject) : base(gameObject)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicDataSlot>();
			this.SetProductionType(gameObject);
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x0000B023 File Offset: 0x00009223
		public void SetProductionType(LogicGameObject gameObject)
		{
			this.logicCombatItemType_0 = LogicCombatItemType.CHARACTER;
			if (gameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				this.logicCombatItemType_0 = (((LogicBuilding)gameObject).GetBuildingData().IsForgesSpells() ? LogicCombatItemType.SPELL : LogicCombatItemType.CHARACTER);
			}
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x0000B050 File Offset: 0x00009250
		public LogicCombatItemType GetProductionType()
		{
			return this.logicCombatItemType_0;
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x0000B058 File Offset: 0x00009258
		public int GetRemainingSeconds()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x0000B07F File Offset: 0x0000927F
		public LogicCombatItemData GetCurrentlyTrainedUnit()
		{
			if (this.logicArrayList_0.Size() > 0)
			{
				return (LogicCombatItemData)this.logicArrayList_0[0].GetData();
			}
			return null;
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x00048808 File Offset: 0x00046A08
		public bool ContainsUnit(LogicCombatItemData data)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetData() == data)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x00048844 File Offset: 0x00046A44
		public override void Load(LogicJSONObject root)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
			{
				this.logicArrayList_0[i].Destruct();
				this.logicArrayList_0.Remove(i);
			}
			LogicJSONObject jsonobject = root.GetJSONObject("unit_prod");
			if (jsonobject != null)
			{
				if (jsonobject.GetJSONNumber("m") != null)
				{
					this.bool_0 = true;
				}
				LogicJSONNumber jsonnumber = jsonobject.GetJSONNumber("unit_type");
				if (jsonnumber != null)
				{
					this.logicCombatItemType_0 = (LogicCombatItemType)jsonnumber.GetIntValue();
				}
				LogicJSONArray jsonarray = jsonobject.GetJSONArray("slots");
				if (jsonarray != null)
				{
					for (int j = 0; j < jsonarray.Size(); j++)
					{
						LogicJSONObject jsonobject2 = jsonarray.GetJSONObject(j);
						if (jsonobject2 != null)
						{
							LogicJSONNumber jsonnumber2 = jsonobject2.GetJSONNumber("id");
							if (jsonnumber2 != null)
							{
								LogicData dataById = LogicDataTables.GetDataById(jsonnumber2.GetIntValue(), (this.logicCombatItemType_0 == LogicCombatItemType.CHARACTER) ? LogicDataType.CHARACTER : LogicDataType.SPELL);
								if (dataById != null)
								{
									LogicJSONNumber jsonnumber3 = jsonobject2.GetJSONNumber("cnt");
									if (jsonnumber3 != null && jsonnumber3.GetIntValue() > 0)
									{
										this.logicArrayList_0.Add(new LogicDataSlot(dataById, jsonnumber3.GetIntValue()));
									}
								}
							}
						}
					}
				}
				if (this.logicArrayList_0.Size() > 0)
				{
					LogicJSONNumber jsonnumber4 = jsonobject.GetJSONNumber("t");
					if (jsonnumber4 != null)
					{
						this.logicTimer_0 = new LogicTimer();
						this.logicTimer_0.StartTimer(jsonnumber4.GetIntValue(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
						return;
					}
					LogicCombatItemData logicCombatItemData = (LogicCombatItemData)this.logicArrayList_0[0].GetData();
					LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
					int index = (homeOwnerAvatar != null) ? homeOwnerAvatar.GetUnitUpgradeLevel(logicCombatItemData) : 0;
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(logicCombatItemData.GetTrainingTime(index, this.m_parent.GetLevel(), 0), this.m_parent.GetLevel().GetLogicTime(), false, -1);
					return;
				}
			}
			else
			{
				this.logicCombatItemType_0 = LogicCombatItemType.CHARACTER;
				if (this.m_parent.GetVillageType() == 0)
				{
					Debugger.Warning("LogicUnitProductionComponent::load - Component wasn't found from the JSON");
				}
			}
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x00048A6C File Offset: 0x00046C6C
		public override void Save(LogicJSONObject root, int villageType)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("m", new LogicJSONNumber(1));
			logicJSONObject.Put("unit_type", new LogicJSONNumber((int)this.logicCombatItemType_0));
			if (this.logicTimer_0 != null)
			{
				logicJSONObject.Put("t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime())));
			}
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicDataSlot logicDataSlot = this.logicArrayList_0[i];
					LogicJSONObject logicJSONObject2 = new LogicJSONObject();
					logicJSONObject2.Put("id", new LogicJSONNumber(logicDataSlot.GetData().GetGlobalID()));
					logicJSONObject2.Put("cnt", new LogicJSONNumber(logicDataSlot.GetCount()));
					logicJSONArray.Add(logicJSONObject2);
				}
				logicJSONObject.Put("slots", logicJSONArray);
			}
			root.Put("unit_prod", logicJSONObject);
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x00002C4D File Offset: 0x00000E4D
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.UNIT_PRODUCTION;
		}

		// Token: 0x040006C4 RID: 1732
		private LogicTimer logicTimer_0;

		// Token: 0x040006C5 RID: 1733
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_0;

		// Token: 0x040006C6 RID: 1734
		private bool bool_0;

		// Token: 0x040006C7 RID: 1735
		private LogicCombatItemType logicCombatItemType_0;
	}
}
