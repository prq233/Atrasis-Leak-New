using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B4 RID: 180
	public class AllianceShareReplayMessage : ServerAccountMessage
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x00007956 File Offset: 0x00005B56
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x0000795E File Offset: 0x00005B5E
		public LogicLong MemberId { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x00007967 File Offset: 0x00005B67
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x0000796F File Offset: 0x00005B6F
		public LogicLong ReplayId { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x00007978 File Offset: 0x00005B78
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x00007980 File Offset: 0x00005B80
		public string Message { get; set; }

		// Token: 0x0600050E RID: 1294 RVA: 0x00007989 File Offset: 0x00005B89
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.ReplayId);
			stream.WriteString(this.Message);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x000079AF File Offset: 0x00005BAF
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.ReplayId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x000079DA File Offset: 0x00005BDA
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_SHARE_REPLAY;
		}

		// Token: 0x04000219 RID: 537
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400021A RID: 538
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x0400021B RID: 539
		[CompilerGenerated]
		private string string_0;
	}
}
