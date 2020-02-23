using System.Collections.Generic;
using ScholarPortal.Services.Identity.Application.DTO;
using ScholarPortal.Services.Identity.Core.Entities;

namespace ScholarPortal.Services.Identity.Infrastructure.Mongo.Documents
{
	public static class Extensions
	{
		public static User AsEntity(this UserDocument document)
			=> new User(
				document.Id,
				document.FirstName,
				document.LastName,
				document.Email,
				document.Password,
				document.SocialSecurityNumber,
				document.Birthdate,
				document.Status,
				document.Roles,
				document.Created,
				document.PasswordChanged,
				document.RegistrationToken,
				document.RegistrationTokenCreated,
				document.EmployeeId,
				document.SuspendedUntil
			);
		
		public static UserDocument AsDocument(this User user)
			=> new UserDocument(
				user.Id,
				user.FirstName,
				user.LastName,
				user.Email,
				user.Password,
				user.SocialSecurityNumber,
				user.Birthdate,
				user.Status,
				user.Roles,
				user.Created,
				user.PasswordChanged,
				user.RegistrationToken,
				user.RegistrationTokenCreated,
				user.EmployeeId,
				user.SuspendedUntil
			);
		
		public static UserDto AsDto(this UserDocument document)
			=> new UserDto(
				document.AsEntity()
			);
	}
}