using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApi.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public List<CategorizationEvent> Events { get; set; }

        public Category()
        {
            //WhichBelongsTo = new List<Book>();
            Events = new List<CategorizationEvent>();
        }
    }
}
