using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Helper
{
	// Token: 0x02000023 RID: 35
	public static class ResponseBuilder
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x00003DE4 File Offset: 0x00001FE4
		public static JObject BuildResponse(this Controller controller, HttpStatusCode successCode)
		{
			JObject jobject = new JObject();
			jobject.Add("success", (int)successCode);
			controller.Response.StatusCode = (int)successCode;
			return jobject;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00002980 File Offset: 0x00000B80
		public static JObject AddAttribute(this JObject obj, string attribute, JToken content)
		{
			obj.Add(attribute, content);
			return obj;
		}
	}
}
