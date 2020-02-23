using Convey;
using Convey.Logging.CQRS;
using Microsoft.Extensions.DependencyInjection;
using ScholarPortal.Services.Identity.Application.Commands;

namespace ScholarPortal.Services.Identity.Infrastructure.Logging
{
	internal static class Extensions
	{
		public static IConveyBuilder AddHandlersLogging(this IConveyBuilder builder)
		{
			var assembly = typeof(CreateUser).Assembly;
            
			builder.Services.AddSingleton<IMessageToLogTemplateMapper>(new MessageToLogTemplateMapper());
            
			return builder
				.AddCommandHandlersLogging(assembly)
				.AddEventHandlersLogging(assembly);
		}
	}
}