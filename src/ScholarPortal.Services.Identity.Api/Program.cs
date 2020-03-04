using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.Types;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScholarPortal.Services.Identity.Application;
using ScholarPortal.Services.Identity.Infrastructure;
using ScholarPortal.Services.Identity.Infrastructure.Services;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace ScholarPortal.Services.Identity.Api
{
	class Program
	{
		public static async Task Main(string[] args)
			=> await CreateWebHostBuilder(args)
				.Build()
				.RunAsync();
		
		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
			=> WebHost.CreateDefaultBuilder(args)
				.ConfigureKestrel(options =>
				{
					options.ListenAnyIP(80,o => o.Protocols = HttpProtocols.Http1AndHttp2);
					options.ListenAnyIP(5001,o => o.Protocols = HttpProtocols.Http2);
				})
				.ConfigureLogging(logging => { logging.AddFilter("Grpc", LogLevel.Debug); })
				.ConfigureServices(services =>
				{
					services
						.AddGrpc(options => { options.EnableDetailedErrors = true; });
					services
						.AddConvey()
						.AddWebApi()
						.AddApplication()
						.AddInfrastructure()
						.Build();
				})
				.Configure(app =>
					{
						app.UseRouting()
							.UseEndpoints(endpoints => endpoints
								.MapGrpcService<QueryUsersService>()
							);
						app
							.UseInfrastructure()
							.UseEndpoints(endpoints => endpoints
								.Get("",
									ctx => ctx.Response.WriteAsync(ctx.RequestServices.GetService<AppOptions>().Name))
							);
					}
				)
				.UseLogging();
	}
}