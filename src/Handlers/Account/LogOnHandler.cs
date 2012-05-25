﻿using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using $safeprojectname$.Handlers.Home;
using $safeprojectname$.Services;

namespace $safeprojectname$.Handlers.Account
{
    public class LogOnHandler
    {
        private readonly IMembershipService _membershipService;
        private readonly IAuthenticationContext _authenticationContext;

        public LogOnHandler(IMembershipService membershipService, IAuthenticationContext authenticationContext)
        {
            _membershipService = membershipService;
            _authenticationContext = authenticationContext;
        }

        public LogOnModel LogOn(LogOnInput input)
        {
            return new LogOnModel();
        }

        public FubuContinuation LogOnCommand(LogOnModel input)
        {
            if (_membershipService.UserExists(input.UserName, input.Password))
            {
                _authenticationContext.ThisUserHasBeenAuthenticated(input.UserName, input.RememberMe);
                return FubuContinuation.RedirectTo<IndexInput>();
            }
            return FubuContinuation.TransferTo<LogOnInput>();
        }

    }

    public class LogOnInput
    {
    }

    public class LogOnModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

}