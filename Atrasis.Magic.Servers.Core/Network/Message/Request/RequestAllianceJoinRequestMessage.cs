using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000088 RID: 136
	public class RequestAllianceJoinRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00006C36 File Offset: 0x00004E36
		// (set) Token: 0x060003CF RID: 975 RVA: 0x00006C3E File Offset: 0x00004E3E
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x00006C47 File Offset: 0x00004E47
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x00006C4F File Offset: 0x00004E4F
		public LogicClientAvatar Avatar { get; set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x00006C58 File Offset: 0x00004E58
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x00006C60 File Offset: 0x00004E60
		public string Message { get; set; }

		// Token: 0x060003D4 RID: 980 RVA: 0x00006C69 File Offset: 0x00004E69
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.Message);
			stream.WriteLong(this.AllianceId);
			this.Avatar.Encode(stream);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00006C8F File Offset: 0x00004E8F
		public override void Decode(ByteStream stream)
		{
			this.Message = stream.ReadString(900000);
			this.AllianceId = stream.ReadLong();
			this.Avatar = new LogicClientAvatar();
			this.Avatar.Decode(stream);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00006CC5 File Offset: 0x00004EC5
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REQUEST_ALLIANCE_JOIN_REQUEST;
		}

		// Token: 0x040001C4 RID: 452
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001C5 RID: 453
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x040001C6 RID: 454
		[CompilerGenerated]
		private string string_0;
	}
}
