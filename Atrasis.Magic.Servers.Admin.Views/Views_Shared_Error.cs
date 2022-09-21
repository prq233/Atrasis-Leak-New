using System;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCore
{
	// Token: 0x02000009 RID: 9
	[RazorSourceChecksum("SHA1", "d6a5625cc8fb4476f348b0fe9041c550465d8bf9", "/Views/Shared/Error.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Shared_Error : RazorPage<ErrorViewModel>
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x0000532C File Offset: 0x0000352C
		public override async Task ExecuteAsync()
		{
			base.ViewData["Title"] = "Error";
			this.BeginContext(64, 120, true);
			this.WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n\r\n");
			this.EndContext();
			if (base.Model.ShowRequestId)
			{
				this.BeginContext(214, 52, true);
				this.WriteLiteral("    <p>\r\n        <strong>Request ID:</strong> <code>");
				this.EndContext();
				this.BeginContext(267, 15, false);
				this.Write(base.Model.RequestId);
				this.EndContext();
				this.BeginContext(282, 19, true);
				this.WriteLiteral("</code>\r\n    </p>\r\n");
				this.EndContext();
			}
			this.BeginContext(304, 577, true);
			this.WriteLiteral("\r\n<h3>Development Mode</h3>\r\n<p>\r\n    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.\r\n</p>\r\n<p>\r\n    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>\r\n    It can result in displaying sensitive information from exceptions to end users.\r\n    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>\r\n    and restarting the app.\r\n</p>\r\n");
			this.EndContext();
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000023EA File Offset: 0x000005EA
		// (set) Token: 0x060000BA RID: 186 RVA: 0x000023F2 File Offset: 0x000005F2
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000023FB File Offset: 0x000005FB
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00002403 File Offset: 0x00000603
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000240C File Offset: 0x0000060C
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00002414 File Offset: 0x00000614
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000241D File Offset: 0x0000061D
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00002425 File Offset: 0x00000625
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000242E File Offset: 0x0000062E
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00002436 File Offset: 0x00000636
		[RazorInject]
		public IHtmlHelper<ErrorViewModel> Html { get; private set; }
	}
}
