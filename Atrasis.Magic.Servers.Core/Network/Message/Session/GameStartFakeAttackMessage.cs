using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003C RID: 60
	public class GameStartFakeAttackMessage : ServerSessionMessage
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600016C RID: 364 RVA: 0x000053F1 File Offset: 0x000035F1
		// (set) Token: 0x0600016D RID: 365 RVA: 0x000053F9 File Offset: 0x000035F9
		public LogicLong AccountId { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00005402 File Offset: 0x00003602
		// (set) Token: 0x0600016F RID: 367 RVA: 0x0000540A File Offset: 0x0000360A
		public LogicData ArgData { get; set; }

		// Token: 0x06000170 RID: 368 RVA: 0x00005413 File Offset: 0x00003613
		public override void Encode(ByteStream stream)
		{
			if (this.AccountId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.AccountId);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			ByteStreamHelper.WriteDataReference(stream, this.ArgData);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00005445 File Offset: 0x00003645
		public override void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.AccountId = stream.ReadLong();
			}
			this.ArgData = ByteStreamHelper.ReadDataReference(stream);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00005467 File Offset: 0x00003667
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_START_FAKE_ATTACK;
		}

		// Token: 0x040000F3 RID: 243
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000F4 RID: 244
		[CompilerGenerated]
		private LogicData logicData_0;
	}
}
