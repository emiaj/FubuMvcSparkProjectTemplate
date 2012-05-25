using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using $safeprojectname$.Handlers.Home;

namespace $safeprojectname$.Handlers.Account
{
    public class LogOffHandler
    {
        private readonly IAuthenticationContext _authenticationContext;

        public LogOffHandler(IAuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        public FubuContinuation LogOff(LogOffInput input)
        {
            _authenticationContext.SignOut();
            return FubuContinuation.RedirectTo<IndexInput>();
        }
    }

    public class LogOffInput
    {
    }

}