using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F8 RID: 504
	public class LogicCalendarTargeting
	{
		// Token: 0x060019BF RID: 6591 RVA: 0x000111E4 File Offset: 0x0000F3E4
		public LogicCalendarTargeting(LogicJSONObject jsonObject)
		{
			this.Load(jsonObject);
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x00061B7C File Offset: 0x0005FD7C
		public void Load(LogicJSONObject jsonObject)
		{
			Debugger.DoAssert(jsonObject != null, "Unable to load targeting");
			this.int_0 = (LogicJSONHelper.GetInt(jsonObject, "minTownHallLevel") & int.MaxValue);
			this.int_1 = (LogicJSONHelper.GetInt(jsonObject, "maxTownHallLevel") & int.MaxValue);
			this.int_2 = (LogicJSONHelper.GetInt(jsonObject, "minGemsPurchased") & int.MaxValue);
			this.int_3 = (LogicJSONHelper.GetInt(jsonObject, "maxGemsPurchased") & int.MaxValue);
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x00061BF4 File Offset: 0x0005FDF4
		public void Save(LogicJSONObject jsonObject)
		{
			Debugger.DoAssert(jsonObject != null, "Unable to save targeting");
			jsonObject.Put("minTownHallLevel", new LogicJSONNumber(this.int_0));
			jsonObject.Put("maxTownHallLevel", new LogicJSONNumber(this.int_1));
			jsonObject.Put("minGemsPurchased", new LogicJSONNumber(this.int_2));
			jsonObject.Put("maxGemsPurchased", new LogicJSONNumber(this.int_3));
		}

		// Token: 0x04000DD7 RID: 3543
		private int int_0;

		// Token: 0x04000DD8 RID: 3544
		private int int_1;

		// Token: 0x04000DD9 RID: 3545
		private int int_2;

		// Token: 0x04000DDA RID: 3546
		private int int_3;
	}
}
