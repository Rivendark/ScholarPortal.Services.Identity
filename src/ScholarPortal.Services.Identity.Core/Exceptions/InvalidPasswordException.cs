namespace ScholarPortal.Services.Identity.Core.Exceptions
{
	public class InvalidPasswordException : DomainException
	{
		public override string Code => "invalid_password";

		public InvalidPasswordException() : base(
			"Invalid password. Must contain at least one letter, number, and symbol. Must be at least 8 character in length.")
		{
			
		}
	}
}