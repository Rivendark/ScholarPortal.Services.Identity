using System;
using System.Collections.Generic;
using ScholarPortal.Services.Identity.Core.Entities;

namespace ScholarPortal.Services.Identity.Application.DTO
{
	public class UserDto
	{
		private ISet<string> _roles = new HashSet<string>();
		public Guid Id { get; private set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string SocialSecurityNumber { get; private set; }
		public DateTime Birthdate { get; private set; }
		public string Email { get; set; }
		public DateTime Created { get; private set; }
		public UserStatus Status { get; set; }
		public Guid? EmployeeId { get; set; }

		public UserDto()
		{
		}

		public UserDto(User user)
		{
			Id = user.Id;
			FirstName = user.FirstName;
			LastName = user.LastName;
			SocialSecurityNumber = user.SocialSecurityNumber;
			Birthdate = user.Birthdate;
			Email = user.Email;
			Created = user.Created;
			Status = user.Status;
			EmployeeId = user.EmployeeId;
		}
	}
}