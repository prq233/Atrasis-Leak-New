using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F4 RID: 244
	public class LoginOkMessage : PiranhaMessage
	{
		// Token: 0x06000B17 RID: 2839 RVA: 0x000083BA File Offset: 0x000065BA
		public LoginOkMessage() : this(1)
		{
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0000328C File Offset: 0x0000148C
		public LoginOkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x000256CC File Offset: 0x000238CC
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.logicLong_1 = this.m_stream.ReadLong();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.string_2 = this.m_stream.ReadString(900000);
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.string_3 = this.m_stream.ReadString(900000);
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			this.int_5 = this.m_stream.ReadInt();
			this.string_4 = this.m_stream.ReadString(900000);
			this.string_5 = this.m_stream.ReadString(900000);
			this.string_6 = this.m_stream.ReadString(900000);
			this.int_6 = this.m_stream.ReadInt();
			this.string_7 = this.m_stream.ReadString(9000);
			this.string_8 = this.m_stream.ReadString(9000);
			this.m_stream.ReadString(9000);
			this.m_stream.ReadInt();
			this.m_stream.ReadString(9000);
			this.m_stream.ReadString(9000);
			this.m_stream.ReadString(9000);
			int num = this.m_stream.ReadInt();
			if (num != -1)
			{
				this.logicArrayList_0 = new LogicArrayList<string>(num);
				if (num != 0)
				{
					for (int i = 0; i < num; i++)
					{
						this.logicArrayList_0.Add(this.m_stream.ReadString(900000));
					}
				}
			}
			int num2 = this.m_stream.ReadInt();
			if (num2 != -1)
			{
				this.logicArrayList_1 = new LogicArrayList<string>(num2);
				if (num2 != 0)
				{
					for (int j = 0; j < num2; j++)
					{
						this.logicArrayList_1.Add(this.m_stream.ReadString(900000));
					}
				}
			}
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0002591C File Offset: 0x00023B1C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteLong(this.logicLong_1);
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteString(this.string_2);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteString(this.string_3);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			this.m_stream.WriteInt(this.int_5);
			this.m_stream.WriteString(this.string_4);
			this.m_stream.WriteString(this.string_5);
			this.m_stream.WriteString(this.string_6);
			this.m_stream.WriteInt(this.int_6);
			this.m_stream.WriteString(this.string_7);
			this.m_stream.WriteString(this.string_8);
			this.m_stream.WriteString(null);
			this.m_stream.WriteInt(1);
			this.m_stream.WriteString(null);
			this.m_stream.WriteString(null);
			this.m_stream.WriteString(null);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.m_stream.WriteString(this.logicArrayList_0[i]);
				}
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			if (this.logicArrayList_1 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_1.Size());
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					this.m_stream.WriteString(this.logicArrayList_1[j]);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x000083C3 File Offset: 0x000065C3
		public override short GetMessageType()
		{
			return 20104;
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00025B50 File Offset: 0x00023D50
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_1 = null;
			this.logicArrayList_0 = null;
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.string_4 = null;
			this.string_5 = null;
			this.string_6 = null;
			this.string_7 = null;
			this.string_8 = null;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x000083CA File Offset: 0x000065CA
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x000083D2 File Offset: 0x000065D2
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x000083DB File Offset: 0x000065DB
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x000083E3 File Offset: 0x000065E3
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000083EC File Offset: 0x000065EC
		public string GetPassToken()
		{
			return this.string_0;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x000083F4 File Offset: 0x000065F4
		public void SetPassToken(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x000083FD File Offset: 0x000065FD
		public string GetFacebookId()
		{
			return this.string_1;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x00008405 File Offset: 0x00006605
		public void SetFacebookId(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0000840E File Offset: 0x0000660E
		public string GetGamecenterId()
		{
			return this.string_2;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x00008416 File Offset: 0x00006616
		public void SetGamecenterId(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0000841F File Offset: 0x0000661F
		public string GetServerEnvironment()
		{
			return this.string_3;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x00008427 File Offset: 0x00006627
		public void SetServerEnvironment(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x00008430 File Offset: 0x00006630
		public string GetFacebookAppId()
		{
			return this.string_4;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x00008438 File Offset: 0x00006638
		public void SetFacebookAppId(string value)
		{
			this.string_4 = value;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x00008441 File Offset: 0x00006641
		public string GetServerTime()
		{
			return this.string_5;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x00008449 File Offset: 0x00006649
		public void SetServerTime(string value)
		{
			this.string_5 = value;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00008452 File Offset: 0x00006652
		public string GetAccountCreatedDate()
		{
			return this.string_6;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0000845A File Offset: 0x0000665A
		public void SetAccountCreatedDate(string value)
		{
			this.string_6 = value;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x00008463 File Offset: 0x00006663
		public string GetGoogleServiceId()
		{
			return this.string_7;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0000846B File Offset: 0x0000666B
		public void SetGoogleServiceId(string value)
		{
			this.string_7 = value;
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x00008474 File Offset: 0x00006674
		public string GetRegion()
		{
			return this.string_8;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0000847C File Offset: 0x0000667C
		public void SetRegion(string value)
		{
			this.string_8 = value;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x00008485 File Offset: 0x00006685
		public int GetServerMajorVersion()
		{
			return this.int_0;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0000848D File Offset: 0x0000668D
		public void SetServerMajorVersion(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00008496 File Offset: 0x00006696
		public int GetServerBuildVersion()
		{
			return this.int_1;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0000849E File Offset: 0x0000669E
		public void SetServerBuildVersion(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x000084A7 File Offset: 0x000066A7
		public int GetContentVersion()
		{
			return this.int_2;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x000084AF File Offset: 0x000066AF
		public void SetContentVersion(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x000084B8 File Offset: 0x000066B8
		public int GetSessionCount()
		{
			return this.int_3;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x000084C0 File Offset: 0x000066C0
		public void SetSessionCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x000084C9 File Offset: 0x000066C9
		public int GetPlayTimeSeconds()
		{
			return this.int_4;
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x000084D1 File Offset: 0x000066D1
		public void SetPlayTimeSeconds(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x000084DA File Offset: 0x000066DA
		public int GetDaysSinceStartedPlaying()
		{
			return this.int_5;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x000084E2 File Offset: 0x000066E2
		public void SetDaysSinceStartedPlaying(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x000084EB File Offset: 0x000066EB
		public int GetStartupCooldownSeconds()
		{
			return this.int_6;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x000084F3 File Offset: 0x000066F3
		public void SetStartupCooldownSeconds(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x000084FC File Offset: 0x000066FC
		public LogicArrayList<string> GetContentUrlList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x00008504 File Offset: 0x00006704
		public void SetContentUrlList(LogicArrayList<string> value)
		{
			this.logicArrayList_0 = value;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0000850D File Offset: 0x0000670D
		public LogicArrayList<string> GetChronosContentUrlList()
		{
			return this.logicArrayList_1;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x00008515 File Offset: 0x00006715
		public void SetChronosContentUrlList(LogicArrayList<string> value)
		{
			this.logicArrayList_1 = value;
		}

		// Token: 0x04000461 RID: 1121
		public const int MESSAGE_TYPE = 20104;

		// Token: 0x04000462 RID: 1122
		private LogicLong logicLong_0;

		// Token: 0x04000463 RID: 1123
		private LogicLong logicLong_1;

		// Token: 0x04000464 RID: 1124
		private string string_0;

		// Token: 0x04000465 RID: 1125
		private string string_1;

		// Token: 0x04000466 RID: 1126
		private string string_2;

		// Token: 0x04000467 RID: 1127
		private string string_3;

		// Token: 0x04000468 RID: 1128
		private string string_4;

		// Token: 0x04000469 RID: 1129
		private string string_5;

		// Token: 0x0400046A RID: 1130
		private string string_6;

		// Token: 0x0400046B RID: 1131
		private string string_7;

		// Token: 0x0400046C RID: 1132
		private string string_8;

		// Token: 0x0400046D RID: 1133
		private int int_0;

		// Token: 0x0400046E RID: 1134
		private int int_1;

		// Token: 0x0400046F RID: 1135
		private int int_2;

		// Token: 0x04000470 RID: 1136
		private int int_3;

		// Token: 0x04000471 RID: 1137
		private int int_4;

		// Token: 0x04000472 RID: 1138
		private int int_5;

		// Token: 0x04000473 RID: 1139
		private int int_6;

		// Token: 0x04000474 RID: 1140
		private LogicArrayList<string> logicArrayList_0;

		// Token: 0x04000475 RID: 1141
		private LogicArrayList<string> logicArrayList_1;
	}
}
