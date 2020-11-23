using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApi.Models.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }

        List<Book> BorrowedBooks { get; set; }

        public int AuthorizationId { get; set; }
        public AuthorizationLevel AuthorizationLevel { get; set; }

        public Account()
        {
            BorrowedBooks = new List<Book>();
        }
    
    }

 
}
