using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000059 RID: 89
	public class OwnHomeDataMessage : PiranhaMessage
	{
		// Token: 0x060003FE RID: 1022 RVA: 0x000045DD File Offset: 0x000027DD
		public OwnHomeDataMessage() : this(0)
		{
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0000328C File Offset: 0x0000148C
		public OwnHomeDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0001C904 File Offset: 0x0001AB04
		public override void Decode()
		{
			base.Decode();
			this.int_2 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.logicClientHome_0 = new LogicClientHome();
			this.logicClientHome_0.Decode(this.m_stream);
			this.logicClientAvatar_0 = new LogicClientAvatar();
			this.logicClientAvatar_0.Decode(this.m_stream);
			this.int_4 = this.m_stream.ReadInt();
			this.int_5 = this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0001CA00 File Offset: 0x0001AC00
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.logicClientHome_0.Encode(this.m_stream);
			this.logicClientAvatar_0.Encode(this.m_stream);
			this.m_stream.WriteInt(this.int_4);
			this.m_stream.WriteInt(this.int_5);
			this.m_stream.WriteInt(352);
			this.m_stream.WriteInt(1190797808);
			this.m_stream.WriteInt(352);
			this.m_stream.WriteInt(1192597808);
			this.m_stream.WriteInt(352);
			this.m_stream.WriteInt(1192597808);
			this.m_stream.WriteInt(this.int_3);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x000045E6 File Offset: 0x000027E6
		public override short GetMessageType()
		{
			return 24101;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000045ED File Offset: 0x000027ED
		public override void Destruct()
		{
			base.Destruct();
			this.logicClientHome_0 = null;
			this.logicClientAvatar_0 = null;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00004603 File Offset: 0x00002803
		public int GetCurrentTimestamp()
		{
			return this.int_1;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000460B File Offset: 0x0000280B
		public void SetCurrentTimestamp(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00004614 File Offset: 0x00002814
		public int GetSecondsSinceLastSave()
		{
			return this.int_2;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000461C File Offset: 0x0000281C
		public void SetSecondsSinceLastSave(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00004625 File Offset: 0x00002825
		public int GetSecondsSinceLastMaintenance()
		{
			return this.int_0;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000462D File Offset: 0x0000282D
		public void SetSecondsSinceLastMaintenance(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00004636 File Offset: 0x00002836
		public int GetReengagementSeconds()
		{
			return this.int_3;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000463E File Offset: 0x0000283E
		public void SetReengagementSeconds(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00004647 File Offset: 0x00002847
		public int GetMapId()
		{
			return this.int_4;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000464F File Offset: 0x0000284F
		public void SetMapId(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00004658 File Offset: 0x00002858
		public int GetLayoutId()
		{
			return this.int_5;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00004660 File Offset: 0x00002860
		public void SetLayoutId(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00004669 File Offset: 0x00002869
		public LogicClientHome RemoveLogicClientHome()
		{
			LogicClientHome result = this.logicClientHome_0;
			this.logicClientHome_0 = null;
			return result;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00004678 File Offset: 0x00002878
		public void SetLogicClientHome(LogicClientHome logicClientHome)
		{
			this.logicClientHome_0 = logicClientHome;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00004681 File Offset: 0x00002881
		public LogicClientAvatar RemoveLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_0;
			this.logicClientAvatar_0 = null;
			return result;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00004690 File Offset: 0x00002890
		public void SetLogicClientAvatar(LogicClientAvatar logicClientAvatar)
		{
			this.logicClientAvatar_0 = logicClientAvatar;
		}

		// Token: 0x0400018C RID: 396
		public const int MESSAGE_TYPE = 24101;

		// Token: 0x0400018D RID: 397
		private int int_0;

		// Token: 0x0400018E RID: 398
		private int int_1;

		// Token: 0x0400018F RID: 399
		private int int_2;

		// Token: 0x04000190 RID: 400
		private int int_3;

		// Token: 0x04000191 RID: 401
		private int int_4;

		// Token: 0x04000192 RID: 402
		private int int_5;

		// Token: 0x04000193 RID: 403
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000194 RID: 404
		private LogicClientHome logicClientHome_0;
	}
}
