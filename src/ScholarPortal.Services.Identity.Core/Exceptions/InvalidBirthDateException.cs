using System;

namespace ScholarPortal.Services.Identity.Core.Exceptions
{
	public class InvalidBirthDateException : DomainException
	{
		public override string Code => "invalid_birthdate";

		public InvalidBirthDateException(DateTime birthdate) : base(
			$"Invalid email: ({birthdate:MM/dd/yyyy}) must be a valid email, and not empty.")
		{
		}
	}
}