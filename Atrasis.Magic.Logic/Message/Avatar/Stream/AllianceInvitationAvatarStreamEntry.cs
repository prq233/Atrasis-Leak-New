using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000091 RID: 145
	public class AllianceInvitationAvatarStreamEntry : AvatarStreamEntry
	{
		// Token: 0x0600062B RID: 1579 RVA: 0x000059D4 File Offset: 0x00003BD4
		public AllianceInvitationAvatarStreamEntry()
		{
			this.int_3 = -1;
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001DCB8 File Offset: 0x0001BEB8
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteLong(this.logicLong_2);
			stream.WriteString(this.string_1);
			stream.WriteInt(this.int_3);
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_3);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteInt(this.int_4);
			stream.WriteBoolean(true);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001DD28 File Offset: 0x0001BF28
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.logicLong_2 = stream.ReadLong();
			this.string_1 = stream.ReadString(900000);
			this.int_3 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
			}
			this.int_4 = stream.ReadInt();
			stream.ReadBoolean();
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x000059E3 File Offset: 0x00003BE3
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x000059EB File Offset: 0x00003BEB
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x000059F4 File Offset: 0x00003BF4
		public LogicLong GetSenderHomeId()
		{
			return this.logicLong_3;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000059FC File Offset: 0x00003BFC
		public void SetSenderHomeId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00005A05 File Offset: 0x00003C05
		public string GetAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00005A0D File Offset: 0x00003C0D
		public void SetAllianceName(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00005A16 File Offset: 0x00003C16
		public int GetAllianceBadgeId()
		{
			return this.int_3;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00005A1E File Offset: 0x00003C1E
		public void SetAllianceBadgeId(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00005A27 File Offset: 0x00003C27
		public int GetAllianceLevel()
		{
			return this.int_4;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00005A2F File Offset: 0x00003C2F
		public void SetAllianceLevel(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00002EAE File Offset: 0x000010AE
		public override AvatarStreamEntryType GetAvatarStreamEntryType()
		{
			return AvatarStreamEntryType.ALLIANCE_INVITATION;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0001DD8C File Offset: 0x0001BF8C
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("AllianceInvitationAvatarStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("alli_id_high");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("alli_id_low");
			if (jsonnumber != null && jsonnumber2 != null)
			{
				this.logicLong_2 = new LogicLong(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
			}
			this.string_1 = jsonObject.GetJSONString("alli_name").GetStringValue();
			this.int_3 = jsonObject.GetJSONNumber("alli_badge_id").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("alli_level").GetIntValue();
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("sender_id_high");
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("sender_id_low");
			if (jsonnumber3 != null && jsonnumber4 != null)
			{
				this.logicLong_3 = new LogicLong(jsonnumber3.GetIntValue(), jsonnumber4.GetIntValue());
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001DE68 File Offset: 0x0001C068
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("alli_id_high", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
			jsonObject.Put("alli_id_low", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
			jsonObject.Put("alli_name", new LogicJSONString(this.string_1));
			jsonObject.Put("alli_badge_id", new LogicJSONNumber(this.int_3));
			jsonObject.Put("alli_level", new LogicJSONNumber(this.int_4));
			if (this.logicLong_3 != null)
			{
				jsonObject.Put("sender_id_high", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("sender_id_low", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			}
		}

		// Token: 0x0400024E RID: 590
		private LogicLong logicLong_2;

		// Token: 0x0400024F RID: 591
		private LogicLong logicLong_3;

		// Token: 0x04000250 RID: 592
		private string string_1;

		// Token: 0x04000251 RID: 593
		private int int_3;

		// Token: 0x04000252 RID: 594
		private int int_4;
	}
}
