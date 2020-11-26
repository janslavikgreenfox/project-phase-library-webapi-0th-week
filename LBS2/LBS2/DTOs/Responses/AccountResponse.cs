using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.DTOs.Responses
{
    public class AccountResponse
    {
        public string Name { get; set; }
        public List<Book> BooksBorrowed { get; set; } 
    }
}
