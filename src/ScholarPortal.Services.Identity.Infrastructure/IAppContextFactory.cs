using ScholarPortal.Services.Identity.Application;

namespace ScholarPortal.Services.Identity.Infrastructure
{
    public interface IAppContextFactory
    {
        IAppContext Create();
    }
}