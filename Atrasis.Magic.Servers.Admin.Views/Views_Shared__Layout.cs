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
	// Token: 0x0200000B RID: 11
	[RazorSourceChecksum("SHA1", "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e", "/Views/Shared/_Layout.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Shared__Layout : RazorPage<BaseModel>
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000024E2 File Offset: 0x000006E2
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

		// Token: 0x060000D4 RID: 212 RVA: 0x00005450 File Offset: 0x00003650
		public override async Task ExecuteAsync()
		{
			this.BeginContext(18, 27, true);
			this.WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
			this.EndContext();
			this.BeginContext(45, 2086, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("head", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e17084", async delegate
			{
				this.BeginContext(51, 171, true);
				this.WriteLiteral("\r\n    <!-- Required meta tags-->\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    \r\n    <title>");
				this.EndContext();
				this.BeginContext(223, 17, false);
				this.Write(base.ViewData["Title"]);
				this.EndContext();
				this.BeginContext(240, 26, true);
				this.WriteLiteral(" - Atrasis</title>\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(266, 62, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e18047", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_0);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(328, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(334, 93, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e19468", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_3);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(427, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(433, 94, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e20889", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_4);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(527, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(533, 100, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e22311", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_5);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(633, 8, true);
				this.WriteLiteral("\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(641, 83, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e23736", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_6);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(724, 8, true);
				this.WriteLiteral("\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(732, 81, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e25161", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_7);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(813, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(819, 109, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e26583", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_8);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(928, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(934, 67, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e28004", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_9);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1001, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(1007, 85, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e29427", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_10);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1092, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(1098, 67, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e30851", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_11);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1165, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(1171, 75, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e32275", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_12);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1246, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(1252, 91, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e33699", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_13);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1343, 8, true);
				this.WriteLiteral("\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(1351, 58, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("link", TagMode.StartTagOnly, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e35127", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_14);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_1);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_2);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1409, 715, true);
				this.WriteLiteral("\r\n    <script>\r\n        function formatSecondsToTime(secs) {\r\n            if (secs >= 60) {\r\n                if (secs >= 3600) {\r\n                    if (secs >= 86400) {\r\n                        return Math.floor(secs / 86400) + \"d \" + Math.floor(secs % 86400 / 3600) + \"h \" + Math.floor(secs % 86400 % 3600 / 60) + \"mn \" + Math.floor(secs % 86400 % 3600 % 60) + \"s\";\r\n                    }\r\n                    return Math.floor(secs / 3600) + \"h \" + Math.floor(secs % 3600 / 60) + \"mn \" + Math.floor(secs % 3600 % 60) + \"secs\";\r\n                }\r\n                return Math.floor(secs / 60) + \"mn \" + Math.floor(secs % 60) + \"secs\";\r\n            }\r\n            return secs + \"secs\";\r\n        }\r\n    </script>\r\n");
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
			this.BeginContext(2131, 2, true);
			this.WriteLiteral("\r\n");
			this.EndContext();
			this.BeginContext(2133, 7811, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("body", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e38083", async delegate
			{
				this.BeginContext(2139, 212, true);
				this.WriteLiteral("\r\n    <header class=\"header-mobile d-block d-lg-none\">\r\n        <div class=\"header-mobile__bar\">\r\n            <div class=\"container-fluid\">\r\n                <div class=\"header-mobile-inner\">\r\n                    ");
				this.EndContext();
				this.BeginContext(2351, 139, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e38696", async delegate
				{
					this.BeginContext(2409, 77, true);
					this.WriteLiteral("\r\n                        <h1 class=\"mb-4\">Atrasis</h1>\r\n                    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_15);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_16.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(2490, 521, true);
				this.WriteLiteral("\r\n                    <button class=\"hamburger hamburger--slider\" type=\"button\">\r\n                        <span class=\"hamburger-box\">\r\n                            <span class=\"hamburger-inner\"></span>\r\n                        </span>\r\n                    </button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <nav class=\"navbar-mobile\">\r\n            <div class=\"container-fluid\">\r\n                <ul class=\"navbar-mobile__list list-unstyled\">\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(3011, 151, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e41076", async delegate
				{
					this.BeginContext(3056, 102, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-tachometer-alt\"></i>Dashboard\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_16.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3162, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(3241, 146, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e42942", async delegate
				{
					this.BeginContext(3288, 95, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-chart-bar\"></i>Servers\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_18.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_18);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3387, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(3466, 138, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e44800", async delegate
				{
					this.BeginContext(3511, 89, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-table\"></i>Users\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_19.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_19);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3604, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(3683, 143, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e46652", async delegate
				{
					this.BeginContext(3727, 95, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-check-square\"></i>Logs\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_20.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_20);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(3826, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(3905, 166, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e48510", async delegate
				{
					this.BeginContext(3957, 110, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-exclamation-circle\"></i>Server Events\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_21.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_21);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(4071, 474, true);
				this.WriteLiteral("\r\n                    </li>\r\n                </ul>\r\n            </div>\r\n        </nav>\r\n    </header>\r\n    <aside class=\"menu-sidebar d-none d-lg-block\">\r\n        <div class=\"logo\">\r\n            <a class=\"navbar-brand\" href=\"index.html\">Atrasis</a>\r\n        </div>\r\n        <div class=\"menu-sidebar__content js-scrollbar1\">\r\n            <nav class=\"navbar-sidebar\">\r\n                <ul class=\"list-unstyled navbar__list\">\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(4545, 151, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e50789", async delegate
				{
					this.BeginContext(4590, 102, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-tachometer-alt\"></i>Dashboard\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_16.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_16);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(4696, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(4775, 143, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e52655", async delegate
				{
					this.BeginContext(4822, 92, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-server\"></i>Servers\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_18.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_18);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(4918, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(4997, 137, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e54510", async delegate
				{
					this.BeginContext(5042, 88, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-user\"></i>Users\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_19.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_19);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(5134, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(5213, 143, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e56361", async delegate
				{
					this.BeginContext(5257, 95, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-check-square\"></i>Logs\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_20.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_20);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(5356, 79, true);
				this.WriteLiteral("\r\n                    </li>\r\n                    <li>\r\n                        ");
				this.EndContext();
				this.BeginContext(5435, 166, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e58219", async delegate
				{
					this.BeginContext(5487, 110, true);
					this.WriteLiteral("\r\n                            <i class=\"fas fa-exclamation-circle\"></i>Server Events\r\n                        ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_21.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_21);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(5601, 337, true);
				this.WriteLiteral("\r\n                    </li>\r\n                </ul>\r\n            </nav>\r\n        </div>\r\n    </aside>\r\n    <div class=\"page-container\">\r\n        <header class=\"header-desktop\">\r\n            <div class=\"section__content section__content--p30\">\r\n                <div class=\"container-fluid\">\r\n                    <div class=\"header-wrap\">\r\n");
				this.EndContext();
				if (base.Model.User != null)
				{
					this.BeginContext(6020, 312, true);
					this.WriteLiteral("                            <div class=\"header-button\">\r\n                                <div class=\"account-wrap\">\r\n                                    <div class=\"account-item clearfix js-item-menu\">\r\n                                        <div class=\"image\">\r\n                                            <img");
					this.EndContext();
					this.BeginWriteAttribute("src", " src=\"", 6332, "\"", 6362, 1);
					base.WriteAttributeValue("", 6338, base.Model.User.Profile, 6338, 24, false);
					this.EndWriteAttribute();
					this.BeginWriteAttribute("alt", " alt=\"", 6363, "\"", 6390, 1);
					base.WriteAttributeValue("", 6369, base.Model.User.Name, 6369, 21, false);
					this.EndWriteAttribute();
					this.BeginContext(6391, 190, true);
					this.WriteLiteral("/>\r\n                                        </div>\r\n                                        <div class=\"content\">\r\n                                            <a class=\"js-acc-btn\" href=\"#\">");
					this.EndContext();
					this.BeginContext(6582, 20, false);
					this.Write(base.Model.User.Name);
					this.EndContext();
					this.BeginContext(6602, 406, true);
					this.WriteLiteral("</a>\r\n                                        </div>\r\n                                        <div class=\"account-dropdown js-dropdown\">\r\n                                            <div class=\"info clearfix\">\r\n                                                <div class=\"image\">\r\n                                                    <a href=\"#\">\r\n                                                        <img");
					this.EndContext();
					this.BeginWriteAttribute("src", " src=\"", 7008, "\"", 7038, 1);
					base.WriteAttributeValue("", 7014, base.Model.User.Profile, 7014, 24, false);
					this.EndWriteAttribute();
					this.BeginWriteAttribute("alt", " alt=\"", 7039, "\"", 7066, 1);
					base.WriteAttributeValue("", 7045, base.Model.User.Name, 7045, 21, false);
					this.EndWriteAttribute();
					this.BeginContext(7067, 328, true);
					this.WriteLiteral("/>\r\n                                                    </a>\r\n                                                </div>\r\n                                                <div class=\"content\">\r\n                                                    <h5 class=\"name\">\r\n                                                        <a href=\"#\">");
					this.EndContext();
					this.BeginContext(7396, 20, false);
					this.Write(base.Model.User.Name);
					this.EndContext();
					this.BeginContext(7416, 137, true);
					this.WriteLiteral("</a>\r\n                                                    </h5>\r\n                                                    <span class=\"email\">");
					this.EndContext();
					this.BeginContext(7554, 21, false);
					this.Write(base.Model.User.Email);
					this.EndContext();
					this.BeginContext(7575, 747, true);
					this.WriteLiteral("</span>\r\n                                                </div>\r\n                                            </div>\r\n                                            <div class=\"account-dropdown__body\">\r\n                                                <div class=\"account-dropdown__item\">\r\n                                                    <a href=\"#\">\r\n                                                        <i class=\"zmdi zmdi-account\"></i>Account\r\n                                                    </a>\r\n                                                </div>\r\n                                            </div>\r\n                                            <div class=\"account-dropdown__footer\">\r\n                                                ");
					this.EndContext();
					this.BeginContext(8322, 190, false);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e65735", async delegate
					{
						this.BeginContext(8367, 141, true);
						this.WriteLiteral("\r\n                                                    <i class=\"zmdi zmdi-power\"></i>Logout\r\n                                                ");
						this.EndContext();
					});
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
					this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__Layout.__tagHelperAttribute_22.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_22);
					this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__Layout.__tagHelperAttribute_17.Value;
					this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__Layout.__tagHelperAttribute_17);
					await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
					if (!this.__tagHelperExecutionContext.Output.IsContentModified)
					{
						await this.__tagHelperExecutionContext.SetOutputContentAsync();
					}
					this.Write(this.__tagHelperExecutionContext.Output);
					this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
					this.EndContext();
					this.BeginContext(8512, 222, true);
					this.WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
					this.EndContext();
				}
				this.BeginContext(8761, 139, true);
				this.WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </header>\r\n        <div class=\"main-content\">\r\n            ");
				this.EndContext();
				this.BeginContext(8901, 12, false);
				this.Write(this.RenderBody());
				this.EndContext();
				this.BeginContext(8913, 36, true);
				this.WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(8949, 52, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e68636", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_23);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9001, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9007, 60, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e69893", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_24);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9067, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9073, 63, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e71150", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_25);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9136, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9142, 57, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e72407", async delegate
				{
					this.BeginContext(9184, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_26);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9199, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9205, 47, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e73796", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_27);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9252, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9258, 61, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e75053", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_28);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9319, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9325, 89, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e76310", async delegate
				{
					this.BeginContext(9399, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_29);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9414, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9420, 67, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e77699", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_30);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9487, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9493, 73, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e78956", async delegate
				{
					this.BeginContext(9551, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_31);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9566, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9572, 71, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e80345", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_32);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9643, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9649, 71, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e81602", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_33);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9720, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9726, 60, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e82859", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_34);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9786, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9792, 61, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e84116", async delegate
				{
					this.BeginContext(9838, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_35);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9853, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(9859, 36, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "3d1dec7bb5a862bbe90ba84ae7386223dfafb60e85505", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__Layout.__tagHelperAttribute_36);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(9895, 8, true);
				this.WriteLiteral("\r\n\r\n    ");
				this.EndContext();
				this.BeginContext(9904, 31, false);
				this.Write(base.RenderSection("Scripts", false));
				this.EndContext();
				this.BeginContext(9935, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = base.CreateTagHelper<BodyTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(9944, 9, true);
			this.WriteLiteral("\r\n</html>");
			this.EndContext();
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00002515 File Offset: 0x00000715
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000251D File Offset: 0x0000071D
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00002526 File Offset: 0x00000726
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000252E File Offset: 0x0000072E
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00002537 File Offset: 0x00000737
		// (set) Token: 0x060000DA RID: 218 RVA: 0x0000253F File Offset: 0x0000073F
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00002548 File Offset: 0x00000748
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00002550 File Offset: 0x00000750
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00002559 File Offset: 0x00000759
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00002561 File Offset: 0x00000761
		[RazorInject]
		public IHtmlHelper<BaseModel> Html { get; private set; }

		// Token: 0x0400009B RID: 155
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("href", new HtmlString("~/css/font-face.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400009C RID: 156
		private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("rel", new HtmlString("stylesheet"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400009D RID: 157
		private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("media", new HtmlString("all"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400009E RID: 158
		private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("href", new HtmlString("~/vendor/font-awesome-4.7/css/font-awesome.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400009F RID: 159
		private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("href", new HtmlString("~/vendor/font-awesome-5/css/fontawesome-all.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A0 RID: 160
		private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("href", new HtmlString("~/vendor/mdi-font/css/material-design-iconic-font.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A1 RID: 161
		private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("href", new HtmlString("~/vendor/bootstrap-4.1/bootstrap.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A2 RID: 162
		private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("href", new HtmlString("~/vendor/animsition/animsition.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A3 RID: 163
		private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("href", new HtmlString("~/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A4 RID: 164
		private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("href", new HtmlString("~/vendor/wow/animate.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A5 RID: 165
		private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("href", new HtmlString("~/vendor/css-hamburgers/hamburgers.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A6 RID: 166
		private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("href", new HtmlString("~/vendor/slick/slick.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A7 RID: 167
		private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("href", new HtmlString("~/vendor/select2/select2.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A8 RID: 168
		private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("href", new HtmlString("~/vendor/perfect-scrollbar/perfect-scrollbar.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000A9 RID: 169
		private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("href", new HtmlString("~/css/theme.css"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000AA RID: 170
		private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("class", new HtmlString("logo"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000AB RID: 171
		private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("asp-action", "Index", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000AC RID: 172
		private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("asp-controller", "Panel", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000AD RID: 173
		private static readonly TagHelperAttribute __tagHelperAttribute_18 = new TagHelperAttribute("asp-action", "Servers", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000AE RID: 174
		private static readonly TagHelperAttribute __tagHelperAttribute_19 = new TagHelperAttribute("asp-action", "Users", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000AF RID: 175
		private static readonly TagHelperAttribute __tagHelperAttribute_20 = new TagHelperAttribute("asp-action", "Logs", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B0 RID: 176
		private static readonly TagHelperAttribute __tagHelperAttribute_21 = new TagHelperAttribute("asp-action", "ServerEvents", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B1 RID: 177
		private static readonly TagHelperAttribute __tagHelperAttribute_22 = new TagHelperAttribute("asp-action", "Login", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B2 RID: 178
		private static readonly TagHelperAttribute __tagHelperAttribute_23 = new TagHelperAttribute("src", new HtmlString("~/vendor/jquery-3.2.1.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B3 RID: 179
		private static readonly TagHelperAttribute __tagHelperAttribute_24 = new TagHelperAttribute("src", new HtmlString("~/vendor/bootstrap-4.1/popper.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B4 RID: 180
		private static readonly TagHelperAttribute __tagHelperAttribute_25 = new TagHelperAttribute("src", new HtmlString("~/vendor/bootstrap-4.1/bootstrap.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B5 RID: 181
		private static readonly TagHelperAttribute __tagHelperAttribute_26 = new TagHelperAttribute("src", new HtmlString("~/vendor/slick/slick.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B6 RID: 182
		private static readonly TagHelperAttribute __tagHelperAttribute_27 = new TagHelperAttribute("src", new HtmlString("~/vendor/wow/wow.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B7 RID: 183
		private static readonly TagHelperAttribute __tagHelperAttribute_28 = new TagHelperAttribute("src", new HtmlString("~/vendor/animsition/animsition.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B8 RID: 184
		private static readonly TagHelperAttribute __tagHelperAttribute_29 = new TagHelperAttribute("src", new HtmlString("~/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000B9 RID: 185
		private static readonly TagHelperAttribute __tagHelperAttribute_30 = new TagHelperAttribute("src", new HtmlString("~/vendor/counter-up/jquery.waypoints.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000BA RID: 186
		private static readonly TagHelperAttribute __tagHelperAttribute_31 = new TagHelperAttribute("src", new HtmlString("~/vendor/counter-up/jquery.counterup.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000BB RID: 187
		private static readonly TagHelperAttribute __tagHelperAttribute_32 = new TagHelperAttribute("src", new HtmlString("~/vendor/circle-progress/circle-progress.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000BC RID: 188
		private static readonly TagHelperAttribute __tagHelperAttribute_33 = new TagHelperAttribute("src", new HtmlString("~/vendor/perfect-scrollbar/perfect-scrollbar.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000BD RID: 189
		private static readonly TagHelperAttribute __tagHelperAttribute_34 = new TagHelperAttribute("src", new HtmlString("~/vendor/chartjs/Chart.bundle.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000BE RID: 190
		private static readonly TagHelperAttribute __tagHelperAttribute_35 = new TagHelperAttribute("src", new HtmlString("~/vendor/select2/select2.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000BF RID: 191
		private static readonly TagHelperAttribute __tagHelperAttribute_36 = new TagHelperAttribute("src", new HtmlString("~/js/main.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000C0 RID: 192
		private string __tagHelperStringValueBuffer;

		// Token: 0x040000C1 RID: 193
		private TagHelperExecutionContext __tagHelperExecutionContext;

		// Token: 0x040000C2 RID: 194
		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		// Token: 0x040000C3 RID: 195
		private TagHelperScopeManager __backed__tagHelperScopeManager;

		// Token: 0x040000C4 RID: 196
		private HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;

		// Token: 0x040000C5 RID: 197
		private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

		// Token: 0x040000C6 RID: 198
		private BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;

		// Token: 0x040000C7 RID: 199
		private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
	}
}
