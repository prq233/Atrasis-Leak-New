using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ns0
{
	// Token: 0x0200001E RID: 30
	public static class GClass13
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00005B6C File Offset: 0x00003D6C
		public static Task<bool> smethod_0(string string_1)
		{
			GClass13.Struct9 @struct;
			@struct.string_0 = string_1;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<bool>.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass13.Struct9>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0400007E RID: 126
		private const string string_0 = "https://www.googleapis.com/oauth2/v4/token";
	}
}
