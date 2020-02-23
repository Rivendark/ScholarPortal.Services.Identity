using System;
using System.Threading.Tasks;
using ScholarPortal.Services.Identity.Application.DTO;
using ScholarPortal.Services.Identity.Application.Events.External;

namespace ScholarPortal.Services.Identity.Application.Services
{
	public interface IIdentityService
	{
		Task<UserDto> GetAsync(Guid id);
		Task<JwtDto> SignInAsync(EmployeeCreated command);
	}
}