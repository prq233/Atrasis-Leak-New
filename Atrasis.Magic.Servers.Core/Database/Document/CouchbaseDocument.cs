using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F7 RID: 247
	public abstract class CouchbaseDocument
	{
		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00009131 File Offset: 0x00007331
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x00009139 File Offset: 0x00007339
		public LogicLong Id { get; private set; }

		// Token: 0x06000761 RID: 1889 RVA: 0x00004712 File Offset: 0x00002912
		protected CouchbaseDocument()
		{
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00009142 File Offset: 0x00007342
		protected CouchbaseDocument(LogicLong id)
		{
			this.Id = id;
		}

		// Token: 0x06000763 RID: 1891
		protected abstract void Save(LogicJSONObject jsonObject);

		// Token: 0x06000764 RID: 1892
		protected abstract void Load(LogicJSONObject jsonObject);

		// Token: 0x06000765 RID: 1893
		protected abstract void Encode(ByteStream stream);

		// Token: 0x06000766 RID: 1894
		protected abstract void Decode(ByteStream stream);

		// Token: 0x06000767 RID: 1895 RVA: 0x000173F8 File Offset: 0x000155F8
		public static string Save(CouchbaseDocument document)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("id_hi", new LogicJSONNumber(document.Id.GetHigherInt()));
			logicJSONObject.Put("id_lo", new LogicJSONNumber(document.Id.GetLowerInt()));
			document.Save(logicJSONObject);
			return LogicJSONParser.CreateJSONString(logicJSONObject, 256);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00017454 File Offset: 0x00015654
		public static T Load<T>(string json) where T : CouchbaseDocument, new()
		{
			LogicJSONObject logicJSONObject = LogicJSONParser.ParseObject(json);
			T t = Activator.CreateInstance<T>();
			t.Id = LogicLong.ToLong(logicJSONObject.GetJSONNumber("id_hi").GetIntValue(), logicJSONObject.GetJSONNumber("id_lo").GetIntValue());
			t.Load(logicJSONObject);
			return t;
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00009151 File Offset: 0x00007351
		public static void Encode(ByteStream stream, CouchbaseDocument document)
		{
			stream.WriteLong(document.Id);
			document.Encode(stream);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00009166 File Offset: 0x00007366
		public static T Decode<T>(ByteStream stream) where T : CouchbaseDocument, new()
		{
			T t = Activator.CreateInstance<T>();
			t.Id = stream.ReadLong();
			t.Decode(stream);
			return t;
		}

		// Token: 0x04000420 RID: 1056
		public const string JSON_ATTRIBUTE_ID_HIGH = "id_hi";

		// Token: 0x04000421 RID: 1057
		public const string JSON_ATTRIBUTE_ID_LOW = "id_lo";

		// Token: 0x04000422 RID: 1058
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
