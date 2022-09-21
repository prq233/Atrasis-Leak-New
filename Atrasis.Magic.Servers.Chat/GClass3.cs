using System;
using System.Runtime.CompilerServices;
using System.Text;
using Atrasis.Magic.Logic.Command.Debug;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Chat;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public class GClass3
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002165 File Offset: 0x00000365
		public GClass3(GClass1 gclass1_1)
		{
			this.gclass1_0 = gclass1_1;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002174 File Offset: 0x00000374
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			if (piranhaMessage_0.GetMessageType() == 14715)
			{
				this.method_1((SendGlobalChatLineMessage)piranhaMessage_0);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002274 File Offset: 0x00000474
		private void method_1(SendGlobalChatLineMessage sendGlobalChatLineMessage_0)
		{
			GClass3.Class1 @class = new GClass3.Class1();
			@class.gclass3_0 = this;
			if (!this.method_3())
			{
				return;
			}
			@class.string_0 = StringUtil.RemoveMultipleSpaces(sendGlobalChatLineMessage_0.RemoveMessage());
			if (@class.string_0.Length > 0)
			{
				if (@class.string_0.Length > 128)
				{
					@class.string_0 = @class.string_0.Substring(0, 128);
				}
				if (@class.string_0.StartsWith("/"))
				{
					if (!ResourceSettings.Environment.OPCommandAllowedInGlobalChat)
					{
						this.method_2("OP commands must be executed in the News menu");
						return;
					}
					GClass3.Class2 class2 = new GClass3.Class2();
					class2.class1_0 = @class;
					class2.string_0 = class2.class1_0.string_0.Split(' ', StringSplitOptions.None);
					string text = class2.string_0[0].ToLowerInvariant();
					if (text != null)
					{
						uint num = Class3.smethod_0(text);
						if (num <= 1946511834U)
						{
							if (num <= 1726118479U)
							{
								if (num != 1271957719U)
								{
									if (num != 1726118479U)
									{
										return;
									}
									if (!(text == "/clear"))
									{
										return;
									}
									AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
									availableServerCommandMessage.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.REMOVE_OBSTACLES));
									this.gclass1_0.SendPiranhaMessage(availableServerCommandMessage, 1);
									return;
								}
								else
								{
									if (!(text == "/diamonds"))
									{
										return;
									}
									LogicDiamondsAddedCommand logicDiamondsAddedCommand = new LogicDiamondsAddedCommand();
									logicDiamondsAddedCommand.SetData(true, 1000000, 0, false, 0, null);
									ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
									{
										AccountId = this.gclass1_0.AccountId,
										ServerCommand = logicDiamondsAddedCommand
									}, 9);
									return;
								}
							}
							else if (num != 1776830250U)
							{
								if (num != 1946511834U)
								{
									return;
								}
								if (!(text == "/attack"))
								{
									return;
								}
								if (class2.string_0.Length >= 2)
								{
									string text2 = class2.string_0[1];
									if (text2.StartsWith("#"))
									{
										LogicLong accountId = HashTagCodeGenerator.m_instance.ToId(text2.ToUpperInvariant());
										this.gclass1_0.SendMessage(new GameStartFakeAttackMessage
										{
											AccountId = accountId
										}, 9);
										return;
									}
									if (text2 != null)
									{
										if (text2 == "me")
										{
											this.gclass1_0.SendMessage(new GameStartFakeAttackMessage
											{
												AccountId = this.gclass1_0.AccountId
											}, 9);
											return;
										}
										if (!(text2 == "generated"))
										{
											return;
										}
										this.gclass1_0.SendMessage(new GameStartFakeAttackMessage(), 9);
										return;
									}
								}
							}
							else
							{
								if (!(text == "/castle"))
								{
									return;
								}
								ServerRequestManager.Create(new AvatarRequestMessage
								{
									AccountId = this.gclass1_0.AccountId
								}, ServerManager.GetDocumentSocket(9, this.gclass1_0.AccountId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(class2.method_0);
								return;
							}
						}
						else if (num <= 2553977278U)
						{
							if (num != 2434390366U)
							{
								if (num != 2553977278U)
								{
									return;
								}
								if (!(text == "/upgrade"))
								{
									return;
								}
								AvailableServerCommandMessage availableServerCommandMessage2 = new AvailableServerCommandMessage();
								availableServerCommandMessage2.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.UPGRADE_BUILDINGS));
								this.gclass1_0.SendPiranhaMessage(availableServerCommandMessage2, 1);
								return;
							}
							else
							{
								if (!(text == "/load"))
								{
									return;
								}
								AvailableServerCommandMessage availableServerCommandMessage3 = new AvailableServerCommandMessage();
								LogicDebugCommand logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.LOAD_LEVEL);
								logicDebugCommand.SetDebugString(ResourceSettings.Environment.PresetLevelJSON[ServerCore.Random.Rand(ResourceSettings.Environment.PresetLevelJSON.Length)]);
								availableServerCommandMessage3.SetServerCommand(logicDebugCommand);
								this.gclass1_0.SendPiranhaMessage(availableServerCommandMessage3, 1);
								return;
							}
						}
						else if (num != 2595342849U)
						{
							if (num != 3343210618U)
							{
								return;
							}
							if (!(text == "/remove"))
							{
								return;
							}
							AvailableServerCommandMessage availableServerCommandMessage4 = new AvailableServerCommandMessage();
							availableServerCommandMessage4.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.REMOVE_UNITS));
							this.gclass1_0.SendPiranhaMessage(availableServerCommandMessage4, 1);
							return;
						}
						else
						{
							if (!(text == "/help"))
							{
								return;
							}
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.AppendLine("Available commands:");
							stringBuilder.AppendLine("/attack me (attack my village)");
							stringBuilder.AppendLine("/attack generated (attack a generated village)");
							stringBuilder.AppendLine("/attack generated BUILDING_ID (attack a generated village with the specified b.)");
							stringBuilder.AppendLine("/attack #PLAYER_TAG (attack the specified player)");
							stringBuilder.AppendLine("/clear (clear all obstacles)");
							stringBuilder.AppendLine("/load (load a preset village)");
							stringBuilder.AppendLine("/upgrade (upgrade buildings to max level allowed by TH)");
							stringBuilder.AppendLine("/remove (remove all troops and spells)");
							stringBuilder.AppendLine("/diamonds (add 1,000,000 diamonds)");
							stringBuilder.AppendLine("/castle (fills the clan castle with troops)");
							stringBuilder.AppendLine("/castle TROOP_ID (fills the clan castle with the specified troops)");
							this.method_2(stringBuilder.ToString());
							return;
						}
					}
				}
				else
				{
					ServerRequestManager.Create(new AvatarRequestMessage
					{
						AccountId = this.gclass1_0.AccountId
					}, ServerManager.GetDocumentSocket(9, this.gclass1_0.AccountId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000026F8 File Offset: 0x000008F8
		private void method_2(string string_0)
		{
			GlobalChatLineMessage globalChatLineMessage = new GlobalChatLineMessage();
			globalChatLineMessage.SetMessage(string_0);
			globalChatLineMessage.SetAvatarId(new LogicLong(0, 1));
			globalChatLineMessage.SetHomeId(new LogicLong(0, 1));
			globalChatLineMessage.SetAvatarExpLevel(500);
			globalChatLineMessage.SetAvatarLeagueType(LogicDataTables.GetTable(LogicDataType.LEAGUE).GetItemCount() - 1);
			globalChatLineMessage.SetAvatarName("Atrasis - Bot");
			this.gclass1_0.SendPiranhaMessage(globalChatLineMessage, 1);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002764 File Offset: 0x00000964
		private bool method_3()
		{
			return DateTime.UtcNow.Subtract(this.dateTime_0).TotalSeconds >= 1.0;
		}

		// Token: 0x04000004 RID: 4
		private readonly GClass1 gclass1_0;

		// Token: 0x04000005 RID: 5
		private DateTime dateTime_0;

		// Token: 0x02000007 RID: 7
		[CompilerGenerated]
		private sealed class Class1
		{
			// Token: 0x06000014 RID: 20 RVA: 0x0000279C File Offset: 0x0000099C
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					this.gclass3_0.gclass1_0.method_1().method_3(((AvatarResponseMessage)serverRequestArgs_0.ResponseMessage).LogicClientAvatar, this.string_0);
				}
			}

			// Token: 0x04000006 RID: 6
			public GClass3 gclass3_0;

			// Token: 0x04000007 RID: 7
			public string string_0;
		}

		// Token: 0x02000008 RID: 8
		[CompilerGenerated]
		private sealed class Class2
		{
			// Token: 0x06000016 RID: 22 RVA: 0x000027EC File Offset: 0x000009EC
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					AvatarResponseMessage avatarResponseMessage = (AvatarResponseMessage)serverRequestArgs_0.ResponseMessage;
					LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
					LogicCharacterData logicCharacterData = null;
					int allianceCastleFreeCapacity = avatarResponseMessage.LogicClientAvatar.GetAllianceCastleFreeCapacity();
					int num = 0;
					int num2;
					if (this.string_0.Length >= 2 && int.TryParse(this.string_0[1], out num2))
					{
						int i = 0;
						int num3 = 0;
						while (i < table.GetItemCount())
						{
							LogicCharacterData logicCharacterData2 = (LogicCharacterData)table.GetItemAt(i);
							if (logicCharacterData.IsEnabledInVillageType(0) && !logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop() && logicCharacterData.IsProductionEnabled())
							{
								num3++;
								if (num3 == num2)
								{
									logicCharacterData = logicCharacterData2;
									num = allianceCastleFreeCapacity / logicCharacterData.GetHousingSpace();
									break;
								}
							}
							i++;
						}
					}
					if (logicCharacterData == null)
					{
						for (int j = 0; j < 10; j++)
						{
							logicCharacterData = (LogicCharacterData)table.GetItemAt(ServerCore.Random.Rand(table.GetItemCount()));
							if (logicCharacterData.IsEnabledInVillageType(0) && !logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop() && logicCharacterData.IsProductionEnabled())
							{
								num = allianceCastleFreeCapacity / logicCharacterData.GetHousingSpace();
								if (num != 0)
								{
									break;
								}
							}
						}
					}
					if (logicCharacterData != null)
					{
						for (int k = 0; k < num; k++)
						{
							LogicAllianceUnitReceivedCommand logicAllianceUnitReceivedCommand = new LogicAllianceUnitReceivedCommand();
							logicAllianceUnitReceivedCommand.SetData("Atrasis - Bot", logicCharacterData, logicCharacterData.GetUpgradeLevelCount() - 1);
							ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
							{
								AccountId = this.class1_0.gclass3_0.gclass1_0.AccountId,
								ServerCommand = logicAllianceUnitReceivedCommand
							}, 9);
						}
					}
				}
			}

			// Token: 0x04000008 RID: 8
			public string[] string_0;

			// Token: 0x04000009 RID: 9
			public GClass3.Class1 class1_0;
		}
	}
}
