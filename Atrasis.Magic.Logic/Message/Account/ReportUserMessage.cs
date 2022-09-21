using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F6 RID: 246
	public class ReportUserMessage : PiranhaMessage
	{
		// Token: 0x06000B4F RID: 2895 RVA: 0x00008571 File Offset: 0x00006771
		public ReportUserMessage() : this(0)
		{
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0000328C File Offset: 0x0000148C
		public ReportUserMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0000857A File Offset: 0x0000677A
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x000085A4 File Offset: 0x000067A4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x000085CE File Offset: 0x000067CE
		public override short GetMessageType()
		{
			return 10117;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x000085D5 File Offset: 0x000067D5
		public int GetReportSource()
		{
			return this.int_0;
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x000085DD File Offset: 0x000067DD
		public void SetReportSource(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x000085E6 File Offset: 0x000067E6
		public LogicLong RemoveReportedAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x000085F5 File Offset: 0x000067F5
		public void SetReportedAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000478 RID: 1144
		public const int MESSAGE_TYPE = 10117;

		// Token: 0x04000479 RID: 1145
		private int int_0;

		// Token: 0x0400047A RID: 1146
		private LogicLong logicLong_0;
	}
}
