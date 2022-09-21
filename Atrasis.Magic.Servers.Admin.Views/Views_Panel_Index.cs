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
	// Token: 0x02000002 RID: 2
	[RazorSourceChecksum("SHA1", "f58f8f161376e40266b93c71a40e4809f7ba351b", "/Views/Panel/Index.cshtml")]
	[RazorSourceChecksum("SHA1", "70597ae65e7f66ff7f03332aa3841371e4e2ac1e", "/Views/_ViewImports.cshtml")]
	public class Views_Panel_Index : RazorPage<IndexModel>
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00003088 File Offset: 0x00001288
		public override async Task ExecuteAsync()
		{
			base.ViewData["Title"] = "Dashboard";
			this.BeginContext(91, 582, true);
			this.WriteLiteral("\r\n<div class=\"section__content section__content--p30\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row m-t-25\">\r\n            <div class=\"col-sm-6 col-lg-3\">\r\n                <div class=\"overview-item overview-item--c1\">\r\n                    <div class=\"overview__inner\">\r\n                        <div class=\"overview-box clearfix\">\r\n                            <div class=\"icon\">\r\n                                <i class=\"zmdi zmdi-account-o\"></i>\r\n                            </div>\r\n                            <div class=\"text\">\r\n                                <h2>");
			this.EndContext();
			this.BeginContext(674, 21, false);
			this.Write(base.Model.TotalUsers);
			this.EndContext();
			this.BeginContext(695, 815, true);
			this.WriteLiteral("</h2>\r\n                                <span>Total Users</span>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"overview-chart\">\r\n                            <canvas id=\"totalUsersChart\"></canvas>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-sm-6 col-lg-3\">\r\n                <div class=\"overview-item overview-item--c2\">\r\n                    <div class=\"overview__inner\">\r\n                        <div class=\"overview-box clearfix\">\r\n                            <div class=\"icon\">\r\n                                <i class=\"zmdi zmdi-accounts\"></i>\r\n                            </div>\r\n                            <div class=\"text\">\r\n                                <h2>");
			this.EndContext();
			this.BeginContext(1511, 27, false);
			this.Write(base.Model.DailyActiveUsers);
			this.EndContext();
			this.BeginContext(1538, 831, true);
			this.WriteLiteral("</h2>\r\n                                <span>Daily Active Users</span>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"overview-chart\">\r\n                            <canvas id=\"dailyActiveUsersChart\"></canvas>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-sm-6 col-lg-3\">\r\n                <div class=\"overview-item overview-item--c3\">\r\n                    <div class=\"overview__inner\">\r\n                        <div class=\"overview-box clearfix\">\r\n                            <div class=\"icon\">\r\n                                <i class=\"zmdi zmdi-account-add\"></i>\r\n                            </div>\r\n                            <div class=\"text\">\r\n                                <h2>");
			this.EndContext();
			this.BeginContext(2370, 19, false);
			this.Write(base.Model.NewUsers);
			this.EndContext();
			this.BeginContext(2389, 808, true);
			this.WriteLiteral("</h2>\r\n                                <span>New Users</span>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"overview-chart\">\r\n                            <canvas id=\"newUsersChart\"></canvas>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-sm-6 col-lg-3\">\r\n                <div class=\"overview-item overview-item--c4\">\r\n                    <div class=\"overview__inner\">\r\n                        <div class=\"overview-box clearfix\">\r\n                            <div class=\"icon\">\r\n                                <i class=\"zmdi zmdi-globe\"></i>\r\n                            </div>\r\n                            <div class=\"text\">\r\n                                <h2>");
			this.EndContext();
			this.BeginContext(3198, 22, false);
			this.Write(base.Model.OnlineUsers);
			this.EndContext();
			this.BeginContext(3220, 1375, true);
			this.WriteLiteral("</h2>\r\n                                <span>Online Users</span>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"overview-chart\">\r\n                            <canvas id=\"onlineUsersChart\"></canvas>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <div class=\"au-card chart-percent-card\">\r\n                    <div class=\"au-card-inner\">\r\n                        <h3 class=\"title-2 tm-b-5\">Users by Country</h3>\r\n                        <div class=\"row no-gutters\">\r\n                            <div class=\"col-xl-12\">\r\n                                <div class=\"percent-chart\">\r\n                                    <canvas id=\"usersByCountryChart\"></canvas>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </d");
			this.WriteLiteral("iv>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"copyright\">\r\n                    <p>\r\n                        Copyright © 2019 Atrasis. All rights reserved.\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
			this.EndContext();
			this.DefineSection("scripts", async delegate()
			{
				this.BeginContext(4613, 287, true);
				this.WriteLiteral("\r\n    <script>\r\n        var ctx = document.getElementById(\"totalUsersChart\");\r\n        if (ctx) {\r\n            ctx.height = 130;\r\n            var myChart = new Chart(ctx,\r\n                {\r\n                    type: 'line',\r\n                    data: {\r\n                        labels: ");
				this.EndContext();
				this.BeginContext(4901, 59, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.TotalUsersChart.Labels)));
				this.EndContext();
				this.BeginContext(4960, 148, true);
				this.WriteLiteral(",\r\n                        type: 'line',\r\n                        datasets: [\r\n                            {\r\n                                data: ");
				this.EndContext();
				this.BeginContext(5109, 58, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.TotalUsersChart.Datas)));
				this.EndContext();
				this.BeginContext(5167, 2612, true);
				this.WriteLiteral(",\r\n                                label: 'Dataset',\r\n                                backgroundColor: 'rgba(255,255,255,.1)',\r\n                                borderColor: 'rgba(255,255,255,.55)',\r\n                            }\r\n                        ]\r\n                    },\r\n                    options: {\r\n                        maintainAspectRatio: true,\r\n                        legend: {\r\n                            display: false\r\n                        },\r\n                        layout: {\r\n                            padding: {\r\n                                left: 0,\r\n                                right: 0,\r\n                                top: 0,\r\n                                bottom: 0\r\n                            }\r\n                        },\r\n                        responsive: true,\r\n                        scales: {\r\n                            xAxes: [\r\n                                {\r\n                                    gridLines: {\r\n                                        color: '");
				this.WriteLiteral("transparent',\r\n                                        zeroLineColor: 'transparent'\r\n                                    },\r\n                                    ticks: {\r\n                                        fontSize: 2,\r\n                                        fontColor: 'transparent'\r\n                                    }\r\n                                }\r\n                            ],\r\n                            yAxes: [\r\n                                {\r\n                                    display: false,\r\n                                    ticks: {\r\n                                        display: false,\r\n                                    }\r\n                                }\r\n                            ]\r\n                        },\r\n                        title: {\r\n                            display: false,\r\n                        },\r\n                        elements: {\r\n                            line: {\r\n                                borderWidth: 0\r\n                            },\r\n    ");
				this.WriteLiteral("                        point: {\r\n                                radius: 0,\r\n                                hitRadius: 10,\r\n                                hoverRadius: 4\r\n                            }\r\n                        }\r\n                    }\r\n                });\r\n        }\r\n        var ctx = document.getElementById(\"dailyActiveUsersChart\");\r\n        if (ctx) {\r\n            ctx.height = 130;\r\n            var myChart = new Chart(ctx,\r\n                {\r\n                    type: 'line',\r\n                    data: {\r\n                        labels: ");
				this.EndContext();
				this.BeginContext(7780, 65, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.DailyActiveUsersChart.Labels)));
				this.EndContext();
				this.BeginContext(7845, 148, true);
				this.WriteLiteral(",\r\n                        type: 'line',\r\n                        datasets: [\r\n                            {\r\n                                data: ");
				this.EndContext();
				this.BeginContext(7994, 64, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.DailyActiveUsersChart.Datas)));
				this.EndContext();
				this.BeginContext(8058, 2604, true);
				this.WriteLiteral(",\r\n                                label: 'Dataset',\r\n                                backgroundColor: 'rgba(255,255,255,.1)',\r\n                                borderColor: 'rgba(255,255,255,.55)',\r\n                            }\r\n                        ]\r\n                    },\r\n                    options: {\r\n                        maintainAspectRatio: true,\r\n                        legend: {\r\n                            display: false\r\n                        },\r\n                        layout: {\r\n                            padding: {\r\n                                left: 0,\r\n                                right: 0,\r\n                                top: 0,\r\n                                bottom: 0\r\n                            }\r\n                        },\r\n                        responsive: true,\r\n                        scales: {\r\n                            xAxes: [\r\n                                {\r\n                                    gridLines: {\r\n                                        color: '");
				this.WriteLiteral("transparent',\r\n                                        zeroLineColor: 'transparent'\r\n                                    },\r\n                                    ticks: {\r\n                                        fontSize: 2,\r\n                                        fontColor: 'transparent'\r\n                                    }\r\n                                }\r\n                            ],\r\n                            yAxes: [\r\n                                {\r\n                                    display: false,\r\n                                    ticks: {\r\n                                        display: false,\r\n                                    }\r\n                                }\r\n                            ]\r\n                        },\r\n                        title: {\r\n                            display: false,\r\n                        },\r\n                        elements: {\r\n                            line: {\r\n                                borderWidth: 0\r\n                            },\r\n    ");
				this.WriteLiteral("                        point: {\r\n                                radius: 0,\r\n                                hitRadius: 10,\r\n                                hoverRadius: 4\r\n                            }\r\n                        }\r\n                    }\r\n                });\r\n        }\r\n        var ctx = document.getElementById(\"newUsersChart\");\r\n        if (ctx) {\r\n            ctx.height = 130;\r\n            var myChart = new Chart(ctx,\r\n                {\r\n                    type: 'line',\r\n                    data: {\r\n                        labels: ");
				this.EndContext();
				this.BeginContext(10663, 57, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.NewUsersChart.Labels)));
				this.EndContext();
				this.BeginContext(10720, 148, true);
				this.WriteLiteral(",\r\n                        type: 'line',\r\n                        datasets: [\r\n                            {\r\n                                data: ");
				this.EndContext();
				this.BeginContext(10869, 56, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.NewUsersChart.Datas)));
				this.EndContext();
				this.BeginContext(10925, 2607, true);
				this.WriteLiteral(",\r\n                                label: 'Dataset',\r\n                                backgroundColor: 'rgba(255,255,255,.1)',\r\n                                borderColor: 'rgba(255,255,255,.55)',\r\n                            }\r\n                        ]\r\n                    },\r\n                    options: {\r\n                        maintainAspectRatio: true,\r\n                        legend: {\r\n                            display: false\r\n                        },\r\n                        layout: {\r\n                            padding: {\r\n                                left: 0,\r\n                                right: 0,\r\n                                top: 0,\r\n                                bottom: 0\r\n                            }\r\n                        },\r\n                        responsive: true,\r\n                        scales: {\r\n                            xAxes: [\r\n                                {\r\n                                    gridLines: {\r\n                                        color: '");
				this.WriteLiteral("transparent',\r\n                                        zeroLineColor: 'transparent'\r\n                                    },\r\n                                    ticks: {\r\n                                        fontSize: 2,\r\n                                        fontColor: 'transparent'\r\n                                    }\r\n                                }\r\n                            ],\r\n                            yAxes: [\r\n                                {\r\n                                    display: false,\r\n                                    ticks: {\r\n                                        display: false,\r\n                                    }\r\n                                }\r\n                            ]\r\n                        },\r\n                        title: {\r\n                            display: false,\r\n                        },\r\n                        elements: {\r\n                            line: {\r\n                                borderWidth: 0\r\n                            },\r\n    ");
				this.WriteLiteral("                        point: {\r\n                                radius: 0,\r\n                                hitRadius: 10,\r\n                                hoverRadius: 4\r\n                            }\r\n                        }\r\n                    }\r\n                });\r\n        }\r\n        var ctx = document.getElementById(\"onlineUsersChart\");\r\n        if (ctx) {\r\n            ctx.height = 130;\r\n            var myChart = new Chart(ctx,\r\n                {\r\n                    type: 'line',\r\n                    data: {\r\n                        labels: ");
				this.EndContext();
				this.BeginContext(13533, 60, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.OnlineUsersChart.Labels)));
				this.EndContext();
				this.BeginContext(13593, 148, true);
				this.WriteLiteral(",\r\n                        type: 'line',\r\n                        datasets: [\r\n                            {\r\n                                data: ");
				this.EndContext();
				this.BeginContext(13742, 59, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.OnlineUsersChart.Datas)));
				this.EndContext();
				this.BeginContext(13801, 2480, true);
				this.WriteLiteral(",\r\n                                label: 'Dataset',\r\n                                backgroundColor: 'rgba(255,255,255,.1)',\r\n                                borderColor: 'rgba(255,255,255,.55)',\r\n                            }\r\n                        ]\r\n                    },\r\n                    options: {\r\n                        maintainAspectRatio: true,\r\n                        legend: {\r\n                            display: false\r\n                        },\r\n                        layout: {\r\n                            padding: {\r\n                                left: 0,\r\n                                right: 0,\r\n                                top: 0,\r\n                                bottom: 0\r\n                            }\r\n                        },\r\n                        responsive: true,\r\n                        scales: {\r\n                            xAxes: [\r\n                                {\r\n                                    gridLines: {\r\n                                        color: '");
				this.WriteLiteral("transparent',\r\n                                        zeroLineColor: 'transparent'\r\n                                    },\r\n                                    ticks: {\r\n                                        fontSize: 2,\r\n                                        fontColor: 'transparent'\r\n                                    }\r\n                                }\r\n                            ],\r\n                            yAxes: [\r\n                                {\r\n                                    display: false,\r\n                                    ticks: {\r\n                                        display: false,\r\n                                    }\r\n                                }\r\n                            ]\r\n                        },\r\n                        title: {\r\n                            display: false,\r\n                        },\r\n                        elements: {\r\n                            line: {\r\n                                borderWidth: 0\r\n                            },\r\n    ");
				this.WriteLiteral("                        point: {\r\n                                radius: 0,\r\n                                hitRadius: 10,\r\n                                hoverRadius: 4\r\n                            }\r\n                        }\r\n                    }\r\n                });\r\n        }\r\n        var ctx = document.getElementById(\"usersByCountryChart\");\r\n        if (ctx) {\r\n            ctx.height = 250;\r\n\r\n            var labels = ");
				this.EndContext();
				this.BeginContext(16282, 63, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.UsersByCountryChart.Labels)));
				this.EndContext();
				this.BeginContext(16345, 281, true);
				this.WriteLiteral(";\r\n\r\n            var myChart = new Chart(ctx,\r\n                {\r\n                    type: 'doughnut',\r\n                    data: {\r\n                        labels: labels,\r\n                        datasets: [\r\n                            {\r\n                                data: ");
				this.EndContext();
				this.BeginContext(16627, 62, false);
				this.Write(this.Html.Raw(this.Json.Serialize(base.Model.UsersByCountryChart.Datas)));
				this.EndContext();
				this.BeginContext(16689, 919, true);
				this.WriteLiteral(",\r\n                                backgroundColor: [\r\n                                    \"rgba(0, 123, 255,0.9)\",\r\n                                    \"rgba(0, 123, 255,0.7)\",\r\n                                    \"rgba(0, 123, 255,0.5)\",\r\n                                    \"rgba(0, 123, 255,0.3)\",\r\n                                    \"rgba(0,0,0,0.07)\"\r\n                                ],\r\n                                hoverBackgroundColor: [\r\n                                    \"rgba(0, 123, 255,0.9)\",\r\n                                    \"rgba(0, 123, 255,0.7)\",\r\n                                    \"rgba(0, 123, 255,0.5)\",\r\n                                    \"rgba(0, 123, 255,0.3)\",\r\n                                    \"rgba(0,0,0,0.07)\"\r\n                                ]\r\n                            }\r\n                        ]\r\n                    }\r\n                });\r\n        }\r\n    </script>\r\n");
				this.EndContext();
			});
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002058 File Offset: 0x00000258
		[RazorInject]
		public IJsonHelper Json { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000005 RID: 5 RVA: 0x00002069 File Offset: 0x00000269
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000007 RID: 7 RVA: 0x0000207A File Offset: 0x0000027A
		[RazorInject]
		public IUrlHelper Url { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002083 File Offset: 0x00000283
		// (set) Token: 0x06000009 RID: 9 RVA: 0x0000208B File Offset: 0x0000028B
		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002094 File Offset: 0x00000294
		// (set) Token: 0x0600000B RID: 11 RVA: 0x0000209C File Offset: 0x0000029C
		[RazorInject]
		public IHtmlHelper<IndexModel> Html { get; private set; }
	}
}
