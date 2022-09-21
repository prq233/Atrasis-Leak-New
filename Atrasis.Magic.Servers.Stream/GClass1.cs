using System;
using Atrasis.Magic.Logic.Data;

namespace ns0
{
	// Token: 0x02000004 RID: 4
	public static class GClass1
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000023D0 File Offset: 0x000005D0
		public static void smethod_0(int int_0, out LogicAllianceBadgeLayerData logicAllianceBadgeLayerData_0, out LogicAllianceBadgeLayerData logicAllianceBadgeLayerData_1, out LogicAllianceBadgeLayerData logicAllianceBadgeLayerData_2)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ALLIANCE_BADGE_LAYER);
			int itemCount = LogicDataTables.GetTable(LogicDataType.ALLIANCE_BADGE_LAYER).GetItemCount();
			int num = (int)((byte)int_0) % itemCount;
			int num2 = (int)((byte)(int_0 >> 8)) % itemCount;
			int num3 = (int)((byte)(int_0 >> 16)) % itemCount;
			logicAllianceBadgeLayerData_0 = ((num != 0) ? ((LogicAllianceBadgeLayerData)table.GetItemAt(num)) : null);
			logicAllianceBadgeLayerData_1 = ((num2 != 0) ? ((LogicAllianceBadgeLayerData)table.GetItemAt(num2)) : null);
			logicAllianceBadgeLayerData_2 = ((num3 != 0) ? ((LogicAllianceBadgeLayerData)table.GetItemAt(num3)) : null);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002448 File Offset: 0x00000648
		public static int smethod_1(LogicAllianceBadgeLayerData logicAllianceBadgeLayerData_0, LogicAllianceBadgeLayerData logicAllianceBadgeLayerData_1, LogicAllianceBadgeLayerData logicAllianceBadgeLayerData_2)
		{
			int num = (logicAllianceBadgeLayerData_0 != null) ? logicAllianceBadgeLayerData_0.GetInstanceID() : 0;
			int num2 = (logicAllianceBadgeLayerData_1 != null) ? logicAllianceBadgeLayerData_1.GetInstanceID() : 0;
			int num3 = (logicAllianceBadgeLayerData_2 != null) ? logicAllianceBadgeLayerData_2.GetInstanceID() : 0;
			return num + (num2 << 8) + (num3 << 16);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002484 File Offset: 0x00000684
		public static LogicAllianceBadgeLayerData smethod_2(LogicAllianceBadgeLayerType logicAllianceBadgeLayerType_0, int int_0)
		{
			LogicAllianceBadgeLayerData result = null;
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ALLIANCE_BADGE_LAYER);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicAllianceBadgeLayerData logicAllianceBadgeLayerData = (LogicAllianceBadgeLayerData)table.GetItemAt(i);
				if (logicAllianceBadgeLayerData.GetBadgeType() == LogicAllianceBadgeLayerType.FOREGROUND && logicAllianceBadgeLayerData.GetRequiredClanLevel() <= int_0)
				{
					result = logicAllianceBadgeLayerData;
					return result;
				}
			}
			return result;
		}
	}
}
