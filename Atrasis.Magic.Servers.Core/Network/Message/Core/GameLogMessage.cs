using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009F RID: 159
	public class GameLogMessage : ServerCoreMessage
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x000072F7 File Offset: 0x000054F7
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x000072FF File Offset: 0x000054FF
		public int LogType { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x00007308 File Offset: 0x00005508
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x00007310 File Offset: 0x00005510
		public string Message { get; set; }

		// Token: 0x06000468 RID: 1128 RVA: 0x00007319 File Offset: 0x00005519
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.LogType);
			stream.WriteString(this.Message);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00007333 File Offset: 0x00005533
		public override void Decode(ByteStream stream)
		{
			this.LogType = stream.ReadVInt();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00007352 File Offset: 0x00005552
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_LOG;
		}

		// Token: 0x040001F0 RID: 496
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001F1 RID: 497
		[CompilerGenerated]
		private string string_0;
	}
}
