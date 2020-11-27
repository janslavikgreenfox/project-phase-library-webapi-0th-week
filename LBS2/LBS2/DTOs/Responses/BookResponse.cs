using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.DTOs.Responses
{
    public class BookResponse
    {
        public string Title { get; set; }
        public string WhenBorrowed { get; set; }
        public string WhoBorrowedName { get; set; }
    }
}
