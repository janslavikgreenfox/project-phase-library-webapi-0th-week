﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApi.Models.Entities
{
    public class Cathegory
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        List<Book> WhichBelongsTo { get; set; }

        public Cathegory()
        {
            WhichBelongsTo = new List<Book>();
        }
    }
}