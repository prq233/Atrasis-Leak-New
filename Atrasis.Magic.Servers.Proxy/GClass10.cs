using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000018 RID: 24
	public static class GClass10
	{
		// Token: 0x0600008A RID: 138 RVA: 0x000057FC File Offset: 0x000039FC
		public static Task<GClass11> smethod_0(LogicLong logicLong_0)
		{
			GClass10.Struct6 @struct;
			@struct.logicLong_0 = logicLong_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<GClass11>.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder<GClass11> asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass10.Struct6>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005844 File Offset: 0x00003A44
		public static Task<bool> smethod_1(GClass11 gclass11_0)
		{
			GClass10.Struct7 @struct;
			@struct.gclass11_0 = gclass11_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<bool>.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass10.Struct7>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000588C File Offset: 0x00003A8C
		public static Task<bool> smethod_2(GClass11 gclass11_0)
		{
			GClass10.Struct8 @struct;
			@struct.gclass11_0 = gclass11_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<bool>.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass10.Struct8>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}
	}
}
