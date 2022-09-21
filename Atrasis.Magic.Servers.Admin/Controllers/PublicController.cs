using System;
using System.Net;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000028 RID: 40
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class PublicController : Controller
	{
		// Token: 0x06000113 RID: 275 RVA: 0x00004508 File Offset: 0x00002708
		[HttpGet]
		public JObject Index()
		{
			return this.BuildResponse(HttpStatusCode.OK).AddAttribute("totalUsers", DashboardManager.TotalUsers[6]).AddAttribute("dailyActiveUsers", DashboardManager.DailyActiveUsers[6]).AddAttribute("newUsers", DashboardManager.NewUsers[6]).AddAttribute("onlineUsers", ServerManager.OnlineUsers);
		}
	}
}
