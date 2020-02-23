using System;
using ScholarPortal.Services.Identity.Application.Services;

namespace ScholarPortal.Services.Identity.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now  => DateTime.UtcNow;
    }
}