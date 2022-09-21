using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCore
{
	// Token: 0x0200000E RID: 14
	[Dynamic(new bool[]
	{
		false,
		true
	})]
	[RazorSourceChecksum("SHA1", "7091c65830b0329e613be026ede8a57552863778", "/Views/_ViewStart.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views__ViewStart : RazorPage<object>
	{
		// Token: 0x06000111 RID: 273 RVA: 0x00006034 File Offset: 0x00004234
		public override async Task ExecuteAsync()
		{
			base.Layout = "_Layout";
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00002675 File Offset: 0x00000875
		// (set) Token: 0x06000113 RID: 275 RVA: 0x0000267D File Offset: 0x0000087D
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00002686 File Offset: 0x00000886
		// (set) Token: 0x06000115 RID: 277 RVA: 0x0000268E File Offset: 0x0000088E
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00002697 File Offset: 0x00000897
		// (set) Token: 0x06000117 RID: 279 RVA: 0x0000269F File Offset: 0x0000089F
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000026A8 File Offset: 0x000008A8
		// (set) Token: 0x06000119 RID: 281 RVA: 0x000026B0 File Offset: 0x000008B0
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600011A RID: 282 RVA: 0x000026B9 File Offset: 0x000008B9
		// (set) Token: 0x0600011B RID: 283 RVA: 0x000026C1 File Offset: 0x000008C1
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
	}
}
