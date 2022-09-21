using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000C9 RID: 201
	public class AllianceWarDataFailedMessage : PiranhaMessage
	{
		// Token: 0x060008B8 RID: 2232 RVA: 0x00006FD2 File Offset: 0x000051D2
		public AllianceWarDataFailedMessage() : this(0)
		{
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceWarDataFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00006FDB File Offset: 0x000051DB
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00006FF4 File Offset: 0x000051F4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0000700D File Offset: 0x0000520D
		public override short GetMessageType()
		{
			return 24337;
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00007014 File Offset: 0x00005214
		public int GetErrorCode()
		{
			return this.int_0;
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0000701C File Offset: 0x0000521C
		public void SetErrorCode(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000355 RID: 853
		public const int MESSAGE_TYPE = 24337;

		// Token: 0x04000356 RID: 854
		public const int WAR_DATA_ERROR_INTERNAL = 2;

		// Token: 0x04000357 RID: 855
		public const int WAR_DATA_ERROR_INVALID_WAR = 1;

		// Token: 0x04000358 RID: 856
		public const int WAR_DATA_ERROR_ERROR_NO_LONGER_AVAILABLE = 0;

		// Token: 0x04000359 RID: 857
		private int int_0;
	}
}
