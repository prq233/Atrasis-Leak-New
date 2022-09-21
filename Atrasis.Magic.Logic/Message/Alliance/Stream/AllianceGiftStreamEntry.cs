using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000D7 RID: 215
	public class AllianceGiftStreamEntry : StreamEntry
	{
		// Token: 0x06000935 RID: 2357 RVA: 0x00021D44 File Offset: 0x0001FF44
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadVInt();
			this.int_4 = stream.ReadVInt();
			int num = stream.ReadInt();
			if (num <= 50)
			{
				if (num > 0)
				{
					this.logicArrayList_0 = new LogicArrayList<LogicLong>(num);
					for (int i = 0; i < num; i++)
					{
						this.logicArrayList_0.Add(stream.ReadLong());
					}
					return;
				}
			}
			else
			{
				Debugger.Error(string.Format("Number of collected players ({0}) is too high.", num));
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00021DC0 File Offset: 0x0001FFC0
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteVInt(this.int_3);
			stream.WriteVInt(this.int_4);
			if (this.logicArrayList_0 != null)
			{
				stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					stream.WriteLong(this.logicArrayList_0[i]);
				}
				return;
			}
			stream.WriteInt(0);
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x000073FB File Offset: 0x000055FB
		public bool CanClaimGift(LogicLong id)
		{
			return this.logicArrayList_0.Size() < this.int_4 && this.logicArrayList_0.IndexOf(id) == -1;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00007421 File Offset: 0x00005621
		public void AddCollectedPlayer(LogicLong id)
		{
			if (this.logicArrayList_0.IndexOf(id) != -1)
			{
				Debugger.Error("AllianceGiftStreamEntry::addCollectedPlayer - specified player already added!");
			}
			this.logicArrayList_0.Add(id);
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00007448 File Offset: 0x00005648
		public int GetDiamondReward()
		{
			return this.int_3;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00007450 File Offset: 0x00005650
		public void SetDiamondReward(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00007459 File Offset: 0x00005659
		public int GetGiftCount()
		{
			return this.int_4;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00007461 File Offset: 0x00005661
		public void SetGiftCount(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0000746A File Offset: 0x0000566A
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.ALLIANCE_GIFT;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x00021E38 File Offset: 0x00020038
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("AllianceGiftStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.int_3 = jsonObject.GetJSONNumber("diamond_reward").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("gift_count").GetIntValue();
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("collected_players");
			for (int i = 0; i < jsonarray.Size(); i++)
			{
				LogicJSONArray jsonarray2 = jsonarray.GetJSONArray(i);
				LogicLong item = new LogicLong(jsonarray2.GetJSONNumber(0).GetIntValue(), jsonarray2.GetJSONNumber(1).GetIntValue());
				if (this.logicArrayList_0.IndexOf(item) == -1)
				{
					this.logicArrayList_0.Add(item);
				}
			}
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00021EF4 File Offset: 0x000200F4
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("diamond_reward", new LogicJSONNumber(this.int_3));
			jsonObject.Put("gift_count", new LogicJSONNumber(this.int_4));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicJSONArray logicJSONArray2 = new LogicJSONArray(2);
				logicJSONArray2.Add(new LogicJSONNumber(this.logicArrayList_0[i].GetHigherInt()));
				logicJSONArray2.Add(new LogicJSONNumber(this.logicArrayList_0[i].GetLowerInt()));
				logicJSONArray.Add(logicJSONArray2);
			}
			jsonObject.Put("collected_players", logicJSONArray);
		}

		// Token: 0x040003A3 RID: 931
		private int int_3;

		// Token: 0x040003A4 RID: 932
		private int int_4;

		// Token: 0x040003A5 RID: 933
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
