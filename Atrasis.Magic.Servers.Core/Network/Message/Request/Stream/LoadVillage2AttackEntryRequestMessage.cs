using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200009A RID: 154
	public class LoadVillage2AttackEntryRequestMessage : ServerRequestMessage
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x00007161 File Offset: 0x00005361
		// (set) Token: 0x06000443 RID: 1091 RVA: 0x00007169 File Offset: 0x00005369
		public LogicLong Id { get; set; }

		// Token: 0x06000444 RID: 1092 RVA: 0x00007172 File Offset: 0x00005372
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.Id);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00007180 File Offset: 0x00005380
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadLong();
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000718E File Offset: 0x0000538E
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_VILLAGE2_ATTACK_ENTRY_REQUEST;
		}

		// Token: 0x040001E9 RID: 489
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
