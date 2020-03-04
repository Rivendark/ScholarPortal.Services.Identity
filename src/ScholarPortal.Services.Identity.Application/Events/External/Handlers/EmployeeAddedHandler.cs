using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Microsoft.Extensions.Logging;
using ScholarPortal.Services.Identity.Application.Exceptions;
using ScholarPortal.Services.Identity.Core.Repositories;

namespace ScholarPortal.Services.Identity.Application.Events.External.Handlers
{
	public class EmployeeAddedHandler : IEventHandler<EmployeeAdded>
	{
		private readonly IUserRepository _userRepository;
		private readonly ILogger<EmployeeAddedHandler> _logger;

		public EmployeeAddedHandler(IUserRepository repository, ILogger<EmployeeAddedHandler> logger)
		{
			_userRepository = repository;
			_logger = logger;
		}

		public async Task HandleAsync(EmployeeAdded @event)
		{
			var user = await _userRepository.GetAsync(@event.IdentityId);
			if (user is {})
			{
				throw new UserAlreadyExistsException(@event.EmployeeId, @event.IdentityId);
			}

			if (user.EmployeeId.HasValue && user.EmployeeId != Guid.Empty)
			{
				throw new EmployeeAlreadySet(@event.EmployeeId, @event.IdentityId);
			}

			var employeeUser = await _userRepository.GetAsync(@event.EmployeeId);
			if (employeeUser is {})
			{
				throw new UserAlreadyExistsException(@event.EmployeeId, @event.IdentityId);
			}
			
			_logger.LogDebug($"Employee added to User: {@event.IdentityId} with ID: {@event.EmployeeId}");
			user.EmployeeId = @event.EmployeeId;
			await _userRepository.UpdateAsync(user);
		}
	}
}