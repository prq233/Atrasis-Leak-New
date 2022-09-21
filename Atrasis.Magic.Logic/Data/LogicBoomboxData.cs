using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013E RID: 318
	public class LogicBoomboxData : LogicData
	{
		// Token: 0x06001126 RID: 4390 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicBoomboxData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x0004B6F8 File Offset: 0x000498F8
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_0 = base.GetBooleanValue("Enabled", 0);
			this.bool_1 = base.GetBooleanValue("EnabledLowMem", 0);
			this.bool_2 = base.GetBooleanValue("PreLoading", 0);
			this.bool_3 = base.GetBooleanValue("PreLoadingLowMem", 0);
			this.string_0 = new string[base.GetArraySize("DisabledDevices")];
			for (int i = 0; i < this.string_0.Length; i++)
			{
				this.string_0[i] = base.GetValue("DisabledDevices", i);
			}
			this.string_1 = new string[base.GetArraySize("SupportedPlatforms")];
			for (int j = 0; j < this.string_1.Length; j++)
			{
				this.string_1[j] = base.GetValue("SupportedPlatforms", j);
			}
			this.string_2 = new string[base.GetArraySize("SupportedPlatformsVersion")];
			for (int k = 0; k < this.string_2.Length; k++)
			{
				this.string_2[k] = base.GetValue("SupportedPlatformsVersion", k);
			}
			this.string_3 = new string[base.GetArraySize("AllowedDomains")];
			for (int l = 0; l < this.string_3.Length; l++)
			{
				this.string_3[l] = base.GetValue("AllowedDomains", l);
			}
			this.string_4 = new string[base.GetArraySize("AllowedUrls")];
			for (int m = 0; m < this.string_4.Length; m++)
			{
				this.string_4[m] = base.GetValue("AllowedUrls", m);
			}
		}

		// Token: 0x04000770 RID: 1904
		private bool bool_0;

		// Token: 0x04000771 RID: 1905
		private bool bool_1;

		// Token: 0x04000772 RID: 1906
		private bool bool_2;

		// Token: 0x04000773 RID: 1907
		private bool bool_3;

		// Token: 0x04000774 RID: 1908
		private string[] string_0;

		// Token: 0x04000775 RID: 1909
		private string[] string_1;

		// Token: 0x04000776 RID: 1910
		private string[] string_2;

		// Token: 0x04000777 RID: 1911
		private string[] string_3;

		// Token: 0x04000778 RID: 1912
		private string[] string_4;
	}
}
