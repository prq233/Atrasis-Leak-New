using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000078 RID: 120
	public class CreateAllianceRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000362 RID: 866 RVA: 0x0000682B File Offset: 0x00004A2B
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00006833 File Offset: 0x00004A33
		public string AllianceName { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000364 RID: 868 RVA: 0x0000683C File Offset: 0x00004A3C
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00006844 File Offset: 0x00004A44
		public string AllianceDescription { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0000684D File Offset: 0x00004A4D
		// (set) Token: 0x06000367 RID: 871 RVA: 0x00006855 File Offset: 0x00004A55
		public AllianceType AllianceType { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0000685E File Offset: 0x00004A5E
		// (set) Token: 0x06000369 RID: 873 RVA: 0x00006866 File Offset: 0x00004A66
		public int AllianceBadgeId { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600036A RID: 874 RVA: 0x0000686F File Offset: 0x00004A6F
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00006877 File Offset: 0x00004A77
		public int RequiredScore { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00006880 File Offset: 0x00004A80
		// (set) Token: 0x0600036D RID: 877 RVA: 0x00006888 File Offset: 0x00004A88
		public int RequiredDuelScore { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00006891 File Offset: 0x00004A91
		// (set) Token: 0x0600036F RID: 879 RVA: 0x00006899 File Offset: 0x00004A99
		public int WarFrequency { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000370 RID: 880 RVA: 0x000068A2 File Offset: 0x00004AA2
		// (set) Token: 0x06000371 RID: 881 RVA: 0x000068AA File Offset: 0x00004AAA
		public bool PublicWarLog { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000372 RID: 882 RVA: 0x000068B3 File Offset: 0x00004AB3
		// (set) Token: 0x06000373 RID: 883 RVA: 0x000068BB File Offset: 0x00004ABB
		public bool ArrangedWarEnabled { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000374 RID: 884 RVA: 0x000068C4 File Offset: 0x00004AC4
		// (set) Token: 0x06000375 RID: 885 RVA: 0x000068CC File Offset: 0x00004ACC
		public LogicData OriginData { get; set; }

		// Token: 0x06000376 RID: 886 RVA: 0x0000CA64 File Offset: 0x0000AC64
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.AllianceName);
			stream.WriteString(this.AllianceDescription);
			stream.WriteVInt((int)this.AllianceType);
			stream.WriteVInt(this.AllianceBadgeId);
			stream.WriteVInt(this.RequiredScore);
			stream.WriteVInt(this.RequiredDuelScore);
			stream.WriteVInt(this.WarFrequency);
			stream.WriteBoolean(this.PublicWarLog);
			stream.WriteBoolean(this.ArrangedWarEnabled);
			ByteStreamHelper.WriteDataReference(stream, this.OriginData);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000CAEC File Offset: 0x0000ACEC
		public override void Decode(ByteStream stream)
		{
			this.AllianceName = stream.ReadString(900000);
			this.AllianceDescription = stream.ReadString(900000);
			this.AllianceType = (AllianceType)stream.ReadVInt();
			this.AllianceBadgeId = stream.ReadVInt();
			this.RequiredScore = stream.ReadVInt();
			this.RequiredDuelScore = stream.ReadVInt();
			this.WarFrequency = stream.ReadVInt();
			this.PublicWarLog = stream.ReadBoolean();
			this.ArrangedWarEnabled = stream.ReadBoolean();
			this.OriginData = ByteStreamHelper.ReadDataReference(stream);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000068D5 File Offset: 0x00004AD5
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_ALLIANCE_REQUEST;
		}

		// Token: 0x0400018F RID: 399
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000190 RID: 400
		[CompilerGenerated]
		private string string_1;

		// Token: 0x04000191 RID: 401
		[CompilerGenerated]
		private AllianceType allianceType_0;

		// Token: 0x04000192 RID: 402
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000193 RID: 403
		[CompilerGenerated]
		private int int_3;

		// Token: 0x04000194 RID: 404
		[CompilerGenerated]
		private int int_4;

		// Token: 0x04000195 RID: 405
		[CompilerGenerated]
		private int int_5;

		// Token: 0x04000196 RID: 406
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000197 RID: 407
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000198 RID: 408
		[CompilerGenerated]
		private LogicData logicData_0;
	}
}
