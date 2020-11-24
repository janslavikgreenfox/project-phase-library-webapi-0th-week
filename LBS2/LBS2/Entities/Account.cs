using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public int AuthorizationId { get; set; }
        public AuthorizationLevel LevelOfAuthorization { get; set; }

        public List<Borrowing> BooksBorrowed { get; set; }

        public Account()
        {
            BooksBorrowed = new List<Borrowing>();
        }

    }
}
