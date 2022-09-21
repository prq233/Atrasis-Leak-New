using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Command.Debug;
using Atrasis.Magic.Servers.Admin.Controllers;
using Atrasis.Magic.Servers.Admin.Models;
using Atrasis.Magic.Servers.Core.Database.Document;
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
	// Token: 0x02000007 RID: 7
	[RazorSourceChecksum("SHA1", "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4", "/Views/Panel/UserProfile.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Panel_UserProfile : RazorPage<UserModel>
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000057 RID: 87 RVA: 0x0000229D File Offset: 0x0000049D
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

		// Token: 0x06000058 RID: 88 RVA: 0x00003D60 File Offset: 0x00001F60
		public override async Task ExecuteAsync()
		{
			base.ViewData["Title"] = "Profile";
			this.BeginContext(271, 723, true);
			this.WriteLiteral("\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-header\">\r\n                        <strong>Account</strong> Data\r\n                    </div>\r\n                    <div class=\"card-body card-block\">\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Id</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(996, 80, false);
			this.Write(base.Model.Account.Id.GetHigherInt() + "-" + base.Model.Account.Id.GetLowerInt());
			this.EndContext();
			this.BeginContext(1077, 427, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Password</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(1505, 28, false);
			this.Write(base.Model.Account.PassToken);
			this.EndContext();
			this.BeginContext(1533, 379, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label for=\"text-input\" class=\" form-control-label\">Status</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n");
			this.EndContext();
			AccountState state = base.Model.Account.State;
			if (state != AccountState.NORMAL)
			{
				if (state - AccountState.LOCKED <= 1)
				{
					this.BeginContext(2352, 65, true);
					this.WriteLiteral("                                        <span class=\"role admin\">");
					this.EndContext();
					this.BeginContext(2418, 24, false);
					this.Write(base.Model.Account.State);
					this.EndContext();
					this.BeginContext(2442, 9, true);
					this.WriteLiteral("</span>\r\n");
					this.EndContext();
				}
			}
			else
			{
				this.BeginContext(2078, 66, true);
				this.WriteLiteral("                                        <span class=\"role member\">");
				this.EndContext();
				this.BeginContext(2145, 24, false);
				this.Write(base.Model.Account.State);
				this.EndContext();
				this.BeginContext(2169, 9, true);
				this.WriteLiteral("</span>\r\n");
				this.EndContext();
			}
			this.BeginContext(2534, 68, true);
			this.WriteLiteral("                            </div>\r\n                        </div>\r\n");
			this.EndContext();
			if (base.Model.Account.State == AccountState.LOCKED)
			{
				this.BeginContext(2708, 397, true);
				this.WriteLiteral("                            <div class=\"row form-group\">\r\n                                <div class=\"col col-md-3\">\r\n                                    <label for=\"text-input\" class=\" form-control-label\">Unlock Code</label>\r\n                                </div>\r\n                                <div class=\"col-12 col-md-9\">\r\n                                    <p class=\"form-control-static\">");
				this.EndContext();
				this.BeginContext(3106, 27, false);
				this.Write(base.Model.Account.StateArg);
				this.EndContext();
				this.BeginContext(3133, 82, true);
				this.WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n");
				this.EndContext();
			}
			this.BeginContext(3242, 24, true);
			this.WriteLiteral("                        ");
			this.EndContext();
			if (base.Model.Account.State == AccountState.BANNED && base.Model.Account.StateArgValue != 0)
			{
				this.BeginContext(3389, 564, true);
				this.WriteLiteral("                            <div class=\"row form-group\">\r\n                                <div class=\"col col-md-3\">\r\n                                    <label for=\"text-input\" class=\" form-control-label\">Remaining Ban Time</label>\r\n                                </div>\r\n                                <div class=\"col-12 col-md-9\">\r\n                                    <p class=\"form-control-static\" id=\"remBan\"></p>\r\n                                    <script>\r\n                                        var time =\r\n                                            ");
				this.EndContext();
				this.BeginContext(3955, 58, false);
				this.Write(base.Model.Account.StateArgValue - TimeUtil.GetTimestamp());
				this.EndContext();
				this.BeginContext(4014, 773, true);
				this.WriteLiteral(";\r\n                                        if (time < 0)\r\n                                            time = 0;\r\n                                        setInterval(function() {\r\n                                                if (time >= 0) {\r\n                                                    var doc = document.getElementById(\"remBan\");\r\n                                                    doc.innerHTML = formatSecondsToTime(time);\r\n                                                }\r\n                                                time -= 1;\r\n                                            },\r\n                                            1000);\r\n                                    </script>\r\n                                </div>\r\n                            </div>\r\n");
				this.EndContext();
			}
			this.BeginContext(4814, 361, true);
			this.WriteLiteral("                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label for=\"text-input\" class=\" form-control-label\">Rank</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <span class=\"role member\">");
			this.EndContext();
			this.BeginContext(5176, 23, false);
			this.Write(base.Model.Account.Rank);
			this.EndContext();
			this.BeginContext(5199, 446, true);
			this.WriteLiteral("</span>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label for=\"text-input\" class=\" form-control-label\">Country</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(5646, 26, false);
			this.Write(base.Model.Account.Country);
			this.EndContext();
			this.BeginContext(5672, 448, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label for=\"text-input\" class=\" form-control-label\">Created Date</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(6121, 78, false);
			this.Write(TimeUtil.GetDateTimeFromTimestamp(base.Model.Account.CreateTime).ToString("F"));
			this.EndContext();
			this.BeginContext(6199, 448, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label for=\"text-input\" class=\" form-control-label\">Last Session</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(6648, 83, false);
			this.Write(TimeUtil.GetDateTimeFromTimestamp(base.Model.Account.LastSessionTime).ToString("F"));
			this.EndContext();
			this.BeginContext(6731, 453, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label for=\"text-input\" class=\" form-control-label\">Total Played Time</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(7185, 67, false);
			this.Write(UserController.GetSecondsToTime(base.Model.Account.PlayTimeSeconds));
			this.EndContext();
			this.BeginContext(7252, 74, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
			this.EndContext();
			if (base.Model.Account.BanChatTime != 0 && base.Model.Account.BanChatTime > TimeUtil.GetTimestamp())
			{
				this.BeginContext(7480, 565, true);
				this.WriteLiteral("                            <div class=\"row form-group\">\r\n                                <div class=\"col col-md-3\">\r\n                                    <label for=\"text-input\" class=\" form-control-label\">Remaining Chat Ban</label>\r\n                                </div>\r\n                                <div class=\"col-12 col-md-9\">\r\n                                    <p class=\"form-control-static\" id=\"remCBan\"></p>\r\n                                    <script>\r\n                                        var time =\r\n                                            ");
				this.EndContext();
				this.BeginContext(8047, 56, false);
				this.Write(base.Model.Account.BanChatTime - TimeUtil.GetTimestamp());
				this.EndContext();
				this.BeginContext(8104, 774, true);
				this.WriteLiteral(";\r\n                                        if (time < 0)\r\n                                            time = 0;\r\n                                        setInterval(function() {\r\n                                                if (time >= 0) {\r\n                                                    var doc = document.getElementById(\"remCBan\");\r\n                                                    doc.innerHTML = formatSecondsToTime(time);\r\n                                                }\r\n                                                time -= 1;\r\n                                            },\r\n                                            1000);\r\n                                    </script>\r\n                                </div>\r\n                            </div>\r\n");
				this.EndContext();
			}
			this.BeginContext(8905, 75, true);
			this.WriteLiteral("                    </div>\r\n                    <div class=\"card-footer\">\r\n");
			this.EndContext();
			if (base.Model.Account.State == AccountState.NORMAL)
			{
				this.BeginContext(9086, 413, true);
				this.WriteLiteral("                            <div class=\"btn-group\">\r\n                                <button type=\"button\" class=\"dropdown-toggle btn btn-primary btn-sm\" data-toggle=\"dropdown\">\r\n                                    Ban Account\r\n                                </button>\r\n                                <div tabindex=\"-1\" aria-hidden=\"true\" role=\"menu\" class=\"dropdown-menu\">\r\n                                    ");
				this.EndContext();
				this.BeginContext(9499, 216, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a427231", async delegate
				{
					this.BeginContext(9709, 2, true);
					this.WriteLiteral("1d");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_0);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(AccountCommandType.BAN_ACCOUNT);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_3.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_3);
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
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9715, 38, true);
				this.WriteLiteral("\r\n                                    ");
				this.EndContext();
				this.BeginContext(9753, 216, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a431285", async delegate
				{
					this.BeginContext(9963, 2, true);
					this.WriteLiteral("7d");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_4);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(AccountCommandType.BAN_ACCOUNT);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_5.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_5);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9969, 38, true);
				this.WriteLiteral("\r\n                                    ");
				this.EndContext();
				this.BeginContext(10007, 225, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a435340", async delegate
				{
					this.BeginContext(10217, 11, true);
					this.WriteLiteral("Permanently");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_4);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(AccountCommandType.BAN_ACCOUNT);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_6.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_6);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(10232, 78, true);
				this.WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
				this.EndContext();
				if (base.Model.Account.BanChatTime == -1)
				{
					this.BeginContext(10414, 442, true);
					this.WriteLiteral("                                 <div class=\"btn-group\">\r\n                                     <button type=\"button\" class=\"dropdown-toggle btn btn-secondary btn-sm\" data-toggle=\"dropdown\">\r\n                                         Ban Chat\r\n                                     </button>\r\n                                     <div tabindex=\"-1\" aria-hidden=\"true\" role=\"menu\" class=\"dropdown-menu\">\r\n                                         ");
					this.EndContext();
					this.BeginContext(10856, 213, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a440265", async delegate
					{
						this.BeginContext(11063, 2, true);
						this.WriteLiteral("1d");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_0);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					base.BeginWriteTagHelperAttribute();
					this.WriteLiteral(base.Model.Account.Id);
					this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
					this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
					base.BeginWriteTagHelperAttribute();
					this.WriteLiteral(AccountCommandType.BAN_CHAT);
					this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
					this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_3.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_3);
					TaskAwaiter taskAwaiter3 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11069, 43, true);
					this.WriteLiteral("\r\n                                         ");
					this.EndContext();
					this.BeginContext(11112, 213, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a444334", async delegate
					{
						this.BeginContext(11319, 2, true);
						this.WriteLiteral("7d");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_4);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					base.BeginWriteTagHelperAttribute();
					this.WriteLiteral(base.Model.Account.Id);
					this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
					this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
					base.BeginWriteTagHelperAttribute();
					this.WriteLiteral(AccountCommandType.BAN_CHAT);
					this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
					this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_5.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_5);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11325, 88, true);
					this.WriteLiteral("\r\n                                     </div>\r\n                                 </div>\r\n");
					this.EndContext();
				}
				else
				{
					this.BeginContext(11512, 20, true);
					this.WriteLiteral("                    ");
					this.EndContext();
					this.BeginContext(11532, 246, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a448821", async delegate
					{
						this.BeginContext(11716, 58, true);
						this.WriteLiteral("\r\n                        Unban Chat\r\n                    ");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_7);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
					if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
					{
						throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
					}
					base.BeginWriteTagHelperAttribute();
					this.WriteLiteral(base.Model.Account.Id);
					this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
					this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
					base.BeginWriteTagHelperAttribute();
					this.WriteLiteral(AccountCommandType.UNBAN_CHAT);
					this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
					this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
					TaskAwaiter taskAwaiter4 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
					if (!taskAwaiter4.IsCompleted)
					{
						await taskAwaiter4;
						taskAwaiter4 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter4.GetResult();
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(11778, 2, true);
					this.WriteLiteral("\r\n");
					this.EndContext();
				}
				this.BeginContext(11814, 28, true);
				this.WriteLiteral("                            ");
				this.EndContext();
				this.BeginContext(11842, 264, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a452570", async delegate
				{
					this.BeginContext(12026, 76, true);
					this.WriteLiteral("\r\n                                Lock Account\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_8);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(AccountCommandType.LOCK_ACCOUNT);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(12106, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			}
			else if (base.Model.Account.State == AccountState.BANNED)
			{
				this.BeginContext(12245, 28, true);
				this.WriteLiteral("                            ");
				this.EndContext();
				this.BeginContext(12273, 265, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a456456", async delegate
				{
					this.BeginContext(12457, 77, true);
					this.WriteLiteral("\r\n                                Unban Account\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_9);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(AccountCommandType.UNBAN_ACCOUNT);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				TaskAwaiter taskAwaiter5 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter2;
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(12538, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			}
			else
			{
				this.BeginContext(12624, 28, true);
				this.WriteLiteral("                            ");
				this.EndContext();
				this.BeginContext(12652, 267, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a460289", async delegate
				{
					this.BeginContext(12837, 78, true);
					this.WriteLiteral("\r\n                                Unlock Account\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_9);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(AccountCommandType.UNLOCK_ACCOUNT);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				TaskAwaiter taskAwaiter6 = this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext).GetAwaiter();
				if (!taskAwaiter6.IsCompleted)
				{
					await taskAwaiter6;
					TaskAwaiter taskAwaiter2;
					taskAwaiter6 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter6.GetResult();
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(12919, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			}
			this.BeginContext(12948, 391, true);
			this.WriteLiteral("\r\n                        <div class=\"btn-group\">\r\n                            <button type=\"button\" class=\"dropdown-toggle btn btn-warning btn-sm\" data-toggle=\"dropdown\">\r\n                                Change Rank\r\n                            </button>\r\n                            <div tabindex=\"-1\" aria-hidden=\"true\" role=\"menu\" class=\"dropdown-menu\">\r\n                                ");
			this.EndContext();
			this.BeginContext(13339, 220, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a464448", async delegate
			{
				this.BeginContext(13549, 6, true);
				this.WriteLiteral("Normal");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_0);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AccountCommandType.CHANGE_RANK);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_3.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_3);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(13559, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(13593, 221, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a468497", async delegate
			{
				this.BeginContext(13803, 7, true);
				this.WriteLiteral("Premium");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_4);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AccountCommandType.CHANGE_RANK);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_5.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_5);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(13814, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(13848, 219, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a472547", async delegate
			{
				this.BeginContext(14058, 5, true);
				this.WriteLiteral("Admin");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_10);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_2.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_2);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AccountCommandType.CHANGE_RANK);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_6.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_6);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(14067, 748, true);
			this.WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-header\">\r\n                        <strong>Avatar</strong> Data\r\n                    </div>\r\n                    <div class=\"card-body card-block\">\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Name</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(14816, 45, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.GetName());
			this.EndContext();
			this.BeginContext(14861, 439, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Name Already Changed</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(15302, 61, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.GetNameChangeState() >= 1);
			this.EndContext();
			this.BeginContext(15364, 427, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">XP Level</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(15792, 49, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.GetExpLevel());
			this.EndContext();
			this.BeginContext(15841, 427, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Diamonds</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(16269, 68, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.GetDiamonds().ToString("##,###"));
			this.EndContext();
			this.BeginContext(16337, 432, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Free Diamonds</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(16770, 72, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.GetFreeDiamonds().ToString("##,###"));
			this.EndContext();
			this.BeginContext(16842, 424, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Score</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(17267, 65, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.GetScore().ToString("##,###"));
			this.EndContext();
			this.BeginContext(17332, 429, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Duel Score</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(17762, 69, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.GetDuelScore().ToString("##,###"));
			this.EndContext();
			this.BeginContext(17831, 427, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row form-group\">\r\n                            <div class=\"col col-md-3\">\r\n                                <label class=\" form-control-label\">Alliance</label>\r\n                            </div>\r\n                            <div class=\"col-12 col-md-9\">\r\n                                <p class=\"form-control-static\">");
			this.EndContext();
			this.BeginContext(18260, 122, false);
			this.Write(base.Model.Avatar.LogicClientAvatar.IsInAlliance() ? base.Model.Avatar.LogicClientAvatar.GetAllianceName() : "No Alliance");
			this.EndContext();
			this.BeginContext(18383, 173, true);
			this.WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer\">\r\n                        ");
			this.EndContext();
			this.BeginContext(18556, 276, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a484277", async delegate
			{
				this.BeginContext(18749, 79, true);
				this.WriteLiteral("\r\n                            Reset Name Change State\r\n                        ");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_8);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.RESET_NAME_CHANGE_STATE);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(18832, 392, true);
			this.WriteLiteral("\r\n                        <div class=\"btn-group\">\r\n                            <button type=\"button\" class=\"dropdown-toggle btn btn-primary btn-sm\" data-toggle=\"dropdown\">\r\n                                Add Diamonds\r\n                            </button>\r\n                            <div tabindex=\"-1\" aria-hidden=\"true\" role=\"menu\" class=\"dropdown-menu\">\r\n                                ");
			this.EndContext();
			this.BeginContext(19224, 217, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a488160", async delegate
			{
				this.BeginContext(19433, 4, true);
				this.WriteLiteral("1000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_0);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.ADD_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_3.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_3);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(19441, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(19475, 218, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a492207", async delegate
			{
				this.BeginContext(19684, 5, true);
				this.WriteLiteral("10000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_4);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.ADD_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_5.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_5);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(19693, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(19727, 219, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a496255", async delegate
			{
				this.BeginContext(19936, 6, true);
				this.WriteLiteral("100000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_10);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.ADD_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_6.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_6);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(19946, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(19980, 220, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4100305", async delegate
			{
				this.BeginContext(20189, 7, true);
				this.WriteLiteral("1000000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_12);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.ADD_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_13.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_13);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(20200, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(20234, 221, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4104359", async delegate
			{
				this.BeginContext(20443, 8, true);
				this.WriteLiteral("10000000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_14);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.ADD_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_15.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_15);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(20455, 465, true);
			this.WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"btn-group\">\r\n                            <button type=\"button\" class=\"dropdown-toggle btn btn-secondary btn-sm\" data-toggle=\"dropdown\">\r\n                                Remove Diamonds\r\n                            </button>\r\n                            <div tabindex=\"-1\" aria-hidden=\"true\" role=\"menu\" class=\"dropdown-menu\">\r\n                                ");
			this.EndContext();
			this.BeginContext(20920, 220, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4108861", async delegate
			{
				this.BeginContext(21132, 4, true);
				this.WriteLiteral("1000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_0);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.REMOVE_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_3.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_3);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(21140, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(21174, 221, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4112912", async delegate
			{
				this.BeginContext(21386, 5, true);
				this.WriteLiteral("10000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_4);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.REMOVE_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_5.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_5);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(21395, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(21429, 222, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4116964", async delegate
			{
				this.BeginContext(21641, 6, true);
				this.WriteLiteral("100000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_10);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.REMOVE_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_6.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_6);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(21651, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(21685, 223, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4121018", async delegate
			{
				this.BeginContext(21897, 7, true);
				this.WriteLiteral("1000000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_12);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.REMOVE_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_13.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_13);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(21908, 34, true);
			this.WriteLiteral("\r\n                                ");
			this.EndContext();
			this.BeginContext(21942, 224, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4125075", async delegate
			{
				this.BeginContext(22154, 8, true);
				this.WriteLiteral("10000000");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_14);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_1);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_11.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_11);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(base.Model.Account.Id);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
			base.BeginWriteTagHelperAttribute();
			this.WriteLiteral(AvatarCommandType.REMOVE_DIAMONDS);
			this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
			this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
			if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
			{
				throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-argValue", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
			}
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["argValue"] = (string)Views_Panel_UserProfile.__tagHelperAttribute_15.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_15);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(22166, 142, true);
			this.WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
			this.EndContext();
			if (base.Model.Online)
			{
				this.BeginContext(22360, 320, true);
				this.WriteLiteral("                <div class=\"col-lg-3 col-md-6\">\r\n                    <div class=\"card\">\r\n                        <div class=\"card-header\">\r\n                            <strong>Debug Menu: </strong> Resources\r\n                        </div>\r\n                        <div class=\"card-footer\">\r\n                            ");
				this.EndContext();
				this.BeginContext(22680, 321, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4129884", async delegate
				{
					this.BeginContext(22920, 77, true);
					this.WriteLiteral("\r\n                                Add Resources\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_RESOURCES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(23001, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(23031, 327, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4133496", async delegate
				{
					this.BeginContext(23274, 80, true);
					this.WriteLiteral("\r\n                                Remove Resources\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.REMOVE_RESOURCES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(23358, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(23388, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4137114", async delegate
				{
					this.BeginContext(23632, 81, true);
					this.WriteLiteral("\r\n                                Add War Resources\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_WAR_RESOURCES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(23717, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(23747, 335, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4140734", async delegate
				{
					this.BeginContext(23994, 84, true);
					this.WriteLiteral("\r\n                                Remove War Resources\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.REMOVE_WAR_RESOURCES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(24082, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(24112, 337, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4144360", async delegate
				{
					this.BeginContext(24360, 85, true);
					this.WriteLiteral("\r\n                                Collect War Resources\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.COLLECT_WAR_RESOURCES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(24449, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(24479, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4147988", async delegate
				{
					this.BeginContext(24723, 81, true);
					this.WriteLiteral("\r\n                                Increase XP Level\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.INCREASE_XP_LEVEL);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(24808, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(24838, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4151608", async delegate
				{
					this.BeginContext(25082, 81, true);
					this.WriteLiteral("\r\n                                Increase Trophies\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.INCREASE_TROPHIES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(25167, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(25197, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4155228", async delegate
				{
					this.BeginContext(25441, 81, true);
					this.WriteLiteral("\r\n                                Decrease Trophies\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.INCREASE_TROPHIES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(25526, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(25556, 327, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4158848", async delegate
				{
					this.BeginContext(25799, 80, true);
					this.WriteLiteral("\r\n                                Add 100 Trophies\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_100_TROPHIES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(25883, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(25913, 333, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4162466", async delegate
				{
					this.BeginContext(26159, 83, true);
					this.WriteLiteral("\r\n                                Remove 100 Trophies\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.REMOVE_100_TROPHIES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(26246, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(26276, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4166090", async delegate
				{
					this.BeginContext(26520, 81, true);
					this.WriteLiteral("\r\n                                Add 1000 Trophies\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_1000_TROPHIES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(26605, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(26635, 335, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4169710", async delegate
				{
					this.BeginContext(26882, 84, true);
					this.WriteLiteral("\r\n                                Remove 1000 Trophies\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.REMOVE_1000_TROPHIES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(26970, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(27000, 351, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4173336", async delegate
				{
					this.BeginContext(27253, 94, true);
					this.WriteLiteral("\r\n                                Random Resources + Trophy + XP\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.RANDOM_RESOURCES_TROPHY_XP);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(27351, 402, true);
				this.WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-lg-3 col-md-6\">\r\n                    <div class=\"card\">\r\n                        <div class=\"card-header\">\r\n                            <strong>Debug Menu: </strong> Units\r\n                        </div>\r\n                        <div class=\"card-footer\">\r\n                            ");
				this.EndContext();
				this.BeginContext(27753, 313, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4177358", async delegate
				{
					this.BeginContext(27989, 73, true);
					this.WriteLiteral("\r\n                                Add Units\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_UNITS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(28066, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(28096, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4180962", async delegate
				{
					this.BeginContext(28340, 81, true);
					this.WriteLiteral("\r\n                                Add Preset Troops\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_PRESET_TROOPS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(28425, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(28455, 331, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4184582", async delegate
				{
					this.BeginContext(28700, 82, true);
					this.WriteLiteral("\r\n                                Add Alliance Units\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_ALLIANCE_UNITS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(28786, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(28816, 319, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4188204", async delegate
				{
					this.BeginContext(29055, 76, true);
					this.WriteLiteral("\r\n                                Remove Units\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.REMOVE_UNITS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(29135, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(29165, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4191814", async delegate
				{
					this.BeginContext(29409, 81, true);
					this.WriteLiteral("\r\n                                Deploy All Troops\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.DEPLOY_ALL_TROOPS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(29494, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(29524, 335, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4195434", async delegate
				{
					this.BeginContext(29771, 84, true);
					this.WriteLiteral("\r\n                                Increase Hero Levels\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.INCREASE_HERO_LEVELS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(29859, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(29889, 345, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4199060", async delegate
				{
					this.BeginContext(30141, 89, true);
					this.WriteLiteral("\r\n                                Set Max Unit Spell Levels\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.SET_MAX_UNIT_SPELL_LEVELS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(30234, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(30264, 333, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4202696", async delegate
				{
					this.BeginContext(30510, 83, true);
					this.WriteLiteral("\r\n                                Set Max Hero Levels\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.SET_MAX_HERO_LEVELS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(30597, 404, true);
				this.WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-lg-3 col-md-6\">\r\n                    <div class=\"card\">\r\n                        <div class=\"card-header\">\r\n                            <strong>Debug Menu: </strong> Village\r\n                        </div>\r\n                        <div class=\"card-footer\">\r\n                            ");
				this.EndContext();
				this.BeginContext(31001, 315, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4206702", async delegate
				{
					this.BeginContext(31238, 74, true);
					this.WriteLiteral("\r\n                                Load Level\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.LOAD_LEVEL);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(31316, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(31346, 331, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4210308", async delegate
				{
					this.BeginContext(31591, 82, true);
					this.WriteLiteral("\r\n                                Fast Forward 1 min\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.FAST_FORWARD_1_MIN);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(31677, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(31707, 333, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4213930", async delegate
				{
					this.BeginContext(31953, 83, true);
					this.WriteLiteral("\r\n                                Fast Forward 1 hour\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.FAST_FORWARD_1_HOUR);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(32040, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(32070, 336, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4217554", async delegate
				{
					this.BeginContext(32317, 85, true);
					this.WriteLiteral("\r\n                                Fast Forward 24 hours\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.FAST_FORWARD_24_HOUR);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(32406, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(32436, 333, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4221181", async delegate
				{
					this.BeginContext(32680, 85, true);
					this.WriteLiteral("\r\n                                Upgrade All Buildings\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.UPGRADE_BUILDINGS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(32769, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(32799, 337, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4224805", async delegate
				{
					this.BeginContext(33047, 85, true);
					this.WriteLiteral("\r\n                                Upgrade to Max for TH\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.UPGRADE_TO_MAX_FOR_TH);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(33136, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(33166, 327, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4228433", async delegate
				{
					this.BeginContext(33409, 80, true);
					this.WriteLiteral("\r\n                                Lock Clan Castle\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.LOCK_CLAN_CASTLE);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(33493, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(33523, 339, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4232051", async delegate
				{
					this.BeginContext(33772, 86, true);
					this.WriteLiteral("\r\n                                Toggle Invulnerability\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.TOGGLE_INVULNERABILITY);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(33862, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(33892, 307, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4235681", async delegate
				{
					this.BeginContext(34125, 70, true);
					this.WriteLiteral("\r\n                                Travel\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.TRAVEL);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(34199, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(34229, 321, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4239279", async delegate
				{
					this.BeginContext(34466, 80, true);
					this.WriteLiteral("\r\n                                Toggle RED State\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.TOGGLE_RED);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(34550, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(34580, 362, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4242891", async delegate
				{
					this.BeginContext(34841, 97, true);
					this.WriteLiteral("\r\n                                Give Reengagment Loot for 30 days\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.GIVE_REENGAGEMENT_LOOT_FOR_30_DAYS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(34942, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(34972, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4246544", async delegate
				{
					this.BeginContext(35216, 81, true);
					this.WriteLiteral("\r\n                                Complete Tutorial\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.COMPLETE_TUTORIAL);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(35301, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(35331, 333, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4250164", async delegate
				{
					this.BeginContext(35577, 83, true);
					this.WriteLiteral("\r\n                                Reset All Tutorials\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.RESET_ALL_TUTORIALS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(35664, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(35694, 323, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4253788", async delegate
				{
					this.BeginContext(35935, 78, true);
					this.WriteLiteral("\r\n                                Shield to Half\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.SHIELD_TO_HALF);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(36017, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(36047, 327, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4257402", async delegate
				{
					this.BeginContext(36290, 80, true);
					this.WriteLiteral("\r\n                                Remove Obstacles\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.REMOVE_OBSTACLES);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(36374, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(36404, 319, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4261020", async delegate
				{
					this.BeginContext(36643, 76, true);
					this.WriteLiteral("\r\n                                Disarm Traps\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.DISARM_TRAPS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(36723, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(36753, 325, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4264630", async delegate
				{
					this.BeginContext(36995, 79, true);
					this.WriteLiteral("\r\n                                Remove All Ammo\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.REMOVE_ALL_AMMO);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(37078, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(37108, 329, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4268246", async delegate
				{
					this.BeginContext(37352, 81, true);
					this.WriteLiteral("\r\n                                Reset All Layouts\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.RESET_ALL_LAYOUTS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(37437, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(37467, 327, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4271866", async delegate
				{
					this.BeginContext(37710, 80, true);
					this.WriteLiteral("\r\n                                Pause All Boosts\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.PAUSE_ALL_BOOSTS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(37794, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(37824, 315, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4275484", async delegate
				{
					this.BeginContext(38061, 74, true);
					this.WriteLiteral("\r\n                                Unlock Map\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.UNLOCK_MAP);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(38139, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(38169, 331, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4279090", async delegate
				{
					this.BeginContext(38414, 82, true);
					this.WriteLiteral("\r\n                                Reset Map Progress\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.RESET_MAP_PROGRESS);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(38500, 405, true);
				this.WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-lg-3 col-md-6\">\r\n                    <div class=\"card\">\r\n                        <div class=\"card-header\">\r\n                            <strong>Debug Menu: </strong> Alliance\r\n                        </div>\r\n                        <div class=\"card-footer\">\r\n                            ");
				this.EndContext();
				this.BeginContext(38905, 327, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4283095", async delegate
				{
					this.BeginContext(39148, 80, true);
					this.WriteLiteral("\r\n                                Add 1000 Clan XP\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.ADD_1000_CLAN_XP);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(39232, 30, true);
				this.WriteLiteral("\r\n                            ");
				this.EndContext();
				this.BeginContext(39262, 344, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d0a27aacc8a7f470da36e4f4a71570aa4e6349a4286713", async delegate
				{
					this.BeginContext(39514, 88, true);
					this.WriteLiteral("\r\n                                Random Alliance XP Level\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_UserProfile.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_UserProfile.__tagHelperAttribute_17);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Account.Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(LogicDebugActionType.RANDOM_ALLIANCE_EXP_LEVEL);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commandType", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commandType"], HtmlAttributeValueStyle.DoubleQuotes);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_UserProfile.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(39606, 86, true);
				this.WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
				this.EndContext();
			}
			this.BeginContext(39707, 403, true);
			this.WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n<section class=\"p-t-20\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"copyright\">\r\n                    <p>\r\n                        Copyright © 2019 Atrasis. All rights reserved.\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
			this.EndContext();
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000022D0 File Offset: 0x000004D0
		// (set) Token: 0x0600005A RID: 90 RVA: 0x000022D8 File Offset: 0x000004D8
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000022E1 File Offset: 0x000004E1
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000022E9 File Offset: 0x000004E9
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000022F2 File Offset: 0x000004F2
		// (set) Token: 0x0600005E RID: 94 RVA: 0x000022FA File Offset: 0x000004FA
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002303 File Offset: 0x00000503
		// (set) Token: 0x06000060 RID: 96 RVA: 0x0000230B File Offset: 0x0000050B
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002314 File Offset: 0x00000514
		// (set) Token: 0x06000062 RID: 98 RVA: 0x0000231C File Offset: 0x0000051C
		[RazorInject]
		public IHtmlHelper<UserModel> Html { get; private set; }

		// Token: 0x0400005F RID: 95
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("tabindex", new HtmlString("0"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000060 RID: 96
		private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("class", new HtmlString("dropdown-item"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000061 RID: 97
		private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-action", "UserAccountExecuteAccountCommand", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000062 RID: 98
		private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("asp-route-argValue", "0", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000063 RID: 99
		private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("tabindex", new HtmlString("1"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000064 RID: 100
		private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("asp-route-argValue", "1", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000065 RID: 101
		private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("asp-route-argValue", "2", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000066 RID: 102
		private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("class", new HtmlString("btn btn-secondary btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000067 RID: 103
		private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("class", new HtmlString("btn btn-success btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000068 RID: 104
		private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("class", new HtmlString("btn btn-danger btn-sm"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000069 RID: 105
		private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("tabindex", new HtmlString("2"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400006A RID: 106
		private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("asp-action", "UserAccountExecuteAvatarCommand", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400006B RID: 107
		private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("tabindex", new HtmlString("3"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400006C RID: 108
		private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("asp-route-argValue", "3", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400006D RID: 109
		private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("tabindex", new HtmlString("4"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400006E RID: 110
		private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("asp-route-argValue", "4", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400006F RID: 111
		private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("class", new HtmlString("btn btn-secondary btn-lg btn-block"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000070 RID: 112
		private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("asp-action", "UserAccountExecuteDebugCommand", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000071 RID: 113
		private static readonly TagHelperAttribute __tagHelperAttribute_18 = new TagHelperAttribute("onclick", new HtmlString("return executeDebugCommand(this)"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000072 RID: 114
		private string __tagHelperStringValueBuffer;

		// Token: 0x04000073 RID: 115
		private TagHelperExecutionContext __tagHelperExecutionContext;

		// Token: 0x04000074 RID: 116
		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		// Token: 0x04000075 RID: 117
		private TagHelperScopeManager __backed__tagHelperScopeManager;

		// Token: 0x04000076 RID: 118
		private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
	}
}
