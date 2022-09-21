using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200003B RID: 59
	public class RankingEntry
	{
		// Token: 0x060002BB RID: 699 RVA: 0x00003A74 File Offset: 0x00001C74
		public virtual void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			stream.WriteString(this.string_5);
			stream.WriteInt(this.int_0);
			stream.WriteInt(this.int_2);
			stream.WriteInt(this.int_1);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0001BB08 File Offset: 0x00019D08
		public virtual void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.string_5 = stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00003AB2 File Offset: 0x00001CB2
		public LogicLong GetId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00003ABA File Offset: 0x00001CBA
		public void SetId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00003AC3 File Offset: 0x00001CC3
		public string GetName()
		{
			return this.string_5;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00003ACB File Offset: 0x00001CCB
		public void SetName(string name)
		{
			this.string_5 = name;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00003AD4 File Offset: 0x00001CD4
		public int GetOrder()
		{
			return this.int_0;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00003ADC File Offset: 0x00001CDC
		public void SetOrder(int order)
		{
			this.int_0 = order;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00003AE5 File Offset: 0x00001CE5
		public int GetScore()
		{
			return this.int_2;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00003AED File Offset: 0x00001CED
		public void SetScore(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00003AF6 File Offset: 0x00001CF6
		public int GetPreviousOrder()
		{
			return this.int_1;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00003AFE File Offset: 0x00001CFE
		public void SetPreviousOrder(int order)
		{
			this.int_1 = order;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0001BB58 File Offset: 0x00019D58
		public virtual LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicJSONArray logicJSONArray = new LogicJSONArray(2);
			logicJSONArray.Add(new LogicJSONNumber(this.logicLong_0.GetHigherInt()));
			logicJSONArray.Add(new LogicJSONNumber(this.logicLong_0.GetLowerInt()));
			logicJSONObject.Put("id", logicJSONArray);
			logicJSONObject.Put("name", new LogicJSONString(this.string_5));
			logicJSONObject.Put("o", new LogicJSONNumber(this.int_0));
			logicJSONObject.Put("prevO", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("scr", new LogicJSONNumber(this.int_2));
			return logicJSONObject;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001BC04 File Offset: 0x00019E04
		public virtual void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("id");
			this.logicLong_0 = new LogicLong(jsonarray.GetJSONNumber(0).GetIntValue(), jsonarray.GetJSONNumber(1).GetIntValue());
			this.string_5 = jsonObject.GetJSONString("name").GetStringValue();
			this.int_0 = jsonObject.GetJSONNumber("o").GetIntValue();
			this.int_1 = jsonObject.GetJSONNumber("prevO").GetIntValue();
			this.int_2 = jsonObject.GetJSONNumber("scr").GetIntValue();
		}

		// Token: 0x04000109 RID: 265
		private const string string_0 = "id";

		// Token: 0x0400010A RID: 266
		private const string string_1 = "name";

		// Token: 0x0400010B RID: 267
		private const string string_2 = "o";

		// Token: 0x0400010C RID: 268
		private const string string_3 = "prevO";

		// Token: 0x0400010D RID: 269
		private const string string_4 = "scr";

		// Token: 0x0400010E RID: 270
		private LogicLong logicLong_0;

		// Token: 0x0400010F RID: 271
		private string string_5;

		// Token: 0x04000110 RID: 272
		private int int_0;

		// Token: 0x04000111 RID: 273
		private int int_1;

		// Token: 0x04000112 RID: 274
		private int int_2;
	}
}
