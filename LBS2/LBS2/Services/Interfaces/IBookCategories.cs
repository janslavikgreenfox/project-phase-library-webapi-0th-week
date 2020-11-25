using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    interface IBookCategories
    {
        public void Create(string bookTitle, string categoryDescription, string accountName);
        public List<BookCategory> ReadAll();
        //public List<BookCategory> ReadByBookId(int bookId);
        //public List<BookCategory> ReadByCategoryId(int categoryId);
        public void Update(BookCategory bookCategory);
        public void Delete(BookCategory bookCategory);
    }
}
