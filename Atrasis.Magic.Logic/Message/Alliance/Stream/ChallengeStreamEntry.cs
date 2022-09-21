using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000DE RID: 222
	public class ChallengeStreamEntry : StreamEntry
	{
		// Token: 0x060009B0 RID: 2480 RVA: 0x00022BB8 File Offset: 0x00020DB8
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

		// Token: 0x060009B1 RID: 2481 RVA: 0x00022C1C File Offset: 0x00020E1C
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			if (this.string_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteString(this.string_2);
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

		// Token: 0x060009B2 RID: 2482 RVA: 0x000077D6 File Offset: 0x000059D6
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.CHALLENGE;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x000077DA File Offset: 0x000059DA
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000077E2 File Offset: 0x000059E2
		public void SetMessage(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000077EB File Offset: 0x000059EB
		public string GetBattleLogJSON()
		{
			return this.string_2;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x000077F3 File Offset: 0x000059F3
		public void SetBattleLogJSON(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x000077FC File Offset: 0x000059FC
		public byte[] GetSnapshotHomeJSON()
		{
			return this.byte_0;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00007804 File Offset: 0x00005A04
		public int GetSnapshotHomeLengthJSON()
		{
			return this.byte_0.Length;
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0000780E File Offset: 0x00005A0E
		public void SetSnapshotHomeJSON(byte[] value)
		{
			this.byte_0 = value;
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00007817 File Offset: 0x00005A17
		public int GetSpectatorCount()
		{
			return this.int_3;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0000781F File Offset: 0x00005A1F
		public void SetSpectatorCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00007828 File Offset: 0x00005A28
		public LogicLong GetLiveReplayId()
		{
			return this.logicLong_3;
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00007830 File Offset: 0x00005A30
		public void SetLiveReplayId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00007839 File Offset: 0x00005A39
		public bool IsStarted()
		{
			return this.bool_1;
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x00007841 File Offset: 0x00005A41
		public void SetStarted(bool started)
		{
			this.bool_1 = started;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0000784A File Offset: 0x00005A4A
		public bool IsWarLayout()
		{
			return this.bool_2;
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00007852 File Offset: 0x00005A52
		public void SetWarLayout(bool warLayout)
		{
			this.bool_2 = warLayout;
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00022C88 File Offset: 0x00020E88
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("ChallengeStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_1 = jsonObject.GetJSONString("message").GetStringValue();
			this.byte_0 = Convert.FromBase64String(jsonObject.GetJSONString("snapshot_home").GetStringValue());
			this.bool_2 = jsonObject.GetJSONBoolean("war_layout").IsTrue();
			LogicJSONString jsonstring = jsonObject.GetJSONString("battleLog");
			if (jsonstring != null)
			{
				this.string_2 = jsonstring.GetStringValue();
			}
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00022D18 File Offset: 0x00020F18
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("message", new LogicJSONString(this.string_1));
			jsonObject.Put("snapshot_home", new LogicJSONString(Convert.ToBase64String(this.byte_0)));
			jsonObject.Put("war_layout", new LogicJSONBoolean(this.bool_2));
			if (this.string_2 != null)
			{
				jsonObject.Put("battleLog", new LogicJSONString(this.string_2));
			}
		}

		// Token: 0x040003CD RID: 973
		private string string_1;

		// Token: 0x040003CE RID: 974
		private string string_2;

		// Token: 0x040003CF RID: 975
		private int int_3;

		// Token: 0x040003D0 RID: 976
		private bool bool_1;

		// Token: 0x040003D1 RID: 977
		private bool bool_2;

		// Token: 0x040003D2 RID: 978
		private byte[] byte_0;

		// Token: 0x040003D3 RID: 979
		private LogicLong logicLong_3;
	}
}
