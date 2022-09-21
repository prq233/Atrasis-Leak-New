using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000131 RID: 305
	public sealed class LogicWarResourceStorageComponent : LogicResourceStorageComponent
	{
		// Token: 0x06001090 RID: 4240 RVA: 0x0000B39A File Offset: 0x0000959A
		public LogicWarResourceStorageComponent(LogicGameObject gameObject) : base(gameObject)
		{
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x000046E0 File Offset: 0x000028E0
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.WAR_RESOURCE_STORAGE;
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x0004A024 File Offset: 0x00048224
		public bool IsNotEmpty()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
				if (logicResourceData.GetWarResourceReferenceData() != null && homeOwnerAvatar.GetResourceCount(logicResourceData) > 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x0004A07C File Offset: 0x0004827C
		public override int GetMax(int idx)
		{
			int num = 100;
			if (this.m_parent.GetLevel().GetHomeOwnerAvatar() != null && this.m_parent.GetLevel().GetHomeOwnerAvatar().IsClientAvatar())
			{
				int allianceLevel = ((LogicClientAvatar)this.m_parent.GetLevel().GetHomeOwnerAvatar()).GetAllianceLevel();
				if (allianceLevel > 0)
				{
					num = LogicDataTables.GetAllianceLevel(allianceLevel).GetWarLootCapacityPercent();
				}
			}
			return num * this.m_maxResourceCount[idx] / 100;
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x0004A0F4 File Offset: 0x000482F4
		public override void RecalculateAvailableLoot()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < this.m_resourceCount.Size(); i++)
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
				if (this.m_parent.GetData() == LogicDataTables.GetAllianceCastleData())
				{
					bool warResourceReferenceData = logicResourceData.GetWarResourceReferenceData() != null;
					int num = this.m_resourceCount[i];
					if (warResourceReferenceData)
					{
						int warLootPercentage = LogicDataTables.GetGlobals().GetWarLootPercentage();
						int num2 = 0;
						if ((this.m_parent.GetLevel().GetMatchType() | 4) != 7 && !this.m_parent.GetLevel().IsArrangedWar())
						{
							num2 = (int)((long)num * (long)warLootPercentage / 100L);
						}
						int storageLootCap = LogicDataTables.GetTownHallLevel(homeOwnerAvatar.GetTownHallLevel()).GetStorageLootCap(logicResourceData);
						int num3 = LogicMath.Min(homeOwnerAvatar.GetResourceCount(logicResourceData), homeOwnerAvatar.GetResourceCap(logicResourceData));
						if (num3 > storageLootCap && num3 > 0)
						{
							int num4;
							if (storageLootCap < 1000000)
							{
								if (storageLootCap < 100000)
								{
									if (storageLootCap < 10000)
									{
										num4 = ((storageLootCap < 1000) ? ((num * storageLootCap + (num3 >> 1)) / num3) : (10 * ((num * (storageLootCap / 10) + (num3 >> 1)) / num3)));
									}
									else
									{
										num4 = 100 * ((num * (storageLootCap / 100) + (num3 >> 1)) / num3);
									}
								}
								else
								{
									num4 = 1000 * ((num * (storageLootCap / 1000) + (num3 >> 1)) / num3);
								}
							}
							else
							{
								num4 = 40000 * ((num * (storageLootCap / 40000) + (num3 >> 1)) / num3);
							}
							if (num2 > num4)
							{
								num2 = num4;
							}
						}
						if (num2 > num)
						{
							num2 = num;
						}
						this.m_stealableResourceCount[i] = num2;
					}
				}
			}
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x0004A2B0 File Offset: 0x000484B0
		public override void ResourcesStolen(int damage, int hp)
		{
			if (damage > 0 && hp > 0)
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				for (int i = 0; i < this.m_stealableResourceCount.Size(); i++)
				{
					LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
					int num = base.GetStealableResourceCount(i);
					if (damage < hp)
					{
						num = damage * num / hp;
					}
					if (num > 0 && logicResourceData.GetWarResourceReferenceData() != null)
					{
						this.m_parent.GetLevel().GetBattleLog().IncreaseStolenResourceCount(logicResourceData.GetWarResourceReferenceData(), num);
						LogicArrayList<int> resourceCount = this.m_resourceCount;
						int index = i;
						resourceCount[index] -= num;
						LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
						LogicAvatar visitorAvatar = this.m_parent.GetLevel().GetVisitorAvatar();
						homeOwnerAvatar.CommodityCountChangeHelper(0, logicResourceData, -num);
						visitorAvatar.CommodityCountChangeHelper(0, logicResourceData.GetWarResourceReferenceData(), num);
						this.m_stealableResourceCount[i] = LogicMath.Max(this.m_stealableResourceCount[i] - num, 0);
					}
				}
			}
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x0004A3B4 File Offset: 0x000485B4
		public int CollectResources()
		{
			int result = -1;
			if (this.m_parent.GetLevel().GetHomeOwnerAvatar().IsClientAvatar())
			{
				result = 0;
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.m_parent.GetLevel().GetHomeOwnerAvatar();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
					if (logicResourceData.GetWarResourceReferenceData() != null)
					{
						int num = logicClientAvatar.GetResourceCount(logicResourceData);
						if (num > 0)
						{
							int unusedResourceCap = logicClientAvatar.GetUnusedResourceCap(logicResourceData.GetWarResourceReferenceData());
							if (unusedResourceCap != 0)
							{
								if (num > unusedResourceCap)
								{
									num = unusedResourceCap;
								}
								if (logicResourceData.GetName().Equals("WarGold"))
								{
									this.m_parent.GetLevel().GetAchievementManager().IncreaseWarGoldResourceLoot(num);
								}
								result = num;
								logicClientAvatar.CommodityCountChangeHelper(0, logicResourceData.GetWarResourceReferenceData(), num);
								logicClientAvatar.CommodityCountChangeHelper(0, logicResourceData, -num);
							}
						}
					}
				}
			}
			return result;
		}
	}
}
