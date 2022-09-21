using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F5 RID: 245
	public struct ReportEntry
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x00009034 File Offset: 0x00007234
		// (set) Token: 0x06000745 RID: 1861 RVA: 0x0000903C File Offset: 0x0000723C
		public LogicLong AccountId { get; set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x00009045 File Offset: 0x00007245
		// (set) Token: 0x06000747 RID: 1863 RVA: 0x0000904D File Offset: 0x0000724D
		public DateTime Time { get; set; }

		// Token: 0x06000748 RID: 1864 RVA: 0x00016E70 File Offset: 0x00015070
		public void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteString(this.Time.ToString("O"));
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00009056 File Offset: 0x00007256
		public void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.Time = DateTime.Parse(stream.ReadString(900000));
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00016EA4 File Offset: 0x000150A4
		public LogicJSONNode Save()
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(2);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(2);
			logicJSONArray2.Add(new LogicJSONNumber(this.AccountId.GetHigherInt()));
			logicJSONArray2.Add(new LogicJSONNumber(this.AccountId.GetLowerInt()));
			logicJSONArray.Add(logicJSONArray2);
			logicJSONArray.Add(new LogicJSONString(this.Time.ToString("O")));
			return logicJSONArray;
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00016F10 File Offset: 0x00015110
		public void Load(LogicJSONNode node)
		{
			LogicJSONArray logicJSONArray = (LogicJSONArray)node;
			LogicJSONArray jsonarray = logicJSONArray.GetJSONArray(0);
			this.AccountId = new LogicLong(jsonarray.GetJSONNumber(0).GetIntValue(), jsonarray.GetJSONNumber(1).GetIntValue());
			this.Time = DateTime.Parse(logicJSONArray.GetJSONString(1).GetStringValue());
		}

		// Token: 0x0400040D RID: 1037
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x0400040E RID: 1038
		[CompilerGenerated]
		private DateTime dateTime_0;
	}
}
