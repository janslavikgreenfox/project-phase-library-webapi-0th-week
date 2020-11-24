using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.Entities
{
    public class AuthorizationLevel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Account> AccountsOfTheLevel { get; set; }

        public AuthorizationLevel()
        {
            AccountsOfTheLevel = new List<Account>();
        }
    }
}
