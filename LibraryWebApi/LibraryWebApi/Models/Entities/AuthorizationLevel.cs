using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApi.Models.Entities
{
    public class AuthorizationLevel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Account> WhoHasTheLevel { get; set; }

        public AuthorizationLevel()
        {
            WhoHasTheLevel = new List<Account>();
        }
    }
}
