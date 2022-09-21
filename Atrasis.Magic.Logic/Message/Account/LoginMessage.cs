using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F3 RID: 243
	public class LoginMessage : PiranhaMessage
	{
		// Token: 0x06000AE2 RID: 2786 RVA: 0x00008223 File Offset: 0x00006423
		public LoginMessage() : this(8)
		{
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00025138 File Offset: 0x00023338
		public LoginMessage(short messageVersion) : base(messageVersion)
		{
			this.string_3 = string.Empty;
			this.string_0 = string.Empty;
			this.string_13 = string.Empty;
			this.string_14 = string.Empty;
			this.string_8 = string.Empty;
			this.string_10 = string.Empty;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00025190 File Offset: 0x00023390
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteString(this.string_9);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(0);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteString(this.string_11);
			this.m_stream.WriteString(this.string_12);
			this.m_stream.WriteString(this.string_5);
			this.m_stream.WriteString(this.string_4);
			this.m_stream.WriteString(this.string_2);
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicData_0);
			this.m_stream.WriteString(this.string_10);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteString(this.string_6);
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteStringReference(this.string_3);
			this.m_stream.WriteStringReference(this.string_0);
			this.m_stream.WriteStringReference("");
			this.m_stream.WriteBoolean(false);
			this.m_stream.WriteString("");
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteVInt(this.int_3);
			this.m_stream.WriteStringReference(string.Empty);
			this.m_stream.WriteStringReference(string.Empty);
			this.m_stream.WriteStringReference(this.string_8);
			this.m_stream.WriteStringReference(this.string_13);
			this.m_stream.WriteStringReference(this.string_14);
			this.m_stream.WriteVInt(0);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0002536C File Offset: 0x0002356C
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.string_9 = this.m_stream.ReadString(900000);
			this.int_1 = this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.string_11 = this.m_stream.ReadString(900000);
			this.string_12 = this.m_stream.ReadString(900000);
			this.string_5 = this.m_stream.ReadString(900000);
			this.string_4 = this.m_stream.ReadString(900000);
			this.string_2 = this.m_stream.ReadString(900000);
			if (!this.m_stream.IsAtEnd())
			{
				this.logicData_0 = ByteStreamHelper.ReadDataReference(this.m_stream, LogicDataType.LOCALE);
				this.string_10 = this.m_stream.ReadString(900000);
				if (this.string_10 == null)
				{
					this.string_10 = string.Empty;
				}
				if (!this.m_stream.IsAtEnd())
				{
					this.string_1 = this.m_stream.ReadString(900000);
					if (!this.m_stream.IsAtEnd())
					{
						this.string_6 = this.m_stream.ReadString(900000);
						if (!this.m_stream.IsAtEnd())
						{
							this.bool_0 = this.m_stream.ReadBoolean();
							if (!this.m_stream.IsAtEnd())
							{
								this.string_3 = this.m_stream.ReadStringReference(900000);
								this.string_0 = this.m_stream.ReadStringReference(900000);
								if (!this.m_stream.IsAtEnd())
								{
									this.m_stream.ReadString(900000);
									if (!this.m_stream.IsAtEnd())
									{
										this.bool_1 = this.m_stream.ReadBoolean();
										this.string_7 = this.m_stream.ReadString(900000);
										if (!this.m_stream.IsAtEnd())
										{
											this.int_0 = this.m_stream.ReadInt();
											if (!this.m_stream.IsAtEnd())
											{
												this.int_3 = this.m_stream.ReadVInt();
												this.m_stream.ReadStringReference(900000);
												this.m_stream.ReadStringReference(900000);
												if (!this.m_stream.IsAtEnd())
												{
													this.string_8 = this.m_stream.ReadStringReference(900000);
													if (!this.m_stream.IsAtEnd())
													{
														this.string_13 = this.m_stream.ReadStringReference(900000);
														this.string_14 = this.m_stream.ReadStringReference(900000);
														this.m_stream.ReadVInt();
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0000822C File Offset: 0x0000642C
		public override short GetMessageType()
		{
			return 10101;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0002565C File Offset: 0x0002385C
		public override void Destruct()
		{
			base.Destruct();
			this.string_1 = null;
			this.string_9 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.string_4 = null;
			this.string_6 = null;
			this.string_0 = null;
			this.string_5 = null;
			this.string_10 = null;
			this.string_11 = null;
			this.string_13 = null;
			this.string_14 = null;
			this.string_12 = null;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x00008233 File Offset: 0x00006433
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0000823B File Offset: 0x0000643B
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00008244 File Offset: 0x00006444
		public LogicData GetPreferredLanguage()
		{
			return this.logicData_0;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0000824C File Offset: 0x0000644C
		public void SetPreferredLanguage(LogicData value)
		{
			this.logicData_0 = value;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00008255 File Offset: 0x00006455
		public bool IsAndroidClient()
		{
			return this.bool_0;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0000825D File Offset: 0x0000645D
		public void SetAndroidClient(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x00008266 File Offset: 0x00006466
		public bool IsAdvertisingEnabled()
		{
			return this.bool_1;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0000826E File Offset: 0x0000646E
		public void SetAdvertisingEnabled(bool value)
		{
			this.bool_1 = value;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00008277 File Offset: 0x00006477
		public int GetScramblerSeed()
		{
			return this.int_0;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0000827F File Offset: 0x0000647F
		public void SetScramblerSeed(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x00008288 File Offset: 0x00006488
		public int GetClientMajorVersion()
		{
			return this.int_1;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x00008290 File Offset: 0x00006490
		public void SetClientMajorVersion(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x00008299 File Offset: 0x00006499
		public int GetClientBuildVersion()
		{
			return this.int_2;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x000082A1 File Offset: 0x000064A1
		public void SetClientBuildVersion(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x000082AA File Offset: 0x000064AA
		public int GetAppStore()
		{
			return this.int_3;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x000082B2 File Offset: 0x000064B2
		public void SetAppStore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x000082BB File Offset: 0x000064BB
		public string GetAndroidID()
		{
			return this.string_0;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x000082C3 File Offset: 0x000064C3
		public void SetAndroidID(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x000082CC File Offset: 0x000064CC
		public string GetADID()
		{
			return this.string_1;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x000082D4 File Offset: 0x000064D4
		public void SetADID(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x000082DD File Offset: 0x000064DD
		public string GetDevice()
		{
			return this.string_2;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x000082E5 File Offset: 0x000064E5
		public void SetDevice(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x000082EE File Offset: 0x000064EE
		public string GetIMEI()
		{
			return this.string_3;
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x000082F6 File Offset: 0x000064F6
		public void SetIMEI(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x000082FF File Offset: 0x000064FF
		public string GetMacAddress()
		{
			return this.string_4;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x00008307 File Offset: 0x00006507
		public void SetMacAddress(string value)
		{
			this.string_4 = value;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00008310 File Offset: 0x00006510
		public string GetOpenUDID()
		{
			return this.string_5;
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00008318 File Offset: 0x00006518
		public void SetOpenUDID(string value)
		{
			this.string_5 = value;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00008321 File Offset: 0x00006521
		public string GetOSVersion()
		{
			return this.string_6;
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x00008329 File Offset: 0x00006529
		public void SetOSVersion(string value)
		{
			this.string_6 = value;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00008332 File Offset: 0x00006532
		public string GetAdvertisingId()
		{
			return this.string_7;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0000833A File Offset: 0x0000653A
		public void SetAdvertisingId(string value)
		{
			this.string_7 = value;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00008343 File Offset: 0x00006543
		public string GetAppVersion()
		{
			return this.string_8;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0000834B File Offset: 0x0000654B
		public void SetAppVersion(string value)
		{
			this.string_8 = value;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00008354 File Offset: 0x00006554
		public string GetPassToken()
		{
			return this.string_9;
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0000835C File Offset: 0x0000655C
		public void SetPassToken(string value)
		{
			this.string_9 = value;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x00008365 File Offset: 0x00006565
		public string GetPreferredDeviceLanguage()
		{
			return this.string_10;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0000836D File Offset: 0x0000656D
		public void SetPreferredDeviceLanguage(string value)
		{
			this.string_10 = value;
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00008376 File Offset: 0x00006576
		public string GetResourceSha()
		{
			return this.string_11;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0000837E File Offset: 0x0000657E
		public void SetResourceSha(string value)
		{
			this.string_11 = value;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00008387 File Offset: 0x00006587
		public string GetUDID()
		{
			return this.string_12;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0000838F File Offset: 0x0000658F
		public void SetUDID(string value)
		{
			this.string_12 = value;
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00008398 File Offset: 0x00006598
		public string GetKunlunSSO()
		{
			return this.string_13;
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x000083A0 File Offset: 0x000065A0
		public void SetKunlunSSO(string value)
		{
			this.string_13 = value;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x000083A9 File Offset: 0x000065A9
		public string GetKunlunUID()
		{
			return this.string_14;
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x000083B1 File Offset: 0x000065B1
		public void SetKunlunUID(string value)
		{
			this.string_14 = value;
		}

		// Token: 0x04000449 RID: 1097
		public const int MESSAGE_TYPE = 10101;

		// Token: 0x0400044A RID: 1098
		private LogicLong logicLong_0;

		// Token: 0x0400044B RID: 1099
		private LogicData logicData_0;

		// Token: 0x0400044C RID: 1100
		private bool bool_0;

		// Token: 0x0400044D RID: 1101
		private bool bool_1;

		// Token: 0x0400044E RID: 1102
		private int int_0;

		// Token: 0x0400044F RID: 1103
		private int int_1;

		// Token: 0x04000450 RID: 1104
		private int int_2;

		// Token: 0x04000451 RID: 1105
		private int int_3;

		// Token: 0x04000452 RID: 1106
		private string string_0;

		// Token: 0x04000453 RID: 1107
		private string string_1;

		// Token: 0x04000454 RID: 1108
		private string string_2;

		// Token: 0x04000455 RID: 1109
		private string string_3;

		// Token: 0x04000456 RID: 1110
		private string string_4;

		// Token: 0x04000457 RID: 1111
		private string string_5;

		// Token: 0x04000458 RID: 1112
		private string string_6;

		// Token: 0x04000459 RID: 1113
		private string string_7;

		// Token: 0x0400045A RID: 1114
		private string string_8;

		// Token: 0x0400045B RID: 1115
		private string string_9;

		// Token: 0x0400045C RID: 1116
		private string string_10;

		// Token: 0x0400045D RID: 1117
		private string string_11;

		// Token: 0x0400045E RID: 1118
		private string string_12;

		// Token: 0x0400045F RID: 1119
		private string string_13;

		// Token: 0x04000460 RID: 1120
		private string string_14;
	}
}
