using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000092 RID: 146
	public class AllianceKickOutStreamEntry : AvatarStreamEntry
	{
		// Token: 0x0600063B RID: 1595 RVA: 0x00005A38 File Offset: 0x00003C38
		public AllianceKickOutStreamEntry()
		{
			this.int_3 = -1;
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0001DF44 File Offset: 0x0001C144
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			stream.WriteLong(this.logicLong_2);
			stream.WriteString(this.string_2);
			stream.WriteInt(this.int_3);
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_3);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0001DFAC File Offset: 0x0001C1AC
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
			this.logicLong_2 = stream.ReadLong();
			this.string_2 = stream.ReadString(900000);
			this.int_3 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00005A47 File Offset: 0x00003C47
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x00005A4F File Offset: 0x00003C4F
		public void SetAllianceId(LogicLong allianceId)
		{
			this.logicLong_2 = allianceId;
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00005A58 File Offset: 0x00003C58
		public LogicLong GetSenderHomeId()
		{
			return this.logicLong_3;
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x00005A60 File Offset: 0x00003C60
		public void SetSenderHomeId(LogicLong allianceId)
		{
			this.logicLong_3 = allianceId;
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00005A69 File Offset: 0x00003C69
		public string GetAllianceName()
		{
			return this.string_2;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00005A71 File Offset: 0x00003C71
		public void SetAllianceName(string name)
		{
			this.string_2 = name;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00005A7A File Offset: 0x00003C7A
		public int GetAllianceBadgeId()
		{
			return this.int_3;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00005A82 File Offset: 0x00003C82
		public void SetAllianceBadgeId(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00005A8B File Offset: 0x00003C8B
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00005A93 File Offset: 0x00003C93
		public void SetMessage(string message)
		{
			this.string_1 = message;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00002BCC File Offset: 0x00000DCC
		public override AvatarStreamEntryType GetAvatarStreamEntryType()
		{
			return AvatarStreamEntryType.ALLIANCE_KICKOUT;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0001E010 File Offset: 0x0001C210
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("AllianceKickOutStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("alli_id_high");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("alli_id_low");
			if (jsonnumber != null && jsonnumber2 != null)
			{
				this.logicLong_2 = new LogicLong(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
			}
			this.string_2 = LogicJSONHelper.GetString(jsonObject, "alli_name");
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "alli_badge_id");
			this.string_1 = LogicJSONHelper.GetString(jsonObject, "message");
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("sender_id_high");
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("sender_id_low");
			if (jsonnumber3 != null && jsonnumber4 != null)
			{
				this.logicLong_3 = new LogicLong(jsonnumber3.GetIntValue(), jsonnumber4.GetIntValue());
			}
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001E0E0 File Offset: 0x0001C2E0
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("alli_id_high", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
			jsonObject.Put("alli_id_low", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
			jsonObject.Put("alli_name", new LogicJSONString(this.string_2));
			jsonObject.Put("alli_badge_id", new LogicJSONNumber(this.int_3));
			jsonObject.Put("message", new LogicJSONString(this.string_1));
			if (this.logicLong_3 != null)
			{
				jsonObject.Put("sender_id_high", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("sender_id_low", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			}
		}

		// Token: 0x04000253 RID: 595
		private LogicLong logicLong_2;

		// Token: 0x04000254 RID: 596
		private LogicLong logicLong_3;

		// Token: 0x04000255 RID: 597
		private string string_1;

		// Token: 0x04000256 RID: 598
		private string string_2;

		// Token: 0x04000257 RID: 599
		private int int_3;
	}
}
