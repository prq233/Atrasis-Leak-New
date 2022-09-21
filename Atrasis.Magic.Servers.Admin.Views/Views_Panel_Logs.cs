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
	// Token: 0x02000004 RID: 4
	[RazorSourceChecksum("SHA1", "0d547576764405beba3727e590c6994469e68339", "/Views/Panel/Logs.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Panel_Logs : RazorPage<LogsModel>
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000036A0 File Offset: 0x000018A0
		public override async Task ExecuteAsync()
		{
			base.ViewData["Title"] = "Logs";
			this.BeginContext(173, 1020, true);
			this.WriteLiteral("\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"user-data m-b-30\">\r\n                    <h3 class=\"title-3 m-b-30\">\r\n                        <i class=\"zmdi zmdi-account-calendar\"></i>Server Logs\r\n                    </h3>\r\n                    <div class=\"table-responsive table-data\">\r\n                        <table class=\"table\">\r\n                            <thead>\r\n                                <tr>\r\n                                    <td></td>\r\n                                    <td>Type</td>\r\n                                    <td>Server Type</td>\r\n                                    <td>Server ID</td>\r\n                                    <td>Message</td>\r\n                                    <td>Age</td>\r\n                                    <td></td>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
			this.EndContext();
			for (int i = 0; i < base.Model.ServerLogs.Size(); i++)
			{
				this.BeginContext(1313, 125, true);
				this.WriteLiteral("                                <tr>\r\n                                    <td></td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1439, 40, false);
				this.Write(base.Model.ServerLogs[i].Type.ToString());
				this.EndContext();
				this.BeginContext(1479, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1527, 35, false);
				this.Write(base.Model.ServerLogs[i].ServerType);
				this.EndContext();
				this.BeginContext(1562, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1610, 33, false);
				this.Write(base.Model.ServerLogs[i].ServerId);
				this.EndContext();
				this.BeginContext(1643, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1691, 32, false);
				this.Write(base.Model.ServerLogs[i].Message);
				this.EndContext();
				this.BeginContext(1723, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(1772, 88, false);
				this.Write(UserController.GetSecondsToTime(TimeUtil.GetTimestamp() - base.Model.ServerLogs[i].Time));
				this.EndContext();
				this.BeginContext(1861, 93, true);
				this.WriteLiteral("</td>\r\n                                    <td></td>\r\n                                </tr>\r\n");
				this.EndContext();
			}
			this.BeginContext(1985, 1084, true);
			this.WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"user-data m-b-30\">\r\n                    <h3 class=\"title-3 m-b-30\">\r\n                        <i class=\"zmdi zmdi-account-calendar\"></i>Game Logs\r\n                    </h3>\r\n                    <div class=\"table-responsive table-data\">\r\n                        <table class=\"table\">\r\n                            <thead>\r\n                                <tr>\r\n                                    <td></td>\r\n                                    <td>Type</td>\r\n                                    <td>Message</td>\r\n                                    <td>Age</td>\r\n                                    <td></td>\r\n                                </tr>\r\n               ");
			this.WriteLiteral("             </thead>\r\n                            <tbody>\r\n");
			this.EndContext();
			for (int j = 0; j < base.Model.GameLogs.Size(); j++)
			{
				this.BeginContext(3195, 125, true);
				this.WriteLiteral("                                <tr>\r\n                                    <td></td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(3321, 38, false);
				this.Write(base.Model.GameLogs[j].Type.ToString());
				this.EndContext();
				this.BeginContext(3359, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(3407, 30, false);
				this.Write(base.Model.GameLogs[j].Message);
				this.EndContext();
				this.BeginContext(3437, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(3486, 86, false);
				this.Write(UserController.GetSecondsToTime(TimeUtil.GetTimestamp() - base.Model.GameLogs[j].Time));
				this.EndContext();
				this.BeginContext(3573, 93, true);
				this.WriteLiteral("</td>\r\n                                    <td></td>\r\n                                </tr>\r\n");
				this.EndContext();
			}
			this.BeginContext(3705, 547, true);
			this.WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<section class=\"p-t-20\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"copyright\">\r\n                    <p>\r\n                        Copyright © 2019 Atrasis. All rights reserved.\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
			this.EndContext();
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002148 File Offset: 0x00000348
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002150 File Offset: 0x00000350
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002159 File Offset: 0x00000359
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002161 File Offset: 0x00000361
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000216A File Offset: 0x0000036A
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002172 File Offset: 0x00000372
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002A RID: 42 RVA: 0x0000217B File Offset: 0x0000037B
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002183 File Offset: 0x00000383
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000218C File Offset: 0x0000038C
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002194 File Offset: 0x00000394
		[RazorInject]
		public IHtmlHelper<LogsModel> Html { get; private set; }
	}
}
