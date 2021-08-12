using System;

namespace Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string Salt { get; set; }
    }
}
