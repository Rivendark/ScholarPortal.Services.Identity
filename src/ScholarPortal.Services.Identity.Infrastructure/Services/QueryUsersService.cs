using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ScholarPortal.Services.Identity.Infrastructure.Mongo.Documents;

namespace ScholarPortal.Services.Identity.Infrastructure.Services
{
	public class QueryUsersService : Infrastructure.QueryUsersService.QueryUsersServiceBase
	{
		private readonly IMongoRepository<UserDocument, Guid> _repository;
		private readonly ILogger<QueryUsersService> _logger;

		public QueryUsersService(IMongoRepository<UserDocument, Guid> repository, ILogger<QueryUsersService> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public override async Task<UserModel> GetUser(UserRequest request, ServerCallContext context)
		{
			var user = await _repository.GetAsync(new Guid(request.IdentityId));
			if (user is null)
			{
				throw new RpcException(new Status(StatusCode.NotFound, $"User not found at id {request.IdentityId}"));
			}
			
			var response = new UserModel
			{
				IdentityId = user.Id.ToString(),
				FirstName = user.FirstName,
				LastName = user.LastName,
				SocialSecurityNumber = user.SocialSecurityNumber,
				Birthdate = user.Birthdate.ToTimestamp(),
				Status = user.Status.ToString().ToLowerInvariant(),
				EmployeeId = user.EmployeeId.ToString()
			};
			foreach (var userRole in user.Roles)
			{
				response.Roles.Add(new UserModel.Types.UserRolesModel {Role = userRole});
			}

			return await Task.FromResult(response);
		}
	}
}