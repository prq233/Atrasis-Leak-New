using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014D RID: 333
	public class LogicEffectData : LogicData
	{
		// Token: 0x0600128D RID: 4749 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicEffectData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600128E RID: 4750 RVA: 0x0000C76E File Offset: 0x0000A96E
		// (set) Token: 0x0600128F RID: 4751 RVA: 0x0000C776 File Offset: 0x0000A976
		public string SWF { get; protected set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06001290 RID: 4752 RVA: 0x0000C77F File Offset: 0x0000A97F
		// (set) Token: 0x06001291 RID: 4753 RVA: 0x0000C787 File Offset: 0x0000A987
		public string ExportName { get; protected set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06001292 RID: 4754 RVA: 0x0000C790 File Offset: 0x0000A990
		// (set) Token: 0x06001293 RID: 4755 RVA: 0x0000C798 File Offset: 0x0000A998
		protected string[] ParticleEmitter { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06001294 RID: 4756 RVA: 0x0000C7A1 File Offset: 0x0000A9A1
		// (set) Token: 0x06001295 RID: 4757 RVA: 0x0000C7A9 File Offset: 0x0000A9A9
		public int EmitterDelayMs { get; protected set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06001296 RID: 4758 RVA: 0x0000C7B2 File Offset: 0x0000A9B2
		// (set) Token: 0x06001297 RID: 4759 RVA: 0x0000C7BA File Offset: 0x0000A9BA
		public int CameraShake { get; protected set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06001298 RID: 4760 RVA: 0x0000C7C3 File Offset: 0x0000A9C3
		// (set) Token: 0x06001299 RID: 4761 RVA: 0x0000C7CB File Offset: 0x0000A9CB
		public int CameraShakeTimeMS { get; protected set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600129A RID: 4762 RVA: 0x0000C7D4 File Offset: 0x0000A9D4
		// (set) Token: 0x0600129B RID: 4763 RVA: 0x0000C7DC File Offset: 0x0000A9DC
		public bool CameraShakeInReplay { get; protected set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600129C RID: 4764 RVA: 0x0000C7E5 File Offset: 0x0000A9E5
		// (set) Token: 0x0600129D RID: 4765 RVA: 0x0000C7ED File Offset: 0x0000A9ED
		protected bool[] AttachToParent { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600129E RID: 4766 RVA: 0x0000C7F6 File Offset: 0x0000A9F6
		// (set) Token: 0x0600129F RID: 4767 RVA: 0x0000C7FE File Offset: 0x0000A9FE
		protected bool[] DetachAfterStart { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060012A0 RID: 4768 RVA: 0x0000C807 File Offset: 0x0000AA07
		// (set) Token: 0x060012A1 RID: 4769 RVA: 0x0000C80F File Offset: 0x0000AA0F
		protected bool[] DestroyWhenParentDies { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060012A2 RID: 4770 RVA: 0x0000C818 File Offset: 0x0000AA18
		// (set) Token: 0x060012A3 RID: 4771 RVA: 0x0000C820 File Offset: 0x0000AA20
		public bool Looping { get; protected set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060012A4 RID: 4772 RVA: 0x0000C829 File Offset: 0x0000AA29
		// (set) Token: 0x060012A5 RID: 4773 RVA: 0x0000C831 File Offset: 0x0000AA31
		protected string[] IsoLayer { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060012A6 RID: 4774 RVA: 0x0000C83A File Offset: 0x0000AA3A
		// (set) Token: 0x060012A7 RID: 4775 RVA: 0x0000C842 File Offset: 0x0000AA42
		public bool Targeted { get; protected set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060012A8 RID: 4776 RVA: 0x0000C84B File Offset: 0x0000AA4B
		// (set) Token: 0x060012A9 RID: 4777 RVA: 0x0000C853 File Offset: 0x0000AA53
		public int MaxCount { get; protected set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060012AA RID: 4778 RVA: 0x0000C85C File Offset: 0x0000AA5C
		// (set) Token: 0x060012AB RID: 4779 RVA: 0x0000C864 File Offset: 0x0000AA64
		protected string[] Sound { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060012AC RID: 4780 RVA: 0x0000C86D File Offset: 0x0000AA6D
		// (set) Token: 0x060012AD RID: 4781 RVA: 0x0000C875 File Offset: 0x0000AA75
		protected int[] Volume { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060012AE RID: 4782 RVA: 0x0000C87E File Offset: 0x0000AA7E
		// (set) Token: 0x060012AF RID: 4783 RVA: 0x0000C886 File Offset: 0x0000AA86
		protected int[] MinPitch { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x0000C88F File Offset: 0x0000AA8F
		// (set) Token: 0x060012B1 RID: 4785 RVA: 0x0000C897 File Offset: 0x0000AA97
		protected int[] MaxPitch { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060012B2 RID: 4786 RVA: 0x0000C8A0 File Offset: 0x0000AAA0
		// (set) Token: 0x060012B3 RID: 4787 RVA: 0x0000C8A8 File Offset: 0x0000AAA8
		public string LowEndSound { get; protected set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060012B4 RID: 4788 RVA: 0x0000C8B1 File Offset: 0x0000AAB1
		// (set) Token: 0x060012B5 RID: 4789 RVA: 0x0000C8B9 File Offset: 0x0000AAB9
		public int LowEndVolume { get; protected set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060012B6 RID: 4790 RVA: 0x0000C8C2 File Offset: 0x0000AAC2
		// (set) Token: 0x060012B7 RID: 4791 RVA: 0x0000C8CA File Offset: 0x0000AACA
		public int LowEndMinPitch { get; protected set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060012B8 RID: 4792 RVA: 0x0000C8D3 File Offset: 0x0000AAD3
		// (set) Token: 0x060012B9 RID: 4793 RVA: 0x0000C8DB File Offset: 0x0000AADB
		public int LowEndMaxPitch { get; protected set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060012BA RID: 4794 RVA: 0x0000C8E4 File Offset: 0x0000AAE4
		// (set) Token: 0x060012BB RID: 4795 RVA: 0x0000C8EC File Offset: 0x0000AAEC
		public bool Beam { get; protected set; }

		// Token: 0x060012BC RID: 4796 RVA: 0x0000B50C File Offset: 0x0000970C
		public override void CreateReferences()
		{
			base.CreateReferences();
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x0000C8F5 File Offset: 0x0000AAF5
		public string GetParticleEmitter(int index)
		{
			return this.ParticleEmitter[index];
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x0000C8FF File Offset: 0x0000AAFF
		public bool GetAttachToParent(int index)
		{
			return this.AttachToParent[index];
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x0000C909 File Offset: 0x0000AB09
		public bool GetDetachAfterStart(int index)
		{
			return this.DetachAfterStart[index];
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x0000C913 File Offset: 0x0000AB13
		public bool GetDestroyWhenParentDies(int index)
		{
			return this.DestroyWhenParentDies[index];
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x0000C91D File Offset: 0x0000AB1D
		public string GetIsoLayer(int index)
		{
			return this.IsoLayer[index];
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x0000C927 File Offset: 0x0000AB27
		public string GetSound(int index)
		{
			return this.Sound[index];
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x0000C931 File Offset: 0x0000AB31
		public int GetVolume(int index)
		{
			return this.Volume[index];
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x0000C93B File Offset: 0x0000AB3B
		public int GetMinPitch(int index)
		{
			return this.MinPitch[index];
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x0000C945 File Offset: 0x0000AB45
		public int GetMaxPitch(int index)
		{
			return this.MaxPitch[index];
		}

		// Token: 0x040008D6 RID: 2262
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040008D7 RID: 2263
		[CompilerGenerated]
		private string string_1;

		// Token: 0x040008D8 RID: 2264
		[CompilerGenerated]
		private string[] string_2;

		// Token: 0x040008D9 RID: 2265
		[CompilerGenerated]
		private int int_0;

		// Token: 0x040008DA RID: 2266
		[CompilerGenerated]
		private int int_1;

		// Token: 0x040008DB RID: 2267
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040008DC RID: 2268
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x040008DD RID: 2269
		[CompilerGenerated]
		private bool[] bool_1;

		// Token: 0x040008DE RID: 2270
		[CompilerGenerated]
		private bool[] bool_2;

		// Token: 0x040008DF RID: 2271
		[CompilerGenerated]
		private bool[] bool_3;

		// Token: 0x040008E0 RID: 2272
		[CompilerGenerated]
		private bool bool_4;

		// Token: 0x040008E1 RID: 2273
		[CompilerGenerated]
		private string[] string_3;

		// Token: 0x040008E2 RID: 2274
		[CompilerGenerated]
		private bool bool_5;

		// Token: 0x040008E3 RID: 2275
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040008E4 RID: 2276
		[CompilerGenerated]
		private string[] string_4;

		// Token: 0x040008E5 RID: 2277
		[CompilerGenerated]
		private int[] int_4;

		// Token: 0x040008E6 RID: 2278
		[CompilerGenerated]
		private int[] int_5;

		// Token: 0x040008E7 RID: 2279
		[CompilerGenerated]
		private int[] int_6;

		// Token: 0x040008E8 RID: 2280
		[CompilerGenerated]
		private string string_5;

		// Token: 0x040008E9 RID: 2281
		[CompilerGenerated]
		private int int_7;

		// Token: 0x040008EA RID: 2282
		[CompilerGenerated]
		private int int_8;

		// Token: 0x040008EB RID: 2283
		[CompilerGenerated]
		private int int_9;

		// Token: 0x040008EC RID: 2284
		[CompilerGenerated]
		private bool bool_6;
	}
}
