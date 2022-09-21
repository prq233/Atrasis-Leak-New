using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A9 RID: 169
	public class UpdateResourceSettingsMessage : ServerCoreMessage
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00007536 File Offset: 0x00005736
		// (set) Token: 0x060004A1 RID: 1185 RVA: 0x0000753E File Offset: 0x0000573E
		public string[] SupportedCountries { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00007547 File Offset: 0x00005747
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x0000754F File Offset: 0x0000574F
		public string[] SupportedAppVersions { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00007558 File Offset: 0x00005758
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x00007560 File Offset: 0x00005760
		public string[] DeveloperIPs { get; set; }

		// Token: 0x060004A6 RID: 1190 RVA: 0x0000CF60 File Offset: 0x0000B160
		public override void Encode(ByteStream stream)
		{
			stream.WriteBoolean(this.SupportedCountries != null);
			stream.WriteBoolean(this.SupportedAppVersions != null);
			stream.WriteBoolean(this.DeveloperIPs != null);
			if (this.SupportedCountries != null)
			{
				stream.WriteVInt(this.SupportedCountries.Length);
				for (int i = 0; i < this.SupportedCountries.Length; i++)
				{
					stream.WriteString(this.SupportedCountries[i]);
				}
			}
			if (this.SupportedAppVersions != null)
			{
				stream.WriteVInt(this.SupportedAppVersions.Length);
				for (int j = 0; j < this.SupportedAppVersions.Length; j++)
				{
					stream.WriteString(this.SupportedAppVersions[j]);
				}
			}
			if (this.DeveloperIPs != null)
			{
				stream.WriteVInt(this.DeveloperIPs.Length);
				for (int k = 0; k < this.DeveloperIPs.Length; k++)
				{
					stream.WriteString(this.DeveloperIPs[k]);
				}
			}
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000D040 File Offset: 0x0000B240
		public override void Decode(ByteStream stream)
		{
			bool flag = stream.ReadBoolean();
			bool flag2 = stream.ReadBoolean();
			bool flag3 = stream.ReadBoolean();
			if (flag)
			{
				this.SupportedCountries = new string[stream.ReadVInt()];
				for (int i = 0; i < this.SupportedCountries.Length; i++)
				{
					this.SupportedCountries[i] = stream.ReadString(900000);
				}
			}
			if (flag2)
			{
				this.SupportedAppVersions = new string[stream.ReadVInt()];
				for (int j = 0; j < this.SupportedAppVersions.Length; j++)
				{
					this.SupportedAppVersions[j] = stream.ReadString(900000);
				}
			}
			if (flag3)
			{
				this.DeveloperIPs = new string[stream.ReadVInt()];
				for (int k = 0; k < this.DeveloperIPs.Length; k++)
				{
					this.DeveloperIPs[k] = stream.ReadString(900000);
				}
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00007569 File Offset: 0x00005769
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.UPDATE_RESOURCE_SETTINGS;
		}

		// Token: 0x040001FB RID: 507
		[CompilerGenerated]
		private string[] string_0;

		// Token: 0x040001FC RID: 508
		[CompilerGenerated]
		private string[] string_1;

		// Token: 0x040001FD RID: 509
		[CompilerGenerated]
		private string[] string_2;
	}
}
