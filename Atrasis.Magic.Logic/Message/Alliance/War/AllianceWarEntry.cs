using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000CB RID: 203
	public class AllianceWarEntry
	{
		// Token: 0x060008CA RID: 2250 RVA: 0x00021094 File Offset: 0x0001F294
		public void Decode(ByteStream stream)
		{
			this.allianceWarHeader_0 = new AllianceWarHeader();
			this.allianceWarHeader_0.Decode(stream);
			int num = stream.ReadInt();
			if (num >= 0)
			{
				Debugger.DoAssert(num < 1000, "Too many alliance war member entries in AllianceWarEntry");
				this.logicArrayList_0 = new LogicArrayList<AllianceWarMemberEntry>();
				this.logicArrayList_0.EnsureCapacity(num);
				for (int i = 0; i < num; i++)
				{
					AllianceWarMemberEntry allianceWarMemberEntry = new AllianceWarMemberEntry();
					allianceWarMemberEntry.Decode(stream);
					this.logicArrayList_0.Add(allianceWarMemberEntry);
				}
			}
			this.bool_0 = stream.ReadBoolean();
			stream.ReadBoolean();
			int num2 = stream.ReadInt();
			if (num2 >= 0)
			{
				Debugger.DoAssert(num2 <= 50, "Too many entries in the alliance exp map");
				this.logicArrayList_1 = new LogicArrayList<int>();
				this.logicArrayList_1.EnsureCapacity(num2);
				for (int j = 0; j < num2; j++)
				{
					this.logicArrayList_1.Add(stream.ReadInt());
				}
			}
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x000211D4 File Offset: 0x0001F3D4
		public void Encode(ByteStream encoder)
		{
			this.allianceWarHeader_0.Encode(encoder);
			if (this.logicArrayList_0 != null)
			{
				encoder.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.logicArrayList_0[i].Encode(encoder);
				}
			}
			else
			{
				encoder.WriteInt(-1);
			}
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteBoolean(true);
			if (this.logicArrayList_1 != null)
			{
				encoder.WriteInt(this.logicArrayList_1.Size());
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					encoder.WriteInt(this.logicArrayList_1[j]);
				}
			}
			else
			{
				encoder.WriteInt(-1);
			}
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00007083 File Offset: 0x00005283
		public AllianceWarHeader GetAllianceWarHeader()
		{
			return this.allianceWarHeader_0;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0000708B File Offset: 0x0000528B
		public void SetAllianceWarHeader(AllianceWarHeader value)
		{
			this.allianceWarHeader_0 = value;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00007094 File Offset: 0x00005294
		public LogicArrayList<AllianceWarMemberEntry> GetAllianceWarMemberList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0000709C File Offset: 0x0000529C
		public int GetAllianceWarMemberCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x000070A9 File Offset: 0x000052A9
		public void SetAllianceWarMemberList(LogicArrayList<AllianceWarMemberEntry> value)
		{
			this.logicArrayList_0 = value;
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x000070B2 File Offset: 0x000052B2
		public LogicArrayList<int> GetAllianceExpMap()
		{
			return this.logicArrayList_1;
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x000070BA File Offset: 0x000052BA
		public void SetAllianceExpMap(LogicArrayList<int> value)
		{
			this.logicArrayList_1 = value;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x000070C3 File Offset: 0x000052C3
		public bool IsEnded()
		{
			return this.bool_0;
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x000070CB File Offset: 0x000052CB
		public void SetEnded(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x000070D4 File Offset: 0x000052D4
		public int GetWarState()
		{
			return this.int_0;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x000070DC File Offset: 0x000052DC
		public void SetWarState(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x000070E5 File Offset: 0x000052E5
		public int GetWarStateRemainingSeconds()
		{
			return this.int_1;
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x000070ED File Offset: 0x000052ED
		public void SetWarStateRemainingSeconds(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x000070F6 File Offset: 0x000052F6
		public int GetAllianceWarLootBonusPecentWin()
		{
			return this.int_2;
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000070FE File Offset: 0x000052FE
		public void SetAllianceWarLootBonusPecentWin(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00007107 File Offset: 0x00005307
		public int GetAllianceWarLootBonusPecentDraw()
		{
			return this.int_3;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0000710F File Offset: 0x0000530F
		public void SetAllianceWarLootBonusPecentDraw(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00007118 File Offset: 0x00005318
		public int GetAllianceWarLootBonusPecentLose()
		{
			return this.int_4;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00007120 File Offset: 0x00005320
		public void SetAllianceWarLootBonusPecentLose(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x0400035C RID: 860
		private AllianceWarHeader allianceWarHeader_0;

		// Token: 0x0400035D RID: 861
		private LogicArrayList<AllianceWarMemberEntry> logicArrayList_0;

		// Token: 0x0400035E RID: 862
		private LogicArrayList<int> logicArrayList_1;

		// Token: 0x0400035F RID: 863
		private bool bool_0;

		// Token: 0x04000360 RID: 864
		private int int_0;

		// Token: 0x04000361 RID: 865
		private int int_1;

		// Token: 0x04000362 RID: 866
		private int int_2;

		// Token: 0x04000363 RID: 867
		private int int_3;

		// Token: 0x04000364 RID: 868
		private int int_4;
	}
}
