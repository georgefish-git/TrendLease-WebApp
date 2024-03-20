using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendLease_WebApp.App.Users
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public string UserPass { get; set; }


    }

    public class currentUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}