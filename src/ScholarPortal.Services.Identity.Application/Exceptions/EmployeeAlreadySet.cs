using System;

namespace ScholarPortal.Services.Identity.Application.Exceptions
{
	public class EmployeeAlreadySet : AppException
	{
		public override string Code => "user_already_has_employee";
		public Guid EmployeeId { get; }
		public Guid IdentityId { get; }
		public EmployeeAlreadySet(Guid eventEmployeeId, Guid eventIdentityId)
			: base($"User {eventIdentityId} already has employee id: {eventEmployeeId}.")
		{
			EmployeeId = eventEmployeeId;
			IdentityId = eventIdentityId;
		}
	}
}