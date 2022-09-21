using System;
using System.Net;
using System.Net.Sockets;
using Atrasis.Magic.Servers.Core;

namespace ns0
{
	// Token: 0x0200000D RID: 13
	public class GClass7
	{
		// Token: 0x06000053 RID: 83 RVA: 0x0000237D File Offset: 0x0000057D
		public GClass7(string string_0, int int_2)
		{
			this.socket_0 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			this.socket_0.Bind(new IPEndPoint(IPAddress.Parse(string_0), int_2));
			this.socket_0.Listen(100);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003520 File Offset: 0x00001720
		public void method_0()
		{
			SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
			socketAsyncEventArgs.Completed += this.method_2;
			this.method_1(socketAsyncEventArgs);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000023B7 File Offset: 0x000005B7
		private void method_1(SocketAsyncEventArgs socketAsyncEventArgs_0)
		{
			socketAsyncEventArgs_0.AcceptSocket = null;
			if (!this.socket_0.AcceptAsync(socketAsyncEventArgs_0))
			{
				this.method_2(null, socketAsyncEventArgs_0);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000354C File Offset: 0x0000174C
		private void method_2(object sender, SocketAsyncEventArgs e)
		{
			if (e.SocketError == SocketError.Success)
			{
				Socket acceptSocket = e.AcceptSocket;
				SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
				socketAsyncEventArgs.SetBuffer(new byte[1024], 0, 1024);
				socketAsyncEventArgs.Completed += GClass7.smethod_0;
				GClass3 userToken = GClass4.smethod_2(acceptSocket, socketAsyncEventArgs);
				socketAsyncEventArgs.UserToken = userToken;
				if (!acceptSocket.ReceiveAsync(socketAsyncEventArgs))
				{
					GClass7.smethod_0(null, socketAsyncEventArgs);
				}
			}
			this.method_1(e);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000035BC File Offset: 0x000017BC
		private static void smethod_0(object sender, SocketAsyncEventArgs e)
		{
			GClass3 gclass = (GClass3)e.UserToken;
			if (gclass != null)
			{
				try
				{
					while (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
					{
						gclass.method_16();
						if (!gclass.method_7())
						{
							if (!gclass.method_0().ReceiveAsync(e))
							{
								continue;
							}
						}
						return;
					}
					GClass7.smethod_3(gclass);
				}
				catch (SocketException)
				{
					GClass7.smethod_3(gclass);
				}
				catch (Exception arg)
				{
					Logging.Error("TcpServerSocket.onReceive - unhandled exception thrown : " + arg);
					GClass7.smethod_3(gclass);
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000023D6 File Offset: 0x000005D6
		private static void smethod_1(object sender, SocketAsyncEventArgs e)
		{
			if (e.SocketError != SocketError.Success)
			{
				GClass7.smethod_3((GClass3)e.UserToken);
			}
			e.Dispose();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003650 File Offset: 0x00001850
		public static void smethod_2(GClass3 gclass3_0, byte[] byte_0, int int_2)
		{
			SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
			socketAsyncEventArgs.SetBuffer(byte_0, 0, int_2);
			socketAsyncEventArgs.UserToken = gclass3_0;
			socketAsyncEventArgs.Completed += GClass7.smethod_1;
			try
			{
				if (!gclass3_0.method_0().SendAsync(socketAsyncEventArgs))
				{
					GClass7.smethod_1(null, socketAsyncEventArgs);
				}
			}
			catch (Exception)
			{
				GClass7.smethod_1(null, socketAsyncEventArgs);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000023F6 File Offset: 0x000005F6
		public static void smethod_3(GClass3 gclass3_0)
		{
			if (!gclass3_0.method_7() && GClass4.smethod_4(gclass3_0))
			{
				gclass3_0.method_12();
			}
		}

		// Token: 0x04000037 RID: 55
		public const int int_0 = 100;

		// Token: 0x04000038 RID: 56
		public const int int_1 = 1024;

		// Token: 0x04000039 RID: 57
		private readonly Socket socket_0;
	}
}
