using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000DC RID: 220
	public class BaseBuilderBattleRequestStreamEntry : StreamEntry
	{
		// Token: 0x0600098E RID: 2446 RVA: 0x00022790 File Offset: 0x00020990
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
			if (stream.ReadBoolean())
			{
				this.string_2 = stream.ReadString(900000);
			}
			stream.ReadVInt();
			this.int_3 = stream.ReadVInt();
			this.bool_1 = stream.ReadBoolean();
			stream.ReadVInt();
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x000227F4 File Offset: 0x000209F4
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			if (this.string_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteString(this.string_1);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteVInt(0);
			stream.WriteVInt(this.int_3);
			stream.WriteBoolean(this.bool_1);
			stream.WriteVInt(0);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00007717 File Offset: 0x00005917
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.BASE_BUILDER_BATTLE_REQUEST;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0000771B File Offset: 0x0000591B
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00007723 File Offset: 0x00005923
		public void SetMessage(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0000772C File Offset: 0x0000592C
		public int GetLayoutId()
		{
			return this.int_4;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00007734 File Offset: 0x00005934
		public void SetLayoutId(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0000773D File Offset: 0x0000593D
		public string GetBattleLogJSON()
		{
			return this.string_2;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00007745 File Offset: 0x00005945
		public void SetBattleLogJSON(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0000774E File Offset: 0x0000594E
		public int GetSpectatorCount()
		{
			return this.int_3;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00007756 File Offset: 0x00005956
		public void SetSpectatorCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0000775F File Offset: 0x0000595F
		public bool IsStarted()
		{
			return this.bool_1;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00007767 File Offset: 0x00005967
		public void SetStarted(bool started)
		{
			this.bool_1 = started;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00022860 File Offset: 0x00020A60
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("BaseBuilderBattleRequestStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_1 = jsonObject.GetJSONString("message").GetStringValue();
			LogicJSONString jsonstring = jsonObject.GetJSONString("battleLog");
			if (jsonstring != null)
			{
				this.string_2 = jsonstring.GetStringValue();
			}
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000228C0 File Offset: 0x00020AC0
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("message", new LogicJSONString(this.string_1));
			if (this.string_2 != null)
			{
				jsonObject.Put("battleLog", new LogicJSONString(this.string_2));
			}
		}

		// Token: 0x040003C2 RID: 962
		private string string_1;

		// Token: 0x040003C3 RID: 963
		private string string_2;

		// Token: 0x040003C4 RID: 964
		private int int_3;

		// Token: 0x040003C5 RID: 965
		private int int_4;

		// Token: 0x040003C6 RID: 966
		private bool bool_1;
	}
}
