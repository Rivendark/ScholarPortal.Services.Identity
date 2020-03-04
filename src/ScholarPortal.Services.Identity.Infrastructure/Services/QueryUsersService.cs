using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ScholarPortal.Protos.Users;
using ScholarPortal.Services.Identity.Core.Entities;
using ScholarPortal.Services.Identity.Infrastructure.Mongo.Documents;

namespace ScholarPortal.Services.Identity.Infrastructure.Services
{
	public class QueryUsersService : Protos.Users.QueryUsersService.QueryUsersServiceBase
	{
		private readonly IMongoRepository<UserDocument, Guid> _repository;
		private readonly ILogger<QueryUsersService> _logger;

		public QueryUsersService(IMongoRepository<UserDocument, Guid> repository, ILogger<QueryUsersService> logger)
		{
			_repository = repository;
			_logger = logger;
			_logger.LogError("Inside QueryUserService.");
		}

		public override async Task<UserModel> GetUser(UserRequest request, ServerCallContext context)
		{
			_logger.LogError($"Fetching user with ID: {request.IdentityId}");
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
				Email = user.Email,
				Created = user.Created.ToTimestamp(),
				Status = FindUserStatus(user.Status),
				EmployeeId = user.EmployeeId.ToString()
			};
			foreach (var userRole in user.Roles)
			{
				response.Roles.Add(new UserModel.Types.UserRolesModel {Role = FindUserRole(userRole)});
			}

			return await Task.FromResult(response);
		}

		private static UserModel.Types.UserStatusEnumModel FindUserStatus(UserStatus status)
		{
			switch (status)
			{
				case UserStatus.Created:
					return UserModel.Types.UserStatusEnumModel.Created;
				case UserStatus.Invalid:
					return UserModel.Types.UserStatusEnumModel.Invalid;
				case UserStatus.Registered:
					return UserModel.Types.UserStatusEnumModel.Registered;
				case UserStatus.Suspended:
					return UserModel.Types.UserStatusEnumModel.Suspended;
				case UserStatus.Unknown:
					return UserModel.Types.UserStatusEnumModel.Unknown;
				default:
					throw new Exception("Matching user status not found.");
			}
		}

		private static UserModel.Types.UserRolesModel.Types.UserRolesEnumModel FindUserRole(string role)
		{
			switch (role)
			{
				case UserRoles.SuperAdministrator:
					return UserModel.Types.UserRolesModel.Types.UserRolesEnumModel.Superadministrator;
				case UserRoles.Administrator:
					return UserModel.Types.UserRolesModel.Types.UserRolesEnumModel.Administrator;
				case UserRoles.Faculty:
					return UserModel.Types.UserRolesModel.Types.UserRolesEnumModel.Faculty;
				case UserRoles.Staff:
					return UserModel.Types.UserRolesModel.Types.UserRolesEnumModel.Staff;
				case UserRoles.Student:
					return UserModel.Types.UserRolesModel.Types.UserRolesEnumModel.Student;
				default:
					throw new Exception("Matching user role not found.");
			}
		}
	}
}