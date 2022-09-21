using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013B RID: 315
	public class LogicAnimationTable : LogicDataTable
	{
		// Token: 0x060010C1 RID: 4289 RVA: 0x0000B514 File Offset: 0x00009714
		public LogicAnimationTable(CSVNode node, LogicDataType index) : base(node.GetTable(), index)
		{
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x0004AC4C File Offset: 0x00048E4C
		public override void CreateReferences()
		{
			for (int i = 0; i < this.m_items.Size(); i++)
			{
				this.m_items[i].CreateReferences();
			}
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x00002463 File Offset: 0x00000663
		public void SetTable(CSVNode node)
		{
		}
	}
}
