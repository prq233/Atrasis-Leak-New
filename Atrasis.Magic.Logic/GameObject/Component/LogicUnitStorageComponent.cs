using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200012E RID: 302
	public class LogicUnitStorageComponent : LogicComponent
	{
		// Token: 0x06001050 RID: 4176 RVA: 0x0000B0A7 File Offset: 0x000092A7
		public LogicUnitStorageComponent(LogicGameObject gameObject, int capacity) : base(gameObject)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicUnitSlot>();
			this.int_0 = capacity;
			this.SetStorageType(gameObject);
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x00048B6C File Offset: 0x00046D6C
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicArrayList_0 != null)
			{
				for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
				{
					this.logicArrayList_0[i].Destruct();
					this.logicArrayList_0.Remove(i);
				}
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x0000B0C9 File Offset: 0x000092C9
		public LogicCombatItemType GetStorageType()
		{
			return this.logicCombatItemType_0;
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x0000B0D1 File Offset: 0x000092D1
		public void SetStorageType(LogicGameObject gameObject)
		{
			this.logicCombatItemType_0 = LogicCombatItemType.CHARACTER;
			if (gameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				this.logicCombatItemType_0 = (((LogicBuilding)gameObject).GetBuildingData().IsForgesSpells() ? LogicCombatItemType.SPELL : LogicCombatItemType.CHARACTER);
			}
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x0000B0FE File Offset: 0x000092FE
		public int GetMaxCapacity()
		{
			return this.int_0;
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x0000B106 File Offset: 0x00009306
		public void SetMaxCapacity(int capacity)
		{
			this.int_0 = capacity;
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x0000B10F File Offset: 0x0000930F
		public int GetUnusedCapacity()
		{
			return LogicMath.Max(this.int_0 - this.GetUsedCapacity(), 0);
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x00048BC4 File Offset: 0x00046DC4
		public int GetUsedCapacity()
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicUnitSlot logicUnitSlot = this.logicArrayList_0[i];
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitSlot.GetData();
				num += logicCombatItemData.GetHousingSpace() * logicUnitSlot.GetCount();
			}
			return num;
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x00048C14 File Offset: 0x00046E14
		public bool CanAddUnit(LogicCombatItemData data)
		{
			if (!this.m_parent.GetLevel().GetHomeOwnerAvatar().IsNpcAvatar())
			{
				if (this.GetComponentType() != LogicComponentType.UNIT_STORAGE)
				{
					if (this.logicCombatItemType_0 == data.GetCombatItemType())
					{
						return this.int_0 >= data.GetHousingSpace() + this.GetUsedCapacity();
					}
				}
				else
				{
					LogicComponentManager componentManager = this.m_parent.GetComponentManager();
					int totalUsedHousing = componentManager.GetTotalUsedHousing(this.logicCombatItemType_0);
					int totalMaxHousing = componentManager.GetTotalMaxHousing(this.logicCombatItemType_0);
					if (data.GetCombatItemType() == this.logicCombatItemType_0 && this.GetUsedCapacity() < this.int_0)
					{
						return totalMaxHousing >= totalUsedHousing + data.GetHousingSpace();
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x0000B124 File Offset: 0x00009324
		public void AddUnit(LogicCombatItemData data)
		{
			this.AddUnitImpl(data, -1);
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x00048CBC File Offset: 0x00046EBC
		public void AddUnitImpl(LogicCombatItemData data, int upgLevel)
		{
			if (data == null)
			{
				Debugger.Warning("LogicUnitStorageComponent::addUnitImpl called and storage is full");
				return;
			}
			if (this.CanAddUnit(data))
			{
				int num = -1;
				int i = 0;
				while (i < this.logicArrayList_0.Size())
				{
					LogicUnitSlot logicUnitSlot = this.logicArrayList_0[i];
					if (logicUnitSlot.GetData() == data && logicUnitSlot.GetLevel() == upgLevel)
					{
						num = i;
						IL_4C:
						if (num != -1)
						{
							this.logicArrayList_0[num].SetCount(this.logicArrayList_0[num].GetCount() + 1);
							return;
						}
						this.logicArrayList_0.Add(new LogicUnitSlot(data, upgLevel, 1));
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_4C;
			}
			Debugger.Warning("LogicUnitStorageComponent::addUnitImpl called and storage is full");
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00048D68 File Offset: 0x00046F68
		public void RemoveAllUnits()
		{
			for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
			{
				this.logicArrayList_0[i].Destruct();
				this.logicArrayList_0.Remove(i);
			}
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0000B12E File Offset: 0x0000932E
		public void RemoveUnits(LogicCombatItemData data, int count)
		{
			this.RemoveUnitsImpl(data, -1, count);
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0000B139 File Offset: 0x00009339
		public void RemoveUnits(LogicCombatItemData data, int upgLevel, int count)
		{
			this.RemoveUnitsImpl(data, upgLevel, count);
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x00048DAC File Offset: 0x00046FAC
		protected void RemoveUnitsImpl(LogicCombatItemData data, int upgLevel, int count)
		{
			if (data != null)
			{
				int num = -1;
				int i = 0;
				while (i < this.logicArrayList_0.Size())
				{
					LogicUnitSlot logicUnitSlot = this.logicArrayList_0[i];
					if (logicUnitSlot.GetData() == data && logicUnitSlot.GetLevel() == upgLevel)
					{
						num = i;
						IL_43:
						if (num == -1)
						{
							Debugger.Error("LogicUnitStorageComponent::removeUnitsImpl No units with the given type found");
							return;
						}
						LogicUnitSlot logicUnitSlot2 = this.logicArrayList_0[num];
						if (logicUnitSlot2.GetCount() - count <= 0)
						{
							this.logicArrayList_0[num].Destruct();
							this.logicArrayList_0.Remove(num);
							return;
						}
						logicUnitSlot2.SetCount(logicUnitSlot2.GetCount() - count);
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_43;
			}
			Debugger.Error("LogicUnitStorageComponent::removeUnits called with CharacterData NULL");
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x0000B144 File Offset: 0x00009344
		public int GetUnitTypeCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0000B151 File Offset: 0x00009351
		public LogicCombatItemData GetUnitType(int idx)
		{
			return (LogicCombatItemData)this.logicArrayList_0[idx].GetData();
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x00048E5C File Offset: 0x0004705C
		public int GetUnitCountByData(LogicCombatItemData data)
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicUnitSlot logicUnitSlot = this.logicArrayList_0[i];
				if (logicUnitSlot.GetData() == data)
				{
					num += logicUnitSlot.GetCount();
				}
			}
			return num;
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x0000B169 File Offset: 0x00009369
		public int GetUnitCount(int idx)
		{
			return this.logicArrayList_0[idx].GetCount();
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0000B17C File Offset: 0x0000937C
		public int GetUnitLevel(int idx)
		{
			return this.logicArrayList_0[idx].GetLevel();
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x00048EA4 File Offset: 0x000470A4
		public int GetUnitTypeIndex(LogicCombatItemData data)
		{
			int result = -1;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetData() == data)
				{
					result = i;
					return result;
				}
			}
			return result;
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x00048EE4 File Offset: 0x000470E4
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicUnitSlot logicUnitSlot = this.logicArrayList_0[i];
				if (logicUnitSlot.GetData() != null && logicUnitSlot.GetCount() > 0)
				{
					if (logicUnitSlot.GetLevel() != -1)
					{
						Debugger.Error("Invalid unit level.");
					}
					LogicJSONArray logicJSONArray2 = new LogicJSONArray(2);
					logicJSONArray2.Add(new LogicJSONNumber(logicUnitSlot.GetData().GetGlobalID()));
					logicJSONArray2.Add(new LogicJSONNumber(logicUnitSlot.GetCount()));
					logicJSONArray.Add(logicJSONArray2);
				}
			}
			jsonObject.Put("units", logicJSONArray);
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x00048F80 File Offset: 0x00047180
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("units");
			if (jsonarray != null)
			{
				if (this.logicArrayList_0.Size() > 0)
				{
					Debugger.Error("LogicUnitStorageComponent::load - Unit array size > 0!");
				}
				int i = 0;
				int num = jsonarray.Size();
				while (i < num)
				{
					LogicJSONArray jsonarray2 = jsonarray.GetJSONArray(i);
					if (jsonarray2 != null)
					{
						LogicJSONNumber jsonnumber = jsonarray2.GetJSONNumber(0);
						LogicJSONNumber jsonnumber2 = jsonarray2.GetJSONNumber(1);
						if (jsonnumber != null && jsonnumber2 != null)
						{
							LogicData dataById = LogicDataTables.GetDataById(jsonnumber.GetIntValue(), (this.logicCombatItemType_0 != LogicCombatItemType.CHARACTER) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
							if (dataById == null)
							{
								Debugger.Error("LogicUnitStorageComponent::load - Character data is NULL!");
							}
							this.logicArrayList_0.Add(new LogicUnitSlot(dataById, -1, jsonnumber2.GetIntValue()));
						}
					}
					i++;
				}
			}
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x00049034 File Offset: 0x00047234
		public bool IsEmpty()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetCount() > 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x00002465 File Offset: 0x00000665
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.UNIT_STORAGE;
		}

		// Token: 0x040006C8 RID: 1736
		private LogicCombatItemType logicCombatItemType_0;

		// Token: 0x040006C9 RID: 1737
		private int int_0;

		// Token: 0x040006CA RID: 1738
		private LogicArrayList<LogicUnitSlot> logicArrayList_0;
	}
}
