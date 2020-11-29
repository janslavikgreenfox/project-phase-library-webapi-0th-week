using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.DTOs.Requests
{
    public class BorrowingRequest
    {
        public int? BookId { get; set; }
        public int? AccountId { get; set; }
    }
}
