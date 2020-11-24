using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApi.Models.Entities
{
    public class CategorizationEvent
    {
        [Key]
        public int Id { get; set; }
        public DateTime When { get; set; }

        public int WhatId { get; set; }
        public Book What { get; set; }

        public int CategoryId { get; set; }
        public Category CategorizeAs { get; set; }


    }
}
