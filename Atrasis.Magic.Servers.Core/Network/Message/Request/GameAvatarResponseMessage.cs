using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007C RID: 124
	public class GameAvatarResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000388 RID: 904 RVA: 0x0000697F File Offset: 0x00004B7F
		// (set) Token: 0x06000389 RID: 905 RVA: 0x00006987 File Offset: 0x00004B87
		public GameDocument Document { get; set; }

		// Token: 0x0600038A RID: 906 RVA: 0x00006990 File Offset: 0x00004B90
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				CouchbaseDocument.Encode(stream, this.Document);
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x000069A6 File Offset: 0x00004BA6
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Document = CouchbaseDocument.Decode<GameDocument>(stream);
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000069BC File Offset: 0x00004BBC
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_AVATAR_RESPONSE;
		}

		// Token: 0x040001A2 RID: 418
		[CompilerGenerated]
		private GameDocument gameDocument_0;
	}
}
