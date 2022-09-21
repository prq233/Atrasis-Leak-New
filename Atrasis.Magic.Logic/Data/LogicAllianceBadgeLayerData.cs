using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000136 RID: 310
	public class LogicAllianceBadgeLayerData : LogicData
	{
		// Token: 0x060010AB RID: 4267 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicAllianceBadgeLayerData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x0000B468 File Offset: 0x00009668
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.logicAllianceBadgeLayerType_0 = this.method_0(base.GetValue("Type", 0));
			this.int_0 = base.GetIntegerValue("RequiredClanLevel", 0);
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x0004AA24 File Offset: 0x00048C24
		private LogicAllianceBadgeLayerType method_0(string string_0)
		{
			if (string.Equals(string_0, "Background", StringComparison.InvariantCultureIgnoreCase))
			{
				return LogicAllianceBadgeLayerType.BACKGROUND;
			}
			if (string.Equals(string_0, "Middle", StringComparison.InvariantCultureIgnoreCase))
			{
				return LogicAllianceBadgeLayerType.MIDDLE;
			}
			if (string.Equals(string_0, "Foreground", StringComparison.InvariantCultureIgnoreCase))
			{
				return LogicAllianceBadgeLayerType.FOREGROUND;
			}
			Debugger.Warning("Unknown badge type: " + string_0);
			return LogicAllianceBadgeLayerType.BACKGROUND;
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0000B49A File Offset: 0x0000969A
		public LogicAllianceBadgeLayerType GetBadgeType()
		{
			return this.logicAllianceBadgeLayerType_0;
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x0000B4A2 File Offset: 0x000096A2
		public int GetRequiredClanLevel()
		{
			return this.int_0;
		}

		// Token: 0x040006F6 RID: 1782
		private LogicAllianceBadgeLayerType logicAllianceBadgeLayerType_0;

		// Token: 0x040006F7 RID: 1783
		private int int_0;
	}
}
