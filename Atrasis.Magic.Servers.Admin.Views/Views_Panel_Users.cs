using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Models;
using Atrasis.Magic.Servers.Core.Database.Document;
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
	// Token: 0x02000008 RID: 8
	[RazorSourceChecksum("SHA1", "d504423fbf8792a6c3a49960eeb265ede80d38e0", "/Views/Panel/Users.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Panel_Users : RazorPage<UsersModel>
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00002338 File Offset: 0x00000538
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

		// Token: 0x060000A9 RID: 169 RVA: 0x00005254 File Offset: 0x00003454
		public override async Task ExecuteAsync()
		{
			base.ViewData["Title"] = "Users";
			this.BeginContext(140, 522, true);
			this.WriteLiteral("\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <h2 class=\"title-1 m-b-25\">Main Leaderboard</h2>\r\n                <div class=\"au-card au-card--bg-blue au-card-top-countries m-b-40\">\r\n                    <div class=\"au-card-inner\">\r\n                        <div class=\"table-responsive\">\r\n                            <table class=\"table table-top-countries\">\r\n                                <tbody>\r\n");
			this.EndContext();
			for (int j = 0; j < base.Model.MainLeaderboard.Size(); j++)
			{
				this.BeginContext(791, 86, true);
				this.WriteLiteral("                                    <tr>\r\n                                        <td>");
				this.EndContext();
				this.BeginContext(878, 39, false);
				this.Write(base.Model.MainLeaderboard[j].GetName());
				this.EndContext();
				this.BeginContext(917, 70, true);
				this.WriteLiteral("</td>\r\n                                        <td class=\"text-right\">");
				this.EndContext();
				this.BeginContext(988, 40, false);
				this.Write(base.Model.MainLeaderboard[j].GetScore());
				this.EndContext();
				this.BeginContext(1028, 50, true);
				this.WriteLiteral("</td>\r\n                                    </tr>\r\n");
				this.EndContext();
			}
			this.BeginContext(1113, 593, true);
			this.WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <h2 class=\"title-1 m-b-25\">Secondary Leaderboard</h2>\r\n                <div class=\"au-card au-card--bg-blue au-card-top-countries m-b-40\">\r\n                    <div class=\"au-card-inner\">\r\n                        <div class=\"table-responsive\">\r\n                            <table class=\"table table-top-countries\">\r\n                                <tbody>\r\n");
			this.EndContext();
			for (int k = 0; k < base.Model.SecondaryLeaderboard.Size(); k++)
			{
				this.BeginContext(1840, 86, true);
				this.WriteLiteral("                                    <tr>\r\n                                        <td>");
				this.EndContext();
				this.BeginContext(1927, 44, false);
				this.Write(base.Model.SecondaryLeaderboard[k].GetName());
				this.EndContext();
				this.BeginContext(1971, 70, true);
				this.WriteLiteral("</td>\r\n                                        <td class=\"text-right\">");
				this.EndContext();
				this.BeginContext(2042, 45, false);
				this.Write(base.Model.SecondaryLeaderboard[k].GetScore());
				this.EndContext();
				this.BeginContext(2087, 50, true);
				this.WriteLiteral("</td>\r\n                                    </tr>\r\n");
				this.EndContext();
			}
			this.BeginContext(2172, 642, true);
			this.WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"user-data m-b-30\">\r\n                    <h3 class=\"title-3 m-b-30\">\r\n                        <i class=\"zmdi zmdi-account-calendar\"></i>Find Users\r\n                    </h3>\r\n                    <div class=\"filters\">\r\n                        ");
			this.EndContext();
			this.BeginContext(2814, 2023, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "d504423fbf8792a6c3a49960eeb265ede80d38e09414", async delegate
			{
				this.BeginContext(2839, 197, true);
				this.WriteLiteral("\r\n                            <div class=\"rs-select2--light rs-select2--md\">\r\n                                <input type=\"text\" name=\"Name\" id=\"Name\" placeholder=\"Name or tag\" class=\"form-control\"");
				this.EndContext();
				this.BeginWriteAttribute("value", " value=\"", 3036, "\"", 3146, 1);
				base.WriteAttributeValue("", 3044, (!string.IsNullOrEmpty(base.Model.CurrentFilter.Name)) ? base.Model.CurrentFilter.Name : string.Empty, 3044, 102, false);
				this.EndWriteAttribute();
				this.BeginContext(3147, 242, true);
				this.WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"rs-select2--light rs-select2--sm\">\r\n                                <input type=\"number\" name=\"ExpLevel\" id=\"ExpLevel\" placeholder=\"Exp Level\" class=\"form-control\"");
				this.EndContext();
				this.BeginWriteAttribute("value", " value=\"", 3389, "\"", 3500, 1);
				base.WriteAttributeValue("", 3397, (base.Model.CurrentFilter.ExpLevel != 0) ? base.Model.CurrentFilter.ExpLevel.ToString() : string.Empty, 3397, 103, false);
				this.EndWriteAttribute();
				this.BeginContext(3501, 232, true);
				this.WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"rs-select2--light rs-select2--sm\">\r\n                                <input type=\"number\" name=\"Score\" id=\"Score\" placeholder=\"Score\" class=\"form-control\"");
				this.EndContext();
				this.BeginWriteAttribute("value", " value=\"", 3733, "\"", 3838, 1);
				base.WriteAttributeValue("", 3741, (base.Model.CurrentFilter.Score != 0) ? base.Model.CurrentFilter.Score.ToString() : string.Empty, 3741, 97, false);
				this.EndWriteAttribute();
				this.BeginContext(3839, 245, true);
				this.WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"rs-select2--light rs-select2--sm\">\r\n                                <input type=\"number\" name=\"DuelScore\" id=\"DuelScore\" placeholder=\"Duel Score\" class=\"form-control\"");
				this.EndContext();
				this.BeginWriteAttribute("value", " value=\"", 4084, "\"", 4197, 1);
				base.WriteAttributeValue("", 4092, (base.Model.CurrentFilter.DuelScore != 0) ? base.Model.CurrentFilter.DuelScore.ToString() : string.Empty, 4092, 105, false);
				this.EndWriteAttribute();
				this.BeginContext(4198, 233, true);
				this.WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"rs-select2--light rs-select2--sm\">\r\n                                <input type=\"text\" name=\"Status\" id=\"Status\" placeholder=\"Status\" class=\"form-control\"");
				this.EndContext();
				this.BeginWriteAttribute("value", " value=\"", 4431, "\"", 4548, 1);
				base.WriteAttributeValue("", 4439, (base.Model.CurrentFilter.Status != null) ? base.Model.CurrentFilter.Status.Value.ToString() : string.Empty, 4439, 109, false);
				this.EndWriteAttribute();
				this.BeginContext(4549, 281, true);
				this.WriteLiteral(">\r\n                            </div>\r\n                            <button type=\"submit\" class=\"au-btn au-btn-icon au-btn--green au-btn--small\">\r\n                                <i class=\"zmdi zmdi-search\"></i>Search\r\n                            </button>\r\n                        ");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = base.CreateTagHelper<FormTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = base.CreateTagHelper<RenderAtEndOfFormTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)Views_Panel_Users.__tagHelperAttribute_0.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Users.__tagHelperAttribute_0);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(4837, 752, true);
			this.WriteLiteral("\r\n                    </div>\r\n                    <div class=\"table-responsive table-data\">\r\n                        <table class=\"table\">\r\n                            <thead>\r\n                                <tr>\r\n                                    <td></td>\r\n                                    <td>Name</td>\r\n                                    <td>Exp Level</td>\r\n                                    <td>Score</td>\r\n                                    <td>Duel Score</td>\r\n                                    <td>Status</td>\r\n                                    <td>Alliance Name</td>\r\n                                    <td></td>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
			this.EndContext();
			for (int i = 0; i < base.Model.Users.Size(); i++)
			{
				this.BeginContext(5700, 247, true);
				this.WriteLiteral("                                <tr>\r\n                                    <td></td>\r\n                                    <td>\r\n                                        <div class=\"table-data__info\">\r\n                                            <h6>");
				this.EndContext();
				this.BeginContext(5948, 24, false);
				this.Write(base.Model.Users[i].Name);
				this.EndContext();
				this.BeginContext(5972, 110, true);
				this.WriteLiteral("</h6>\r\n                                            <span>\r\n                                                <a>");
				this.EndContext();
				this.BeginContext(6083, 23, false);
				this.Write(base.Model.Users[i].Tag);
				this.EndContext();
				this.BeginContext(6106, 190, true);
				this.WriteLiteral("</a>\r\n                                            </span>\r\n                                        </div>\r\n                                    </td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(6297, 28, false);
				this.Write(base.Model.Users[i].ExpLevel);
				this.EndContext();
				this.BeginContext(6325, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(6373, 25, false);
				this.Write(base.Model.Users[i].Score);
				this.EndContext();
				this.BeginContext(6398, 47, true);
				this.WriteLiteral("</td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(6446, 29, false);
				this.Write(base.Model.Users[i].DuelScore);
				this.EndContext();
				this.BeginContext(6475, 49, true);
				this.WriteLiteral("</td>\r\n                                    <td>\r\n");
				this.EndContext();
				AccountState status = base.Model.Users[i].Status;
				if (status != AccountState.NORMAL)
				{
					if (status - AccountState.LOCKED <= 1)
					{
						this.BeginContext(7016, 65, true);
						this.WriteLiteral("                                        <span class=\"role admin\">");
						this.EndContext();
						this.BeginContext(7082, 26, false);
						this.Write(base.Model.Users[i].Status);
						this.EndContext();
						this.BeginContext(7108, 9, true);
						this.WriteLiteral("</span>\r\n");
						this.EndContext();
					}
				}
				else
				{
					this.BeginContext(6716, 66, true);
					this.WriteLiteral("                                        <span class=\"role member\">");
					this.EndContext();
					this.BeginContext(6783, 26, false);
					this.Write(base.Model.Users[i].Status);
					this.EndContext();
					this.BeginContext(6809, 9, true);
					this.WriteLiteral("</span>\r\n");
					this.EndContext();
				}
				this.BeginContext(7216, 83, true);
				this.WriteLiteral("                                    </td>\r\n                                    <td>");
				this.EndContext();
				this.BeginContext(7301, 98, false);
				this.Write((!string.IsNullOrEmpty(base.Model.Users[i].Alliance)) ? base.Model.Users[i].Alliance : "No Alliance");
				this.EndContext();
				this.BeginContext(7400, 89, true);
				this.WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
				this.EndContext();
				this.BeginContext(7489, 305, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "d504423fbf8792a6c3a49960eeb265ede80d38e021820", async delegate
				{
					this.BeginContext(7550, 240, true);
					this.WriteLiteral("\r\n                                            <span class=\"more\">\r\n                                                <i class=\"zmdi zmdi-more\"></i>\r\n                                            </span>\r\n                                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Panel_Users.__tagHelperAttribute_0.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Users.__tagHelperAttribute_0);
				if (this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
				{
					throw new InvalidOperationException(base.InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
				}
				base.BeginWriteTagHelperAttribute();
				this.WriteLiteral(base.Model.Users[i].Id);
				this.__tagHelperStringValueBuffer = base.EndWriteTagHelperAttribute();
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = this.__tagHelperStringValueBuffer;
				this.__tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], HtmlAttributeValueStyle.DoubleQuotes);
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
				this.BeginContext(7794, 84, true);
				this.WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
				this.EndContext();
			}
			this.BeginContext(7909, 547, true);
			this.WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<section class=\"p-t-20\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"copyright\">\r\n                    <p>\r\n                        Copyright © 2019 Atrasis. All rights reserved.\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
			this.EndContext();
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000AA RID: 170 RVA: 0x0000236B File Offset: 0x0000056B
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00002373 File Offset: 0x00000573
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000237C File Offset: 0x0000057C
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00002384 File Offset: 0x00000584
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000238D File Offset: 0x0000058D
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00002395 File Offset: 0x00000595
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000239E File Offset: 0x0000059E
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000023A6 File Offset: 0x000005A6
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000023AF File Offset: 0x000005AF
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000023B7 File Offset: 0x000005B7
		[RazorInject]
		public IHtmlHelper<UsersModel> Html { get; private set; }

		// Token: 0x0400007C RID: 124
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("asp-action", "Users", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400007D RID: 125
		private string __tagHelperStringValueBuffer;

		// Token: 0x0400007E RID: 126
		private TagHelperExecutionContext __tagHelperExecutionContext;

		// Token: 0x0400007F RID: 127
		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		// Token: 0x04000080 RID: 128
		private TagHelperScopeManager __backed__tagHelperScopeManager;

		// Token: 0x04000081 RID: 129
		private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;

		// Token: 0x04000082 RID: 130
		private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;

		// Token: 0x04000083 RID: 131
		private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
	}
}
