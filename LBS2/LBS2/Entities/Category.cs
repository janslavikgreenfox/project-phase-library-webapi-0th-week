using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBS2.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public List<BookCategory> BooksBelongsToCategory { get; set; }

        public Category()
        {
            BooksBelongsToCategory = new List<BookCategory>();
        }
    }
}
