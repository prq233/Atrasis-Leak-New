using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command.Debug;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000029 RID: 41
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class UserController : Controller
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00004578 File Offset: 0x00002778
		[HttpGet("{id}")]
		public async Task<JObject> Get(long id, [FromQuery(Name = "pass")] string passToken)
		{
			Task<AccountDocument> account = UserManager.GetAccount(id);
			Task<GameDocument> taskDocument = UserManager.GetAvatar(id);
			AccountDocument accountDocument2 = await account;
			AccountDocument accountDocument = accountDocument2;
			GameDocument gameDocument = await taskDocument;
			JObject result;
			if (accountDocument != null && gameDocument != null)
			{
				if (passToken != accountDocument.PassToken)
				{
					result = this.BuildResponse(HttpStatusCode.Forbidden);
				}
				else
				{
					TaskAwaiter<bool> taskAwaiter = ServerAdmin.SessionDatabase.Exists(id).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<bool> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
					}
					bool result2 = taskAwaiter.GetResult();
					JObject jobject = this.BuildResponse(HttpStatusCode.OK).AddAttribute("online", result2);
					JObject jobject2 = new JObject();
					jobject2.Add("status", accountDocument.State.ToString());
					if (accountDocument.StateArg != null)
					{
						AccountState state = accountDocument.State;
						if (state != AccountState.LOCKED)
						{
							if (state == AccountState.BANNED)
							{
								jobject2.Add("reason", accountDocument.StateArg);
							}
						}
						else
						{
							jobject2.Add("unlockCode", accountDocument.StateArg);
						}
					}
					jobject2.Add("rank", accountDocument.Rank.ToString());
					jobject2.Add("country", accountDocument.Country);
					jobject2.Add("createTime", TimeUtil.GetDateTimeFromTimestamp(accountDocument.CreateTime).ToString("F"));
					jobject2.Add("lastSessionTime", TimeUtil.GetDateTimeFromTimestamp(accountDocument.LastSessionTime).ToString("F"));
					jobject2.Add("playTimeSecs", UserController.GetSecondsToTime(accountDocument.PlayTimeSeconds + (result2 ? ((int)DateTime.UtcNow.Subtract(TimeUtil.GetDateTimeFromTimestamp(accountDocument.LastSessionTime)).TotalSeconds) : 0)));
					jobject.Add("account", jobject2);
					jobject.Add("avatar", new JObject
					{
						{
							"name",
							gameDocument.LogicClientAvatar.GetName()
						},
						{
							"nameChanged",
							gameDocument.LogicClientAvatar.GetNameChangeState() >= 1
						},
						{
							"diamonds",
							gameDocument.LogicClientAvatar.GetDiamonds()
						},
						{
							"lvl",
							gameDocument.LogicClientAvatar.GetExpLevel()
						}
					});
					if (gameDocument.LogicClientAvatar.IsInAlliance())
					{
						JObject jobject3 = new JObject();
						jobject3.Add("name", gameDocument.LogicClientAvatar.GetAllianceName());
						jobject3.Add("badgeId", gameDocument.LogicClientAvatar.GetAllianceBadgeId());
						jobject3.Add("lvl", gameDocument.LogicClientAvatar.GetAllianceLevel());
						switch (gameDocument.LogicClientAvatar.GetAllianceRole())
						{
						case LogicAvatarAllianceRole.MEMBER:
							jobject3.Add("role", "Member");
							break;
						case LogicAvatarAllianceRole.LEADER:
							jobject3.Add("role", "Leader");
							break;
						case LogicAvatarAllianceRole.ELDER:
							jobject3.Add("role", "Elder");
							break;
						case LogicAvatarAllianceRole.CO_LEADER:
							jobject3.Add("role", "Co Leader");
							break;
						}
						jobject.Add("alliance", jobject3);
					}
					if (result2)
					{
						jobject.Add("op-cmd", new JArray
						{
							0,
							1,
							2,
							3,
							4,
							5
						});
					}
					result = jobject;
				}
			}
			else
			{
				result = this.BuildResponse(HttpStatusCode.InternalServerError);
			}
			return result;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000045D0 File Offset: 0x000027D0
		[HttpPost("commands/op/{id}")]
		public async Task<JObject> ExecuteOPCommand(int id, [FromQuery(Name = "userId")] long accountId, [FromQuery(Name = "pass")] string passToken, [FromBody] JObject args)
		{
			AccountDocument accountDocument = await UserManager.GetAccount(accountId);
			AccountDocument accountDocument2 = accountDocument;
			JObject result;
			if (accountDocument2 == null)
			{
				result = this.BuildResponse(HttpStatusCode.InternalServerError);
			}
			else if (passToken != accountDocument2.PassToken)
			{
				result = this.BuildResponse(HttpStatusCode.Forbidden);
			}
			else
			{
				RedisValue value = await ServerAdmin.SessionDatabase.Get(accountDocument2.Id);
				if (value.IsNull)
				{
					result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "No client connected.");
				}
				else
				{
					long sessionId = long.Parse(value);
					switch (id)
					{
					case 0:
					{
						LogicGameObjectData logicGameObjectData = null;
						JToken value2;
						if (args.TryGetValue("objectName", out value2) && ((string)value2).Length > 0)
						{
							logicGameObjectData = LogicDataTables.GetBuildingByName((string)value2, null);
							if (logicGameObjectData == null)
							{
								logicGameObjectData = (LogicGameObjectData)LogicDataTables.GetTable(LogicDataType.TRAP).GetDataByName((string)value2, null);
								if (logicGameObjectData == null)
								{
									return this.BuildResponse(HttpStatusCode.NotFound).AddAttribute("reason", "Unknown object name");
								}
							}
						}
						ServerMessageManager.SendMessage(new GameStartFakeAttackMessage
						{
							SessionId = sessionId,
							ArgData = logicGameObjectData
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetDocumentSocket(9, accountId));
						break;
					}
					case 1:
						ServerMessageManager.SendMessage(new GameStartFakeAttackMessage
						{
							AccountId = accountId,
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetDocumentSocket(9, accountId));
						break;
					case 2:
					{
						AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
						availableServerCommandMessage.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.UPGRADE_ALL_BUILDINGS));
						availableServerCommandMessage.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage.GetMessageType(),
							MessageLength = availableServerCommandMessage.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 3:
					{
						AvailableServerCommandMessage availableServerCommandMessage2 = new AvailableServerCommandMessage();
						availableServerCommandMessage2.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.REMOVE_OBSTACLES));
						availableServerCommandMessage2.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage2.GetMessageType(),
							MessageLength = availableServerCommandMessage2.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage2.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage2.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 4:
					{
						AvailableServerCommandMessage availableServerCommandMessage3 = new AvailableServerCommandMessage();
						availableServerCommandMessage3.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.SET_MAX_UNIT_SPELL_LEVELS));
						availableServerCommandMessage3.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage3.GetMessageType(),
							MessageLength = availableServerCommandMessage3.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage3.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage3.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 5:
					{
						AvailableServerCommandMessage availableServerCommandMessage4 = new AvailableServerCommandMessage();
						availableServerCommandMessage4.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.SET_MAX_HERO_LEVELS));
						availableServerCommandMessage4.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage4.GetMessageType(),
							MessageLength = availableServerCommandMessage4.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage4.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage4.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 6:
					{
						GameDocument gameDocument = await UserManager.GetAvatar(accountId);
						if (gameDocument != null)
						{
							LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
							LogicCharacterData logicCharacterData = null;
							int num = 0;
							JToken value3;
							if (args.TryGetValue("objectName", out value3) && ((string)value3).Length > 0)
							{
								logicCharacterData = (LogicCharacterData)table.GetDataByName((string)value3, null);
								if (logicCharacterData != null)
								{
									if (!logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop())
									{
										num = gameDocument.LogicClientAvatar.GetAllianceCastleFreeCapacity() / logicCharacterData.GetHousingSpace();
										if (num == 0)
										{
											logicCharacterData = null;
										}
									}
									else
									{
										logicCharacterData = null;
									}
								}
							}
							if (logicCharacterData == null)
							{
								for (int i = 0; i < 10; i++)
								{
									logicCharacterData = (LogicCharacterData)table.GetItemAt(ServerCore.Random.Rand(table.GetItemCount()));
									if (logicCharacterData.IsEnabledInVillageType(1) && !logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop())
									{
										num = gameDocument.LogicClientAvatar.GetAllianceCastleFreeCapacity() / logicCharacterData.GetHousingSpace();
										if (num != 0)
										{
											break;
										}
									}
								}
							}
							if (logicCharacterData != null)
							{
								for (int j = 0; j < num; j++)
								{
									LogicAllianceUnitReceivedCommand logicAllianceUnitReceivedCommand = new LogicAllianceUnitReceivedCommand();
									logicAllianceUnitReceivedCommand.SetData("Atrasis - Bot", logicCharacterData, logicCharacterData.GetUpgradeLevelCount() - 1);
									ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
									{
										AccountId = accountId,
										ServerCommand = logicAllianceUnitReceivedCommand
									}, 9);
								}
							}
						}
						break;
					}
					}
					result = this.BuildResponse(HttpStatusCode.OK);
				}
			}
			return result;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00004638 File Offset: 0x00002838
		[HttpGet("commands/debug/{id}/info")]
		public JObject GetOPCommandInfo(int id)
		{
			if (id == 0)
			{
				JArray jarray = new JArray();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicBuildingData logicBuildingData = (LogicBuildingData)table.GetItemAt(i);
					if (!logicBuildingData.IsAllianceCastle() && !logicBuildingData.IsTownHall() && !logicBuildingData.IsTownHallVillage2() && logicBuildingData.IsEnabledInVillageType(0) && !logicBuildingData.IsEnableByCalendar())
					{
						jarray.Add(logicBuildingData.GetName());
					}
				}
				for (int j = 0; j < table2.GetItemCount(); j++)
				{
					LogicTrapData logicTrapData = (LogicTrapData)table2.GetItemAt(j);
					if (logicTrapData.IsEnabledInVillageType(0) && !logicTrapData.IsEnableByCalendar() && logicTrapData.GetSpawnedCharAir() == null && logicTrapData.GetSpawnedCharGround() == null)
					{
						jarray.Add(logicTrapData.GetName());
					}
				}
				return this.BuildResponse(HttpStatusCode.OK).AddAttribute("objects", jarray);
			}
			if (id != 6)
			{
				return this.BuildResponse(HttpStatusCode.NotFound);
			}
			JArray jarray2 = new JArray();
			LogicDataTable table3 = LogicDataTables.GetTable(LogicDataType.CHARACTER);
			for (int k = 0; k < table3.GetItemCount(); k++)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)table3.GetItemAt(k);
				if (logicCharacterData.IsEnabledInVillageType(0) && !logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop())
				{
					jarray2.Add(logicCharacterData.GetName());
				}
			}
			return this.BuildResponse(HttpStatusCode.OK).AddAttribute("objects", jarray2);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000047C4 File Offset: 0x000029C4
		public static string GetSecondsToTime(int secs)
		{
			if (secs < 60)
			{
				return string.Format("{0}secs", secs);
			}
			if (secs < 3600)
			{
				return string.Format("{0}mn {1}secs", secs / 60, secs % 60);
			}
			if (secs < 86400)
			{
				return string.Format("{0}h {1}mn {2}secs", secs / 3600, secs % 3600 / 60, secs % 3600 % 60);
			}
			if (secs >= 31536000)
			{
				return string.Format("{0}y {1}d {2}h {3}mn {4}secs", new object[]
				{
					secs / 31536000,
					secs % 31536000 / 86400,
					secs % 31536000 % 86400 / 3600,
					secs % 31536000 % 86400 % 3600 / 60,
					secs % 31536000 % 86400 % 3600 % 60
				});
			}
			return string.Format("{0}d {1}h {2}mn {3}secs", new object[]
			{
				secs / 86400,
				secs % 86400 / 3600,
				secs % 86400 % 3600 / 60,
				secs % 86400 % 3600 % 60
			});
		}

		// Token: 0x0200004D RID: 77
		public enum OpCommandType
		{
			// Token: 0x04000147 RID: 327
			ATTACK_GENERATED_VILLAGE,
			// Token: 0x04000148 RID: 328
			ATTACK_MY_VILLAGE,
			// Token: 0x04000149 RID: 329
			UPGRADE_VILLAGE,
			// Token: 0x0400014A RID: 330
			REMOVE_OBSTACLE,
			// Token: 0x0400014B RID: 331
			UNIT_MAX,
			// Token: 0x0400014C RID: 332
			HERO_MAX,
			// Token: 0x0400014D RID: 333
			ADD_CASTLE_UNITS
		}
	}
}
