using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ScholarPortal.Services.Identity.Application.DTO;
using ScholarPortal.Services.Identity.Application.Events.External;

namespace ScholarPortal.Services.Identity.Application.Services.Identity
{
	public class IdentityService : IIdentityService
	{
		private static readonly Regex EmailRegex = new Regex(
			@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
			@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
			RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

		public async Task<UserDto> GetAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<JwtDto> SignInAsync(EmployeeCreated command)
		{
			throw new NotImplementedException();
		}
	}
}