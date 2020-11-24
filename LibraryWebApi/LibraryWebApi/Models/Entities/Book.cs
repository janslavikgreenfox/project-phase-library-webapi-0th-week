using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApi.Models.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime WhenLent { get; set; }

        public int AccountId { get; set; }
        public Account WhomLent { get; set; }

        public List<CategorizationEvent> Categorized { get; set; }

        public Book()
        {
            Categorized = new List<CategorizationEvent>();
        }
    }
}
