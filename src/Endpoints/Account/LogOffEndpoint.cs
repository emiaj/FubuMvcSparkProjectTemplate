using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using $safeprojectname$.Endpoints.Home;

namespace $safeprojectname$.Endpoints.Account {
	public class LogOffEndpoint {
		private readonly IAuthenticationContext _authenticationContext;

		public LogOffEndpoint(IAuthenticationContext authenticationContext) {
			_authenticationContext = authenticationContext;
		}

		public FubuContinuation LogOff(LogOffInput input) {
			_authenticationContext.SignOut();
			return FubuContinuation.RedirectTo<IndexInput>();
		}
	}

	public class LogOffInput {
	}

}