using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AD RID: 173
	public class AllianceChallengeRequestMessage : ServerAccountMessage
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00007678 File Offset: 0x00005878
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00007680 File Offset: 0x00005880
		public LogicLong MemberId { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00007689 File Offset: 0x00005889
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x00007691 File Offset: 0x00005891
		public string Message { get; set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000769A File Offset: 0x0000589A
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x000076A2 File Offset: 0x000058A2
		public byte[] HomeJSON { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x000076AB File Offset: 0x000058AB
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x000076B3 File Offset: 0x000058B3
		public bool WarLayout { get; set; }

		// Token: 0x060004CA RID: 1226 RVA: 0x000076BC File Offset: 0x000058BC
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteString(this.Message);
			stream.WriteBytes(this.HomeJSON, this.HomeJSON.Length);
			stream.WriteBoolean(this.WarLayout);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
			this.HomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			this.WarLayout = stream.ReadBoolean();
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000076F6 File Offset: 0x000058F6
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_REQUEST;
		}

		// Token: 0x04000204 RID: 516
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000205 RID: 517
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000206 RID: 518
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x04000207 RID: 519
		[CompilerGenerated]
		private bool bool_0;
	}
}
