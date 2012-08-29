using System;
using System.Resources;
using FubuDate.Endpoints.Users;
using FubuMVC.Core.Continuations;
using FubuValidation;
using Raven.Client;

namespace FubuDate.Endpoints.User
{
    public class SignupEndpoint
    {
        private readonly IDocumentSession _session;

        public SignupEndpoint(IDocumentSession session)
        {
            _session = session;
        }

        public SignupViewModel Get(SignupRequest request)
        {
            return new SignupViewModel();
        }

        public FubuContinuation Post(SignupInput input)
        {
            _session.Store(new Domain.User() { Username = input.Username, Password = input.Password, LastActive = DateTime.Now });
            return FubuContinuation.RedirectTo(new UsersRequest());
        }
    }

    public class SignupRequest { }

    public class SignupViewModel : SignupInput
    {

    }

    public class SignupInput
    {

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}