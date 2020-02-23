namespace ScholarPortal.Services.Identity.Core.Exceptions
{
	public class InvalidFirstNameException : DomainException
	{
		public override string Code => "invalid_firstname";

		public InvalidFirstNameException() : base(
			"Invalid first name, field must not be empty.")
		{
		}
	}
}