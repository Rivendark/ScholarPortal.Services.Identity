namespace ScholarPortal.Services.Identity.Core.Exceptions
{
	public class InvalidRoleException : DomainException
	{
		public override string Code => "invalid_role";

		public InvalidRoleException(string role) : base("Invalid role given.")
		{
		}
	}
}