using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000146 RID: 326
	public class LogicData
	{
		// Token: 0x0600121D RID: 4637 RVA: 0x0004D900 File Offset: 0x0004BB00
		public LogicData(CSVRow row, LogicDataTable table)
		{
			this.m_row = row;
			this.m_table = table;
			this.m_globalId = GlobalID.CreateGlobalID((int)(table.GetTableIndex() + 1), table.GetItemCount());
			this.m_tidIndex = -1;
			this.m_infoTidIndex = -1;
			this.m_iconSWFIndex = -1;
			this.m_iconExportNameIndex = -1;
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x0004D958 File Offset: 0x0004BB58
		public virtual void CreateReferences()
		{
			this.m_iconSWFIndex = (short)this.m_row.GetColumnIndexByName("IconSWF");
			this.m_iconExportNameIndex = (short)this.m_row.GetColumnIndexByName("IconExportName");
			this.m_tidIndex = (short)this.m_row.GetColumnIndexByName("TID");
			this.m_infoTidIndex = (short)this.m_row.GetColumnIndexByName("InfoTID");
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void CreateReferences2()
		{
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x0000C1BF File Offset: 0x0000A3BF
		public void SetCSVRow(CSVRow row)
		{
			this.m_row = row;
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x0000C1C8 File Offset: 0x0000A3C8
		public int GetArraySize(string column)
		{
			return this.m_row.GetArraySize(column);
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x0000C1D6 File Offset: 0x0000A3D6
		public LogicDataType GetDataType()
		{
			return this.m_table.GetTableIndex();
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x0000C1E3 File Offset: 0x0000A3E3
		public int GetGlobalID()
		{
			return this.m_globalId;
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x0000C1EB File Offset: 0x0000A3EB
		public int GetInstanceID()
		{
			return GlobalID.GetInstanceID(this.m_globalId);
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x0004D9C4 File Offset: 0x0004BBC4
		public int GetColumnIndex(string name)
		{
			if (this.m_row.GetColumnIndexByName(name) == -1)
			{
				Debugger.Warning(string.Format("Unable to find column {0} from {1} ({2})", name, this.m_row.GetName(), this.m_table.GetTableName()));
			}
			return this.m_row.GetColumnIndexByName(name);
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x0000C1F8 File Offset: 0x0000A3F8
		public string GetDebuggerName()
		{
			return this.m_row.GetName() + " (" + this.m_table.GetTableName() + ")";
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x0000C21F File Offset: 0x0000A41F
		public bool GetBooleanValue(string columnName, int index)
		{
			return this.m_row.GetBooleanValue(columnName, index);
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x0000C22E File Offset: 0x0000A42E
		public bool GetClampedBooleanValue(string columnName, int index)
		{
			return this.m_row.GetClampedBooleanValue(columnName, index);
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x0000C23D File Offset: 0x0000A43D
		public int GetIntegerValue(string columnName, int index)
		{
			return this.m_row.GetIntegerValue(columnName, index);
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x0000C24C File Offset: 0x0000A44C
		public int GetClampedIntegerValue(string columnName, int index)
		{
			return this.m_row.GetClampedIntegerValue(columnName, index);
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x0000C25B File Offset: 0x0000A45B
		public string GetValue(string columnName, int index)
		{
			return this.m_row.GetValue(columnName, index);
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x0000C26A File Offset: 0x0000A46A
		public string GetClampedValue(string columnName, int index)
		{
			return this.m_row.GetClampedValue(columnName, index);
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x0000C279 File Offset: 0x0000A479
		public string GetName()
		{
			return this.m_row.GetName();
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x0000C286 File Offset: 0x0000A486
		public string GetTID()
		{
			if (this.m_tidIndex == -1)
			{
				return null;
			}
			return this.m_row.GetValueAt((int)this.m_tidIndex, 0);
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x0000C2A5 File Offset: 0x0000A4A5
		public string GetInfoTID()
		{
			if (this.m_infoTidIndex == -1)
			{
				return null;
			}
			return this.m_row.GetValueAt((int)this.m_infoTidIndex, 0);
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		public string GetIconExportName()
		{
			if (this.m_iconExportNameIndex == -1)
			{
				return null;
			}
			return this.m_row.GetValueAt((int)this.m_iconExportNameIndex, 0);
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsEnableByCalendar()
		{
			return false;
		}

		// Token: 0x04000878 RID: 2168
		protected readonly int m_globalId;

		// Token: 0x04000879 RID: 2169
		protected short m_tidIndex;

		// Token: 0x0400087A RID: 2170
		protected short m_infoTidIndex;

		// Token: 0x0400087B RID: 2171
		protected short m_iconExportNameIndex;

		// Token: 0x0400087C RID: 2172
		protected short m_iconSWFIndex;

		// Token: 0x0400087D RID: 2173
		protected CSVRow m_row;

		// Token: 0x0400087E RID: 2174
		protected readonly LogicDataTable m_table;
	}
}
