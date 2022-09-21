using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000038 RID: 56
	public class GameFriendlyScoutMessage : ServerSessionMessage
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00005297 File Offset: 0x00003497
		// (set) Token: 0x0600014F RID: 335 RVA: 0x0000529F File Offset: 0x0000349F
		public LogicLong AccountId { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000052A8 File Offset: 0x000034A8
		// (set) Token: 0x06000151 RID: 337 RVA: 0x000052B0 File Offset: 0x000034B0
		public LogicLong StreamId { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000052B9 File Offset: 0x000034B9
		// (set) Token: 0x06000153 RID: 339 RVA: 0x000052C1 File Offset: 0x000034C1
		public byte[] HomeJSON { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000052CA File Offset: 0x000034CA
		// (set) Token: 0x06000155 RID: 341 RVA: 0x000052D2 File Offset: 0x000034D2
		public int MapId { get; set; }

		// Token: 0x06000156 RID: 342 RVA: 0x000052DB File Offset: 0x000034DB
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteLong(this.StreamId);
			stream.WriteBytes(this.HomeJSON, this.HomeJSON.Length);
			stream.WriteVInt(this.MapId);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00005315 File Offset: 0x00003515
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.StreamId = stream.ReadLong();
			this.HomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			this.MapId = stream.ReadVInt();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00005352 File Offset: 0x00003552
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_FRIENDLY_SCOUT;
		}

		// Token: 0x040000EC RID: 236
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000ED RID: 237
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040000EE RID: 238
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x040000EF RID: 239
		[CompilerGenerated]
		private int int_2;
	}
}
