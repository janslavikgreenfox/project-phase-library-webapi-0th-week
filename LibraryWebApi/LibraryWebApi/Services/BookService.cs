using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Databases;
using LibraryWebApi.Models.Entities;
using LibraryWebApi.Services.Interfaces;

namespace LibraryWebApi.Services
{
    public class BookService : IBook
    {
        private readonly ApplicationDbContext database;

        public BookService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void Create(string title, string accountName)
        {
            var account = database.AccountsTable.Where(x=>x.Name==accountName).FirstOrDefault();
            var book = new Book { Title = title };
            account.BorrowedBooks.Add(book);
            database.SaveChanges()
        }

        public void CreateOrUpdate(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Read(string name)
        {
            throw new NotImplementedException();
        }

        public Book Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
