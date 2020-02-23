using System;

namespace ScholarPortal.Services.Identity.Application.Exceptions
{
	public class UserAlreadyExistsException : AppException
	{
		public override string Code => "user_already_created";
		public Guid EmployeeId { get; }
		public Guid IdentityId { get; }
		public UserAlreadyExistsException(Guid eventEmployeeId, Guid eventIdentityId)
			: base($"User with id: {eventIdentityId} was already created.")
		{
			EmployeeId = eventEmployeeId;
			IdentityId = eventIdentityId;
		}
	}
}