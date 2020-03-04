using System;
using Convey.CQRS.Events;

namespace ScholarPortal.Services.Identity.Application.Events.External
{
	public class EmployeeAdded : IEvent
	{
		public Guid EmployeeId { get; }
		public Guid IdentityId { get; }

		public EmployeeAdded(
			Guid employeeId,
			Guid identityId
		)
		{
			EmployeeId = employeeId;
			IdentityId = identityId;
		}
	}
}