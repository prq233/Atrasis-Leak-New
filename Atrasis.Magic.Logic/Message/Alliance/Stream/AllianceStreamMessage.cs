using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000DA RID: 218
	public class AllianceStreamMessage : PiranhaMessage
	{
		// Token: 0x06000953 RID: 2387 RVA: 0x00007566 File Offset: 0x00005766
		public AllianceStreamMessage() : this(0)
		{
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceStreamMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00021FC0 File Offset: 0x000201C0
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num > 0)
			{
				this.logicArrayList_0 = new LogicArrayList<StreamEntry>(num);
				do
				{
					StreamEntry streamEntry = StreamEntryFactory.CreateStreamEntryByType((StreamEntryType)this.m_stream.ReadInt());
					streamEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(streamEntry);
				}
				while (--num > 0);
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00022020 File Offset: 0x00020220
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(0);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.m_stream.WriteInt((int)this.logicArrayList_0[i].GetStreamEntryType());
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0000756F File Offset: 0x0000576F
		public override short GetMessageType()
		{
			return 24311;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x00007576 File Offset: 0x00005776
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00007585 File Offset: 0x00005785
		public LogicArrayList<StreamEntry> RemovestreamEntries()
		{
			LogicArrayList<StreamEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00007594 File Offset: 0x00005794
		public void SetStreamEntries(LogicArrayList<StreamEntry> array)
		{
			this.logicArrayList_0 = array;
		}

		// Token: 0x040003AA RID: 938
		public const int MESSAGE_TYPE = 24311;

		// Token: 0x040003AB RID: 939
		private LogicArrayList<StreamEntry> logicArrayList_0;
	}
}
