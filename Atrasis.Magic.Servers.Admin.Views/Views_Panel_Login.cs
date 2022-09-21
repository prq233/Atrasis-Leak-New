using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCore
{
	// Token: 0x02000003 RID: 3
	[RazorSourceChecksum("SHA1", "3fbbeeaeb9b6c0d36de60e1a506bf684986f4759", "/Views/Panel/Login.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Panel_Login : RazorPage<LoginModel>
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020AD File Offset: 0x000002AD
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

		// Token: 0x0600000F RID: 15 RVA: 0x00003118 File Offset: 0x00001318
		public override async Task ExecuteAsync()
		{
			base.Layout = string.Empty;
			this.BeginContext(59, 27, true);
			this.WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
			this.EndContext();
			this.BeginContext(86, 1324, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("head", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475915958", async delegate
			{
				this.BeginContext(92, 166, true);
				this.WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n\r\n    <title>Login - Atrasis</title>\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(258, 62, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475916521", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_0);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(320, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(326, 93, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475917942", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_3);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(419, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(425, 94, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475919363", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_4);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(519, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(525, 100, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475920785", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_5);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(625, 8, true);
				this.WriteLiteral("\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(633, 83, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475922210", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_6);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(716, 8, true);
				this.WriteLiteral("\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(724, 81, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475923635", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_7);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(805, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(811, 109, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475925057", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_8);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(920, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(926, 67, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475926478", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_9);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(993, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(999, 85, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475927899", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_10);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1084, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(1090, 67, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475929323", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_11);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1157, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(1163, 75, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475930747", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_12);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1238, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(1244, 91, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475932171", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_13);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1335, 8, true);
				this.WriteLiteral("\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(1343, 58, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475933599", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_14);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1401, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = base.CreateTagHelper<HeadTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(1410, 4, true);
			this.WriteLiteral("\r\n\r\n");
			this.EndContext();
			this.BeginContext(1414, 2760, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("body", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475935825", async delegate
			{
				this.BeginContext(1486, 447, true);
				this.WriteLiteral("\r\n    <div class=\"page-wrapper\">\r\n        <div class=\"page-content--bge5\">\r\n            <div class=\"container\">\r\n                <div class=\"login-wrap\">\r\n                    <div class=\"login-content\">\r\n                        <div class=\"login-logo\">\r\n                            <a class=\"navbar-brand\" href=\"index.html\">Atrasis</a>\r\n                        </div>\r\n                        <div class=\"login-form\">\r\n                            ");
				this.EndContext();
				this.BeginContext(1933, 750, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475936674", async delegate
				{
					this.BeginContext(1958, 718, true);
					this.WriteLiteral("\r\n                                <div class=\"form-group\">\r\n                                    <label>Name</label>\r\n                                    <input class=\"au-input au-input--full\" type=\"text\" name=\"Name\" placeholder=\"Name\">\r\n                                </div>\r\n                                <div class=\"form-group\">\r\n                                    <label>Password</label>\r\n                                    <input class=\"au-input au-input--full\" type=\"password\" name=\"Password\" placeholder=\"Password\">\r\n                                </div>\r\n                                <button class=\"au-btn au-btn--block au-btn--green m-b-20\" type=\"submit\">sign in</button>\r\n                            ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = base.CreateTagHelper<FormTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = base.CreateTagHelper<RenderAtEndOfFormTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)Views_Panel_Login.__tagHelperAttribute_15.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Panel_Login.__tagHelperAttribute_15);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(2683, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
				if (base.Model.LoginFailed)
				{
					this.BeginContext(2774, 276, true);
					this.WriteLiteral("                                <div class=\"register-link\">\r\n                                    <p>\r\n                                        Your login details are incorrect. Please try again\r\n                                    </p>\r\n                                </div>\r\n");
					this.EndContext();
				}
				this.BeginContext(3081, 138, true);
				this.WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(3219, 52, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475940223", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_16);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3271, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3277, 60, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475941480", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3337, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3343, 63, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475942737", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_18);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3406, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3412, 57, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475943994", async delegate
				{
					this.BeginContext(3454, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_19);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3469, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3475, 47, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475945383", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_20);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3522, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3528, 61, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475946640", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_21);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3589, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3595, 89, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475947897", async delegate
				{
					this.BeginContext(3669, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_22);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3684, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3690, 67, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475949286", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_23);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3757, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3763, 73, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475950543", async delegate
				{
					this.BeginContext(3821, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_24);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3836, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3842, 71, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475951932", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_25);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3913, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3919, 71, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475953189", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_26);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3990, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(3996, 60, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475954446", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_27);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(4056, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(4062, 61, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475955703", async delegate
				{
					this.BeginContext(4108, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_28);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(4123, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(4129, 36, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3fbbeeaeb9b6c0d36de60e1a506bf684986f475957092", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_29);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(4165, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = base.CreateTagHelper<BodyTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_30);
			this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Panel_Login.__tagHelperAttribute_31);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(4174, 9, true);
			this.WriteLiteral("\r\n</html>");
			this.EndContext();
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020E0 File Offset: 0x000002E0
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000020E8 File Offset: 0x000002E8
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000020F1 File Offset: 0x000002F1
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000020F9 File Offset: 0x000002F9
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002102 File Offset: 0x00000302
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000210A File Offset: 0x0000030A
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002113 File Offset: 0x00000313
		// (set) Token: 0x06000017 RID: 23 RVA: 0x0000211B File Offset: 0x0000031B
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002124 File Offset: 0x00000324
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000212C File Offset: 0x0000032C
		[RazorInject]
		public IHtmlHelper<LoginModel> Html { get; private set; }

		// Token: 0x04000006 RID: 6
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("href", new HtmlString("~/css/font-face.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000007 RID: 7
		private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("rel", new HtmlString("stylesheet"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000008 RID: 8
		private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("media", new HtmlString("all"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000009 RID: 9
		private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("href", new HtmlString("~/vendor/font-awesome-4.7/css/font-awesome.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400000A RID: 10
		private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("href", new HtmlString("~/vendor/font-awesome-5/css/fontawesome-all.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400000B RID: 11
		private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("href", new HtmlString("~/vendor/mdi-font/css/material-design-iconic-font.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400000C RID: 12
		private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("href", new HtmlString("~/vendor/bootstrap-4.1/bootstrap.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400000D RID: 13
		private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("href", new HtmlString("~/vendor/animsition/animsition.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400000E RID: 14
		private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("href", new HtmlString("~/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400000F RID: 15
		private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("href", new HtmlString("~/vendor/wow/animate.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000010 RID: 16
		private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("href", new HtmlString("~/vendor/css-hamburgers/hamburgers.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000011 RID: 17
		private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("href", new HtmlString("~/vendor/slick/slick.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000012 RID: 18
		private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("href", new HtmlString("~/vendor/select2/select2.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000013 RID: 19
		private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("href", new HtmlString("~/vendor/perfect-scrollbar/perfect-scrollbar.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000014 RID: 20
		private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("href", new HtmlString("~/css/theme.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000015 RID: 21
		private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("asp-action", "Login", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000016 RID: 22
		private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("src", new HtmlString("~/vendor/jquery-3.2.1.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000017 RID: 23
		private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("src", new HtmlString("~/vendor/bootstrap-4.1/popper.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000018 RID: 24
		private static readonly TagHelperAttribute __tagHelperAttribute_18 = new TagHelperAttribute("src", new HtmlString("~/vendor/bootstrap-4.1/bootstrap.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000019 RID: 25
		private static readonly TagHelperAttribute __tagHelperAttribute_19 = new TagHelperAttribute("src", new HtmlString("~/vendor/slick/slick.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400001A RID: 26
		private static readonly TagHelperAttribute __tagHelperAttribute_20 = new TagHelperAttribute("src", new HtmlString("~/vendor/wow/wow.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400001B RID: 27
		private static readonly TagHelperAttribute __tagHelperAttribute_21 = new TagHelperAttribute("src", new HtmlString("~/vendor/animsition/animsition.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400001C RID: 28
		private static readonly TagHelperAttribute __tagHelperAttribute_22 = new TagHelperAttribute("src", new HtmlString("~/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400001D RID: 29
		private static readonly TagHelperAttribute __tagHelperAttribute_23 = new TagHelperAttribute("src", new HtmlString("~/vendor/counter-up/jquery.waypoints.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400001E RID: 30
		private static readonly TagHelperAttribute __tagHelperAttribute_24 = new TagHelperAttribute("src", new HtmlString("~/vendor/counter-up/jquery.counterup.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400001F RID: 31
		private static readonly TagHelperAttribute __tagHelperAttribute_25 = new TagHelperAttribute("src", new HtmlString("~/vendor/circle-progress/circle-progress.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000020 RID: 32
		private static readonly TagHelperAttribute __tagHelperAttribute_26 = new TagHelperAttribute("src", new HtmlString("~/vendor/perfect-scrollbar/perfect-scrollbar.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000021 RID: 33
		private static readonly TagHelperAttribute __tagHelperAttribute_27 = new TagHelperAttribute("src", new HtmlString("~/vendor/chartjs/Chart.bundle.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000022 RID: 34
		private static readonly TagHelperAttribute __tagHelperAttribute_28 = new TagHelperAttribute("src", new HtmlString("~/vendor/select2/select2.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000023 RID: 35
		private static readonly TagHelperAttribute __tagHelperAttribute_29 = new TagHelperAttribute("src", new HtmlString("~/js/main.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000024 RID: 36
		private static readonly TagHelperAttribute __tagHelperAttribute_30 = new TagHelperAttribute("class", new HtmlString("animsition"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000025 RID: 37
		private static readonly TagHelperAttribute __tagHelperAttribute_31 = new TagHelperAttribute("style", new HtmlString("animation-duration: 900ms; opacity: 1;"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000026 RID: 38
		private string __tagHelperStringValueBuffer;

		// Token: 0x04000027 RID: 39
		private TagHelperExecutionContext __tagHelperExecutionContext;

		// Token: 0x04000028 RID: 40
		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		// Token: 0x04000029 RID: 41
		private TagHelperScopeManager __backed__tagHelperScopeManager;

		// Token: 0x0400002A RID: 42
		private HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;

		// Token: 0x0400002B RID: 43
		private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

		// Token: 0x0400002C RID: 44
		private BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;

		// Token: 0x0400002D RID: 45
		private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;

		// Token: 0x0400002E RID: 46
		private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
	}
}
