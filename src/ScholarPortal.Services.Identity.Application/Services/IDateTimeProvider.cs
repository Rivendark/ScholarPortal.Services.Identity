using System;

namespace ScholarPortal.Services.Identity.Application.Services
{
	public interface IDateTimeProvider
	{
		DateTime Now { get; }
	}
}