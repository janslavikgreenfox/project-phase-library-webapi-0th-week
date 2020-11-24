using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.Entities
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime WhenBorrowed { get; set; }
        
        public int BookId { get; set; }
        public Book BorrowedBook { get; set; }

        public int AccountId { get; set; }
        public Account WhoBorrowed { get; set; }

    }
}
