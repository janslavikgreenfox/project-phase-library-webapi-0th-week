using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.Entities
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        public DateTime When { get; set; }
        public Account Who { get; set; }

        public int BookId { get; set; }
        public Book WhatBook { get; set; }

        public int CategoryId { get; set; }
        public Category WhatCategory { get; set; }

    }
}
