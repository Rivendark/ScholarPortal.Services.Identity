using System;
using System.Collections.Generic;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace ScholarPortal.Services.Identity.Application.Events.External
{
	[Message("employees")]
	public class EmployeeCreated : IEvent
	{
		public Guid EmployeeId { get; }
		public Guid IdentityId { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string Email { get; }
		public string Password { get; }
		public DateTime Birthday { get; }

		public EmployeeCreated(
			Guid employeeId,
			Guid identityId,
			string firstName,
			string lastName,
			string email,
			string password,
			DateTime birthday
		) {
			EmployeeId = employeeId;
			IdentityId = identityId;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Password = password;
			Birthday = birthday;
		}
	}
}