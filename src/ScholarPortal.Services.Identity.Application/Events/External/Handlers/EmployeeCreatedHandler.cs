using System.Threading.Tasks;
using Convey.CQRS.Events;
using Microsoft.Extensions.Logging;
using ScholarPortal.Services.Identity.Application.Exceptions;
using ScholarPortal.Services.Identity.Application.Services;
using ScholarPortal.Services.Identity.Core.Entities;
using ScholarPortal.Services.Identity.Core.Repositories;

namespace ScholarPortal.Services.Identity.Application.Events.External.Handlers
{
	public class EmployeeCreatedHandler : IEventHandler<EmployeeCreated>
	{
		private readonly IUserRepository  _userRepository;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly ILogger<EmployeeCreatedHandler> _logger;

		public EmployeeCreatedHandler(IUserRepository userRepository,
			IDateTimeProvider dateTimeProvider,
			ILogger<EmployeeCreatedHandler> logger
		) {
			_userRepository = userRepository;
			_dateTimeProvider = dateTimeProvider;
			_logger = logger;
		}

		public async Task HandleAsync(EmployeeCreated @event)
		{
			var user = await _userRepository.GetAsync(@event.IdentityId);
			if (user is {})
			{
				throw new UserAlreadyExistsException(@event.EmployeeId, @event.IdentityId);
			}

			var employeeUser = await _userRepository.GetAsync(@event.EmployeeId);
			if (employeeUser is {})
			{
				throw new UserAlreadyExistsException(@event.EmployeeId, @event.IdentityId);
			}

			user = new User(
				@event.IdentityId, 
				@event.FirstName,
				@event.LastName,
				@event.Email,
				@event.Password,
				@event.Birthday,
				@event.EmployeeId
			);
			user.Created = _dateTimeProvider.Now;
			user.AddRole(UserRoles.Faculty);
			await _userRepository.AddAsync(user);
		}
	}
}