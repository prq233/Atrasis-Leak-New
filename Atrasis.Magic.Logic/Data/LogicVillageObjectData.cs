using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000168 RID: 360
	public class LogicVillageObjectData : LogicGameObjectData
	{
		// Token: 0x06001580 RID: 5504 RVA: 0x0000B4F2 File Offset: 0x000096F2
		public LogicVillageObjectData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001581 RID: 5505 RVA: 0x00053710 File Offset: 0x00051910
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_3 = base.GetBooleanValue("Disabled", 0);
			this.int_1 = base.GetIntegerValue("TileX100", 0);
			this.int_2 = base.GetIntegerValue("TileY100", 0);
			this.int_3 = base.GetIntegerValue("RequiredTH", 0);
			this.bool_4 = base.GetBooleanValue("AutomaticUpgrades", 0);
			this.bool_5 = base.GetBooleanValue("RequiresBuilder", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("PickUpEffect", 0), this);
			this.int_4 = base.GetIntegerValue("AnimX", 0);
			this.int_5 = base.GetIntegerValue("AnimY", 0);
			this.int_6 = base.GetIntegerValue("AnimID", 0);
			this.int_7 = base.GetIntegerValue("AnimDir", 0);
			this.int_8 = base.GetIntegerValue("AnimVisibilityOdds", 0);
			this.bool_6 = base.GetBooleanValue("HasInfoScreen", 0);
			this.int_9 = base.GetIntegerValue("UnitHousing", 0);
			this.bool_7 = base.GetBooleanValue("HousesUnits", 0);
			this.bool_0 = string.Equals("Shipyard", base.GetName());
			if (!this.bool_0)
			{
				this.bool_0 = string.Equals("Shipyard2", base.GetName());
			}
			this.bool_1 = string.Equals("Rowboat", base.GetName());
			if (!this.bool_1)
			{
				this.bool_1 = string.Equals("Rowboat2", base.GetName());
			}
			this.bool_2 = string.Equals("ClanGate", base.GetName());
			this.int_0 = this.m_row.GetBiggestArraySize();
			this.int_11 = new int[this.m_row.GetBiggestArraySize()];
			this.int_10 = new int[this.m_row.GetBiggestArraySize()];
			this.int_12 = new int[this.m_row.GetBiggestArraySize()];
			for (int i = 0; i < this.int_0; i++)
			{
				this.int_12[i] = base.GetClampedIntegerValue("RequiredTownHall", i);
				this.int_11[i] = base.GetClampedIntegerValue("BuildCost", i);
				this.int_10[i] = 86400 * base.GetClampedIntegerValue("BuildTimeD", i) + 3600 * base.GetClampedIntegerValue("BuildTimeH", i) + 60 * base.GetClampedIntegerValue("BuildTimeM", i) + base.GetClampedIntegerValue("BuildTimeS", i);
			}
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("BuildResource", 0), this);
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x0000E03D File Offset: 0x0000C23D
		public bool IsShipyard()
		{
			return this.bool_0;
		}

		// Token: 0x06001583 RID: 5507 RVA: 0x0000E045 File Offset: 0x0000C245
		public bool IsRowBoat()
		{
			return this.bool_1;
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x0000E04D File Offset: 0x0000C24D
		public bool IsClanGate()
		{
			return this.bool_2;
		}

		// Token: 0x06001585 RID: 5509 RVA: 0x0000E055 File Offset: 0x0000C255
		public int GetBuildTime(int index)
		{
			return this.int_10[index];
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x0000E05F File Offset: 0x0000C25F
		public int GetBuildCost(int index)
		{
			return this.int_11[index];
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x0000E069 File Offset: 0x0000C269
		public int GetRequiredTownHallLevel(int index)
		{
			return this.int_12[index];
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x0000E073 File Offset: 0x0000C273
		public int GetUpgradeLevelCount()
		{
			return this.int_0;
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x0000E07B File Offset: 0x0000C27B
		public LogicResourceData GetBuildResource()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x0000E083 File Offset: 0x0000C283
		public bool IsDisabled()
		{
			return this.bool_3;
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x0000E08B File Offset: 0x0000C28B
		public int GetTileX100()
		{
			return this.int_1;
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x0000E093 File Offset: 0x0000C293
		public int GetTileY100()
		{
			return this.int_2;
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x0000E09B File Offset: 0x0000C29B
		public int GetRequiredTH()
		{
			return this.int_3;
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x0000E0A3 File Offset: 0x0000C2A3
		public bool IsAutomaticUpgrades()
		{
			return this.bool_4;
		}

		// Token: 0x0600158F RID: 5519 RVA: 0x0000E0AB File Offset: 0x0000C2AB
		public bool IsRequiresBuilder()
		{
			return this.bool_5;
		}

		// Token: 0x06001590 RID: 5520 RVA: 0x0000E0B3 File Offset: 0x0000C2B3
		public LogicEffectData GetPickUpEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x06001591 RID: 5521 RVA: 0x0000E0BB File Offset: 0x0000C2BB
		public int GetAnimX()
		{
			return this.int_4;
		}

		// Token: 0x06001592 RID: 5522 RVA: 0x0000E0C3 File Offset: 0x0000C2C3
		public int GetAnimY()
		{
			return this.int_5;
		}

		// Token: 0x06001593 RID: 5523 RVA: 0x0000E0CB File Offset: 0x0000C2CB
		public int GetAnimID()
		{
			return this.int_6;
		}

		// Token: 0x06001594 RID: 5524 RVA: 0x0000E0D3 File Offset: 0x0000C2D3
		public int GetAnimDir()
		{
			return this.int_7;
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x0000E0DB File Offset: 0x0000C2DB
		public int GetAnimVisibilityOdds()
		{
			return this.int_8;
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x0000E0E3 File Offset: 0x0000C2E3
		public bool IsHasInfoScreen()
		{
			return this.bool_6;
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0000E0EB File Offset: 0x0000C2EB
		public int GetUnitHousing()
		{
			return this.int_9;
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x0000E0F3 File Offset: 0x0000C2F3
		public bool IsHousesUnits()
		{
			return this.bool_7;
		}

		// Token: 0x04000BB5 RID: 2997
		private int int_0;

		// Token: 0x04000BB6 RID: 2998
		private int int_1;

		// Token: 0x04000BB7 RID: 2999
		private int int_2;

		// Token: 0x04000BB8 RID: 3000
		private int int_3;

		// Token: 0x04000BB9 RID: 3001
		private int int_4;

		// Token: 0x04000BBA RID: 3002
		private int int_5;

		// Token: 0x04000BBB RID: 3003
		private int int_6;

		// Token: 0x04000BBC RID: 3004
		private int int_7;

		// Token: 0x04000BBD RID: 3005
		private int int_8;

		// Token: 0x04000BBE RID: 3006
		private int int_9;

		// Token: 0x04000BBF RID: 3007
		private int[] int_10;

		// Token: 0x04000BC0 RID: 3008
		private int[] int_11;

		// Token: 0x04000BC1 RID: 3009
		private int[] int_12;

		// Token: 0x04000BC2 RID: 3010
		private bool bool_0;

		// Token: 0x04000BC3 RID: 3011
		private bool bool_1;

		// Token: 0x04000BC4 RID: 3012
		private bool bool_2;

		// Token: 0x04000BC5 RID: 3013
		private bool bool_3;

		// Token: 0x04000BC6 RID: 3014
		private bool bool_4;

		// Token: 0x04000BC7 RID: 3015
		private bool bool_5;

		// Token: 0x04000BC8 RID: 3016
		private bool bool_6;

		// Token: 0x04000BC9 RID: 3017
		private bool bool_7;

		// Token: 0x04000BCA RID: 3018
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000BCB RID: 3019
		private LogicEffectData logicEffectData_0;
	}
}
