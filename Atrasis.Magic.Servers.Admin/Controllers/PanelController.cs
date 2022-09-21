using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Command.Debug;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Admin.Models;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000025 RID: 37
	public class PanelController : Controller
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x00003E18 File Offset: 0x00002018
		public async Task<IActionResult> Index()
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				DateTime date = DashboardManager.LastUpdate.Date;
				string[] labels = new string[]
				{
					date.AddDays(-6.0).DayOfWeek.ToString(),
					date.AddDays(-5.0).DayOfWeek.ToString(),
					date.AddDays(-4.0).DayOfWeek.ToString(),
					date.AddDays(-3.0).DayOfWeek.ToString(),
					date.AddDays(-2.0).DayOfWeek.ToString(),
					date.AddDays(-1.0).DayOfWeek.ToString(),
					date.DayOfWeek.ToString()
				};
				IndexModel indexModel = new IndexModel();
				IndexModel indexModel2 = indexModel;
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				indexModel2.User = this.GetUserData(taskAwaiter3.GetResult());
				indexModel.TotalUsers = DashboardManager.TotalUsers[6];
				indexModel.DailyActiveUsers = DashboardManager.DailyActiveUsers[6];
				indexModel.NewUsers = DashboardManager.NewUsers[6];
				indexModel.OnlineUsers = Atrasis.Magic.Servers.Admin.Logic.ServerManager.OnlineUsers;
				indexModel.TotalUsersChart = new ChartData
				{
					Datas = DashboardManager.TotalUsers,
					Labels = labels
				};
				indexModel.DailyActiveUsersChart = new ChartData
				{
					Datas = DashboardManager.DailyActiveUsers,
					Labels = labels
				};
				indexModel.NewUsersChart = new ChartData
				{
					Datas = DashboardManager.NewUsers,
					Labels = labels
				};
				indexModel.OnlineUsersChart = new ChartData
				{
					Datas = DashboardManager.MaxOnlineUsers,
					Labels = labels
				};
				indexModel.UsersByCountryChart = new ChartData
				{
					Labels = DashboardManager.UsersByCountry.Keys.ToArray<string>(),
					Datas = DashboardManager.UsersByCountry.Values.ToArray<int>()
				};
				result2 = this.View(indexModel);
			}
			return result2;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00003E60 File Offset: 0x00002060
		public async Task<IActionResult> Servers()
		{
			SessionEntry sessionEntry = await this.GetOpenSession();
			SessionEntry session = sessionEntry;
			IActionResult result;
			if (session == null)
			{
				result = this.RedirectToAction("Login");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(session.User);
				if (!userEntry.CanOpenServersPage)
				{
					result = this.RedirectToAction("Index");
				}
				else
				{
					ServerPerformance[][] servers2 = Atrasis.Magic.Servers.Admin.Logic.ServerManager.Servers;
					Dictionary<string, List<ServerPerformance>> servers = new Dictionary<string, List<ServerPerformance>>();
					for (int i = 1; i < 30; i++)
					{
						ServerPerformance[] array = servers2[i];
						for (int j = 0; j < array.Length; j++)
						{
							ServerPerformance item = array[j];
							EnvironmentSettings.ServerConnectionEntry serverConnectionEntry = EnvironmentSettings.Servers[i][j];
							List<ServerPerformance> list;
							if (!servers.TryGetValue(serverConnectionEntry.ServerIP, out list))
							{
								list = new List<ServerPerformance>();
								servers.Add(serverConnectionEntry.ServerIP, list);
							}
							list.Add(item);
						}
					}
					ServersModel serversModel = new ServersModel();
					ServersModel serversModel2 = serversModel;
					serversModel2.User = this.GetUserData(await AuthManager.GetUser(session.User));
					serversModel.Servers = servers;
					result = this.View(serversModel);
				}
			}
			return result;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00003EA8 File Offset: 0x000020A8
		[HttpPost]
		public async Task<IActionResult> SetServerSettings(PanelController.ServerSettings settings)
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					string[] supportedCountries = (settings.SupportedCountries != null) ? settings.SupportedCountries.Split('\n', StringSplitOptions.RemoveEmptyEntries) : null;
					string[] supportedAppVersions = (settings.SupportedAppVersions != null) ? settings.SupportedAppVersions.Split('\n', StringSplitOptions.RemoveEmptyEntries) : null;
					string[] developerIPs = (settings.DeveloperIPs != null) ? settings.DeveloperIPs.Split('\n', StringSplitOptions.RemoveEmptyEntries) : null;
					UpdateResourceSettingsMessage message = new UpdateResourceSettingsMessage
					{
						SupportedCountries = supportedCountries,
						SupportedAppVersions = supportedAppVersions,
						DeveloperIPs = developerIPs
					};
					for (int i = 0; i < 30; i++)
					{
						for (int j = 0; j < Atrasis.Magic.Servers.Core.Network.ServerManager.GetServerCount(i); j++)
						{
							ServerMessageManager.SendMessage(message, Atrasis.Magic.Servers.Core.Network.ServerManager.GetSocket(i, j));
						}
					}
					ResourceSettings.OnUpdateResourceSettingsMessageReceived(message);
					result2 = this.RedirectToAction("Servers");
				}
			}
			return result2;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00003EF8 File Offset: 0x000020F8
		[HttpGet]
		public async Task<IActionResult> StartMaintenance(string id)
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					int maintenanceLength = this.GetMaintenanceLength(id);
					if (maintenanceLength != -1 && (ServerStatus.Status == ServerStatusType.NORMAL || ServerStatus.Status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE))
					{
						ServerStatus.SetStatus(ServerStatusType.SHUTDOWN_STARTED, TimeUtil.GetTimestamp() + 300, LogicMath.Max(maintenanceLength, 0));
					}
					result2 = this.RedirectToAction("Servers");
				}
			}
			return result2;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00003F48 File Offset: 0x00002148
		[HttpGet]
		public async Task<IActionResult> StopMaintenance()
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					if (ServerStatus.Status == ServerStatusType.MAINTENANCE)
					{
						ServerStatus.SetStatus(ServerStatusType.COOLDOWN_AFTER_MAINTENANCE, TimeUtil.GetTimestamp() + 300, 0);
					}
					result2 = this.RedirectToAction("Servers");
				}
			}
			return result2;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00003F90 File Offset: 0x00002190
		[HttpGet]
		public async Task<IActionResult> ExtendMaintenance(string id)
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					int maintenanceLength = this.GetMaintenanceLength(id);
					if (maintenanceLength != -1 && ServerStatus.Status == ServerStatusType.MAINTENANCE)
					{
						ServerStatus.SetStatus(ServerStatusType.MAINTENANCE, TimeUtil.GetTimestamp() + maintenanceLength, 0);
					}
					result2 = this.RedirectToAction("Servers");
				}
			}
			return result2;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003FE0 File Offset: 0x000021E0
		[HttpGet]
		public async Task<IActionResult> CancelMaintenance()
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					if (ServerStatus.Status == ServerStatusType.SHUTDOWN_STARTED)
					{
						ServerStatus.SetStatus(ServerStatusType.NORMAL, 0, 0);
					}
					result2 = this.RedirectToAction("Servers");
				}
			}
			return result2;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004028 File Offset: 0x00002228
		[HttpGet]
		public async Task<IActionResult> CancelCooldownAfterMaintenance()
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					if (ServerStatus.Status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE)
					{
						ServerStatus.SetStatus(ServerStatusType.COOLDOWN_AFTER_MAINTENANCE, 0, 0);
					}
					result2 = this.RedirectToAction("Servers");
				}
			}
			return result2;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00004070 File Offset: 0x00002270
		public async Task<IActionResult> Users()
		{
			SessionEntry sessionEntry = await this.GetOpenSession();
			SessionEntry sessionEntry2 = sessionEntry;
			IActionResult result;
			if (sessionEntry2 == null)
			{
				result = this.RedirectToAction("Login");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanOpenUsersPage)
				{
					result = this.RedirectToAction("Index");
				}
				else
				{
					UsersModel usersModel = new UsersModel();
					usersModel.User = this.GetUserData(userEntry);
					usersModel.MainLeaderboard = UserManager.MainLeaderboard;
					usersModel.SecondaryLeaderboard = UserManager.SecondaryLeaderboard;
					UsersModel usersModel2 = usersModel;
					usersModel2.Users = await UserManager.Search(null, 0, 0, 0, null, null);
					usersModel.CurrentFilter = new PanelController.UserSearch();
					result = this.View(usersModel);
				}
			}
			return result;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000040B8 File Offset: 0x000022B8
		[HttpGet("{controller}/Users/{id}")]
		public async Task<IActionResult> UserProfile(long id)
		{
			SessionEntry sessionEntry = await this.GetOpenSession();
			SessionEntry sessionEntry2 = sessionEntry;
			IActionResult result;
			if (sessionEntry2 == null)
			{
				result = this.RedirectToAction("Login");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanOpenUserProfilePage)
				{
					result = this.RedirectToAction("Index");
				}
				else
				{
					Task<AccountDocument> account = UserManager.GetAccount(id);
					Task<GameDocument> avatarTask = UserManager.GetAvatar(id);
					UserModel userModel = new UserModel();
					userModel.User = this.GetUserData(userEntry);
					UserModel userModel2 = userModel;
					userModel2.Account = await account;
					UserModel userModel3 = userModel;
					userModel3.Avatar = await avatarTask;
					UserModel userModel4 = userModel;
					userModel4.Online = (await ServerAdmin.SessionDatabase.Get(id)).HasValue;
					result = this.View(userModel);
				}
			}
			return result;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00004108 File Offset: 0x00002308
		[HttpPost]
		public async Task<IActionResult> Users(PanelController.UserSearch filter)
		{
			SessionEntry sessionEntry = await this.GetOpenSession();
			SessionEntry sessionEntry2 = sessionEntry;
			IActionResult result;
			if (sessionEntry2 == null)
			{
				result = this.RedirectToAction("Login");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanOpenUsersPage)
				{
					result = this.RedirectToAction("Index");
				}
				else
				{
					UsersModel usersModel = new UsersModel();
					usersModel.User = this.GetUserData(userEntry);
					usersModel.MainLeaderboard = UserManager.MainLeaderboard;
					usersModel.SecondaryLeaderboard = UserManager.SecondaryLeaderboard;
					UsersModel usersModel2 = usersModel;
					usersModel2.Users = await UserManager.Search(filter.Name, filter.ExpLevel, filter.Score, filter.DuelScore, filter.AllianceName, filter.Status);
					usersModel.CurrentFilter = filter;
					result = this.View(usersModel);
				}
			}
			return result;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00004158 File Offset: 0x00002358
		[HttpGet("{controller}/Users/{id}/Account/ExecuteAccountCommand")]
		public async Task<IActionResult> UserAccountExecuteAccountCommand(long id, AccountCommandType commandType, int argValue)
		{
			SessionEntry sessionEntry = await this.GetOpenSession();
			SessionEntry sessionEntry2 = sessionEntry;
			IActionResult result;
			if (sessionEntry2 == null)
			{
				result = this.RedirectToAction("Login");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanExecuteAdminCommand)
				{
					result = this.RedirectToAction("Index");
				}
				else
				{
					AccountDocument accountDocument = await UserManager.GetAccount(id);
					switch (commandType)
					{
					case AccountCommandType.BAN_ACCOUNT:
						if (accountDocument.State == AccountState.NORMAL)
						{
							accountDocument.State = AccountState.BANNED;
							accountDocument.StateArg = null;
							switch (argValue)
							{
							case 0:
								accountDocument.StateArgValue = TimeUtil.GetTimestamp() + 86400;
								break;
							case 1:
								accountDocument.StateArgValue = TimeUtil.GetTimestamp() + 604800;
								break;
							case 2:
								accountDocument.StateArgValue = 0;
								break;
							}
							this.Disconnect(id);
						}
						break;
					case AccountCommandType.BAN_CHAT:
						if (accountDocument.State == AccountState.NORMAL)
						{
							if (argValue != 0)
							{
								if (argValue == 1)
								{
									accountDocument.BanChatTime = TimeUtil.GetTimestamp() + 604800;
								}
							}
							else
							{
								accountDocument.BanChatTime = TimeUtil.GetTimestamp() + 86400;
							}
							if (accountDocument.BanChatTime != -1)
							{
								TaskAwaiter<RedisValue> taskAwaiter = ServerAdmin.SessionDatabase.Get(id).GetAwaiter();
								if (!taskAwaiter.IsCompleted)
								{
									await taskAwaiter;
									TaskAwaiter<RedisValue> taskAwaiter2;
									taskAwaiter = taskAwaiter2;
									taskAwaiter2 = default(TaskAwaiter<RedisValue>);
								}
								RedisValue result2 = taskAwaiter.GetResult();
								if (result2.HasValue)
								{
									long sessionId = long.Parse(result2);
									ServerMessageManager.SendMessage(new ChatAccountBanStatusUpdatedMessage
									{
										EndTime = accountDocument.BanChatTime,
										SessionId = sessionId
									}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
								}
							}
						}
						break;
					case AccountCommandType.LOCK_ACCOUNT:
						if (accountDocument.State == AccountState.NORMAL)
						{
							char[] array = new char[12];
							for (int i = 0; i < 12; i++)
							{
								array[i] = "abcdefghijklmnopqrstuvwxyz0123456789"[ServerCore.Random.Rand("abcdefghijklmnopqrstuvwxyz0123456789".Length)];
							}
							accountDocument.State = AccountState.LOCKED;
							accountDocument.StateArg = new string(array);
							accountDocument.StateArgValue = 0;
							this.Disconnect(id);
						}
						break;
					case AccountCommandType.UNBAN_ACCOUNT:
					case AccountCommandType.UNLOCK_ACCOUNT:
						accountDocument.State = AccountState.NORMAL;
						accountDocument.StateArg = null;
						accountDocument.StateArgValue = 0;
						break;
					case AccountCommandType.UNBAN_CHAT:
						if (accountDocument.BanChatTime != -1)
						{
							accountDocument.BanChatTime = -1;
							TaskAwaiter<RedisValue> taskAwaiter3 = ServerAdmin.SessionDatabase.Get(id).GetAwaiter();
							if (!taskAwaiter3.IsCompleted)
							{
								await taskAwaiter3;
								TaskAwaiter<RedisValue> taskAwaiter2;
								taskAwaiter3 = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter<RedisValue>);
							}
							RedisValue result3 = taskAwaiter3.GetResult();
							if (result3.HasValue)
							{
								long sessionId2 = long.Parse(result3);
								ServerMessageManager.SendMessage(new ChatAccountBanStatusUpdatedMessage
								{
									EndTime = accountDocument.BanChatTime,
									SessionId = sessionId2
								}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId2));
							}
						}
						break;
					case AccountCommandType.CHANGE_RANK:
						switch (argValue)
						{
						case 0:
							accountDocument.Rank = AccountRankingType.NORMAL;
							break;
						case 1:
							accountDocument.Rank = AccountRankingType.PREMIUM;
							break;
						case 2:
							accountDocument.Rank = AccountRankingType.ADMIN;
							break;
						}
						break;
					}
					await UserManager.SaveAccount(accountDocument);
					result = this.RedirectToAction("UserProfile", new
					{
						id
					});
				}
			}
			return result;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000041B8 File Offset: 0x000023B8
		[HttpGet("{controller}/Users/{id}/Account/ExecuteAvatarCommand")]
		public async Task<IActionResult> UserAccountExecuteAvatarCommand(long id, AvatarCommandType commandType, int argValue)
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanExecuteAdminCommand)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					switch (commandType)
					{
					case AvatarCommandType.ADD_DIAMONDS:
					{
						int num;
						switch (argValue)
						{
						case 0:
							num = 1000;
							break;
						case 1:
							num = 10000;
							break;
						case 2:
							num = 100000;
							break;
						case 3:
							num = 1000000;
							break;
						case 4:
							num = 1000000;
							break;
						default:
							num = 0;
							break;
						}
						if (num > 0)
						{
							LogicDiamondsAddedCommand logicDiamondsAddedCommand = new LogicDiamondsAddedCommand();
							logicDiamondsAddedCommand.SetData(true, num, 0, false, 0, null);
							ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
							{
								AccountId = id,
								ServerCommand = logicDiamondsAddedCommand
							}, 9);
						}
						break;
					}
					case AvatarCommandType.REMOVE_DIAMONDS:
					{
						int num2;
						switch (argValue)
						{
						case 0:
							num2 = 1000;
							break;
						case 1:
							num2 = 10000;
							break;
						case 2:
							num2 = 100000;
							break;
						case 3:
							num2 = 1000000;
							break;
						case 4:
							num2 = 1000000;
							break;
						default:
							num2 = 0;
							break;
						}
						if (num2 > 0)
						{
							LogicTransactionsRevokedCommand logicTransactionsRevokedCommand = new LogicTransactionsRevokedCommand();
							logicTransactionsRevokedCommand.SetAmount(num2);
							ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
							{
								AccountId = id,
								ServerCommand = logicTransactionsRevokedCommand
							}, 9);
						}
						break;
					}
					case AvatarCommandType.RESET_NAME_CHANGE_STATE:
						ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
						{
							AccountId = id,
							ServerCommand = new LogicResetAvatarNameChangeStateCommand(0)
						}, 9);
						break;
					}
					result2 = this.RedirectToAction("UserProfile", new
					{
						id
					});
				}
			}
			return result2;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004218 File Offset: 0x00002418
		[HttpGet("{controller}/Users/{id}/Account/ExecuteDebugCommand")]
		public async Task<IActionResult> UserAccountExecuteDebugCommand(long id, LogicDebugActionType commandType)
		{
			SessionEntry sessionEntry = await this.GetOpenSession();
			SessionEntry sessionEntry2 = sessionEntry;
			IActionResult result;
			if (sessionEntry2 == null)
			{
				result = this.RedirectToAction("Login");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanExecuteDebugCommand)
				{
					result = this.RedirectToAction("Index");
				}
				else
				{
					LogicDebugCommand logicDebugCommand = null;
					switch (commandType)
					{
					case LogicDebugActionType.FAST_FORWARD_1_HOUR:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.FAST_FORWARD_1_HOUR);
						break;
					case LogicDebugActionType.FAST_FORWARD_24_HOUR:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.FAST_FORWARD_24_HOUR);
						break;
					case LogicDebugActionType.ADD_UNITS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_UNITS);
						break;
					case LogicDebugActionType.ADD_RESOURCES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_RESOURCES);
						break;
					case LogicDebugActionType.INCREASE_XP_LEVEL:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.INCREASE_XP_LEVEL);
						break;
					case LogicDebugActionType.UPGRADE_ALL_BUILDINGS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_ALL_BUILDINGS);
						break;
					case LogicDebugActionType.COMPLETE_TUTORIAL:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COMPLETE_TUTORIAL);
						break;
					case LogicDebugActionType.UNLOCK_MAP:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UNLOCK_MAP);
						break;
					case LogicDebugActionType.SHIELD_TO_HALF:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SHIELD_TO_HALF);
						break;
					case LogicDebugActionType.FAST_FORWARD_1_MIN:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.FAST_FORWARD_1_MIN);
						break;
					case LogicDebugActionType.INCREASE_TROPHIES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.INCREASE_TROPHIES);
						break;
					case LogicDebugActionType.DECREASE_TROPHIES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.DECREASE_TROPHIES);
						break;
					case LogicDebugActionType.ADD_ALLIANCE_UNITS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_ALLIANCE_UNITS);
						break;
					case LogicDebugActionType.INCREASE_HERO_LEVELS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.INCREASE_HERO_LEVELS);
						break;
					case LogicDebugActionType.REMOVE_RESOURCES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_RESOURCES);
						break;
					case LogicDebugActionType.RESET_MAP_PROGRESS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_MAP_PROGRESS);
						break;
					case LogicDebugActionType.DEPLOY_ALL_TROOPS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.DEPLOY_ALL_TROOPS);
						break;
					case LogicDebugActionType.ADD_100_TROPHIES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_100_TROPHIES);
						break;
					case LogicDebugActionType.REMOVE_100_TROPHIES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_100_TROPHIES);
						break;
					case LogicDebugActionType.UPGRADE_TO_MAX_FOR_TH:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_TO_MAX_FOR_TH);
						break;
					case LogicDebugActionType.REMOVE_UNITS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_UNITS);
						break;
					case LogicDebugActionType.DISARM_TRAPS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.DISARM_TRAPS);
						break;
					case LogicDebugActionType.REMOVE_OBSTACLES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_OBSTACLES);
						break;
					case LogicDebugActionType.RESET_HERO_LEVELS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_HERO_LEVELS);
						break;
					case LogicDebugActionType.COLLECT_WAR_RESOURCES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COLLECT_WAR_RESOURCES);
						break;
					case LogicDebugActionType.SET_RANDOM_TROPHIES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SET_RANDOM_TROPHIES);
						break;
					case LogicDebugActionType.COMPLETE_WAR_TUTORIAL:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COMPLETE_WAR_TUTORIAL);
						break;
					case LogicDebugActionType.ADD_WAR_RESOURCES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_WAR_RESOURCES);
						break;
					case LogicDebugActionType.REMOVE_WAR_RESOURCES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_WAR_RESOURCES);
						break;
					case LogicDebugActionType.RESET_WAR_TUTORIAL:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_WAR_TUTORIAL);
						break;
					case LogicDebugActionType.ADD_UNIT:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_UNIT);
						break;
					case LogicDebugActionType.SET_MAX_UNIT_SPELL_LEVELS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SET_MAX_UNIT_SPELL_LEVELS);
						break;
					case LogicDebugActionType.REMOVE_ALL_AMMO:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_ALL_AMMO);
						break;
					case LogicDebugActionType.RESET_ALL_LAYOUTS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_ALL_LAYOUTS);
						break;
					case LogicDebugActionType.LOCK_CLAN_CASTLE:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.LOCK_CLAN_CASTLE);
						break;
					case LogicDebugActionType.RANDOM_RESOURCES_TROPHY_XP:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RANDOM_RESOURCES_TROPHY_XP);
						break;
					case LogicDebugActionType.LOAD_LEVEL:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.LOAD_LEVEL);
						logicDebugCommand.SetDebugString(UserManager.GetPresetLevel());
						break;
					case LogicDebugActionType.UPGRADE_BUILDING:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_BUILDING);
						break;
					case LogicDebugActionType.UPGRADE_BUILDINGS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_BUILDINGS);
						break;
					case LogicDebugActionType.ADD_1000_CLAN_XP:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_1000_CLAN_XP);
						break;
					case LogicDebugActionType.RESET_ALL_TUTORIALS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_ALL_TUTORIALS);
						break;
					case LogicDebugActionType.ADD_1000_TROPHIES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_1000_TROPHIES);
						break;
					case LogicDebugActionType.REMOVE_1000_TROPHIES:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_1000_TROPHIES);
						break;
					case LogicDebugActionType.CAUSE_DAMAGE:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.CAUSE_DAMAGE);
						break;
					case LogicDebugActionType.SET_MAX_HERO_LEVELS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SET_MAX_HERO_LEVELS);
						break;
					case LogicDebugActionType.ADD_PRESET_TROOPS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_PRESET_TROOPS);
						break;
					case LogicDebugActionType.TOGGLE_INVULNERABILITY:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.TOGGLE_INVULNERABILITY);
						break;
					case LogicDebugActionType.ADD_GEMS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_GEMS);
						break;
					case LogicDebugActionType.PAUSE_ALL_BOOSTS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.PAUSE_ALL_BOOSTS);
						break;
					case LogicDebugActionType.TRAVEL:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.TRAVEL);
						break;
					case LogicDebugActionType.TOGGLE_RED:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.TOGGLE_RED);
						break;
					case LogicDebugActionType.COMPLETE_HOME_TUTORIALS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COMPLETE_HOME_TUTORIALS);
						break;
					case LogicDebugActionType.UNLOCK_SHIPYARD:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UNLOCK_SHIPYARD);
						break;
					case LogicDebugActionType.GIVE_REENGAGEMENT_LOOT_FOR_30_DAYS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.GIVE_REENGAGEMENT_LOOT_FOR_30_DAYS);
						break;
					case LogicDebugActionType.ADD_FREE_UNITS:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_FREE_UNITS);
						break;
					case LogicDebugActionType.RANDOM_ALLIANCE_EXP_LEVEL:
						logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RANDOM_ALLIANCE_EXP_LEVEL);
						break;
					}
					if (logicDebugCommand != null)
					{
						RedisValue value = await ServerAdmin.SessionDatabase.Get(id);
						if (value.HasValue)
						{
							long sessionId = long.Parse(value);
							AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
							availableServerCommandMessage.SetServerCommand(logicDebugCommand);
							availableServerCommandMessage.Encode();
							ServerMessageManager.SendMessage(new ForwardLogicMessage
							{
								MessageType = availableServerCommandMessage.GetMessageType(),
								MessageLength = availableServerCommandMessage.GetEncodingLength(),
								MessageVersion = (short)availableServerCommandMessage.GetMessageVersion(),
								MessageBytes = availableServerCommandMessage.GetByteStream().GetByteArray(),
								SessionId = sessionId
							}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						}
					}
					result = this.RedirectToAction("UserProfile", new
					{
						id
					});
				}
			}
			return result;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004270 File Offset: 0x00002470
		public async Task<IActionResult> Logs()
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanOpenLogsPage)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					result2 = this.View(new LogsModel
					{
						User = this.GetUserData(result3),
						ServerLogs = LogManager.ServerLogs,
						GameLogs = LogManager.GameLogs
					});
				}
			}
			return result2;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000042B8 File Offset: 0x000024B8
		public async Task<IActionResult> Login()
		{
			SessionEntry sessionEntry = await this.GetOpenSession();
			SessionEntry sessionEntry2 = sessionEntry;
			IActionResult result;
			if (sessionEntry2 != null)
			{
				result = this.RedirectToAction("Index");
			}
			else
			{
				result = this.View(new LoginModel());
			}
			return result;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004300 File Offset: 0x00002500
		public async Task<IActionResult> Logout()
		{
			string cookie = this.GetCookie("sessionKey");
			bool flag;
			if (flag = (cookie != null))
			{
				flag = await AuthManager.CloseSession(cookie);
			}
			if (flag)
			{
				this.RemoveCookie("sessionKey");
			}
			return this.RedirectToAction("Login");
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004348 File Offset: 0x00002548
		[HttpPost]
		public async Task<IActionResult> Login(PanelController.LoginRequest request)
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry != null)
			{
				result2 = this.RedirectToAction("Index");
			}
			else
			{
				TaskAwaiter<string> taskAwaiter3 = AuthManager.OpenSession(request.Name, request.Password).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				string result3 = taskAwaiter3.GetResult();
				if (result3 != null)
				{
					this.SetCookie("sessionKey", result3, 3600, true);
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					result2 = this.View(new LoginModel
					{
						LoginFailed = true
					});
				}
			}
			return result2;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00004398 File Offset: 0x00002598
		public async Task<IActionResult> ServerEvents()
		{
			TaskAwaiter<SessionEntry> taskAwaiter = this.GetOpenSession().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<SessionEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
			}
			SessionEntry result = taskAwaiter.GetResult();
			SessionEntry sessionEntry = result;
			IActionResult result2;
			if (sessionEntry == null)
			{
				result2 = this.RedirectToAction("Login");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanOpenServerEventsPage)
				{
					result2 = this.RedirectToAction("Index");
				}
				else
				{
					result2 = this.View(new ServerEventModel
					{
						User = this.GetUserData(result3),
						Events = LogManager.ServerEvents
					});
				}
			}
			return result2;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000043E0 File Offset: 0x000025E0
		private async void Disconnect(long id)
		{
			RedisValue redisValue = await ServerAdmin.SessionDatabase.Get(id);
			RedisValue value = redisValue;
			if (!value.IsNull)
			{
				long sessionId = long.Parse(value);
				ServerMessageManager.SendMessage(new StopSessionMessage
				{
					SessionId = sessionId
				}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000441C File Offset: 0x0000261C
		private async Task<SessionEntry> GetOpenSession()
		{
			string cookie = this.GetCookie("sessionKey");
			SessionEntry result;
			if (cookie == null)
			{
				result = null;
			}
			else
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(cookie);
				result = sessionEntry;
			}
			return result;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004464 File Offset: 0x00002664
		private int GetMaintenanceLength(string id)
		{
			switch (int.Parse(id))
			{
			case 0:
				return 300;
			case 1:
				return 900;
			case 2:
				return 1800;
			case 3:
				return 3600;
			case 4:
				return 7200;
			default:
				return 300;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000029D8 File Offset: 0x00000BD8
		public string GetCookie(string key)
		{
			return base.Request.Cookies[key];
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000044B8 File Offset: 0x000026B8
		public void SetCookie(string key, string value, int expireTime = 86400, bool essential = false)
		{
			CookieOptions cookieOptions = new CookieOptions();
			cookieOptions.Expires = new DateTimeOffset?(DateTime.Now.AddSeconds((double)expireTime));
			cookieOptions.IsEssential = essential;
			base.Response.Cookies.Append(key, value, cookieOptions);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000029EB File Offset: 0x00000BEB
		public void RemoveCookie(string key)
		{
			base.Response.Cookies.Delete(key);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000029FE File Offset: 0x00000BFE
		private UserData GetUserData(UserEntry user)
		{
			return new UserData
			{
				Name = user.User,
				Email = "admin@atrasis.net",
				Profile = "https://atrasis.net/app_icon.jpg"
			};
		}

		// Token: 0x0400006B RID: 107
		public const string COOKIE_SESSION_KEY = "sessionKey";

		// Token: 0x02000035 RID: 53
		public class LoginRequest
		{
			// Token: 0x1700005E RID: 94
			// (get) Token: 0x06000131 RID: 305 RVA: 0x00002AFC File Offset: 0x00000CFC
			// (set) Token: 0x06000132 RID: 306 RVA: 0x00002B04 File Offset: 0x00000D04
			public string Name { get; set; }

			// Token: 0x1700005F RID: 95
			// (get) Token: 0x06000133 RID: 307 RVA: 0x00002B0D File Offset: 0x00000D0D
			// (set) Token: 0x06000134 RID: 308 RVA: 0x00002B15 File Offset: 0x00000D15
			public string Password { get; set; }
		}

		// Token: 0x02000036 RID: 54
		public class ServerSettings
		{
			// Token: 0x17000060 RID: 96
			// (get) Token: 0x06000136 RID: 310 RVA: 0x00002B1E File Offset: 0x00000D1E
			// (set) Token: 0x06000137 RID: 311 RVA: 0x00002B26 File Offset: 0x00000D26
			public string SupportedCountries { get; set; }

			// Token: 0x17000061 RID: 97
			// (get) Token: 0x06000138 RID: 312 RVA: 0x00002B2F File Offset: 0x00000D2F
			// (set) Token: 0x06000139 RID: 313 RVA: 0x00002B37 File Offset: 0x00000D37
			public string SupportedAppVersions { get; set; }

			// Token: 0x17000062 RID: 98
			// (get) Token: 0x0600013A RID: 314 RVA: 0x00002B40 File Offset: 0x00000D40
			// (set) Token: 0x0600013B RID: 315 RVA: 0x00002B48 File Offset: 0x00000D48
			public string DeveloperIPs { get; set; }
		}

		// Token: 0x02000037 RID: 55
		public class UserSearch
		{
			// Token: 0x17000063 RID: 99
			// (get) Token: 0x0600013D RID: 317 RVA: 0x00002B51 File Offset: 0x00000D51
			// (set) Token: 0x0600013E RID: 318 RVA: 0x00002B59 File Offset: 0x00000D59
			public string Name { get; set; }

			// Token: 0x17000064 RID: 100
			// (get) Token: 0x0600013F RID: 319 RVA: 0x00002B62 File Offset: 0x00000D62
			// (set) Token: 0x06000140 RID: 320 RVA: 0x00002B6A File Offset: 0x00000D6A
			public int ExpLevel { get; set; }

			// Token: 0x17000065 RID: 101
			// (get) Token: 0x06000141 RID: 321 RVA: 0x00002B73 File Offset: 0x00000D73
			// (set) Token: 0x06000142 RID: 322 RVA: 0x00002B7B File Offset: 0x00000D7B
			public int Score { get; set; }

			// Token: 0x17000066 RID: 102
			// (get) Token: 0x06000143 RID: 323 RVA: 0x00002B84 File Offset: 0x00000D84
			// (set) Token: 0x06000144 RID: 324 RVA: 0x00002B8C File Offset: 0x00000D8C
			public int DuelScore { get; set; }

			// Token: 0x17000067 RID: 103
			// (get) Token: 0x06000145 RID: 325 RVA: 0x00002B95 File Offset: 0x00000D95
			// (set) Token: 0x06000146 RID: 326 RVA: 0x00002B9D File Offset: 0x00000D9D
			public string AllianceName { get; set; }

			// Token: 0x17000068 RID: 104
			// (get) Token: 0x06000147 RID: 327 RVA: 0x00002BA6 File Offset: 0x00000DA6
			// (set) Token: 0x06000148 RID: 328 RVA: 0x00002BAE File Offset: 0x00000DAE
			public AccountState? Status { get; set; }
		}
	}
}
