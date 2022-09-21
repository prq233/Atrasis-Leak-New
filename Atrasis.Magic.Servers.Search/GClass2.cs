using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Newtonsoft.Json.Linq;

namespace ns0
{
	// Token: 0x0200000B RID: 11
	public static class GClass2
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002AAC File Offset: 0x00000CAC
		public static Task<LogicArrayList<AllianceHeaderEntry>> smethod_0(int int_0, int int_1)
		{
			GClass2.Struct4 @struct;
			@struct.int_1 = int_0;
			@struct.int_2 = int_1;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<LogicArrayList<AllianceHeaderEntry>>.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder<LogicArrayList<AllianceHeaderEntry>> asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass2.Struct4>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002AFC File Offset: 0x00000CFC
		public static Task<LogicArrayList<AllianceHeaderEntry>> smethod_1(LogicArrayList<LogicLong> logicArrayList_0)
		{
			GClass2.Struct5 @struct;
			@struct.logicArrayList_0 = logicArrayList_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<LogicArrayList<AllianceHeaderEntry>>.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder<LogicArrayList<AllianceHeaderEntry>> asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass2.Struct5>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002B44 File Offset: 0x00000D44
		public static Task<LogicArrayList<AllianceHeaderEntry>> smethod_2(SearchAlliancesMessage searchAlliancesMessage_0, LogicClientAvatar logicClientAvatar_0)
		{
			GClass2.Struct6 @struct;
			@struct.searchAlliancesMessage_0 = searchAlliancesMessage_0;
			@struct.logicClientAvatar_0 = logicClientAvatar_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<LogicArrayList<AllianceHeaderEntry>>.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder<LogicArrayList<AllianceHeaderEntry>> asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass2.Struct6>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002B94 File Offset: 0x00000D94
		public static AllianceHeaderEntry smethod_3(JObject jobject_0)
		{
			AllianceHeaderEntry allianceHeaderEntry = new AllianceHeaderEntry();
			allianceHeaderEntry.SetAllianceId(new LogicLong((int)jobject_0["id_hi"], (int)jobject_0["id_lo"]));
			allianceHeaderEntry.SetAllianceName((string)jobject_0["alliance_name"]);
			allianceHeaderEntry.SetAllianceBadgeId((int)jobject_0["badge_id"]);
			allianceHeaderEntry.SetAllianceType((AllianceType)((int)jobject_0["type"]));
			allianceHeaderEntry.SetNumberOfMembers((int)jobject_0["member_count"]);
			allianceHeaderEntry.SetScore((int)jobject_0["score"]);
			allianceHeaderEntry.SetDuelScore((int)jobject_0["duel_score"]);
			allianceHeaderEntry.SetAllianceLevel((int)jobject_0["xp_level"]);
			return allianceHeaderEntry;
		}

		// Token: 0x04000021 RID: 33
		public const string string_0 = "id_hi,id_lo,alliance_name,badge_id,type,member_count,score,duel_score,xp_level";

		// Token: 0x04000022 RID: 34
		public const string string_1 = "meta().id LIKE '%KEY_PREFIX%%' AND type == 1 AND member_count BETWEEN 1 AND 49 AND required_score <= %AVATAR_SCORE% AND required_duel_score <= %AVATAR_DUEL_SCORE%";

		// Token: 0x04000023 RID: 35
		public const string string_2 = "SELECT id_hi,id_lo,alliance_name,badge_id,type,member_count,score,duel_score,xp_level FROM `%BUCKET%` WHERE meta().id LIKE '%KEY_PREFIX%%' AND type == 1 AND member_count BETWEEN 1 AND 49 AND required_score <= %AVATAR_SCORE% AND required_duel_score <= %AVATAR_DUEL_SCORE% ORDER BY score DESC LIMIT 200";

		// Token: 0x0200000C RID: 12
		[CompilerGenerated]
		private sealed class Class3
		{
			// Token: 0x06000021 RID: 33 RVA: 0x00002117 File Offset: 0x00000317
			internal void method_0(JObject jobject_0)
			{
				this.logicArrayList_0.Add(GClass2.smethod_3(jobject_0));
			}

			// Token: 0x04000024 RID: 36
			public LogicArrayList<AllianceHeaderEntry> logicArrayList_0;
		}

		// Token: 0x0200000F RID: 15
		[CompilerGenerated]
		private sealed class Class4
		{
			// Token: 0x06000027 RID: 39 RVA: 0x00002146 File Offset: 0x00000346
			internal void method_0(JObject jobject_0)
			{
				this.logicArrayList_0.Add(GClass2.smethod_3(jobject_0));
			}

			// Token: 0x04000032 RID: 50
			public LogicArrayList<AllianceHeaderEntry> logicArrayList_0;
		}
	}
}
