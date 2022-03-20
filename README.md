# Ans.Net6.Web

[PROJECT]

    <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="5.0.13" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.1" />
    <PackageReference Include="NLog" Version="4.7.13" />
    <PackageReference Include="NLog.Web.AspNetCore" Version="4.14.0" />



[Program.cs]

using Ans.Net6.Web;
using Ans.Net6.Web.Nodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                .ConfigureNLog("_nlog.config")
                .GetCurrentClassLogger();
            try
            {
                logger.Debug("Program Main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(o =>
                {
                    o.UseStartup<Startup>();
                })
                .ConfigureLogging(o =>
                {
                    o.ClearProviders();
                    o.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
        }
    }



    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAnsNet5Web();
            services.AddSingleton<IMapNodesProvider, MapNodes_JsonProvider>();
            //services.AddSingleton<IEmailSender, EmailSenderService>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseAnsNet5WebErrors();
                //app.UseDeveloperExceptionPage();
                //app.UseStatusCodePages();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseAnsNet5WebErrors();
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(o =>
            {
                o.MapControllers();
                o.MapRazorPages();
                o.MapControllerRoute("Nodes", "{*path}",
                    new { controller = "Nodes", action = "Index", path = "start" });
            });
        }
    }



[appsettings.json]
	
	"Ans.Net6.Web": {
		"Debug": false,
		"MailService": {
			"DefaultFromTitle": "",
			"DefaultFromAddress": "",
			"SmtpServer": "",
			"SmtpPort": 0,
			"SmtpUseSsl": false,
			"SmtpUsername": "",
			"SmtpPassword": ""
		}
	}



[_nlog.config]

<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" autoReload="true" internalLogLevel="Off" internalLogFile="c:\temp\internal-nlog-AspNetCore.txt">

	<extensions>
		<add assembly="NLog.Web.AspNetCore"/>
	</extensions>

	<variable name="siteName" value="SimpleSiteEngine" />
	<variable name="logDirectory" value="C:/inetpub/wwwroot/_LOGS/${siteName}/${date:format=yyyy-0MM}" />
	<variable name="logFile" value="${logDirectory}/${level}_${shortdate}.log" />

	<targets>
		<target xsi:type="File" name="defaultLog" fileName="${logFile}" layout="$${longdate}|${event-properties:item=EventId_Id:whenEmpty=0}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}|url: ${aspnet-request-url}|action: ${aspnet-mvc-action}|${callsite}| body: ${aspnet-request-posted-body}" />
		<!--
		<target xsi:type="File" name="allfile" fileName="c:\temp\nlog-AspNetCore-all-${shortdate}.log" layout="${longdate}|${event-properties:item=EventId_Id:whenEmpty=0}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}" />
		<target xsi:type="File" name="ownFile-web" fileName="c:\temp\nlog-AspNetCore-own-${shortdate}.log" layout="${longdate}|${event-properties:item=EventId_Id:whenEmpty=0}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}|url: ${aspnet-request-url}|action: ${aspnet-mvc-action}|${callsite}| body: ${aspnet-request-posted-body}" />
		<target xsi:type="Console" name="lifetimeConsole" layout="${level:truncate=4:lowercase=true}: ${logger}[0]${newline}      ${message}${exception:format=tostring}" /> -->
	</targets>

	<rules>
		<logger name="*" minlevel="Info" writeTo="defaultLog" />
		<!--
		All logs, including from Microsoft
		<logger name="*" minlevel="Trace" writeTo="allfile" /> -->
		<!--
		Output hosting lifetime messages to console target for faster startup detection
		<logger name="Microsoft.Hosting.Lifetime" minlevel="Info" writeTo="lifetimeConsole, ownFile-web" final="true" /> -->
		<!--
		Skip non-critical Microsoft logs and so log only own logs (BlackHole)
		<logger name="Microsoft.*" maxlevel="Info" final="true" />
		<logger name="System.Net.Http.*" maxlevel="Info" final="true" />
		<logger name="*" minlevel="Trace" writeTo="ownFile-web" /> -->
	</rules>

</nlog>



[_nodes.json]

{
  "title": "Стартовый узел",
  "slaves": [
    {
      "name": "node1",
      "title": "Узел 1"
    }
  ]
}



[/Areas/_ViewImports.cshtml]
	
@using Ans.SimpleSiteEngine.WebApp

@using Ans.Net6.Common
@using Ans.Net6.Web
@using Ans.Net6.Web.Nodes
@using System.Text
@using Microsoft.AspNetCore.Html
@inject ISiteContext Site
@inject INodeContext Node
@inject IPageContext Page
@inject ICurrentContext Current
@inject IMapNodesProvider MapNodes
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
@addTagHelper "*, Ans.Net6.Web"



[/Areas/Errors/Pages/_viewstart.cshtml]
	
@{
	Layout = "~/Views/Shared/_Layout.cshtml";
}



[/Controllers/NodesController.cs]

    public class NodesController
        : _NodesController_Base
    {

        public NodesController(
            ILogger<NodesController> logger,
            IViewRenderService viewRender,
            IMapNodesProvider mapNodes,
            ICurrentContext currentContext)
            : base(logger, viewRender, mapNodes, currentContext)
        {
        }


        public override void CurrentNodeRelease()
        {
            base.CurrentNodeRelease();
        }


        [Route("vader/reset")]
        public IActionResult Refresh()
        {
            MapNodes.Refresh();
            return Content("Refresh complete."); ;
        }

    }


    /targets/schools/learn

    /targets
        /schools
            /learn