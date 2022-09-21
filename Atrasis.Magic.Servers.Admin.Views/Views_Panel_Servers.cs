using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Admin.Models;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCore
{
	// Token: 0x02000006 RID: 6
	[RazorSourceChecksum("SHA1", "a0141b56a7ce9b25f91d138ebd75343abd87238d", "/Views/Panel/Servers.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Panel_Servers : RazorPage<ServersModel>
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002202 File Offset: 0x00000402
		private TagHelperScopeManager __tagHelperScopeManager
		{
			get
			{
				if (this.__backed__tagHelperScopeManager == null)
				{
					this.__backed__tagHelperScopeManager = new TagHelperScopeManager(new Action<HtmlEncoder>(base.StartTagHelperWritingScope), new Func<TagHelperContent>(base.EndTagHelperWritingScope));
				}
				return this.__backed__tagHelperScopeManager;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003730 File Offset: 0x00001930
		public override async Task ExecuteAsync()
		{
			base.ViewData["Title"] = "Servers";
			this.BeginContext(252, 337, true);
			this.WriteLiteral("\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-header\">\r\n                        <strong>Settings</strong>\r\n                    </div>\r\n                    ");
			this.EndContext();
			this.BeginContext(589, 11760, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d11706", async delegate
			{
				this.BeginContext(650, 465, true);
				this.WriteLiteral("\r\n                        <div class=\"card-body card-block\">\r\n                                <div class=\"row form-group\">\r\n                                    <div class=\"col col-md-3\">\r\n                                        <label class=\" form-control-label\">Assets SHA</label>\r\n                                    </div>\r\n                                    <div class=\"col-12 col-md-9\">\r\n                                        <p class=\"form-control-static\">");
				this.EndContext();
				this.BeginContext(1116, 28, false);
				this.Write(ResourceSettings.ResourceSHA);
				this.EndContext();
				this.BeginContext(1144, 498, true);
				this.WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"row form-group\">\r\n                                    <div class=\"col col-md-3\">\r\n                                        <label class=\" form-control-label\">Facebook App ID</label>\r\n                                    </div>\r\n                                    <div class=\"col-12 col-md-9\">\r\n                                        <p class=\"form-control-static\">");
				this.EndContext();
				this.BeginContext(1643, 34, false);
				this.Write(ResourceSettings.Api.FacebookAppId);
				this.EndContext();
				this.BeginContext(1677, 562, true);
				this.WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            <div class=\"row form-group\">\r\n                                <div class=\"col col-md-3\">\r\n                                    <label for=\"SupportedCountries\" class=\" form-control-label\">Supported Countries</label>\r\n                                </div>\r\n                                <div class=\"col-12 col-md-9\">\r\n                                    <textarea name=\"SupportedCountries\" id=\"SupportedCountries\" rows=\"4\" class=\"form-control\">");
				this.EndContext();
				this.BeginContext(2240, 83, false);
				this.Write(string.Join('\n', ResourceSettings.Environment.SupportedCountries ?? new string[0]));
				this.EndContext();
				this.BeginContext(2323, 570, true);
				this.WriteLiteral("</textarea>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"row form-group\">\r\n                                <div class=\"col col-md-3\">\r\n                                    <label for=\"SupportedAppVersions\" class=\" form-control-label\">Supported App Versions</label>\r\n                                </div>\r\n                                <div class=\"col-12 col-md-9\">\r\n                                    <textarea name=\"SupportedAppVersions\" id=\"SupportedAppVersions\" rows=\"4\" class=\"form-control\">");
				this.EndContext();
				this.BeginContext(2894, 85, false);
				this.Write(string.Join('\n', ResourceSettings.Environment.SupportedAppVersions ?? new string[0]));
				this.EndContext();
				this.BeginContext(2979, 538, true);
				this.WriteLiteral("</textarea>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"row form-group\">\r\n                                <div class=\"col col-md-3\">\r\n                                    <label for=\"Developer IPs\" class=\" form-control-label\">Developer IPs</label>\r\n                                </div>\r\n                                <div class=\"col-12 col-md-9\">\r\n                                    <textarea name=\"DeveloperIPs\" id=\"DeveloperIPs\" rows=\"4\" class=\"form-control\">");
				this.EndContext();
				this.BeginContext(3518, 77, false);
				this.Write(string.Join('\n', ResourceSettings.Environment.DeveloperIPs ?? new string[0]));
				this.EndContext();
				this.BeginContext(3595, 89, true);
				this.WriteLiteral("</textarea>\r\n                                </div>\r\n                            </div>\r\n");
				this.EndContext();
				switch (ServerStatus.Status)
				{
				case ServerStatusType.SHUTDOWN_STARTED:
					this.BeginContext(3847, 572, true);
					this.WriteLiteral("                                    <div class=\"row form-group\">\r\n                                        <div class=\"col col-md-3\">\r\n                                            <label class=\" form-control-label\">Cooldown Before Maintenance</label>\r\n                                        </div>\r\n                                        <div class=\"col-12 col-md-9\">\r\n                                            <p class=\"form-control-static\" id=\"rem\"></p>\r\n                                            <script>\r\n                                                var time = ");
					this.EndContext();
					this.BeginContext(4421, 43, false);
					this.Write(ServerStatus.Time - TimeUtil.GetTimestamp());
					this.EndContext();
					this.BeginContext(4465, 672, true);
					this.WriteLiteral(";\r\n                                                setInterval(function () {\r\n                                                    time -= 1;\r\n                                                    if (time >= 0) {\r\n                                                        var doc = document.getElementById(\"rem\");\r\n                                                        doc.innerHTML = formatSecondsToTime(time);\r\n                                                    }\r\n                                                }, 1000);\r\n                                            </script>\r\n                                        </div>\r\n                                    </div>\r\n");
					this.EndContext();
					break;
				case ServerStatusType.MAINTENANCE:
					this.BeginContext(5249, 571, true);
					this.WriteLiteral("                                    <div class=\"row form-group\">\r\n                                        <div class=\"col col-md-3\">\r\n                                            <label class=\" form-control-label\">Remaining Maintenance Time</label>\r\n                                        </div>\r\n                                        <div class=\"col-12 col-md-9\">\r\n                                            <p class=\"form-control-static\" id=\"rem\"></p>\r\n                                            <script>\r\n                                                var time = ");
					this.EndContext();
					this.BeginContext(5822, 43, false);
					this.Write(ServerStatus.Time - TimeUtil.GetTimestamp());
					this.EndContext();
					this.BeginContext(5866, 798, true);
					this.WriteLiteral(";\r\n                                                if (time < 0)\r\n                                                    time = 0;\r\n                                                setInterval(function () {\r\n                                                    if (time >= 0) {\r\n                                                        var doc = document.getElementById(\"rem\");\r\n                                                        doc.innerHTML = formatSecondsToTime(time);\r\n                                                    }\r\n                                                    time -= 1;\r\n                                                }, 1000);\r\n                                            </script>\r\n                                        </div>\r\n                                    </div>\r\n");
					this.EndContext();
					break;
				case ServerStatusType.COOLDOWN_AFTER_MAINTENANCE:
					this.BeginContext(6791, 571, true);
					this.WriteLiteral("                                    <div class=\"row form-group\">\r\n                                        <div class=\"col col-md-3\">\r\n                                            <label class=\" form-control-label\">Cooldown After Maintenance</label>\r\n                                        </div>\r\n                                        <div class=\"col-12 col-md-9\">\r\n                                            <p class=\"form-control-static\" id=\"rem\"></p>\r\n                                            <script>\r\n                                                var time = ");
					this.EndContext();
					this.BeginContext(7364, 43, false);
					this.Write(ServerStatus.Time - TimeUtil.GetTimestamp());
					this.EndContext();
					this.BeginContext(7408, 798, true);
					this.WriteLiteral(";\r\n                                                if (time < 0)\r\n                                                    time = 0;\r\n                                                setInterval(function () {\r\n                                                    if (time >= 0) {\r\n                                                        var doc = document.getElementById(\"rem\");\r\n                                                        doc.innerHTML = formatSecondsToTime(time);\r\n                                                    }\r\n                                                    time -= 1;\r\n                                                }, 1000);\r\n                                            </script>\r\n                                        </div>\r\n                                    </div>\r\n");
					this.EndContext();
					break;
				}
				this.BeginContext(8281, 463, true);
				this.WriteLiteral("                        </div>\r\n                        <div class=\"card-footer\">\r\n                            <button type=\"submit\" class=\"btn btn-primary btn-sm\">\r\n                                <i class=\"fa fa-dot-circle-o\"></i> Save\r\n                            </button>\r\n                            <button type=\"reset\" class=\"btn btn-danger btn-sm\">\r\n                                <i class=\"fa fa-ban\"></i> Reset\r\n                            </button>\r\n");
				this.EndContext();
				switch (ServerStatus.Status)
				{
				case ServerStatusType.NORMAL:
				{
					this.BeginContext(8897, 418, true);
					this.WriteLiteral("                                    <button type=\"button\" class=\"dropdown-toggle btn btn-warning btn-sm\" data-toggle=\"dropdown\">\r\n                                        <i class=\"fa fa-stopwatch\"></i> Start Maintenance\r\n                                    </button>\r\n                                    <div tabindex=\"-1\" aria-hidden=\"true\" role=\"menu\" class=\"dropdown-menu\">\r\n                                        ");
					this.EndContext();
					this.BeginContext(9315, 94, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d25613", async delegate
					{
						this.BeginContext(9400, 5, true);
						this.WriteLiteral("5 min");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_0);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_3.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_3);
					TaskAwaiter taskAwaiter4 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
					if (!taskAwaiter4.IsCompleted)
					{
						await taskAwaiter4;
						TaskAwaiter taskAwaiter5;
						taskAwaiter4 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter);
					}
					taskAwaiter4.GetResult();
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(9409, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(9451, 95, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d27822", async delegate
					{
						this.BeginContext(9536, 6, true);
						this.WriteLiteral("15 min");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_4);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_5.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_5);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(9546, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(9588, 95, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d30032", async delegate
					{
						this.BeginContext(9673, 6, true);
						this.WriteLiteral("30 min");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_6);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_7.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_7);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(9683, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(9725, 95, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d32242", async delegate
					{
						this.BeginContext(9810, 6, true);
						this.WriteLiteral("1 hour");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_8);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_9.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_9);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(9820, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(9862, 96, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d34452", async delegate
					{
						this.BeginContext(9947, 7, true);
						this.WriteLiteral("2 hours");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_10);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_11.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_11);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(9958, 46, true);
					this.WriteLiteral("\r\n                                    </div>\r\n");
					this.EndContext();
					break;
				}
				case ServerStatusType.SHUTDOWN_STARTED:
				{
					this.BeginContext(10121, 36, true);
					this.WriteLiteral("                                    ");
					this.EndContext();
					this.BeginContext(10157, 199, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d37085", async delegate
					{
						this.BeginContext(10222, 130, true);
						this.WriteLiteral("\r\n                                        <i class=\"fa fa-power-off\"></i> Cancel Maintenance\r\n                                    ");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_12);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_13.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_13);
					TaskAwaiter taskAwaiter6 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
					if (!taskAwaiter6.IsCompleted)
					{
						await taskAwaiter6;
						TaskAwaiter taskAwaiter5;
						taskAwaiter6 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter);
					}
					taskAwaiter6.GetResult();
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(10356, 2, true);
					this.WriteLiteral("\r\n");
					this.EndContext();
					break;
				}
				case ServerStatusType.MAINTENANCE:
				{
					this.BeginContext(10470, 419, true);
					this.WriteLiteral("                                    <button type=\"button\" class=\"dropdown-toggle btn btn-warning btn-sm\" data-toggle=\"dropdown\">\r\n                                        <i class=\"fa fa-stopwatch\"></i> Extend Maintenance\r\n                                    </button>\r\n                                    <div tabindex=\"-1\" aria-hidden=\"true\" role=\"menu\" class=\"dropdown-menu\">\r\n                                        ");
					this.EndContext();
					this.BeginContext(10889, 95, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d39578", async delegate
					{
						this.BeginContext(10975, 5, true);
						this.WriteLiteral("5 min");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_0);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_14.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_14);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_3.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_3);
					TaskAwaiter taskAwaiter7 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
					if (!taskAwaiter7.IsCompleted)
					{
						await taskAwaiter7;
						TaskAwaiter taskAwaiter5;
						taskAwaiter7 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter);
					}
					taskAwaiter7.GetResult();
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(10984, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(11026, 96, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d41792", async delegate
					{
						this.BeginContext(11112, 6, true);
						this.WriteLiteral("15 min");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_4);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_14.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_14);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_5.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_5);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11122, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(11164, 96, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d44007", async delegate
					{
						this.BeginContext(11250, 6, true);
						this.WriteLiteral("30 min");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_6);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_14.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_14);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_7.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_7);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11260, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(11302, 96, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d46222", async delegate
					{
						this.BeginContext(11388, 6, true);
						this.WriteLiteral("1 hour");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_8);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_14.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_14);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_9.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_9);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11398, 42, true);
					this.WriteLiteral("\r\n                                        ");
					this.EndContext();
					this.BeginContext(11440, 97, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d48437", async delegate
					{
						this.BeginContext(11526, 7, true);
						this.WriteLiteral("2 hours");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_10);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_14.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_14);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)Views_Panel_Servers.__tagHelperAttribute_11.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_11);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11537, 82, true);
					this.WriteLiteral("\r\n                                    </div>\r\n                                    ");
					this.EndContext();
					this.BeginContext(11619, 206, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d50699", async delegate
					{
						this.BeginContext(11693, 128, true);
						this.WriteLiteral("\r\n                                        <i class=\"fa fa-power-off\"></i> Stop Maintenance\r\n                                    ");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_15);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_16);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_17.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_17);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11825, 2, true);
					this.WriteLiteral("\r\n");
					this.EndContext();
					break;
				}
				case ServerStatusType.COOLDOWN_AFTER_MAINTENANCE:
				{
					this.BeginContext(11954, 36, true);
					this.WriteLiteral("                                    ");
					this.EndContext();
					this.BeginContext(11990, 223, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "a0141b56a7ce9b25f91d138ebd75343abd87238d52893", async delegate
					{
						this.BeginContext(12069, 140, true);
						this.WriteLiteral("\r\n                                        <i class=\"fa fa-play\"></i> Cancel Cooldown after Maintenance\r\n                                    ");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_12);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_18.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_18);
					TaskAwaiter taskAwaiter8 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
					if (!taskAwaiter8.IsCompleted)
					{
						await taskAwaiter8;
						TaskAwaiter taskAwaiter5;
						taskAwaiter8 = taskAwaiter5;
						taskAwaiter5 = default(TaskAwaiter);
					}
					taskAwaiter8.GetResult();
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(12213, 2, true);
					this.WriteLiteral("\r\n");
					this.EndContext();
					break;
				}
				}
				this.BeginContext(12290, 52, true);
				this.WriteLiteral("                        </div>\r\n                    ");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = base.CreateTagHelper<FormTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = base.CreateTagHelper<RenderAtEndOfFormTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)Views_Panel_Servers.__tagHelperAttribute_19.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Servers.__tagHelperAttribute_19);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Servers.__tagHelperAttribute_20);
			TaskAwaiter taskAwaiter = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
			TaskAwaiter taskAwaiter2;
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				TaskAwaiter taskAwaiter3 = this.__tagHelperExecutionContext.SetOutputContentAsync().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(12349, 84, true);
			this.WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
			this.EndContext();
			foreach (KeyValuePair<string, List<ServerPerformance>> keyValuePair in base.Model.Servers)
			{
				this.BeginContext(12521, 170, true);
				this.WriteLiteral("<section class=\"p-t-20\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <h3 class=\"title-5 m-b-35\">Server: ");
				this.EndContext();
				this.BeginContext(12692, 8, false);
				this.Write(keyValuePair.Key);
				this.EndContext();
				this.BeginContext(12700, 590, true);
				this.WriteLiteral("</h3>\r\n                <div class=\"table-responsive table-responsive-data2\">\r\n                    <table class=\"table table-data2\">\r\n                        <thead>\r\n                            <tr>\r\n                                <th>Type</th>\r\n                                <th>Id</th>\r\n                                <th>Avg Ping</th>\r\n                                <th>Status</th>\r\n                                <th>Sessions</th>\r\n                                <th></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n\r\n");
				this.EndContext();
				foreach (ServerPerformance serverPerformance in keyValuePair.Value)
				{
					this.BeginContext(13411, 70, true);
					this.WriteLiteral("                            <tr>\r\n                                <td>");
					this.EndContext();
					this.BeginContext(13482, 61, false);
					this.Write(ServerUtil.GetServerName(serverPerformance.Socket.ServerType));
					this.EndContext();
					this.BeginContext(13543, 43, true);
					this.WriteLiteral("</td>\r\n                                <td>");
					this.EndContext();
					this.BeginContext(13587, 33, false);
					this.Write(serverPerformance.Socket.ServerId);
					this.EndContext();
					this.BeginContext(13620, 43, true);
					this.WriteLiteral("</td>\r\n                                <td>");
					this.EndContext();
					this.BeginContext(13664, 22, false);
					this.Write(serverPerformance.Ping);
					this.EndContext();
					this.BeginContext(13686, 45, true);
					this.WriteLiteral("</td>\r\n                                <td>\r\n");
					this.EndContext();
					ServerPerformanceStatus status = serverPerformance.Status;
					if (status > ServerPerformanceStatus.OFFLINE)
					{
						if (status == ServerPerformanceStatus.ONLINE)
						{
							this.BeginContext(13928, 66, true);
							this.WriteLiteral("                                    <span class=\"status--process\">");
							this.EndContext();
							this.BeginContext(13995, 24, false);
							this.Write(serverPerformance.Status);
							this.EndContext();
							this.BeginContext(14019, 9, true);
							this.WriteLiteral("</span>\r\n");
							this.EndContext();
						}
					}
					else
					{
						this.BeginContext(14250, 65, true);
						this.WriteLiteral("                                    <span class=\"status--denied\">");
						this.EndContext();
						this.BeginContext(14316, 24, false);
						this.Write(serverPerformance.Status);
						this.EndContext();
						this.BeginContext(14340, 9, true);
						this.WriteLiteral("</span>\r\n");
						this.EndContext();
					}
					this.BeginContext(14448, 75, true);
					this.WriteLiteral("                                </td>\r\n                                <td>");
					this.EndContext();
					this.BeginContext(14524, 30, false);
					this.Write(serverPerformance.SessionCount);
					this.EndContext();
					this.BeginContext(14554, 96, true);
					this.WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr class=\"spacer\"></tr>\r\n");
					this.EndContext();
				}
				this.BeginContext(14681, 148, true);
				this.WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
				this.EndContext();
			}
			this.BeginContext(14832, 367, true);
			this.WriteLiteral("\r\n<section class=\"p-t-20\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"copyright\">\r\n                    <p>\r\n                        Copyright © 2019 Atrasis. All rights reserved.\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
			this.EndContext();
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002235 File Offset: 0x00000435
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000223D File Offset: 0x0000043D
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002246 File Offset: 0x00000446
		// (set) Token: 0x06000040 RID: 64 RVA: 0x0000224E File Offset: 0x0000044E
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002257 File Offset: 0x00000457
		// (set) Token: 0x06000042 RID: 66 RVA: 0x0000225F File Offset: 0x0000045F
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002268 File Offset: 0x00000468
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002270 File Offset: 0x00000470
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002279 File Offset: 0x00000479
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002281 File Offset: 0x00000481
		[RazorInject]
		public IHtmlHelper<ServersModel> Html { get; private set; }

		// Token: 0x0400003E RID: 62
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("tabindex", new HtmlString("0"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400003F RID: 63
		private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("class", new HtmlString("dropdown-item"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000040 RID: 64
		private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-action", "StartMaintenance", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000041 RID: 65
		private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("asp-route-id", "0", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000042 RID: 66
		private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("tabindex", new HtmlString("1"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000043 RID: 67
		private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("asp-route-id", "1", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000044 RID: 68
		private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("tabindex", new HtmlString("2"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000045 RID: 69
		private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("asp-route-id", "2", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000046 RID: 70
		private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("tabindex", new HtmlString("3"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000047 RID: 71
		private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("asp-route-id", "3", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000048 RID: 72
		private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("tabindex", new HtmlString("4"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000049 RID: 73
		private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("asp-route-id", "4", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400004A RID: 74
		private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("class", new HtmlString("btn btn-warning btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400004B RID: 75
		private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("asp-action", "CancelMaintenance", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400004C RID: 76
		private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("asp-action", "ExtendMaintenance", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400004D RID: 77
		private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("type", new HtmlString("button"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400004E RID: 78
		private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("class", new HtmlString("btn btn-dark btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400004F RID: 79
		private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("asp-action", "StopMaintenance", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000050 RID: 80
		private static readonly TagHelperAttribute __tagHelperAttribute_18 = new TagHelperAttribute("asp-action", "CancelCooldownAfterMaintenance", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000051 RID: 81
		private static readonly TagHelperAttribute __tagHelperAttribute_19 = new TagHelperAttribute("asp-action", "SetServerSettings", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000052 RID: 82
		private static readonly TagHelperAttribute __tagHelperAttribute_20 = new TagHelperAttribute("class", new HtmlString("form-horizontal"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000053 RID: 83
		private string __tagHelperStringValueBuffer;

		// Token: 0x04000054 RID: 84
		private TagHelperExecutionContext __tagHelperExecutionContext;

		// Token: 0x04000055 RID: 85
		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		// Token: 0x04000056 RID: 86
		private TagHelperScopeManager __backed__tagHelperScopeManager;

		// Token: 0x04000057 RID: 87
		private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;

		// Token: 0x04000058 RID: 88
		private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;

		// Token: 0x04000059 RID: 89
		private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
	}
}
