using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000040 RID: 64
	public class SendVillage2AttackEntryListToClientMessage : ServerSessionMessage
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000186 RID: 390 RVA: 0x000054D7 File Offset: 0x000036D7
		// (set) Token: 0x06000187 RID: 391 RVA: 0x000054DF File Offset: 0x000036DF
		public LogicArrayList<LogicLong> EntryIds { get; set; }

		// Token: 0x06000188 RID: 392 RVA: 0x0000BF44 File Offset: 0x0000A144
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.EntryIds.Size());
			for (int i = 0; i < this.EntryIds.Size(); i++)
			{
				stream.WriteLong(this.EntryIds[i]);
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000BF8C File Offset: 0x0000A18C
		public override void Decode(ByteStream stream)
		{
			this.EntryIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.EntryIds.Add(stream.ReadLong());
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000054E8 File Offset: 0x000036E8
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SEND_VILLAGE2_ATTACK_ENTRY_LIST_TO_CLIENT;
		}

		// Token: 0x040000F8 RID: 248
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
