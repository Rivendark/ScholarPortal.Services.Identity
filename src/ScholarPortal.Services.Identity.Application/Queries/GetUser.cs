using System;
using Convey.CQRS.Queries;
using ScholarPortal.Services.Identity.Application.DTO;

namespace ScholarPortal.Services.Identity.Application.Queries
{
	public class GetUser : IQuery<UserDto>
	{
		public Guid IdentityId { get; set; }
	}
}