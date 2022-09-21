using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000057 RID: 87
	public class NpcDataMessage : PiranhaMessage
	{
		// Token: 0x060003DC RID: 988 RVA: 0x000044CB File Offset: 0x000026CB
		public NpcDataMessage() : this(0)
		{
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000328C File Offset: 0x0000148C
		public NpcDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001C6F4 File Offset: 0x0001A8F4
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.logicClientHome_0 = new LogicClientHome();
			this.logicClientHome_0.Decode(this.m_stream);
			this.logicClientAvatar_0 = new LogicClientAvatar();
			this.logicClientAvatar_0.Decode(this.m_stream);
			this.logicNpcAvatar_0 = new LogicNpcAvatar();
			this.logicNpcAvatar_0.Decode(this.m_stream);
			this.bool_0 = this.m_stream.ReadBoolean();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001C790 File Offset: 0x0001A990
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.logicClientHome_0.Encode(this.m_stream);
			this.logicClientAvatar_0.Encode(this.m_stream);
			this.logicNpcAvatar_0.Encode(this.m_stream);
			this.m_stream.WriteBoolean(this.bool_0);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x000044D4 File Offset: 0x000026D4
		public override short GetMessageType()
		{
			return 24133;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000044DB File Offset: 0x000026DB
		public override void Destruct()
		{
			base.Destruct();
			this.logicClientHome_0 = null;
			this.logicClientAvatar_0 = null;
			this.logicNpcAvatar_0 = null;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000044F8 File Offset: 0x000026F8
		public LogicClientHome RemoveLogicClientHome()
		{
			LogicClientHome result = this.logicClientHome_0;
			this.logicClientHome_0 = null;
			return result;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00004507 File Offset: 0x00002707
		public void SetLogicClientHome(LogicClientHome instance)
		{
			this.logicClientHome_0 = instance;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00004510 File Offset: 0x00002710
		public LogicClientAvatar RemoveLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_0;
			this.logicClientAvatar_0 = null;
			return result;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000451F File Offset: 0x0000271F
		public void SetLogicClientAvatar(LogicClientAvatar instance)
		{
			this.logicClientAvatar_0 = instance;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00004528 File Offset: 0x00002728
		public LogicNpcAvatar RemoveLogicNpcAvatar()
		{
			LogicNpcAvatar result = this.logicNpcAvatar_0;
			this.logicNpcAvatar_0 = null;
			return result;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00004537 File Offset: 0x00002737
		public void SetLogicNpcAvatar(LogicNpcAvatar instance)
		{
			this.logicNpcAvatar_0 = instance;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00004540 File Offset: 0x00002740
		public int GetCurrentTimestamp()
		{
			return this.int_1;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00004548 File Offset: 0x00002748
		public void SetCurrentTimestamp(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00004551 File Offset: 0x00002751
		public int GetSecondsSinceLastSave()
		{
			return this.int_0;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00004559 File Offset: 0x00002759
		public void SetSecondsSinceLastSave(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00004562 File Offset: 0x00002762
		public bool IsNpcDuel()
		{
			return this.bool_0;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000456A File Offset: 0x0000276A
		public void SetNpcDuel(bool npcDuel)
		{
			this.bool_0 = npcDuel;
		}

		// Token: 0x04000180 RID: 384
		public const int MESSAGE_TYPE = 24133;

		// Token: 0x04000181 RID: 385
		private LogicClientHome logicClientHome_0;

		// Token: 0x04000182 RID: 386
		private LogicNpcAvatar logicNpcAvatar_0;

		// Token: 0x04000183 RID: 387
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000184 RID: 388
		private int int_0;

		// Token: 0x04000185 RID: 389
		private int int_1;

		// Token: 0x04000186 RID: 390
		private bool bool_0;
	}
}
