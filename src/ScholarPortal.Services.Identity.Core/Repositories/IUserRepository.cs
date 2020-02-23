using System;
using System.Threading.Tasks;
using ScholarPortal.Services.Identity.Core.Entities;

namespace ScholarPortal.Services.Identity.Core.Repositories
{
	public interface IUserRepository
	{
		Task<User> GetAsync(Guid id);
		Task<User> GetByEmployeeIdAsync(Guid id);
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task DeleteAsync(Guid id);
	}
}