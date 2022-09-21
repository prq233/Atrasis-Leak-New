using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.League.Entry
{
	// Token: 0x02000104 RID: 260
	public class LogicAvatarTournamentEntry
	{
		// Token: 0x06000C6D RID: 3181 RVA: 0x00002463 File Offset: 0x00000663
		public void Destruct()
		{
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x0002B19C File Offset: 0x0002939C
		public void Decode(ByteStream stream)
		{
			this.int_0 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.int_9 = stream.ReadInt();
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x0002B224 File Offset: 0x00029424
		public void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(this.int_7);
			encoder.WriteInt(this.int_6);
			encoder.WriteInt(this.int_8);
			encoder.WriteInt(this.int_9);
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x000090AF File Offset: 0x000072AF
		public int GetLastSeasonState()
		{
			return this.int_5;
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x000090B7 File Offset: 0x000072B7
		public void SetLastSeasonState(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x000090C0 File Offset: 0x000072C0
		public int GetLastSeasonYear()
		{
			return this.int_7;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x000090C8 File Offset: 0x000072C8
		public int GetLastSeasonMonth()
		{
			return this.int_6;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x000090D0 File Offset: 0x000072D0
		public void SetLastSeasonDate(int year, int month)
		{
			this.int_7 = year;
			this.int_6 = month;
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x000090E0 File Offset: 0x000072E0
		public int GetLastSeasonScore()
		{
			return this.int_9;
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x000090E8 File Offset: 0x000072E8
		public void SetLastSeasonScore(int score)
		{
			this.int_9 = score;
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x000090F1 File Offset: 0x000072F1
		public int GetLastSeasonRank()
		{
			return this.int_8;
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x000090F9 File Offset: 0x000072F9
		public void SetLastSeasonRank(int score)
		{
			this.int_8 = score;
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x00009102 File Offset: 0x00007302
		public int GetBestSeasonState()
		{
			return this.int_0;
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0000910A File Offset: 0x0000730A
		public void SetBestSeasonState(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x00009113 File Offset: 0x00007313
		public int GetBestSeasonYear()
		{
			return this.int_2;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x0000911B File Offset: 0x0000731B
		public int GetBestSeasonMonth()
		{
			return this.int_1;
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x00009123 File Offset: 0x00007323
		public void SetBestSeasonDate(int year, int month)
		{
			this.int_2 = year;
			this.int_1 = month;
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00009133 File Offset: 0x00007333
		public int GetBestSeasonScore()
		{
			return this.int_4;
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0000913B File Offset: 0x0000733B
		public void SetBestSeasonScore(int score)
		{
			this.int_4 = score;
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x00009144 File Offset: 0x00007344
		public int GetBestSeasonRank()
		{
			return this.int_3;
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x0000914C File Offset: 0x0000734C
		public void SetBestSeasonRank(int score)
		{
			this.int_3 = score;
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0002B2AC File Offset: 0x000294AC
		public void ReadFromJSON(LogicJSONObject jsonObject)
		{
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "best_season_state");
			this.int_2 = LogicJSONHelper.GetInt(jsonObject, "best_season_year");
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "best_season_month");
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "best_season_rank");
			this.int_4 = LogicJSONHelper.GetInt(jsonObject, "best_season_score");
			this.int_5 = LogicJSONHelper.GetInt(jsonObject, "last_season_state");
			this.int_7 = LogicJSONHelper.GetInt(jsonObject, "last_season_year");
			this.int_6 = LogicJSONHelper.GetInt(jsonObject, "last_season_month");
			this.int_8 = LogicJSONHelper.GetInt(jsonObject, "last_season_rank");
			this.int_9 = LogicJSONHelper.GetInt(jsonObject, "last_season_score");
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0002B364 File Offset: 0x00029564
		public void WriteToJSON(LogicJSONObject jsonObject)
		{
			jsonObject.Put("best_season_state", new LogicJSONNumber(this.int_0));
			jsonObject.Put("best_season_year", new LogicJSONNumber(this.int_2));
			jsonObject.Put("best_season_month", new LogicJSONNumber(this.int_1));
			jsonObject.Put("best_season_rank", new LogicJSONNumber(this.int_3));
			jsonObject.Put("best_season_score", new LogicJSONNumber(this.int_4));
			jsonObject.Put("last_season_state", new LogicJSONNumber(this.int_5));
			jsonObject.Put("last_season_year", new LogicJSONNumber(this.int_7));
			jsonObject.Put("last_season_month", new LogicJSONNumber(this.int_6));
			jsonObject.Put("last_season_rank", new LogicJSONNumber(this.int_8));
			jsonObject.Put("last_season_score", new LogicJSONNumber(this.int_9));
		}

		// Token: 0x040004F9 RID: 1273
		private int int_0;

		// Token: 0x040004FA RID: 1274
		private int int_1;

		// Token: 0x040004FB RID: 1275
		private int int_2;

		// Token: 0x040004FC RID: 1276
		private int int_3;

		// Token: 0x040004FD RID: 1277
		private int int_4;

		// Token: 0x040004FE RID: 1278
		private int int_5;

		// Token: 0x040004FF RID: 1279
		private int int_6;

		// Token: 0x04000500 RID: 1280
		private int int_7;

		// Token: 0x04000501 RID: 1281
		private int int_8;

		// Token: 0x04000502 RID: 1282
		private int int_9;
	}
}
