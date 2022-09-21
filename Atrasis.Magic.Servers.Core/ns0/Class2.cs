using System;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Titan.DataStream;

namespace ns0
{
	// Token: 0x02000023 RID: 35
	internal static class Class2
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00004DA1 File Offset: 0x00002FA1
		internal static void smethod_0(ServerMessageManager serverMessageManager_0)
		{
			Class2.class4_0 = new Class4(serverMessageManager_0);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004DAE File Offset: 0x00002FAE
		public static void smethod_1()
		{
			if (Class2.class4_0 != null)
			{
				Class2.class4_0.vmethod_0();
				Class2.class4_0 = null;
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000B464 File Offset: 0x00009664
		internal static void smethod_2(byte[] byte_0, int int_0)
		{
			ServerMessage serverMessage = Class2.smethod_3(byte_0, int_0);
			if (serverMessage != null)
			{
				Class2.class4_0.method_2(serverMessage);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000B488 File Offset: 0x00009688
		internal static ServerMessage smethod_3(byte[] byte_0, int int_0)
		{
			ByteStream byteStream = new ByteStream(byte_0, int_0);
			ServerMessage serverMessage = ServerMessageFactory.CreateMessageByType((ServerMessageType)byteStream.ReadShort());
			if (serverMessage != null)
			{
				ServerMessage result;
				try
				{
					serverMessage.DecodeHeader(byteStream);
					serverMessage.Decode(byteStream);
					result = serverMessage;
				}
				catch (Exception arg)
				{
					Logging.Error(string.Format("ServerMessaging.onReceive exception when the decoding of message type {0}, trace: {1}", serverMessage.GetMessageType(), arg));
					goto IL_49;
				}
				return result;
			}
			IL_49:
			return null;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000B4F0 File Offset: 0x000096F0
		internal static void smethod_4(ServerMessage serverMessage_0, out byte[] byte_0, out int int_0)
		{
			ByteStream byteStream = new ByteStream(64);
			byteStream.WriteShort((short)serverMessage_0.GetMessageType());
			serverMessage_0.EncodeHeader(byteStream);
			serverMessage_0.Encode(byteStream);
			byte_0 = byteStream.GetByteArray();
			int_0 = byteStream.GetOffset();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004DC7 File Offset: 0x00002FC7
		internal static void smethod_5(ServerMessage serverMessage_0, ServerSocket serverSocket_0)
		{
			if (serverSocket_0 == null)
			{
				Logging.Warning("ServerMessaging.send - socket is NULL");
				return;
			}
			serverMessage_0.SenderType = ServerCore.Type;
			serverMessage_0.SenderId = ServerCore.Id;
			Class2.class4_0.method_3(serverMessage_0, serverSocket_0);
		}

		// Token: 0x04000053 RID: 83
		private static Class4 class4_0;
	}
}
