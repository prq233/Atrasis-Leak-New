using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003E RID: 62
	public class SendAllianceBookmarksFullDataToClientMessage : ServerSessionMessage
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600017A RID: 378 RVA: 0x000054A7 File Offset: 0x000036A7
		// (set) Token: 0x0600017B RID: 379 RVA: 0x000054AF File Offset: 0x000036AF
		public LogicArrayList<LogicLong> AllianceIds { get; set; }

		// Token: 0x0600017C RID: 380 RVA: 0x0000BE3C File Offset: 0x0000A03C
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.AllianceIds.Size());
			for (int i = 0; i < this.AllianceIds.Size(); i++)
			{
				stream.WriteLong(this.AllianceIds[i]);
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000BE84 File Offset: 0x0000A084
		public override void Decode(ByteStream stream)
		{
			this.AllianceIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.AllianceIds.Add(stream.ReadLong());
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000054B8 File Offset: 0x000036B8
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SEND_ALLIANCE_BOOKMARKS_FULL_DATA_TO_CLIENT;
		}

		// Token: 0x040000F6 RID: 246
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
