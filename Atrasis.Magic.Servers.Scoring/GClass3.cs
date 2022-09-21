using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public class GClass3 : SeasonDocument
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002218 File Offset: 0x00000418
		public GClass3()
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002220 File Offset: 0x00000420
		public GClass3(LogicLong logicLong_0) : base(logicLong_0)
		{
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A74 File Offset: 0x00000C74
		public void method_0()
		{
			this.dictionary_0 = new Dictionary<long, AllianceRankingEntry>[2];
			this.dictionary_0[0] = new Dictionary<long, AllianceRankingEntry>();
			this.dictionary_0[1] = new Dictionary<long, AllianceRankingEntry>();
			this.dictionary_1 = new Dictionary<long, AvatarRankingEntry>();
			this.dictionary_2 = new Dictionary<long, AvatarDuelRankingEntry>();
			if (base.EndTime < DateTime.UtcNow)
			{
				this.bool_0 = true;
			}
			this.method_1().Wait();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002AE4 File Offset: 0x00000CE4
		public Task method_1()
		{
			GClass3.Struct0 @struct;
			@struct.gclass3_0 = this;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct0>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002229 File Offset: 0x00000429
		public bool method_2()
		{
			return this.bool_0;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002B2C File Offset: 0x00000D2C
		private Task method_3(int int_0)
		{
			GClass3.Struct1 @struct;
			@struct.gclass3_0 = this;
			@struct.int_1 = int_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct1>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002B7C File Offset: 0x00000D7C
		private Task method_4()
		{
			GClass3.Struct2 @struct;
			@struct.gclass3_0 = this;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct2>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002BC4 File Offset: 0x00000DC4
		private Task method_5()
		{
			GClass3.Struct3 @struct;
			@struct.gclass3_0 = this;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct3>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x04000009 RID: 9
		private Dictionary<long, AllianceRankingEntry>[] dictionary_0;

		// Token: 0x0400000A RID: 10
		private Dictionary<long, AvatarRankingEntry> dictionary_1;

		// Token: 0x0400000B RID: 11
		private Dictionary<long, AvatarDuelRankingEntry> dictionary_2;

		// Token: 0x0400000C RID: 12
		private bool bool_0;
	}
}
