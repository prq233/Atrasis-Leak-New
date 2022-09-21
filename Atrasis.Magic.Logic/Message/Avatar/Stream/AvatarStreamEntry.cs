using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000094 RID: 148
	public class AvatarStreamEntry
	{
		// Token: 0x0600065B RID: 1627 RVA: 0x00005B00 File Offset: 0x00003D00
		public AvatarStreamEntry()
		{
			this.logicLong_0 = new LogicLong();
			this.bool_0 = true;
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x00005B1A File Offset: 0x00003D1A
		public virtual void Destruct()
		{
			this.logicLong_0 = null;
			this.logicLong_1 = null;
			this.string_0 = null;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0001E434 File Offset: 0x0001C634
		public virtual void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			if (this.logicLong_1 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_1);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteString(this.string_0);
			stream.WriteInt(this.int_0);
			stream.WriteInt(this.int_1);
			stream.WriteInt(this.int_2);
			stream.WriteBoolean(this.bool_1);
			stream.WriteBoolean(this.bool_0);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0001E4BC File Offset: 0x0001C6BC
		public virtual void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.logicLong_1 = stream.ReadLong();
			}
			this.string_0 = stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_1 = stream.ReadBoolean();
			this.bool_0 = stream.ReadBoolean();
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00005B31 File Offset: 0x00003D31
		public virtual AvatarStreamEntryType GetAvatarStreamEntryType()
		{
			Debugger.Error("getAvatarStreamEntryType() must be overridden");
			return (AvatarStreamEntryType)(-1);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0001E538 File Offset: 0x0001C738
		public virtual void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			if (this.logicLong_1 != null)
			{
				logicJSONObject.Put("avatar_id_hi", new LogicJSONNumber(this.logicLong_1.GetHigherInt()));
				logicJSONObject.Put("avatar_id_lo", new LogicJSONNumber(this.logicLong_1.GetLowerInt()));
			}
			logicJSONObject.Put("name", new LogicJSONString(this.string_0));
			logicJSONObject.Put("exp_lvl", new LogicJSONNumber(this.int_0));
			logicJSONObject.Put("league_type", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("is_dismissed", new LogicJSONBoolean(this.bool_1));
			logicJSONObject.Put("is_new", new LogicJSONBoolean(this.bool_0));
			jsonObject.Put("sender", logicJSONObject);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001E604 File Offset: 0x0001C804
		public virtual void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("sender");
			if (jsonobject != null)
			{
				LogicJSONNumber jsonnumber = jsonobject.GetJSONNumber("avatar_id_hi");
				if (jsonnumber != null)
				{
					this.logicLong_1 = new LogicLong(jsonnumber.GetIntValue(), jsonobject.GetJSONNumber("avatar_id_lo").GetIntValue());
				}
				this.string_0 = jsonobject.GetJSONString("name").GetStringValue();
				this.int_0 = jsonobject.GetJSONNumber("exp_lvl").GetIntValue();
				this.int_1 = jsonobject.GetJSONNumber("league_type").GetIntValue();
				LogicJSONBoolean jsonboolean = jsonobject.GetJSONBoolean("is_dismissed");
				if (jsonboolean != null)
				{
					this.bool_1 = jsonboolean.IsTrue();
				}
				LogicJSONBoolean jsonboolean2 = jsonobject.GetJSONBoolean("is_new");
				if (jsonboolean2 != null)
				{
					this.bool_0 = jsonboolean2.IsTrue();
				}
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x00005B3E File Offset: 0x00003D3E
		public LogicLong GetId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00005B46 File Offset: 0x00003D46
		public void SetId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x00005B4F File Offset: 0x00003D4F
		public LogicLong GetSenderAvatarId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00005B57 File Offset: 0x00003D57
		public void SetSenderAvatarId(LogicLong allianceId)
		{
			this.logicLong_1 = allianceId;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00005B60 File Offset: 0x00003D60
		public int GetAgeSeconds()
		{
			return this.int_2;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x00005B68 File Offset: 0x00003D68
		public void SetAgeSeconds(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x00005B71 File Offset: 0x00003D71
		public string GetSenderName()
		{
			return this.string_0;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00005B79 File Offset: 0x00003D79
		public void SetSenderName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00005B82 File Offset: 0x00003D82
		public int GetSenderLevel()
		{
			return this.int_0;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00005B8A File Offset: 0x00003D8A
		public void SetSenderLevel(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00005B93 File Offset: 0x00003D93
		public int GetSenderLeagueType()
		{
			return this.int_1;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00005B9B File Offset: 0x00003D9B
		public void SetSenderLeagueType(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00005BA4 File Offset: 0x00003DA4
		public bool IsNew()
		{
			return this.bool_0;
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00005BAC File Offset: 0x00003DAC
		public void SetNew(bool isNew)
		{
			this.bool_0 = isNew;
		}

		// Token: 0x0400025D RID: 605
		private LogicLong logicLong_0;

		// Token: 0x0400025E RID: 606
		private LogicLong logicLong_1;

		// Token: 0x0400025F RID: 607
		private string string_0;

		// Token: 0x04000260 RID: 608
		private int int_0;

		// Token: 0x04000261 RID: 609
		private int int_1;

		// Token: 0x04000262 RID: 610
		private int int_2;

		// Token: 0x04000263 RID: 611
		private bool bool_0;

		// Token: 0x04000264 RID: 612
		private bool bool_1;
	}
}
