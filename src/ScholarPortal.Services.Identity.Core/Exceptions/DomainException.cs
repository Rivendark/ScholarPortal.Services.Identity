using System;

namespace ScholarPortal.Services.Identity.Core.Exceptions
{
	public abstract class DomainException : Exception
	{
		public abstract string Code { get; }

		protected DomainException(string message) : base(message)
		{
		}
	}
}