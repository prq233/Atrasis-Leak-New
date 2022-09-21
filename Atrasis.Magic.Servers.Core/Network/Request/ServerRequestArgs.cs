using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Request;

namespace Atrasis.Magic.Servers.Core.Network.Request
{
	// Token: 0x02000025 RID: 37
	public class ServerRequestArgs
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004E47 File Offset: 0x00003047
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00004E4F File Offset: 0x0000304F
		public ServerRequestArgs.CompleteHandler OnComplete { get; set; } = new ServerRequestArgs.CompleteHandler(ServerRequestArgs.Class3.class3_0.method_0);

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004E58 File Offset: 0x00003058
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00004E60 File Offset: 0x00003060
		public ServerResponseMessage ResponseMessage { get; private set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00004E69 File Offset: 0x00003069
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00004E71 File Offset: 0x00003071
		public ServerRequestError ErrorCode { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00004E7A File Offset: 0x0000307A
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x00004E82 File Offset: 0x00003082
		internal DateTime ExpireTime { get; set; }

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B5B4 File Offset: 0x000097B4
		public ServerRequestArgs(int timeout)
		{
			this.ExpireTime = DateTime.UtcNow.AddSeconds((double)timeout);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004E8B File Offset: 0x0000308B
		internal void method_0()
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.ErrorCode = ServerRequestError.Aborted;
				this.OnComplete(this);
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004EAF File Offset: 0x000030AF
		internal void method_1(ServerResponseMessage serverResponseMessage_1)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.ResponseMessage = serverResponseMessage_1;
				this.ErrorCode = ServerRequestError.Success;
				this.OnComplete(this);
			}
		}

		// Token: 0x04000057 RID: 87
		[CompilerGenerated]
		private ServerRequestArgs.CompleteHandler completeHandler_0;

		// Token: 0x04000058 RID: 88
		[CompilerGenerated]
		private ServerResponseMessage serverResponseMessage_0;

		// Token: 0x04000059 RID: 89
		[CompilerGenerated]
		private ServerRequestError serverRequestError_0;

		// Token: 0x0400005A RID: 90
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x0400005B RID: 91
		private bool bool_0;

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x060000EC RID: 236
		public delegate void CompleteHandler(ServerRequestArgs args);

		// Token: 0x02000027 RID: 39
		[CompilerGenerated]
		[Serializable]
		private sealed class Class3
		{
			// Token: 0x060000F1 RID: 241 RVA: 0x00004631 File Offset: 0x00002831
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
			}

			// Token: 0x0400005C RID: 92
			public static readonly ServerRequestArgs.Class3 class3_0 = new ServerRequestArgs.Class3();

			// Token: 0x0400005D RID: 93
			public static ServerRequestArgs.CompleteHandler completeHandler_0;
		}
	}
}
