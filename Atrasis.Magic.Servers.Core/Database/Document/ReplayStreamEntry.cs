using System;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000FC RID: 252
	public class ReplayStreamEntry
	{
		// Token: 0x060007B4 RID: 1972 RVA: 0x00004712 File Offset: 0x00002912
		public ReplayStreamEntry()
		{
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00009442 File Offset: 0x00007642
		public ReplayStreamEntry(byte[] streamData)
		{
			this.byte_0 = streamData;
			this.int_0 = 9;
			this.int_1 = 256;
			this.int_2 = ResourceManager.GetContentVersion();
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0000946F File Offset: 0x0000766F
		public byte[] GetStreamData()
		{
			return this.byte_0;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00009477 File Offset: 0x00007677
		public int GetMajorVersion()
		{
			return this.int_0;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0000947F File Offset: 0x0000767F
		public int GetBuildVersion()
		{
			return this.int_1;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00009487 File Offset: 0x00007687
		public int GetContentVersion()
		{
			return this.int_2;
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000186E8 File Offset: 0x000168E8
		public void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("data", new LogicJSONString(Convert.ToBase64String(this.byte_0)));
			LogicJSONArray logicJSONArray = new LogicJSONArray(3);
			logicJSONArray.Add(new LogicJSONNumber(this.int_0));
			logicJSONArray.Add(new LogicJSONNumber(this.int_1));
			logicJSONArray.Add(new LogicJSONNumber(this.int_2));
			jsonObject.Put("version", logicJSONArray);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00018758 File Offset: 0x00016958
		public void Load(LogicJSONObject jsonObject)
		{
			this.byte_0 = Convert.FromBase64String(jsonObject.GetJSONString("data").GetStringValue());
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("version");
			this.int_0 = jsonarray.GetJSONNumber(0).GetIntValue();
			this.int_1 = jsonarray.GetJSONNumber(1).GetIntValue();
			this.int_2 = jsonarray.GetJSONNumber(2).GetIntValue();
		}

		// Token: 0x04000452 RID: 1106
		public const string JSON_ATTRIBUTE_STREAM_DATA = "data";

		// Token: 0x04000453 RID: 1107
		public const string JSON_ATTRIBUTE_STREAM_VERSION = "version";

		// Token: 0x04000454 RID: 1108
		private byte[] byte_0;

		// Token: 0x04000455 RID: 1109
		private int int_0;

		// Token: 0x04000456 RID: 1110
		private int int_1;

		// Token: 0x04000457 RID: 1111
		private int int_2;
	}
}
