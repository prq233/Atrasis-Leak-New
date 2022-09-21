using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200004C RID: 76
	public class FriendlyScoutHomeDataMessage : PiranhaMessage
	{
		// Token: 0x06000378 RID: 888 RVA: 0x00004198 File Offset: 0x00002398
		public FriendlyScoutHomeDataMessage() : this(0)
		{
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000328C File Offset: 0x0000148C
		public FriendlyScoutHomeDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0001C210 File Offset: 0x0001A410
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.logicLong_1 = this.m_stream.ReadLong();
			this.logicClientHome_0 = new LogicClientHome();
			this.logicClientHome_0.Decode(this.m_stream);
			this.int_1 = this.m_stream.ReadInt();
			if (this.m_stream.ReadBoolean())
			{
				this.logicClientAvatar_0 = new LogicClientAvatar();
				this.logicClientAvatar_0.Decode(this.m_stream);
			}
			this.logicLong_2 = this.m_stream.ReadLong();
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0001C2C0 File Offset: 0x0001A4C0
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteLong(this.logicLong_1);
			this.logicClientHome_0.Encode(this.m_stream);
			this.m_stream.WriteInt(this.int_1);
			if (this.logicClientAvatar_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.logicClientAvatar_0.Encode(this.m_stream);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.m_stream.WriteLong(this.logicLong_2);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x000041A1 File Offset: 0x000023A1
		public override short GetMessageType()
		{
			return 25007;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x000041A8 File Offset: 0x000023A8
		public override void Destruct()
		{
			base.Destruct();
			this.logicClientHome_0 = null;
			this.logicClientAvatar_0 = null;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x000041BE File Offset: 0x000023BE
		public int GetCurrentTimestamp()
		{
			return this.int_0;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000041C6 File Offset: 0x000023C6
		public void SetCurrentTimestamp(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x000041CF File Offset: 0x000023CF
		public int GetMapId()
		{
			return this.int_1;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x000041D7 File Offset: 0x000023D7
		public void SetMapId(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000041E0 File Offset: 0x000023E0
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x000041E8 File Offset: 0x000023E8
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000041F1 File Offset: 0x000023F1
		public LogicLong GetAccountId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x000041F9 File Offset: 0x000023F9
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00004202 File Offset: 0x00002402
		public LogicLong GetStreamId()
		{
			return this.logicLong_2;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000420A File Offset: 0x0000240A
		public void SetStreamId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00004213 File Offset: 0x00002413
		public LogicClientHome RemoveLogicClientHome()
		{
			LogicClientHome result = this.logicClientHome_0;
			this.logicClientHome_0 = null;
			return result;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00004222 File Offset: 0x00002422
		public void SetLogicClientHome(LogicClientHome logicClientHome)
		{
			this.logicClientHome_0 = logicClientHome;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000422B File Offset: 0x0000242B
		public LogicClientAvatar RemoveLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_0;
			this.logicClientAvatar_0 = null;
			return result;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000423A File Offset: 0x0000243A
		public void SetLogicClientAvatar(LogicClientAvatar logicClientAvatar)
		{
			this.logicClientAvatar_0 = logicClientAvatar;
		}

		// Token: 0x0400015A RID: 346
		public const int MESSAGE_TYPE = 25007;

		// Token: 0x0400015B RID: 347
		private int int_0;

		// Token: 0x0400015C RID: 348
		private int int_1;

		// Token: 0x0400015D RID: 349
		private LogicLong logicLong_0;

		// Token: 0x0400015E RID: 350
		private LogicLong logicLong_1;

		// Token: 0x0400015F RID: 351
		private LogicLong logicLong_2;

		// Token: 0x04000160 RID: 352
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000161 RID: 353
		private LogicClientHome logicClientHome_0;
	}
}
