using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public List<BookCategory> BelongsToCatgegories { get; set; }

        public List<Borrowing> Borrowings { get; set; }

        public Book()
        {
            BelongsToCatgegories = new List<BookCategory>();
            Borrowings = new List<Borrowing>();

        }


    }
}
