using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.War.Event
{
	// Token: 0x020000D3 RID: 211
	public class WarEventEntry
	{
		// Token: 0x06000925 RID: 2341 RVA: 0x00007315 File Offset: 0x00005515
		public virtual void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			stream.WriteInt(this.int_0);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0000732F File Offset: 0x0000552F
		public virtual void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.int_0 = stream.ReadInt();
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00002B30 File Offset: 0x00000D30
		public virtual int GetWarEventEntryType()
		{
			return -1;
		}

		// Token: 0x04000391 RID: 913
		public const int WAR_EVENT_ENTRY_TYPE_ATTACK = 1;

		// Token: 0x04000392 RID: 914
		private LogicLong logicLong_0;

		// Token: 0x04000393 RID: 915
		private int int_0;
	}
}
