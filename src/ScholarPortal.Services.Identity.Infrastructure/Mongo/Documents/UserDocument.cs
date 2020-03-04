using System;
using System.Collections.Generic;
using Convey.Types;
using ScholarPortal.Services.Identity.Core.Entities;
using ScholarPortal.Services.Identity.Core.Exceptions;

namespace ScholarPortal.Services.Identity.Infrastructure.Mongo.Documents
{
	public class UserDocument : IIdentifiable<Guid>
	{
		private ISet<string> _roles = new HashSet<string>();
		public Guid Id { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string SocialSecurityNumber { get; private set; }
		public DateTime Birthdate { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
		public DateTime? PasswordChanged { get; private set; }
		public Guid? RegistrationToken { get; private set; }
		public DateTime? RegistrationTokenCreated { get; private set; }
		public UserStatus Status { get; private set; }
		public DateTime? SuspendedUntil { get; private set; }
		public DateTime Created { get; private set; }
		public Guid? EmployeeId { get; private set; }

		public ISet<string> Roles
		{
			get => _roles;
			private set => _roles = new HashSet<string>(value);
		}

		public UserDocument(Guid id,
			string firstName,
			string lastName,
			string email,
			string password,
			string socialSecurityNumber,
			DateTime birthdate,
			UserStatus status,
			IEnumerable<string> roles,
			DateTime created,
			DateTime? passwordChanged,
			Guid? registrationToken,
			DateTime? registrationTokenCreated,
			Guid? employeeId,
			DateTime? suspendedUntil = null
		) {
			if (string.IsNullOrWhiteSpace(email))
			{
				throw new InvalidEmailException(email);
			}

			if (string.IsNullOrWhiteSpace(firstName))
			{
				throw new InvalidFirstNameException();
			}
			
			if (string.IsNullOrWhiteSpace(lastName))
			{
				throw new InvalidLastNameException();
			}

			if (birthdate == DateTime.MinValue)
			{
				throw new InvalidBirthDateException(birthdate);
			}

			if (string.IsNullOrWhiteSpace(password))
			{
				throw new InvalidPasswordException();
			}

			Id = id;
			FirstName = firstName;
			LastName = lastName;
			Email = email.ToLowerInvariant();
			Password = password;
			SocialSecurityNumber = socialSecurityNumber;
			Birthdate = birthdate;
			Status = status;
			Created = created;
			PasswordChanged = passwordChanged;
			RegistrationToken = registrationToken;
			RegistrationTokenCreated = registrationTokenCreated;
			SuspendedUntil = suspendedUntil;
			EmployeeId = employeeId;

			foreach (var role in roles)
			{
				if (!UserRoles.IsValid(role))
				{
					throw new InvalidRoleException(role);
				}

				Roles.Add(role.ToLowerInvariant());
			}
		}
	}
}