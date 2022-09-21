using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x0200009B RID: 155
	public class JoinAllianceResponseAvatarStreamEntry : AvatarStreamEntry
	{
		// Token: 0x060006A1 RID: 1697 RVA: 0x00005D69 File Offset: 0x00003F69
		public JoinAllianceResponseAvatarStreamEntry()
		{
			this.int_3 = -1;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0001EB58 File Offset: 0x0001CD58
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteLong(this.logicLong_2);
			stream.WriteString(this.string_1);
			stream.WriteInt(this.int_3);
			stream.WriteString(this.string_2);
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_3);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001EBC0 File Offset: 0x0001CDC0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.logicLong_2 = stream.ReadLong();
			this.string_1 = stream.ReadString(900000);
			this.int_3 = stream.ReadInt();
			this.string_2 = stream.ReadString(900000);
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
			}
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00005D78 File Offset: 0x00003F78
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00005D80 File Offset: 0x00003F80
		public void SetAllianceId(LogicLong allianceId)
		{
			this.logicLong_2 = allianceId;
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00005D89 File Offset: 0x00003F89
		public LogicLong GetSenderHomeId()
		{
			return this.logicLong_3;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00005D91 File Offset: 0x00003F91
		public void SetSenderHomeId(LogicLong allianceId)
		{
			this.logicLong_3 = allianceId;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00005D9A File Offset: 0x00003F9A
		public string GetAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00005DA2 File Offset: 0x00003FA2
		public void SetAllianceName(string name)
		{
			this.string_1 = name;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00005DAB File Offset: 0x00003FAB
		public int GetAllianceBadgeId()
		{
			return this.int_3;
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00005DB3 File Offset: 0x00003FB3
		public void SetAllianceBadgeId(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00005DBC File Offset: 0x00003FBC
		public string GetMessage()
		{
			return this.string_2;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00005DC4 File Offset: 0x00003FC4
		public void SetMessage(string message)
		{
			this.string_2 = message;
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00002C4D File Offset: 0x00000E4D
		public override AvatarStreamEntryType GetAvatarStreamEntryType()
		{
			return AvatarStreamEntryType.JOIN_ALLIANCE_RESPONSE;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001EC24 File Offset: 0x0001CE24
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("JoinAllianceResponseAvatarStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("alli_id_high");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("alli_id_low");
			if (jsonnumber != null && jsonnumber2 != null)
			{
				this.logicLong_2 = new LogicLong(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
			}
			this.string_1 = LogicJSONHelper.GetString(jsonObject, "alli_name");
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "alli_badge_id");
			this.string_2 = LogicJSONHelper.GetString(jsonObject, "message");
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("sender_id_high");
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("sender_id_low");
			if (jsonnumber3 != null && jsonnumber4 != null)
			{
				this.logicLong_3 = new LogicLong(jsonnumber3.GetIntValue(), jsonnumber4.GetIntValue());
			}
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0001ECF4 File Offset: 0x0001CEF4
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("alli_id_high", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
			jsonObject.Put("alli_id_low", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
			jsonObject.Put("alli_name", new LogicJSONString(this.string_1));
			jsonObject.Put("alli_badge_id", new LogicJSONNumber(this.int_3));
			jsonObject.Put("message", new LogicJSONString(this.string_2));
			if (this.logicLong_3 != null)
			{
				jsonObject.Put("sender_id_high", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("sender_id_low", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			}
		}

		// Token: 0x0400027C RID: 636
		private LogicLong logicLong_2;

		// Token: 0x0400027D RID: 637
		private LogicLong logicLong_3;

		// Token: 0x0400027E RID: 638
		private string string_1;

		// Token: 0x0400027F RID: 639
		private string string_2;

		// Token: 0x04000280 RID: 640
		private int int_3;
	}
}
