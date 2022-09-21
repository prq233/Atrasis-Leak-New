using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015F RID: 351
	public class LogicProjectileData : LogicGameObjectData
	{
		// Token: 0x060014AD RID: 5293 RVA: 0x0000B4F2 File Offset: 0x000096F2
		public LogicProjectileData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x00051D08 File Offset: 0x0004FF08
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("SWF", 0);
			this.string_1 = base.GetValue("ExportName", 0);
			this.string_2 = base.GetValue("ShadowSWF", 0);
			this.string_3 = base.GetValue("ShadowExportName", 0);
			this.int_0 = base.GetIntegerValue("StartHeight", 0);
			this.int_1 = base.GetIntegerValue("StartOffset", 0);
			this.bool_0 = base.GetBooleanValue("RandomHitPosition", 0);
			string value = base.GetValue("ParticleEmitter", 0);
			if (value.Length > 0)
			{
				this.logicParticleEmitterData_0 = LogicDataTables.GetParticleEmitterByName(value, this);
			}
			this.bool_1 = base.GetBooleanValue("IsBallistic", 0);
			this.int_2 = (base.GetIntegerValue("Speed", 0) << 9) / 100;
			this.bool_2 = base.GetBooleanValue("PlayOnce", 0);
			this.bool_3 = base.GetBooleanValue("UseRotate", 0);
			this.bool_4 = base.GetBooleanValue("UseTopLayer", 0);
			this.int_3 = base.GetIntegerValue("Scale", 0);
			if (this.int_3 == 0)
			{
				this.int_3 = 100;
			}
			this.int_4 = base.GetIntegerValue("SlowdownDefencePercent", 0);
			this.logicSpellData_0 = LogicDataTables.GetSpellByName(base.GetValue("HitSpell", 0), this);
			this.int_5 = base.GetIntegerValue("HitSpellLevel", 0);
			this.bool_5 = !base.GetBooleanValue("DontTrackTarget", 0);
			this.int_6 = base.GetIntegerValue("BallisticHeight", 0);
			this.int_7 = base.GetIntegerValue("TrajectoryStyle", 0);
			this.int_8 = base.GetIntegerValue("FixedTravelTime", 0);
			this.int_9 = base.GetIntegerValue("DamageDelay", 0);
			this.bool_6 = base.GetBooleanValue("UseDirections", 0);
			this.bool_7 = base.GetBooleanValue("ScaleTimeline", 0);
			this.int_10 = base.GetIntegerValue("TargetPosRandomRadius", 0);
			this.bool_8 = base.GetBooleanValue("DirectionFrame", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("Effect", 0), this);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("DestroyedEffect", 0), this);
			this.logicEffectData_2 = LogicDataTables.GetEffectByName(base.GetValue("BounceEffect", 0), this);
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x0000D8B9 File Offset: 0x0000BAB9
		public LogicSpellData GetHitSpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x0000D8C1 File Offset: 0x0000BAC1
		public LogicEffectData GetEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x0000D8C9 File Offset: 0x0000BAC9
		public LogicEffectData GetDestroyedEffect()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0000D8D1 File Offset: 0x0000BAD1
		public LogicEffectData GetBounceEffect()
		{
			return this.logicEffectData_2;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x0000D8D9 File Offset: 0x0000BAD9
		public LogicParticleEmitterData GetParticleEmiter()
		{
			return this.logicParticleEmitterData_0;
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0000D8E1 File Offset: 0x0000BAE1
		public string GetSwf()
		{
			return this.string_0;
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x0000D8E9 File Offset: 0x0000BAE9
		public string GetExportName()
		{
			return this.string_1;
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x0000D8F1 File Offset: 0x0000BAF1
		public string GetShadowSWF()
		{
			return this.string_2;
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x0000D8F9 File Offset: 0x0000BAF9
		public string GetShadowExportName()
		{
			return this.string_3;
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x0000D901 File Offset: 0x0000BB01
		public string GetParticleEmitter()
		{
			return this.string_4;
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x0000D909 File Offset: 0x0000BB09
		public int GetStartHeight()
		{
			return this.int_0;
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0000D911 File Offset: 0x0000BB11
		public int GetStartOffset()
		{
			return this.int_1;
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x0000D919 File Offset: 0x0000BB19
		public int GetSpeed()
		{
			return this.int_2;
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x0000D921 File Offset: 0x0000BB21
		public int GetScale()
		{
			return this.int_3;
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x0000D929 File Offset: 0x0000BB29
		public int GetSlowdownDefensePercent()
		{
			return this.int_4;
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0000D931 File Offset: 0x0000BB31
		public int GetHitSpellLevel()
		{
			return this.int_5;
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0000D939 File Offset: 0x0000BB39
		public int GetBallisticHeight()
		{
			return this.int_6;
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0000D941 File Offset: 0x0000BB41
		public int GetTrajectoryStyle()
		{
			return this.int_7;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0000D949 File Offset: 0x0000BB49
		public int GetFixedTravelTime()
		{
			return this.int_8;
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0000D951 File Offset: 0x0000BB51
		public int GetDamageDelay()
		{
			return this.int_9;
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0000D959 File Offset: 0x0000BB59
		public int GetTargetPosRandomRadius()
		{
			return this.int_10;
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0000D961 File Offset: 0x0000BB61
		public bool GetRandomHitPosition()
		{
			return this.bool_0;
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x0000D969 File Offset: 0x0000BB69
		public bool IsBallistic()
		{
			return this.bool_1;
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x0000D971 File Offset: 0x0000BB71
		public bool GetPlayOnce()
		{
			return this.bool_2;
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x0000D979 File Offset: 0x0000BB79
		public bool GetUseRotate()
		{
			return this.bool_3;
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0000D981 File Offset: 0x0000BB81
		public bool GetUseTopLayer()
		{
			return this.bool_4;
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x0000D989 File Offset: 0x0000BB89
		public bool GetTrackTarget()
		{
			return this.bool_5;
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x0000D991 File Offset: 0x0000BB91
		public bool GetUseDirection()
		{
			return this.bool_6;
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x0000D999 File Offset: 0x0000BB99
		public bool GetScaleTimeline()
		{
			return this.bool_7;
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x0000D9A1 File Offset: 0x0000BBA1
		public bool GetDirectionFrame()
		{
			return this.bool_8;
		}

		// Token: 0x04000AF5 RID: 2805
		private LogicSpellData logicSpellData_0;

		// Token: 0x04000AF6 RID: 2806
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000AF7 RID: 2807
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000AF8 RID: 2808
		private LogicEffectData logicEffectData_2;

		// Token: 0x04000AF9 RID: 2809
		private LogicParticleEmitterData logicParticleEmitterData_0;

		// Token: 0x04000AFA RID: 2810
		private string string_0;

		// Token: 0x04000AFB RID: 2811
		private string string_1;

		// Token: 0x04000AFC RID: 2812
		private string string_2;

		// Token: 0x04000AFD RID: 2813
		private string string_3;

		// Token: 0x04000AFE RID: 2814
		private string string_4;

		// Token: 0x04000AFF RID: 2815
		private int int_0;

		// Token: 0x04000B00 RID: 2816
		private int int_1;

		// Token: 0x04000B01 RID: 2817
		private int int_2;

		// Token: 0x04000B02 RID: 2818
		private int int_3;

		// Token: 0x04000B03 RID: 2819
		private int int_4;

		// Token: 0x04000B04 RID: 2820
		private int int_5;

		// Token: 0x04000B05 RID: 2821
		private int int_6;

		// Token: 0x04000B06 RID: 2822
		private int int_7;

		// Token: 0x04000B07 RID: 2823
		private int int_8;

		// Token: 0x04000B08 RID: 2824
		private int int_9;

		// Token: 0x04000B09 RID: 2825
		private int int_10;

		// Token: 0x04000B0A RID: 2826
		private bool bool_0;

		// Token: 0x04000B0B RID: 2827
		private bool bool_1;

		// Token: 0x04000B0C RID: 2828
		private bool bool_2;

		// Token: 0x04000B0D RID: 2829
		private bool bool_3;

		// Token: 0x04000B0E RID: 2830
		private bool bool_4;

		// Token: 0x04000B0F RID: 2831
		private bool bool_5;

		// Token: 0x04000B10 RID: 2832
		private bool bool_6;

		// Token: 0x04000B11 RID: 2833
		private bool bool_7;

		// Token: 0x04000B12 RID: 2834
		private bool bool_8;
	}
}
