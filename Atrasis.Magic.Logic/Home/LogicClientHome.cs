using System;
using Atrasis.Magic.Logic.Home.Change;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Home
{
	// Token: 0x02000105 RID: 261
	public class LogicClientHome
	{
		// Token: 0x06000C85 RID: 3205 RVA: 0x00009155 File Offset: 0x00007355
		public LogicClientHome()
		{
			this.logicCompressibleString_0 = new LogicCompressibleString();
			this.logicCompressibleString_1 = new LogicCompressibleString();
			this.logicCompressibleString_2 = new LogicCompressibleString();
			this.Init();
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0002B450 File Offset: 0x00029650
		public void Destruct()
		{
			if (this.logicCompressibleString_1 != null)
			{
				this.logicCompressibleString_1.Destruct();
				this.logicCompressibleString_1 = null;
			}
			if (this.logicCompressibleString_2 != null)
			{
				this.logicCompressibleString_2.Destruct();
				this.logicCompressibleString_2 = null;
			}
			if (this.logicCompressibleString_0 != null)
			{
				this.logicCompressibleString_0.Destruct();
				this.logicCompressibleString_0 = null;
			}
			if (this.logicHomeChangeListener_0 != null)
			{
				this.logicHomeChangeListener_0.Destruct();
				this.logicHomeChangeListener_0 = null;
			}
			this.logicLong_0 = null;
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00009184 File Offset: 0x00007384
		public void Init()
		{
			this.logicLong_0 = new LogicLong();
			this.logicHomeChangeListener_0 = new LogicHomeChangeListener();
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x0002B4CC File Offset: 0x000296CC
		public virtual void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			this.logicCompressibleString_0.Encode(encoder);
			this.logicCompressibleString_2.Encode(encoder);
			this.logicCompressibleString_1.Encode(encoder);
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x0002B530 File Offset: 0x00029730
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicCompressibleString_0.Decode(stream);
			this.logicCompressibleString_2.Decode(stream);
			this.logicCompressibleString_1.Decode(stream);
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x0000919C File Offset: 0x0000739C
		public LogicLong GetHomeId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x000091A4 File Offset: 0x000073A4
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x000091AD File Offset: 0x000073AD
		public int GetShieldDurationSeconds()
		{
			return this.int_0;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x000091B5 File Offset: 0x000073B5
		public int GetGuardDurationSeconds()
		{
			return this.int_1;
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x000091BD File Offset: 0x000073BD
		public int GetPersonalBreakSeconds()
		{
			return this.int_2;
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x000091C5 File Offset: 0x000073C5
		public LogicCompressibleString GetCompressibleCalendarJSON()
		{
			return this.logicCompressibleString_2;
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x000091CD File Offset: 0x000073CD
		public LogicCompressibleString GetCompressibleGlobalJSON()
		{
			return this.logicCompressibleString_1;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x000091D5 File Offset: 0x000073D5
		public LogicCompressibleString GetCompressibleHomeJSON()
		{
			return this.logicCompressibleString_0;
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x000091DD File Offset: 0x000073DD
		public string GetHomeJSON()
		{
			return this.logicCompressibleString_0.Get();
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x000091EA File Offset: 0x000073EA
		public void SetHomeJSON(string json)
		{
			this.logicCompressibleString_0.Set(json);
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x000091F8 File Offset: 0x000073F8
		public string GetCalendarJSON()
		{
			return this.logicCompressibleString_2.Get();
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x00009205 File Offset: 0x00007405
		public void SetCalendarJSON(string json)
		{
			this.logicCompressibleString_2.Set(json);
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00009213 File Offset: 0x00007413
		public string GetGlobalJSON()
		{
			return this.logicCompressibleString_1.Get();
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00009220 File Offset: 0x00007420
		public void SetGlobalJSON(string json)
		{
			this.logicCompressibleString_1.Set(json);
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x0000922E File Offset: 0x0000742E
		public void SetShieldDurationSeconds(int secs)
		{
			this.int_0 = secs;
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x00009237 File Offset: 0x00007437
		public void SetGuardDurationSeconds(int secs)
		{
			this.int_1 = secs;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x00009240 File Offset: 0x00007440
		public void SetPersonalBreakSeconds(int secs)
		{
			this.int_2 = secs;
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00009249 File Offset: 0x00007449
		public LogicHomeChangeListener GetChangeListener()
		{
			return this.logicHomeChangeListener_0;
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x00009251 File Offset: 0x00007451
		public void SetChangeListener(LogicHomeChangeListener listener)
		{
			this.logicHomeChangeListener_0 = listener;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0002B594 File Offset: 0x00029794
		public LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("homeJSON", this.logicCompressibleString_0.Save());
			logicJSONObject.Put("shield_t", new LogicJSONNumber(this.int_0));
			logicJSONObject.Put("guard_t", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("personal_break_t", new LogicJSONNumber(this.int_2));
			return logicJSONObject;
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x0002B600 File Offset: 0x00029800
		public void Load(LogicJSONObject jsonObject)
		{
			this.logicCompressibleString_0.Load(jsonObject.GetJSONObject("homeJSON"));
			this.int_0 = jsonObject.GetJSONNumber("shield_t").GetIntValue();
			this.int_1 = jsonObject.GetJSONNumber("guard_t").GetIntValue();
			this.int_2 = jsonObject.GetJSONNumber("personal_break_t").GetIntValue();
		}

		// Token: 0x04000503 RID: 1283
		private LogicLong logicLong_0;

		// Token: 0x04000504 RID: 1284
		private LogicHomeChangeListener logicHomeChangeListener_0;

		// Token: 0x04000505 RID: 1285
		private int int_0;

		// Token: 0x04000506 RID: 1286
		private int int_1;

		// Token: 0x04000507 RID: 1287
		private int int_2;

		// Token: 0x04000508 RID: 1288
		private LogicCompressibleString logicCompressibleString_0;

		// Token: 0x04000509 RID: 1289
		private LogicCompressibleString logicCompressibleString_1;

		// Token: 0x0400050A RID: 1290
		private LogicCompressibleString logicCompressibleString_2;
	}
}
