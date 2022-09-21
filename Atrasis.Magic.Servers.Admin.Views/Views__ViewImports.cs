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
	// Token: 0x0200000D RID: 13
	[Dynamic(new bool[]
	{
		false,
		true
	})]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views__ViewImports : RazorPage<object>
	{
		// Token: 0x06000105 RID: 261 RVA: 0x00005FF4 File Offset: 0x000041F4
		public override async Task ExecuteAsync()
		{
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00002618 File Offset: 0x00000818
		// (set) Token: 0x06000107 RID: 263 RVA: 0x00002620 File Offset: 0x00000820
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00002629 File Offset: 0x00000829
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00002631 File Offset: 0x00000831
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600010A RID: 266 RVA: 0x0000263A File Offset: 0x0000083A
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00002642 File Offset: 0x00000842
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600010C RID: 268 RVA: 0x0000264B File Offset: 0x0000084B
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00002653 File Offset: 0x00000853
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0000265C File Offset: 0x0000085C
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00002664 File Offset: 0x00000864
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
