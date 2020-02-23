using System;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using ScholarPortal.Services.Identity.Application.DTO;
using ScholarPortal.Services.Identity.Application.Queries;
using ScholarPortal.Services.Identity.Infrastructure.Mongo.Documents;

namespace ScholarPortal.Services.Identity.Infrastructure.Mongo.Queries.Handlers
{
	public class GetUserHandler : IQueryHandler<GetUser, UserDto>
	{
		private readonly IMongoRepository<UserDocument, Guid> _repository;

		public GetUserHandler(IMongoRepository<UserDocument, Guid> repository)
		{
			_repository = repository;
		}
		public async Task<UserDto> HandleAsync(GetUser query)
		{
			var user = await _repository.GetAsync(query.IdentityId);

			return user?.AsDto();
		}
	}
}