using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using ScholarPortal.Services.Identity.Core.Entities;
using ScholarPortal.Services.Identity.Core.Repositories;
using ScholarPortal.Services.Identity.Infrastructure.Mongo.Documents;

namespace ScholarPortal.Services.Identity.Infrastructure.Mongo.Repositories
{
	public class UserMongoRepository : IUserRepository
	{
		private readonly IMongoRepository<UserDocument, Guid> _repository;
		
		public UserMongoRepository(IMongoRepository<UserDocument, Guid> repository)
		{
			_repository = repository;
		}

		public async Task<User> GetAsync(Guid id)
		{
			var user = await _repository.GetAsync(o => o.Id == id);

			return user?.AsEntity();
		}

		public async Task<User> GetByEmployeeIdAsync(Guid id)
		{
			var user = await _repository.GetAsync(o => o.EmployeeId == id);

			return user?.AsEntity();
		}

		public async Task AddAsync(User user)
			=> await _repository.AddAsync(user.AsDocument());

		public async Task UpdateAsync(User user)
			=> await _repository.UpdateAsync(user.AsDocument());

		public async Task DeleteAsync(Guid id)
			=> await _repository.DeleteAsync(id);
	}
}