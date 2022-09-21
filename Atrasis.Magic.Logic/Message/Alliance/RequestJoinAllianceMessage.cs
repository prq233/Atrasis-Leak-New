using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C5 RID: 197
	public class RequestJoinAllianceMessage : PiranhaMessage
	{
		// Token: 0x06000884 RID: 2180 RVA: 0x00006DBE File Offset: 0x00004FBE
		public RequestJoinAllianceMessage() : this(0)
		{
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0000328C File Offset: 0x0000148C
		public RequestJoinAllianceMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00006DC7 File Offset: 0x00004FC7
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00006DF6 File Offset: 0x00004FF6
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00006E20 File Offset: 0x00005020
		public override short GetMessageType()
		{
			return 14317;
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00006E27 File Offset: 0x00005027
		public LogicLong RemoveAllianceId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00006E36 File Offset: 0x00005036
		public void SetAllianceId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00006E3F File Offset: 0x0000503F
		public string GetMessage()
		{
			return this.string_0;
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00006E47 File Offset: 0x00005047
		public void SetMessage(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x04000343 RID: 835
		public const int MESSAGE_TYPE = 14317;

		// Token: 0x04000344 RID: 836
		private LogicLong logicLong_0;

		// Token: 0x04000345 RID: 837
		private string string_0;
	}
}
