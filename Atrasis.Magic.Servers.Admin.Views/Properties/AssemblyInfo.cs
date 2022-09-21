using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using AspNetCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Razor.Hosting;

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: RazorCompiledItem(typeof(Views_Panel_Index), "mvc.1.0.view", "/Views/Panel/Index.cshtml")]
[assembly: RazorView("/Views/Panel/Index.cshtml", typeof(Views_Panel_Index))]
[assembly: RazorCompiledItem(typeof(Views_Panel_Login), "mvc.1.0.view", "/Views/Panel/Login.cshtml")]
[assembly: RazorView("/Views/Panel/Login.cshtml", typeof(Views_Panel_Login))]
[assembly: RazorCompiledItem(typeof(Views_Panel_Logs), "mvc.1.0.view", "/Views/Panel/Logs.cshtml")]
[assembly: RazorView("/Views/Panel/Logs.cshtml", typeof(Views_Panel_Logs))]
[assembly: RazorCompiledItem(typeof(Views_Panel_ServerEvents), "mvc.1.0.view", "/Views/Panel/ServerEvents.cshtml")]
[assembly: RazorView("/Views/Panel/ServerEvents.cshtml", typeof(Views_Panel_ServerEvents))]
[assembly: RazorCompiledItem(typeof(Views_Panel_Servers), "mvc.1.0.view", "/Views/Panel/Servers.cshtml")]
[assembly: RazorView("/Views/Panel/Servers.cshtml", typeof(Views_Panel_Servers))]
[assembly: RazorCompiledItem(typeof(Views_Panel_UserProfile), "mvc.1.0.view", "/Views/Panel/UserProfile.cshtml")]
[assembly: RazorView("/Views/Panel/UserProfile.cshtml", typeof(Views_Panel_UserProfile))]
[assembly: RazorCompiledItem(typeof(Views_Panel_Users), "mvc.1.0.view", "/Views/Panel/Users.cshtml")]
[assembly: RazorView("/Views/Panel/Users.cshtml", typeof(Views_Panel_Users))]
[assembly: RazorCompiledItem(typeof(Views_Shared_Error), "mvc.1.0.view", "/Views/Shared/Error.cshtml")]
[assembly: RazorView("/Views/Shared/Error.cshtml", typeof(Views_Shared_Error))]
[assembly: RazorCompiledItem(typeof(Views_Shared__CookieConsentPartial), "mvc.1.0.view", "/Views/Shared/_CookieConsentPartial.cshtml")]
[assembly: RazorView("/Views/Shared/_CookieConsentPartial.cshtml", typeof(Views_Shared__CookieConsentPartial))]
[assembly: RazorCompiledItem(typeof(Views_Shared__Layout), "mvc.1.0.view", "/Views/Shared/_Layout.cshtml")]
[assembly: RazorView("/Views/Shared/_Layout.cshtml", typeof(Views_Shared__Layout))]
[assembly: RazorCompiledItem(typeof(Views_Shared__ValidationScriptsPartial), "mvc.1.0.view", "/Views/Shared/_ValidationScriptsPartial.cshtml")]
[assembly: RazorView("/Views/Shared/_ValidationScriptsPartial.cshtml", typeof(Views_Shared__ValidationScriptsPartial))]
[assembly: RazorCompiledItem(typeof(Views__ViewImports), "mvc.1.0.view", "/Views/_ViewImports.cshtml")]
[assembly: RazorView("/Views/_ViewImports.cshtml", typeof(Views__ViewImports))]
[assembly: RazorCompiledItem(typeof(Views__ViewStart), "mvc.1.0.view", "/Views/_ViewStart.cshtml")]
[assembly: RazorView("/Views/_ViewStart.cshtml", typeof(Views__ViewStart))]
[assembly: ProvideApplicationPartFactory("Microsoft.AspNetCore.Mvc.ApplicationParts.CompiledRazorAssemblyApplicationPartFactory, Microsoft.AspNetCore.Mvc.Razor")]
[assembly: AssemblyCompany("Atrasis.Magic.Servers.Admin")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyProduct("Atrasis.Magic.Servers.Admin")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyTitle("Atrasis.Magic.Servers.Admin.Views")]
