using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000093 RID: 147
	public class AllianceMailAvatarStreamEntry : AvatarStreamEntry
	{
		// Token: 0x0600064B RID: 1611 RVA: 0x00005A9C File Offset: 0x00003C9C
		public AllianceMailAvatarStreamEntry()
		{
			this.int_3 = -1;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0001E1BC File Offset: 0x0001C3BC
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_3);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteLong(this.logicLong_2);
			stream.WriteString(this.string_2);
			stream.WriteInt(this.int_3);
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0001E224 File Offset: 0x0001C424
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
			}
			this.logicLong_2 = stream.ReadLong();
			this.string_2 = stream.ReadString(900000);
			this.int_3 = stream.ReadInt();
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00005AAB File Offset: 0x00003CAB
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x00005AB3 File Offset: 0x00003CB3
		public void SetAllianceId(LogicLong allianceId)
		{
			this.logicLong_2 = allianceId;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x00005ABC File Offset: 0x00003CBC
		public LogicLong GetSenderHomeId()
		{
			return this.logicLong_3;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x00005AC4 File Offset: 0x00003CC4
		public void SetSenderHomeId(LogicLong allianceId)
		{
			this.logicLong_3 = allianceId;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x00005ACD File Offset: 0x00003CCD
		public string GetAllianceName()
		{
			return this.string_2;
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00005AD5 File Offset: 0x00003CD5
		public void SetAllianceName(string name)
		{
			this.string_2 = name;
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00005ADE File Offset: 0x00003CDE
		public int GetAllianceBadgeId()
		{
			return this.int_3;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00005AE6 File Offset: 0x00003CE6
		public void SetAllianceBadgeId(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00005AEF File Offset: 0x00003CEF
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00005AF7 File Offset: 0x00003CF7
		public void SetMessage(string message)
		{
			this.string_1 = message;
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00002D0B File Offset: 0x00000F0B
		public override AvatarStreamEntryType GetAvatarStreamEntryType()
		{
			return AvatarStreamEntryType.ALLIANCE_MAIL;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001E288 File Offset: 0x0001C488
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

		// Token: 0x0600065A RID: 1626 RVA: 0x0001E358 File Offset: 0x0001C558
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

		// Token: 0x04000258 RID: 600
		private LogicLong logicLong_2;

		// Token: 0x04000259 RID: 601
		private LogicLong logicLong_3;

		// Token: 0x0400025A RID: 602
		private string string_1;

		// Token: 0x0400025B RID: 603
		private string string_2;

		// Token: 0x0400025C RID: 604
		private int int_3;
	}
}
