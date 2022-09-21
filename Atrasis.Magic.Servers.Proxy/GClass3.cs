using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using MaxMind.GeoIP2.Responses;

namespace ns0
{
	// Token: 0x02000007 RID: 7
	public class GClass3
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002191 File Offset: 0x00000391
		[CompilerGenerated]
		public Socket method_0()
		{
			return this.socket_0;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002199 File Offset: 0x00000399
		[CompilerGenerated]
		public GClass5 method_1()
		{
			return this.gclass5_0;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000021A1 File Offset: 0x000003A1
		[CompilerGenerated]
		public GClass8 method_2()
		{
			return this.gclass8_0;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000021A9 File Offset: 0x000003A9
		[CompilerGenerated]
		public GClass1 method_3()
		{
			return this.gclass1_0;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000021B1 File Offset: 0x000003B1
		[CompilerGenerated]
		private void method_4(GClass1 gclass1_1)
		{
			this.gclass1_0 = gclass1_1;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000021BA File Offset: 0x000003BA
		[CompilerGenerated]
		public IPAddress method_5()
		{
			return this.ipaddress_0;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000021C2 File Offset: 0x000003C2
		[CompilerGenerated]
		public string method_6()
		{
			return this.string_0;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000021CA File Offset: 0x000003CA
		[CompilerGenerated]
		public bool method_7()
		{
			return this.bool_0;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000021D2 File Offset: 0x000003D2
		[CompilerGenerated]
		private void method_8(bool bool_1)
		{
			this.bool_0 = bool_1;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000021DB File Offset: 0x000003DB
		[CompilerGenerated]
		public long method_9()
		{
			return this.long_0;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000021E3 File Offset: 0x000003E3
		[CompilerGenerated]
		public GEnum0 method_10()
		{
			return this.genum0_0;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021EB File Offset: 0x000003EB
		[CompilerGenerated]
		private void method_11(GEnum0 genum0_1)
		{
			this.genum0_0 = genum0_1;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002BFC File Offset: 0x00000DFC
		public GClass3(Socket socket_1, SocketAsyncEventArgs socketAsyncEventArgs_1, long long_1)
		{
			this.long_0 = long_1;
			this.socket_0 = socket_1;
			this.socketAsyncEventArgs_0 = socketAsyncEventArgs_1;
			this.gclass6_0 = new GClass6(4096);
			this.gclass5_0 = new GClass5(this);
			this.gclass8_0 = new GClass8(this);
			this.method_11(GEnum0.const_0);
			this.ipaddress_0 = ((IPEndPoint)this.method_0().RemoteEndPoint).Address;
			CountryResponse countryResponse;
			this.string_0 = (GClass0.smethod_0().TryCountry(this.method_5(), out countryResponse) ? countryResponse.Country.IsoCode : "LO");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000021F4 File Offset: 0x000003F4
		public void method_12()
		{
			if (!this.method_7())
			{
				this.method_8(true);
				this.method_0().Close(5);
				this.socketAsyncEventArgs_0.Dispose();
				this.method_11(GEnum0.const_4);
				this.method_13();
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002229 File Offset: 0x00000429
		public void method_13()
		{
			if (this.method_3() != null)
			{
				GClass2.smethod_5(this.method_3());
				this.method_3().Destruct();
				this.method_4(null);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002250 File Offset: 0x00000450
		public void method_14(GEnum0 genum0_1)
		{
			if (this.method_10() != GEnum0.const_4)
			{
				this.method_11(genum0_1);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002262 File Offset: 0x00000462
		public void method_15(GClass1 gclass1_1)
		{
			this.method_4(gclass1_1);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002C9C File Offset: 0x00000E9C
		public void method_16()
		{
			if (!this.method_7())
			{
				this.gclass6_0.method_1(this.socketAsyncEventArgs_0.Buffer, this.socketAsyncEventArgs_0.BytesTransferred);
				if (this.method_10() != GEnum0.const_4)
				{
					int int_ = this.gclass6_0.method_3();
					int num;
					for (;;)
					{
						num = this.method_1().method_9(this.gclass6_0.method_4(), int_);
						if (num <= 0)
						{
							break;
						}
						this.gclass6_0.method_2(num);
						if ((int_ = this.gclass6_0.method_3()) <= 0)
						{
							return;
						}
					}
					if (num == -1)
					{
						GClass7.smethod_3(this);
						return;
					}
				}
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000226B File Offset: 0x0000046B
		public void method_17(byte[] byte_0, int int_0)
		{
			if (!this.method_7())
			{
				GClass7.smethod_2(this, byte_0, int_0);
			}
		}

		// Token: 0x04000010 RID: 16
		private readonly GClass6 gclass6_0;

		// Token: 0x04000011 RID: 17
		private readonly SocketAsyncEventArgs socketAsyncEventArgs_0;

		// Token: 0x04000012 RID: 18
		[CompilerGenerated]
		private readonly Socket socket_0;

		// Token: 0x04000013 RID: 19
		[CompilerGenerated]
		private readonly GClass5 gclass5_0;

		// Token: 0x04000014 RID: 20
		[CompilerGenerated]
		private readonly GClass8 gclass8_0;

		// Token: 0x04000015 RID: 21
		[CompilerGenerated]
		private GClass1 gclass1_0;

		// Token: 0x04000016 RID: 22
		[CompilerGenerated]
		private readonly IPAddress ipaddress_0;

		// Token: 0x04000017 RID: 23
		[CompilerGenerated]
		private readonly string string_0;

		// Token: 0x04000018 RID: 24
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000019 RID: 25
		[CompilerGenerated]
		private readonly long long_0;

		// Token: 0x0400001A RID: 26
		[CompilerGenerated]
		private GEnum0 genum0_0;
	}
}
