using System;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Controllers;
using Atrasis.Magic.Servers.Admin.Models;
using Atrasis.Magic.Servers.Core.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCore
{
	// Token: 0x02000005 RID: 5
	[RazorSourceChecksum("SHA1", "d2fee69a2b54ced69b1783d7f23447e434819a17", "/Views/Panel/ServerEvents.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Panel_ServerEvents : RazorPage<ServerEventModel>
	{
		// Token: 0x0600002F RID: 47 RVA: 0x000036E8 File Offset: 0x000018E8
		public override async Task ExecuteAsync()
		{
			base.ViewData["Title"] = "Server Events";
			this.BeginContext(189, 880, true);
			this.WriteLiteral("\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"user-data m-b-30\">\r\n                    <h3 class=\"title-3 m-b-30\">\r\n                        <i class=\"zmdi zmdi-account-calendar\"></i>Server Events\r\n                    </h3>\r\n                    <div class=\"table-responsive table-data\">\r\n                        <table class=\"table\">\r\n                            <thead>\r\n                            <tr>\r\n                                <td></td>\r\n                                <td>Type</td>\r\n                                <td>Message</td>\r\n                                <td>Age</td>\r\n                                <td></td>\r\n                            </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
			this.EndContext();
			for (int i = 0; i < base.Model.Events.Size(); i++)
			{
				this.BeginContext(1181, 125, true);
				this.WriteLiteral("                                <tr>\r\n                                    <td></td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1307, 25, false);
				this.Write(base.Model.Events[i].Type);
				this.EndContext();
				this.BeginContext(1332, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1380, 28, false);
				this.Write(base.Model.Events[i].Message);
				this.EndContext();
				this.BeginContext(1408, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1457, 84, false);
				this.Write(UserController.GetSecondsToTime(TimeUtil.GetTimestamp() - base.Model.Events[i].Time));
				this.EndContext();
				this.BeginContext(1542, 93, true);
				this.WriteLiteral("</td>\r\n                                    <td></td>\r\n                                </tr>\r\n");
				this.EndContext();
			}
			this.BeginContext(1666, 577, true);
			this.WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"copyright\">\r\n                    <p>\r\n                        Copyright © 2019 Atrasis. All rights reserved.\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
			this.EndContext();
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000021A5 File Offset: 0x000003A5
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000021AD File Offset: 0x000003AD
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000021B6 File Offset: 0x000003B6
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000021BE File Offset: 0x000003BE
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000021C7 File Offset: 0x000003C7
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000021CF File Offset: 0x000003CF
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000021D8 File Offset: 0x000003D8
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000021E0 File Offset: 0x000003E0
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000021E9 File Offset: 0x000003E9
		// (set) Token: 0x06000039 RID: 57 RVA: 0x000021F1 File Offset: 0x000003F1
		[RazorInject]
		public IHtmlHelper<ServerEventModel> Html { get; private set; }
	}
}
