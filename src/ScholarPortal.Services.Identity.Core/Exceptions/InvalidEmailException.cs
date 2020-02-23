namespace ScholarPortal.Services.Identity.Core.Exceptions
{
	public class InvalidEmailException : DomainException
	{
		public override string Code => "invalid_email";

		public InvalidEmailException(string email) : base($"Invalid email: ({email}) must be a valid email, and not empty.")
		{
		}
	}
}