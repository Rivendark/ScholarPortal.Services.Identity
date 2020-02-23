using System.Collections.Generic;
using System.Linq;

namespace ScholarPortal.Services.Identity.Core.Entities
{
	public static class UserRoles
	{
		public const string Faculty = "faculty";
		public const string Student = "student";
		public const string Staff = "staff";
		public const string Administrator = "administrator";
		public const string SuperAdministrator = "superadministrator";

		private static readonly IEnumerable<string> RoleList = new List<string>()
		{
			Faculty,
			Student,
			Staff,
			Administrator,
			SuperAdministrator
		};

		public static bool IsValid(string role)
		{
			return !string.IsNullOrWhiteSpace(role) && RoleList.Contains(role.ToLowerInvariant());
		}
	}
}