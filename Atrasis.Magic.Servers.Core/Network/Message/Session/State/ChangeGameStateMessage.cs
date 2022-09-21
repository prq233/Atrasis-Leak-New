using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x02000049 RID: 73
	public class ChangeGameStateMessage : ServerSessionMessage
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x0000569E File Offset: 0x0000389E
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x000056A6 File Offset: 0x000038A6
		public int LayoutId { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x000056AF File Offset: 0x000038AF
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x000056B7 File Offset: 0x000038B7
		public int MapId { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x000056C0 File Offset: 0x000038C0
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x000056C8 File Offset: 0x000038C8
		public GameStateType StateType { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x000056D1 File Offset: 0x000038D1
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x000056D9 File Offset: 0x000038D9
		public LogicNpcData NpcData { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000056E2 File Offset: 0x000038E2
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000056EA File Offset: 0x000038EA
		public LogicLong HomeId { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001CB RID: 459 RVA: 0x000056F3 File Offset: 0x000038F3
		// (set) Token: 0x060001CC RID: 460 RVA: 0x000056FB File Offset: 0x000038FB
		public int VisitType { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00005704 File Offset: 0x00003904
		// (set) Token: 0x060001CE RID: 462 RVA: 0x0000570C File Offset: 0x0000390C
		public LogicLong ChallengeHomeId { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00005715 File Offset: 0x00003915
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x0000571D File Offset: 0x0000391D
		public LogicLong ChallengeStreamId { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00005726 File Offset: 0x00003926
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x0000572E File Offset: 0x0000392E
		public LogicLong ChallengeAllianceId { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00005737 File Offset: 0x00003937
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000573F File Offset: 0x0000393F
		public byte[] ChallengeHomeJSON { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00005748 File Offset: 0x00003948
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00005750 File Offset: 0x00003950
		public int ChallengeMapId { get; set; }

		// Token: 0x060001D7 RID: 471 RVA: 0x0000C184 File Offset: 0x0000A384
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.StateType);
			switch (this.StateType)
			{
			case GameStateType.HOME:
				stream.WriteVInt(this.LayoutId);
				stream.WriteVInt(this.MapId);
				return;
			case GameStateType.NPC_ATTACK:
			case GameStateType.NPC_DUEL:
				ByteStreamHelper.WriteDataReference(stream, this.NpcData);
				return;
			case GameStateType.MATCHED_ATTACK:
			case GameStateType.FAKE_ATTACK:
			case GameStateType.DUEL:
				break;
			case GameStateType.CHALLENGE_ATTACK:
				stream.WriteLong(this.ChallengeHomeId);
				stream.WriteLong(this.ChallengeStreamId);
				stream.WriteLong(this.ChallengeAllianceId);
				stream.WriteBytes(this.ChallengeHomeJSON, this.ChallengeHomeJSON.Length);
				stream.WriteVInt(this.ChallengeMapId);
				break;
			case GameStateType.VISIT:
				stream.WriteLong(this.HomeId);
				stream.WriteVInt(this.VisitType);
				return;
			default:
				return;
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000C250 File Offset: 0x0000A450
		public override void Decode(ByteStream stream)
		{
			this.StateType = (GameStateType)stream.ReadVInt();
			switch (this.StateType)
			{
			case GameStateType.HOME:
				this.LayoutId = stream.ReadVInt();
				this.MapId = stream.ReadVInt();
				return;
			case GameStateType.NPC_ATTACK:
			case GameStateType.NPC_DUEL:
				this.NpcData = (LogicNpcData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.NPC);
				return;
			case GameStateType.MATCHED_ATTACK:
			case GameStateType.FAKE_ATTACK:
			case GameStateType.DUEL:
				break;
			case GameStateType.CHALLENGE_ATTACK:
				this.ChallengeHomeId = stream.ReadLong();
				this.ChallengeStreamId = stream.ReadLong();
				this.ChallengeAllianceId = stream.ReadLong();
				this.ChallengeHomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
				this.ChallengeMapId = stream.ReadVInt();
				break;
			case GameStateType.VISIT:
				this.HomeId = stream.ReadLong();
				this.VisitType = stream.ReadVInt();
				return;
			default:
				return;
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00005759 File Offset: 0x00003959
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CHANGE_GAME_STATE;
		}

		// Token: 0x04000104 RID: 260
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000105 RID: 261
		[CompilerGenerated]
		private int int_3;

		// Token: 0x04000106 RID: 262
		[CompilerGenerated]
		private GameStateType gameStateType_0;

		// Token: 0x04000107 RID: 263
		[CompilerGenerated]
		private LogicNpcData logicNpcData_0;

		// Token: 0x04000108 RID: 264
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000109 RID: 265
		[CompilerGenerated]
		private int int_4;

		// Token: 0x0400010A RID: 266
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400010B RID: 267
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x0400010C RID: 268
		[CompilerGenerated]
		private LogicLong logicLong_3;

		// Token: 0x0400010D RID: 269
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x0400010E RID: 270
		[CompilerGenerated]
		private int int_5;
	}
}
