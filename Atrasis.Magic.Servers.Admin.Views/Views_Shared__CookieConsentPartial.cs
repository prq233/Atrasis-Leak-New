using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
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
	// Token: 0x0200000A RID: 10
	[Dynamic(new bool[]
	{
		false,
		true
	})]
	[RazorSourceChecksum("SHA1", "dbc780d52d9a88c509359642b78d9fa9d1ce81a5", "/Views/Shared/_CookieConsentPartial.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Shared__CookieConsentPartial : RazorPage<object>
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00002447 File Offset: 0x00000647
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

		// Token: 0x060000C5 RID: 197 RVA: 0x00005374 File Offset: 0x00003574
		public override async Task ExecuteAsync()
		{
			this.BeginContext(43, 2, true);
			this.WriteLiteral("\r\n");
			this.EndContext();
			ITrackingConsentFeature trackingConsentFeature = base.Context.Features.Get<ITrackingConsentFeature>();
			bool flag = trackingConsentFeature != null && !trackingConsentFeature.CanTrack;
			string cookieString = (trackingConsentFeature != null) ? trackingConsentFeature.CreateConsentCookie() : null;
			this.BeginContext(248, 2, true);
			this.WriteLiteral("\r\n");
			this.EndContext();
			if (flag)
			{
				this.BeginContext(271, 168, true);
				this.WriteLiteral("    <div id=\"cookieConsent\" class=\"alert alert-info alert-dismissible fade show\" role=\"alert\">\r\n        Use this space to summarize your privacy and cookie use policy. ");
				this.EndContext();
				this.BeginContext(439, 73, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "dbc780d52d9a88c509359642b78d9fa9d1ce81a55398", async delegate
				{
					this.BeginContext(498, 10, true);
					this.WriteLiteral("Learn More");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = base.CreateTagHelper<AnchorTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)Views_Shared__CookieConsentPartial.__tagHelperAttribute_0.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__CookieConsentPartial.__tagHelperAttribute_0);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)Views_Shared__CookieConsentPartial.__tagHelperAttribute_1.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__CookieConsentPartial.__tagHelperAttribute_1);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)Views_Shared__CookieConsentPartial.__tagHelperAttribute_2.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__CookieConsentPartial.__tagHelperAttribute_2);
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
				this.BeginContext(512, 121, true);
				this.WriteLiteral(".\r\n        <button type=\"button\" class=\"accept-policy close\" data-dismiss=\"alert\" aria-label=\"Close\" data-cookie-string=\"");
				this.EndContext();
				this.BeginContext(634, 12, false);
				this.Write(cookieString);
				this.EndContext();
				this.BeginContext(646, 403, true);
				this.WriteLiteral("\">\r\n            <span aria-hidden=\"true\">Accept</span>\r\n        </button>\r\n    </div>\r\n    <script>\r\n        (function () {\r\n            var button = document.querySelector(\"#cookieConsent button[data-cookie-string]\");\r\n            button.addEventListener(\"click\", function (event) {\r\n                document.cookie = button.dataset.cookieString;\r\n            }, false);\r\n        })();\r\n    </script>\r\n");
				this.EndContext();
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000247A File Offset: 0x0000067A
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00002482 File Offset: 0x00000682
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000248B File Offset: 0x0000068B
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00002493 File Offset: 0x00000693
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0000249C File Offset: 0x0000069C
		// (set) Token: 0x060000CB RID: 203 RVA: 0x000024A4 File Offset: 0x000006A4
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000024AD File Offset: 0x000006AD
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000024B5 File Offset: 0x000006B5
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000CE RID: 206 RVA: 0x000024BE File Offset: 0x000006BE
		// (set) Token: 0x060000CF RID: 207 RVA: 0x000024C6 File Offset: 0x000006C6
		[Dynamic(new bool[]
		{
			false,
			true
		})]
		[RazorInject]
		public IHtmlHelper<dynamic> Html { [return: Dynamic(new bool[]
		{
			false,
			true
		})] get; [param: Dynamic(new bool[]
		{
			false,
			true
		})] private set; }

		// Token: 0x0400008E RID: 142
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("asp-area", "", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x0400008F RID: 143
		private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("asp-controller", "Panel", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000090 RID: 144
		private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-action", "Privacy", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x04000091 RID: 145
		private string __tagHelperStringValueBuffer;

		// Token: 0x04000092 RID: 146
		private TagHelperExecutionContext __tagHelperExecutionContext;

		// Token: 0x04000093 RID: 147
		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		// Token: 0x04000094 RID: 148
		private TagHelperScopeManager __backed__tagHelperScopeManager;

		// Token: 0x04000095 RID: 149
		private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
	}
}
