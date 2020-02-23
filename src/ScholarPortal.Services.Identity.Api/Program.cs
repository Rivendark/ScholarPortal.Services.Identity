using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.Types;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ScholarPortal.Services.Identity.Application;
using ScholarPortal.Services.Identity.Infrastructure;
using QueryUsersService = ScholarPortal.Services.Identity.Infrastructure.Services.QueryUsersService;

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
				.ConfigureServices(services =>
				{
					services
						.AddGrpc();
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