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

		private static readonly IDictionary<int, string> RoleList = new Dictionary<int, string>()
		{
			{0, Student},
			{1, Staff},
			{2, Faculty},
			{3, Administrator},
			{4, SuperAdministrator}
		};

		public static bool IsValid(int role)
		{
			return RoleList.ContainsKey(role);
		}

		public static bool IsValid(string role)
		{
			return RoleList.Any(r => r.Value == role);
		}
	}
}