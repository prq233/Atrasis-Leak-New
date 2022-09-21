using System;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000D0 RID: 208
	public class AllianceWarMemberEntry
	{
		// Token: 0x0600090A RID: 2314 RVA: 0x000217AC File Offset: 0x0001F9AC
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.logicLong_1 = stream.ReadLong();
			this.logicLong_2 = stream.ReadLong();
			this.string_0 = stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			this.int_1 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				stream.ReadString(900000);
				stream.ReadInt();
				stream.ReadInt();
				stream.ReadInt();
				stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				stream.ReadLong();
			}
			if (stream.ReadBoolean())
			{
				stream.ReadLong();
			}
			if (stream.ReadBoolean())
			{
				stream.ReadLong();
			}
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadString(900000);
			stream.ReadInt();
			int num = stream.ReadInt();
			if (num >= 0)
			{
				Debugger.DoAssert(num < 10000, "Too large amount of donations in AllianceWarMemberEntry");
				this.logicArrayList_0 = new LogicArrayList<DonationContainer>();
				this.logicArrayList_0.EnsureCapacity(num);
				for (int i = stream.ReadInt(); i > 0; i--)
				{
					DonationContainer donationContainer = new DonationContainer();
					donationContainer.Decode(stream);
					this.logicArrayList_0.Add(donationContainer);
				}
			}
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00021954 File Offset: 0x0001FB54
		public void Encode(ByteStream encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteLong(this.logicLong_1);
			encoder.WriteLong(this.logicLong_2);
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteBoolean(false);
			encoder.WriteBoolean(false);
			encoder.WriteBoolean(false);
			encoder.WriteBoolean(false);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteString(null);
			encoder.WriteInt(0);
			if (this.logicArrayList_0 != null)
			{
				encoder.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.logicArrayList_0[i].Encode(encoder);
				}
				return;
			}
			encoder.WriteInt(0);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0000726A File Offset: 0x0000546A
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00007272 File Offset: 0x00005472
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0000727B File Offset: 0x0000547B
		public LogicLong GetAvatarId()
		{
			return this.logicLong_1;
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00007283 File Offset: 0x00005483
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0000728C File Offset: 0x0000548C
		public LogicLong GetHomeId()
		{
			return this.logicLong_2;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00007294 File Offset: 0x00005494
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0000729D File Offset: 0x0000549D
		public LogicArrayList<DonationContainer> GetDonations()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x000072A5 File Offset: 0x000054A5
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x000072AD File Offset: 0x000054AD
		public void SetName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x000072B6 File Offset: 0x000054B6
		public int GetExpLevel()
		{
			return this.int_0;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x000072BE File Offset: 0x000054BE
		public void SetExpLevel(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0400037E RID: 894
		private LogicLong logicLong_0;

		// Token: 0x0400037F RID: 895
		private LogicLong logicLong_1;

		// Token: 0x04000380 RID: 896
		private LogicLong logicLong_2;

		// Token: 0x04000381 RID: 897
		private LogicArrayList<DonationContainer> logicArrayList_0;

		// Token: 0x04000382 RID: 898
		private string string_0;

		// Token: 0x04000383 RID: 899
		private int int_0;

		// Token: 0x04000384 RID: 900
		private int int_1;
	}
}
