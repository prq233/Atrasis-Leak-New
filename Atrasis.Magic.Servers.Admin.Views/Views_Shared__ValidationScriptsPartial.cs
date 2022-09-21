using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
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
	// Token: 0x0200000C RID: 12
	[Dynamic(new bool[]
	{
		false,
		true
	})]
	[RazorSourceChecksum("SHA1", "1161b4f9c26a241dfca291df40a11895ab0c72a2", "/Views/Shared/_ValidationScriptsPartial.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Shared__ValidationScriptsPartial : RazorPage<object>
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000257D File Offset: 0x0000077D
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

		// Token: 0x060000F4 RID: 244 RVA: 0x00005D54 File Offset: 0x00003F54
		public override async Task ExecuteAsync()
		{
			this.BeginContext(0, 224, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("environment", TagMode.StartTagAndEndTag, "1161b4f9c26a241dfca291df40a11895ab0c72a28368", async delegate
			{
				this.BeginContext(35, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(41, 71, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "1161b4f9c26a241dfca291df40a11895ab0c72a28758", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_0);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(112, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(118, 90, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "1161b4f9c26a241dfca291df40a11895ab0c72a210011", async delegate
				{
				});
				this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = base.CreateTagHelper<UrlResolutionTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_1);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(208, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = base.CreateTagHelper<EnvironmentTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_2.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_2);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(224, 2, true);
			this.WriteLiteral("\r\n");
			this.EndContext();
			this.BeginContext(226, 919, false);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("environment", TagMode.StartTagAndEndTag, "1161b4f9c26a241dfca291df40a11895ab0c72a212272", async delegate
			{
				this.BeginContext(261, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(267, 386, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "1161b4f9c26a241dfca291df40a11895ab0c72a212666", async delegate
				{
					this.BeginContext(638, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = base.CreateTagHelper<ScriptTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_3.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_3);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.FallbackSrc = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_4.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_4);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.FallbackTestExpression = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_5.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_5);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_6);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_7);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(653, 6, true);
				this.WriteLiteral("\r\n    ");
				this.EndContext();
				this.BeginContext(659, 470, false);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "1161b4f9c26a241dfca291df40a11895ab0c72a214748", async delegate
				{
					this.BeginContext(1114, 6, true);
					this.WriteLiteral("\r\n    ");
					this.EndContext();
				});
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = base.CreateTagHelper<ScriptTagHelper>();
				this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_8.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_8);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.FallbackSrc = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_9.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_9);
				this.__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.FallbackTestExpression = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_10.Value;
				this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_10);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_6);
				this.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_11);
				await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
				if (!this.__tagHelperExecutionContext.Output.IsContentModified)
				{
					await this.__tagHelperExecutionContext.SetOutputContentAsync();
				}
				this.Write(this.__tagHelperExecutionContext.Output);
				this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
				this.EndContext();
				this.BeginContext(1129, 2, true);
				this.WriteLiteral("\r\n");
				this.EndContext();
			});
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = base.CreateTagHelper<EnvironmentTagHelper>();
			this.__tagHelperExecutionContext.Add(this.__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
			this.__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Exclude = (string)Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_12.Value;
			this.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_12);
			await this.__tagHelperRunner.RunAsync(this.__tagHelperExecutionContext);
			if (!this.__tagHelperExecutionContext.Output.IsContentModified)
			{
				await this.__tagHelperExecutionContext.SetOutputContentAsync();
			}
			this.Write(this.__tagHelperExecutionContext.Output);
			this.__tagHelperExecutionContext = this.__tagHelperScopeManager.End();
			this.EndContext();
			this.BeginContext(1145, 2, true);
			this.WriteLiteral("\r\n");
			this.EndContext();
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x000025B0 File Offset: 0x000007B0
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x000025B8 File Offset: 0x000007B8
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000025C1 File Offset: 0x000007C1
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x000025C9 File Offset: 0x000007C9
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x000025D2 File Offset: 0x000007D2
		// (set) Token: 0x060000FA RID: 250 RVA: 0x000025DA File Offset: 0x000007DA
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000FB RID: 251 RVA: 0x000025E3 File Offset: 0x000007E3
		// (set) Token: 0x060000FC RID: 252 RVA: 0x000025EB File Offset: 0x000007EB
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000FD RID: 253 RVA: 0x000025F4 File Offset: 0x000007F4
		// (set) Token: 0x060000FE RID: 254 RVA: 0x000025FC File Offset: 0x000007FC
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

		// Token: 0x040000CD RID: 205
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("src", new HtmlString("~/lib/jquery-validation/dist/jquery.validate.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000CE RID: 206
		private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("src", new HtmlString("~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000CF RID: 207
		private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("include", "Development", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D0 RID: 208
		private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.17.0/jquery.validate.min.js", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D1 RID: 209
		private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("asp-fallback-src", "~/lib/jquery-validation/dist/jquery.validate.min.js", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D2 RID: 210
		private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("asp-fallback-test", "window.jQuery && window.jQuery.validator", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D3 RID: 211
		private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("crossorigin", new HtmlString("anonymous"), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D4 RID: 212
		private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("integrity", new HtmlString("sha256-F6h55Qw6sweK+t7SiOJX+2bpSAa3b/fnlrVCJvmEj1A="), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D5 RID: 213
		private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D6 RID: 214
		private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("asp-fallback-src", "~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D7 RID: 215
		private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("asp-fallback-test", "window.jQuery && window.jQuery.validator && window.jQuery.validator.unobtrusive", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D8 RID: 216
		private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("integrity", new HtmlString("sha256-9GycpJnliUjJDVDqP0UEu/bsm9U+3dnQUH8+3W10vkY="), HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000D9 RID: 217
		private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("exclude", "Development", HtmlAttributeValueStyle.DoubleQuotes);

		// Token: 0x040000DA RID: 218
		private string __tagHelperStringValueBuffer;

		// Token: 0x040000DB RID: 219
		private TagHelperExecutionContext __tagHelperExecutionContext;

		// Token: 0x040000DC RID: 220
		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		// Token: 0x040000DD RID: 221
		private TagHelperScopeManager __backed__tagHelperScopeManager;

		// Token: 0x040000DE RID: 222
		private EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;

		// Token: 0x040000DF RID: 223
		private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

		// Token: 0x040000E0 RID: 224
		private ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
	}
}
