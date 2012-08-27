using System;

namespace FubuDate.Domain
{
    public class User : IEntity
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastActive { get; set; }
    }
}