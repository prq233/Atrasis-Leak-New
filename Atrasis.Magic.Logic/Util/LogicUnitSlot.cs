using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x02000013 RID: 19
	public class LogicUnitSlot
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x0000265D File Offset: 0x0000085D
		public LogicUnitSlot(LogicData data, int level, int count)
		{
			this.logicData_0 = data;
			this.int_0 = level;
			this.int_1 = count;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000267A File Offset: 0x0000087A
		public void Destruct()
		{
			this.logicData_0 = null;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002683 File Offset: 0x00000883
		public void Decode(ByteStream stream)
		{
			this.logicData_0 = ByteStreamHelper.ReadDataReference(stream);
			this.int_1 = stream.ReadInt();
			this.int_0 = stream.ReadInt();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000026A9 File Offset: 0x000008A9
		public void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicData_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_0);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000026CF File Offset: 0x000008CF
		public LogicData GetData()
		{
			return this.logicData_0;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000026D7 File Offset: 0x000008D7
		public int GetCount()
		{
			return this.int_1;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000026DF File Offset: 0x000008DF
		public int GetLevel()
		{
			return this.int_0;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000156AC File Offset: 0x000138AC
		public void GetChecksum(ChecksumHelper checksumHelper)
		{
			checksumHelper.StartObject("LogicUnitSlot");
			if (this.logicData_0 != null)
			{
				checksumHelper.WriteValue("globalID", this.logicData_0.GetGlobalID());
			}
			checksumHelper.WriteValue("m_level", this.int_0);
			checksumHelper.WriteValue("m_count", this.int_1);
			checksumHelper.EndObject();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000026E7 File Offset: 0x000008E7
		public void SetCount(int count)
		{
			this.int_1 = count;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0001570C File Offset: 0x0001390C
		public void ReadFromJSON(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("id");
			if (jsonnumber != null && jsonnumber.GetIntValue() != 0)
			{
				this.logicData_0 = LogicDataTables.GetDataById(jsonnumber.GetIntValue());
			}
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "cnt");
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "lvl");
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00015764 File Offset: 0x00013964
		public void WriteToJSON(LogicJSONObject jsonObject)
		{
			jsonObject.Put("id", new LogicJSONNumber((this.logicData_0 != null) ? this.logicData_0.GetGlobalID() : 0));
			jsonObject.Put("cnt", new LogicJSONNumber(this.int_1));
			jsonObject.Put("lvl", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x0400005D RID: 93
		private LogicData logicData_0;

		// Token: 0x0400005E RID: 94
		private int int_0;

		// Token: 0x0400005F RID: 95
		private int int_1;
	}
}
