using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.DTOs.Requests
{
    public class AccountRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string AuthorizationLevel { get; set; }
        public AccountRequest()
        {
        }
    }
}
