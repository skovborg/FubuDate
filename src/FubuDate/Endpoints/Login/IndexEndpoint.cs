using FubuDate.Endpoints.Users;
using FubuLocalization;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;

namespace FubuDate.Endpoints.Login
{
    public class IndexEndpoint
    {
        private readonly IAuthenticationContext _authenticationContext;

        public IndexEndpoint(IAuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        public LoginIndexViewModel Get(LoginIndexRequest request)
        {
            return new LoginIndexViewModel(request.Username, request.Password);
        }

        public FubuContinuation Post(LoginInput input)
        {
            if (input.Username == "username" && input.Password == "password")
            {
                _authenticationContext.ThisUserHasBeenAuthenticated(input.Username, false);
                return FubuContinuation.RedirectTo(new UsersRequest());
            }

            return FubuContinuation.TransferTo(new LoginIndexRequest(input.Username, input.Password));


        }
    }

    public class LoginInput
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginIndexRequest : LoginInput
    {
        public LoginIndexRequest()
        { }

        public LoginIndexRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

    public class LoginIndexViewModel : LoginInput
    {
        public LoginIndexViewModel()
        { }

        public LoginIndexViewModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public StringToken Title
        {
            get { return StringToken.FromKeyString("Title_Login"); }
        }
    }
}