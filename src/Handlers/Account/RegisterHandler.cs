using FubuCore;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using $safeprojectname$.Handlers.Home;
using $safeprojectname$.Services;

namespace $safeprojectname$.Handlers.Account
{
    public class RegisterHandler
    {
        private readonly IMembershipService _membershipService;
        private readonly IAuthenticationContext _authenticationContext;
        private readonly IFubuRequest _request;

        public RegisterHandler(IMembershipService membershipService, IAuthenticationContext authenticationContext,IFubuRequest request)
        {
            _membershipService = membershipService;
            _authenticationContext = authenticationContext;
            _request = request;
        }

        public RegisterModel Register(RegisterInput input)
        {
            return _request.Has<RegisterModel>() ? _request.Get<RegisterModel>() : new RegisterModel();
        }

        public FubuContinuation RegisterCommand(RegisterModel input)
        {
            // TODO: VALIDATION
            if (input.UserName.IsEmpty() || input.Password.IsEmpty())
            {
                return FubuContinuation.TransferTo<RegisterInput>();
            }
            if(!input.Password.Equals(input.ConfirmPassword))
            {
                return FubuContinuation.TransferTo<RegisterInput>();
            }
            if (_membershipService.CreateUser(input.UserName, input.Password, input.Email))
            {
                _authenticationContext.ThisUserHasBeenAuthenticated(input.UserName, false);
                return FubuContinuation.RedirectTo<IndexInput>();
            }
            return FubuContinuation.TransferTo<RegisterInput>();
        }
    }

    public class RegisterInput
    {
    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}