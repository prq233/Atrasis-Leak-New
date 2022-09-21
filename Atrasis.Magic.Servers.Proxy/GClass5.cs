using System;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Logic.Message.Security;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x0200000A RID: 10
	public class GClass5
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002297 File Offset: 0x00000497
		public GClass5(GClass3 gclass3_1)
		{
			this.gclass3_0 = gclass3_1;
			this.logicMessageFactory_0 = LogicMagicMessageFactory.Instance;
			this.enum0_0 = GClass5.Enum0.const_1;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002F68 File Offset: 0x00001168
		public void method_0(string string_0)
		{
			if (this.streamEncrypter_0 != null)
			{
				this.streamEncrypter_0.Destruct();
			}
			if (this.streamEncrypter_1 != null)
			{
				this.streamEncrypter_1.Destruct();
			}
			this.streamEncrypter_0 = new RC4Encrypter("fhsd6f86f67rt8fw78fw789we78r9789wer6re", string_0);
			this.streamEncrypter_1 = new RC4Encrypter("fhsd6f86f67rt8fw78fw789we78r9789wer6re", string_0);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000022B8 File Offset: 0x000004B8
		public void method_1()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000022BF File Offset: 0x000004BF
		public string method_2()
		{
			if (EnvironmentSettings.IsStageServer())
			{
				return "4c444a4b4c396876736b6c3b6473766b666c73676a90fbef";
			}
			if (EnvironmentSettings.IsIntegrationServer())
			{
				return "77035c098d0a04753b77167c7133cdd4b7052813ed47c461";
			}
			return "nonce";
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000022E0 File Offset: 0x000004E0
		private int method_3(byte[] byte_0, byte[] byte_1, int int_4)
		{
			return this.streamEncrypter_0.Decrypt(byte_0, byte_1, int_4);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000022F0 File Offset: 0x000004F0
		private int method_4(byte[] byte_0, byte[] byte_1, int int_4)
		{
			return this.streamEncrypter_1.Encrypt(byte_0, byte_1, int_4);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002300 File Offset: 0x00000500
		public void method_5(int int_4)
		{
			this.int_3 = int_4;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002FC0 File Offset: 0x000011C0
		private void method_6(ExtendedSetEncryptionMessage extendedSetEncryptionMessage_0)
		{
			byte[] array = extendedSetEncryptionMessage_0.RemoveNonce();
			if (extendedSetEncryptionMessage_0.GetNonceMethod() == 1)
			{
				this.method_7(array, array.Length);
			}
			else
			{
				this.method_8(array, array.Length);
			}
			char[] array2 = new char[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (char)array[i];
			}
			this.method_0(new string(array2));
			this.bool_0 = true;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003024 File Offset: 0x00001224
		private void method_7(byte[] byte_0, int int_4)
		{
			LogicMersenneTwisterRandom logicMersenneTwisterRandom = new LogicMersenneTwisterRandom(this.int_3);
			int num = 0;
			for (int i = 0; i < 100; i++)
			{
				num = logicMersenneTwisterRandom.Rand(256);
			}
			for (int j = 0; j < int_4; j++)
			{
				int num2 = j;
				byte_0[num2] ^= (byte)(num & (int)((byte)logicMersenneTwisterRandom.Rand(256)));
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003080 File Offset: 0x00001280
		private void method_8(byte[] byte_0, int int_4)
		{
			LogicRandom logicRandom = new LogicRandom(this.int_3);
			for (int i = 0; i < int_4; i++)
			{
				int num = i;
				byte_0[num] ^= (byte)logicRandom.Rand(256);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000030C0 File Offset: 0x000012C0
		public int method_9(byte[] byte_0, int int_4)
		{
			if (int_4 >= 7)
			{
				int num;
				int num2;
				int messageVersion;
				GClass5.smethod_1(byte_0, out num, out num2, out messageVersion);
				if (int_4 - 7 >= num2)
				{
					byte[] array = new byte[num2];
					Buffer.BlockCopy(byte_0, 7, array, 0, num2);
					int num3;
					byte[] array2;
					if (this.streamEncrypter_0 != null)
					{
						num3 = num2 - this.streamEncrypter_0.GetOverheadEncryption();
						array2 = new byte[num3];
						this.method_3(array, array2, num2);
					}
					else if (ResourceSettings.Encryption.Enabled)
					{
						if (this.enum0_0 == GClass5.Enum0.const_1)
						{
							if (num == 10100)
							{
								this.enum0_0 = GClass5.Enum0.const_2;
								num3 = num2;
								array2 = array;
							}
							else
							{
								if (num != 10101)
								{
									return num2 + 7;
								}
								this.enum0_0 = GClass5.Enum0.const_0;
								this.method_0(this.method_2());
								num3 = num2 - this.streamEncrypter_0.GetOverheadEncryption();
								array2 = new byte[num3];
								this.method_3(array, array2, num2);
							}
						}
						else
						{
							if (this.enum0_0 != GClass5.Enum0.const_3)
							{
								return num2 + 7;
							}
							if (num != 10101)
							{
								return num2 + 7;
							}
							throw new NotImplementedException();
						}
					}
					else
					{
						if (this.enum0_0 == GClass5.Enum0.const_1)
						{
							this.enum0_0 = GClass5.Enum0.const_0;
						}
						num3 = num2;
						array2 = array;
					}
					PiranhaMessage piranhaMessage = this.logicMessageFactory_0.CreateMessageByType(num);
					if (piranhaMessage != null)
					{
						piranhaMessage.GetByteStream().SetByteArray(array2, num3);
						piranhaMessage.SetMessageVersion(messageVersion);
						try
						{
							piranhaMessage.Decode();
							if (!piranhaMessage.IsServerToClientMessage())
							{
								Class1.smethod_3(piranhaMessage, this.gclass3_0);
							}
							goto IL_179;
						}
						catch (Exception arg)
						{
							Logging.Error(string.Format("Messaging::onReceive: error while the decoding of message type {0}, trace: {1}", num, arg));
							goto IL_179;
						}
					}
					Logging.Warning(string.Format("Messaging::onReceive: ignoring message of unknown type {0}", num));
					IL_179:
					return num2 + 7;
				}
				if (((int)byte_0[0] << 16 | (int)byte_0[1] << 8 | (int)byte_0[2]) == 4670804)
				{
					return -1;
				}
			}
			return 0;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002309 File Offset: 0x00000509
		public void method_10(PiranhaMessage piranhaMessage_0)
		{
			if (piranhaMessage_0.IsServerToClientMessage())
			{
				Class1.smethod_4(piranhaMessage_0, this.gclass3_0);
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003274 File Offset: 0x00001474
		public void method_11(PiranhaMessage piranhaMessage_0)
		{
			if (piranhaMessage_0.GetEncodingLength() == 0)
			{
				piranhaMessage_0.Encode();
			}
			int encodingLength = piranhaMessage_0.GetEncodingLength();
			byte[] messageBytes = piranhaMessage_0.GetMessageBytes();
			int num;
			byte[] array;
			if (this.streamEncrypter_1 != null)
			{
				if (!this.bool_0 && piranhaMessage_0.GetMessageType() == 20104)
				{
					byte[] nonce = GClass5.smethod_0();
					ExtendedSetEncryptionMessage extendedSetEncryptionMessage = new ExtendedSetEncryptionMessage();
					extendedSetEncryptionMessage.SetNonce(nonce);
					extendedSetEncryptionMessage.SetNonceMethod(1);
					this.method_11(extendedSetEncryptionMessage);
					this.method_6(extendedSetEncryptionMessage);
				}
				num = encodingLength + this.streamEncrypter_1.GetOverheadEncryption();
				array = new byte[num];
				this.method_4(messageBytes, array, encodingLength);
			}
			else if (ResourceSettings.Encryption.Enabled)
			{
				if (this.enum0_0 == GClass5.Enum0.const_2)
				{
					if (piranhaMessage_0.GetMessageType() == 20100)
					{
						this.enum0_0 = GClass5.Enum0.const_3;
					}
					num = encodingLength;
					array = messageBytes;
				}
				else
				{
					if (this.enum0_0 == GClass5.Enum0.const_4)
					{
						throw new NotImplementedException();
					}
					num = encodingLength;
					array = messageBytes;
				}
			}
			else
			{
				if (!this.bool_0 && piranhaMessage_0.GetMessageType() == 20104)
				{
					byte[] nonce2 = GClass5.smethod_0();
					ExtendedSetEncryptionMessage extendedSetEncryptionMessage2 = new ExtendedSetEncryptionMessage();
					extendedSetEncryptionMessage2.SetNonce(nonce2);
					extendedSetEncryptionMessage2.SetNonceMethod(1);
					this.method_11(extendedSetEncryptionMessage2);
					this.bool_0 = true;
				}
				num = encodingLength;
				array = messageBytes;
			}
			byte[] array2 = new byte[num + 7];
			GClass5.smethod_2(piranhaMessage_0, array2, num);
			Buffer.BlockCopy(array, 0, array2, 7, num);
			this.gclass3_0.method_17(array2, num + 7);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000033C4 File Offset: 0x000015C4
		private static byte[] smethod_0()
		{
			byte[] array = new byte[24];
			for (int i = 0; i < 24; i += 4)
			{
				int num = ServerCore.Random.Rand(int.MaxValue);
				array[i] = (byte)(num >> 24);
				array[i + 1] = (byte)(num >> 16);
				array[i + 2] = (byte)(num >> 8);
				array[i + 3] = (byte)num;
			}
			return array;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000231F File Offset: 0x0000051F
		private static void smethod_1(byte[] byte_0, out int int_4, out int int_5, out int int_6)
		{
			int_4 = ((int)byte_0[0] << 8 | (int)byte_0[1]);
			int_5 = ((int)byte_0[2] << 16 | (int)byte_0[3] << 8 | (int)byte_0[4]);
			int_6 = ((int)byte_0[5] << 8 | (int)byte_0[6]);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000341C File Offset: 0x0000161C
		private static void smethod_2(PiranhaMessage piranhaMessage_0, byte[] byte_0, int int_4)
		{
			int messageType = (int)piranhaMessage_0.GetMessageType();
			int messageVersion = piranhaMessage_0.GetMessageVersion();
			byte_0[0] = (byte)(messageType >> 8);
			byte_0[1] = (byte)messageType;
			byte_0[2] = (byte)(int_4 >> 16);
			byte_0[3] = (byte)(int_4 >> 8);
			byte_0[4] = (byte)int_4;
			byte_0[5] = (byte)(messageVersion >> 8);
			byte_0[6] = (byte)messageVersion;
			if (int_4 > 16777215)
			{
				Logging.Error("NetworkMessaging::writeHeader trying to send too big message, type " + messageType);
			}
		}

		// Token: 0x04000025 RID: 37
		public const int int_0 = 7;

		// Token: 0x04000026 RID: 38
		public const int int_1 = 24;

		// Token: 0x04000027 RID: 39
		public const int int_2 = 1;

		// Token: 0x04000028 RID: 40
		private readonly GClass3 gclass3_0;

		// Token: 0x04000029 RID: 41
		private readonly LogicMessageFactory logicMessageFactory_0;

		// Token: 0x0400002A RID: 42
		private StreamEncrypter streamEncrypter_0;

		// Token: 0x0400002B RID: 43
		private StreamEncrypter streamEncrypter_1;

		// Token: 0x0400002C RID: 44
		private int int_3;

		// Token: 0x0400002D RID: 45
		private bool bool_0;

		// Token: 0x0400002E RID: 46
		private GClass5.Enum0 enum0_0;

		// Token: 0x0200000B RID: 11
		private enum Enum0
		{
			// Token: 0x04000030 RID: 48
			const_0,
			// Token: 0x04000031 RID: 49
			const_1,
			// Token: 0x04000032 RID: 50
			const_2,
			// Token: 0x04000033 RID: 51
			const_3,
			// Token: 0x04000034 RID: 52
			const_4
		}
	}
}
