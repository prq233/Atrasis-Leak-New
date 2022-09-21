using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000150 RID: 336
	public abstract class LogicGameObjectData : LogicData
	{
		// Token: 0x060012D9 RID: 4825 RVA: 0x0000C9E7 File Offset: 0x0000ABE7
		protected LogicGameObjectData(CSVRow row, LogicDataTable table) : base(row, table)
		{
			this.m_villageType = -1;
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x0004E488 File Offset: 0x0004C688
		public override void CreateReferences()
		{
			base.CreateReferences();
			int columnIndexByName = this.m_row.GetColumnIndexByName("VillageType");
			if (columnIndexByName > 0)
			{
				this.m_villageType = this.m_row.GetIntegerValueAt(columnIndexByName, 0);
				if (this.m_villageType >= 2)
				{
					Debugger.Error("invalid VillageType");
				}
			}
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x0000C9F8 File Offset: 0x0000ABF8
		public int GetVillageType()
		{
			return this.m_villageType;
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x0000CA00 File Offset: 0x0000AC00
		public bool IsEnabledInVillageType(int villageType)
		{
			return this.m_villageType == -1 || this.m_villageType == villageType;
		}

		// Token: 0x040008FB RID: 2299
		protected int m_villageType;
	}
}
