using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x02000019 RID: 25
	public class GClass12
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x000026AE File Offset: 0x000008AE
		[CompilerGenerated]
		public LogicLong method_0()
		{
			return this.logicLong_0;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000026B6 File Offset: 0x000008B6
		[CompilerGenerated]
		public DateTime method_1()
		{
			return this.dateTime_0;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000026BE File Offset: 0x000008BE
		[CompilerGenerated]
		public bool method_2()
		{
			return this.bool_0;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000026C6 File Offset: 0x000008C6
		[CompilerGenerated]
		private void method_3(bool bool_3)
		{
			this.bool_0 = bool_3;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000026CF File Offset: 0x000008CF
		[CompilerGenerated]
		public bool method_4()
		{
			return this.bool_1;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000026D7 File Offset: 0x000008D7
		[CompilerGenerated]
		private void method_5(bool bool_3)
		{
			this.bool_1 = bool_3;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000068BC File Offset: 0x00004ABC
		public GClass12(LogicLong logicLong_3, LogicLong logicLong_4, LogicLong logicLong_5, GClass1 gclass1_1)
		{
			this.logicLong_0 = logicLong_3;
			this.dateTime_0 = DateTime.UtcNow;
			this.logicLong_1 = logicLong_4;
			this.logicLong_2 = logicLong_5;
			this.gclass1_0 = gclass1_1;
			this.dictionary_0 = new Dictionary<long, GClass13>[2];
			this.dictionary_0[0] = new Dictionary<long, GClass13>();
			this.dictionary_0[1] = new Dictionary<long, GClass13>();
			this.logicArrayList_0 = new LogicArrayList<LogicCommand>();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000026E0 File Offset: 0x000008E0
		public void method_6(byte[] byte_1)
		{
			if (this.method_2())
			{
				throw new Exception("LiveReplay.init: live already initialized!");
			}
			this.byte_0 = byte_1;
			this.method_3(true);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002703 File Offset: 0x00000903
		public void method_7(int int_3, LogicArrayList<LogicCommand> logicArrayList_1)
		{
			this.int_1 = int_3;
			if (logicArrayList_1 != null)
			{
				this.logicArrayList_0.AddAll(logicArrayList_1);
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000271B File Offset: 0x0000091B
		public void method_8()
		{
			this.bool_2 = true;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00006928 File Offset: 0x00004B28
		public void method_9(int int_3)
		{
			if (this.method_2() && !this.method_4())
			{
				int num = LogicTime.GetMSInTicks(int_3);
				if (this.int_1 < this.int_2 + num)
				{
					if (!this.bool_2)
					{
						return;
					}
					num = this.int_1 - this.int_2;
					this.method_5(true);
				}
				if (this.dictionary_0[0].Count > 0 || this.dictionary_0[1].Count > 0)
				{
					LiveReplayDataMessage liveReplayDataMessage = new LiveReplayDataMessage();
					liveReplayDataMessage.SetServerSubTick(this.int_2 + num);
					liveReplayDataMessage.SetCommands(this.method_16(this.int_2, this.int_2 + num));
					liveReplayDataMessage.SetViewerCount(this.dictionary_0[0].Count);
					liveReplayDataMessage.SetEnemyViewerCount(this.dictionary_0[1].Count);
					liveReplayDataMessage.Encode();
					for (int i = 0; i < 2; i++)
					{
						Dictionary<long, GClass13> dictionary = this.dictionary_0[i];
						if (dictionary.Count >= 1)
						{
							foreach (GClass13 gclass in dictionary.Values)
							{
								gclass.method_1(liveReplayDataMessage);
							}
							if (this.method_4())
							{
								foreach (GClass13 gclass2 in dictionary.Values)
								{
									gclass2.method_1(new LiveReplayEndMessage());
								}
							}
						}
					}
				}
				this.int_2 += num;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00002724 File Offset: 0x00000924
		public bool method_10()
		{
			return this.dictionary_0[0].Count + this.dictionary_0[1].Count >= 100;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002748 File Offset: 0x00000948
		public bool method_11(long long_0, int int_3)
		{
			return this.dictionary_0[int_3].ContainsKey(long_0);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00006AC4 File Offset: 0x00004CC4
		public void method_12(long long_0, int int_3)
		{
			GClass13 gclass = new GClass13(long_0);
			LiveReplayHeaderMessage liveReplayHeaderMessage = new LiveReplayHeaderMessage();
			int num = this.int_2;
			liveReplayHeaderMessage.SetCompressedStreamHeaderJson(this.byte_0);
			liveReplayHeaderMessage.SetCommands(this.method_16(0, num));
			liveReplayHeaderMessage.SetServerSubTick(num);
			gclass.method_1(liveReplayHeaderMessage);
			this.dictionary_0[int_3].Add(long_0, gclass);
			this.method_14();
			if (this.logicLong_1 != null)
			{
				this.method_15();
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00002758 File Offset: 0x00000958
		public void method_13(long long_0, int int_3)
		{
			if (this.dictionary_0[int_3].Remove(long_0))
			{
				this.method_14();
				if (this.logicLong_1 != null)
				{
					this.method_15();
				}
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006B30 File Offset: 0x00004D30
		private void method_14()
		{
			if (!this.gclass1_0.IsDestructed() && this.gclass1_0.method_2() != null && this.gclass1_0.method_2().GetGameStateType() != GameStateType.HOME)
			{
				AttackSpectatorCountMessage attackSpectatorCountMessage = new AttackSpectatorCountMessage();
				attackSpectatorCountMessage.SetViewerCount(this.dictionary_0[0].Count);
				attackSpectatorCountMessage.SetEnemyViewerCount(this.dictionary_0[1].Count);
				this.gclass1_0.SendPiranhaMessage(attackSpectatorCountMessage, 1);
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006BA4 File Offset: 0x00004DA4
		private void method_15()
		{
			ServerMessageManager.SendMessage(new AllianceChallengeSpectatorCountMessage
			{
				AccountId = this.logicLong_1,
				StreamId = this.logicLong_2,
				Count = this.dictionary_0[0].Count + this.dictionary_0[1].Count
			}, 11);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006BF8 File Offset: 0x00004DF8
		private LogicArrayList<LogicCommand> method_16(int int_3, int int_4)
		{
			LogicArrayList<LogicCommand> logicArrayList = new LogicArrayList<LogicCommand>();
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicCommand logicCommand = this.logicArrayList_0[i];
				if (logicCommand.GetExecuteSubTick() >= int_3 && logicCommand.GetExecuteSubTick() < int_4)
				{
					logicArrayList.Add(logicCommand);
				}
			}
			return logicArrayList;
		}

		// Token: 0x04000036 RID: 54
		public const int int_0 = 100;

		// Token: 0x04000037 RID: 55
		[CompilerGenerated]
		private readonly LogicLong logicLong_0;

		// Token: 0x04000038 RID: 56
		[CompilerGenerated]
		private readonly DateTime dateTime_0;

		// Token: 0x04000039 RID: 57
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400003A RID: 58
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x0400003B RID: 59
		private bool bool_2;

		// Token: 0x0400003C RID: 60
		private readonly LogicLong logicLong_1;

		// Token: 0x0400003D RID: 61
		private readonly LogicLong logicLong_2;

		// Token: 0x0400003E RID: 62
		private readonly GClass1 gclass1_0;

		// Token: 0x0400003F RID: 63
		private readonly Dictionary<long, GClass13>[] dictionary_0;

		// Token: 0x04000040 RID: 64
		private readonly LogicArrayList<LogicCommand> logicArrayList_0;

		// Token: 0x04000041 RID: 65
		private byte[] byte_0;

		// Token: 0x04000042 RID: 66
		private int int_1;

		// Token: 0x04000043 RID: 67
		private int int_2;
	}
}
