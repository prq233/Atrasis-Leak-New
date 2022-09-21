using System;
using System.Diagnostics;
using Atrasis.Magic.Servers.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000024 RID: 36
	public class HomeController : Controller
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x0000298B File Offset: 0x00000B8B
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			ErrorViewModel errorViewModel = new ErrorViewModel();
			Activity activity = Activity.Current;
			string requestId;
			if (activity != null)
			{
				if ((requestId = activity.Id) != null)
				{
					goto IL_27;
				}
			}
			requestId = base.HttpContext.TraceIdentifier;
			IL_27:
			errorViewModel.RequestId = requestId;
			return this.View(errorViewModel);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000029BE File Offset: 0x00000BBE
		public IActionResult Index()
		{
			return this.RedirectToAction("Index", "Panel");
		}
	}
}
