namespace ScholarPortal.Services.Identity.Core.Exceptions
{
	public class InvalidLastNameException : DomainException
	{
		public override string Code => "invalid_birthdate";

		public InvalidLastNameException() : base(
			"Invalid last name, field must not be empty.")
		{
		}
	}
}