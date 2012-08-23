using System.Collections.Generic;

namespace FubuDate.Endpoints.Users
{
    public class IndexEndpoint
    {
        public UsersViewModel Get(UsersRequest request)
        {
            return new UsersViewModel();
        }
    }

    public class UsersRequest { }

    public class UsersViewModel 
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }

    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
}