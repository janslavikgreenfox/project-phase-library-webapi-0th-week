using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Databases;
using LBS2.Entities;
using LBS2.Services.Interfaces;

namespace LBS2.Services
{
    public class DbBookCategoriesService : IBookCategories
    {
        private readonly ApplicationDbContext Database;

        public DbBookCategoriesService(ApplicationDbContext database)
        {
            Database = database;
        }
        public void Create(string bookTitle, string categoryDescription, string accountName)
        {
            var dbBookService = new DbBookService(Database);
            var book = dbBookService.Read(bookTitle);

            var dbCathegoryService = new DbCategoryServices(Database);
            var category = dbCathegoryService.Read(categoryDescription);

            var dbAccountService = new DbAccountService(Database);
            var account = dbAccountService.Read(accountName);

            var bookCat = new BookCategory { When = DateTime.Now, Who = account };
            book.BelongsToCatgegories.Add(bookCat);
            category.BooksBelongsToCategory.Add(bookCat);

            Database.SaveChanges();
        }

        public void Delete(BookCategory bookCategory)
        {
            Database.BookCategoriesTbl.Remove(bookCategory);
            Database.SaveChanges();
        }

        public List<BookCategory> ReadAll()
        {
            return Database.BookCategoriesTbl.ToList();
        }

        //public List<BookCategory> ReadByBookId(int bookId)
        //{
        //    return Database.BookCategoriesTbl
        //        .Where(bookCat=>bookCat.BookId==bookId)
        //        .ToList();
        //}

        //public List<BookCategory> ReadByCategoryId(int categoryId)
        //{
        //    return Database.BookCategoriesTbl
        //        .Where(bookCat=>bookCat.CategoryId==categoryId)
        //        .ToList();
        //}

        public void Update(BookCategory bookCategory)
        {
            Database.BookCategoriesTbl.Update(bookCategory);
        }
    }
}
