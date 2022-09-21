using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000126 RID: 294
	public sealed class LogicLootCartComponent : LogicComponent
	{
		// Token: 0x06000FBE RID: 4030 RVA: 0x000439CC File Offset: 0x00041BCC
		public LogicLootCartComponent(LogicGameObject gameObject) : base(gameObject)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			this.logicArrayList_0 = new LogicArrayList<int>(table.GetItemCount());
			this.logicArrayList_1 = new LogicArrayList<int>(table.GetItemCount());
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				this.logicArrayList_0.Add(0);
				this.logicArrayList_1.Add(0);
			}
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x0000AB8A File Offset: 0x00008D8A
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
			this.logicArrayList_1 = null;
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0000ABA0 File Offset: 0x00008DA0
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.LOOT_CART;
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x00043A34 File Offset: 0x00041C34
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
				if (!logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
				{
					if (LogicDataTables.GetGoldData() == logicResourceData)
					{
						LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("defg");
						if (jsonnumber != null)
						{
							this.SetResourceCount(i, jsonnumber.GetIntValue());
						}
					}
					else if (LogicDataTables.GetElixirData() == logicResourceData)
					{
						LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("defe");
						if (jsonnumber2 != null)
						{
							this.SetResourceCount(i, jsonnumber2.GetIntValue());
						}
					}
					else if (LogicDataTables.GetDarkElixirData() == logicResourceData)
					{
						LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("defde");
						if (jsonnumber3 != null)
						{
							this.SetResourceCount(i, jsonnumber3.GetIntValue());
						}
					}
				}
			}
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00043AF4 File Offset: 0x00041CF4
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
				if (!logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
				{
					if (LogicDataTables.GetGoldData() == logicResourceData)
					{
						int resourceCount = this.GetResourceCount(i);
						if (resourceCount > 0)
						{
							jsonObject.Put("defg", new LogicJSONNumber(resourceCount));
						}
					}
					else if (LogicDataTables.GetElixirData() == logicResourceData)
					{
						int resourceCount2 = this.GetResourceCount(i);
						if (resourceCount2 > 0)
						{
							jsonObject.Put("defe", new LogicJSONNumber(resourceCount2));
						}
					}
					else if (LogicDataTables.GetDarkElixirData() == logicResourceData)
					{
						int resourceCount3 = this.GetResourceCount(i);
						if (resourceCount3 > 0)
						{
							jsonObject.Put("defde", new LogicJSONNumber(resourceCount3));
						}
					}
				}
			}
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		public int GetResourceCount(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x0000ABB2 File Offset: 0x00008DB2
		public void SetResourceCount(int idx, int count)
		{
			this.logicArrayList_0[idx] = LogicMath.Clamp(count, 0, this.logicArrayList_1[idx]);
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x0000ABD3 File Offset: 0x00008DD3
		public int GetCapacityCount(int idx)
		{
			return this.logicArrayList_1[idx];
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x00043BB8 File Offset: 0x00041DB8
		public void SetCapacityCount(LogicArrayList<int> count)
		{
			for (int i = 0; i < count.Size(); i++)
			{
				this.logicArrayList_1[i] = count[i];
			}
			this.m_parent.GetLevel().RefreshResourceCaps();
		}

		// Token: 0x04000673 RID: 1651
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000674 RID: 1652
		private LogicArrayList<int> logicArrayList_1;
	}
}
