using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Databases;
using LBS2.Entities;
using LBS2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LBS2.Services
{
    public class DbBookService : IBook
    {
        private readonly ApplicationDbContext Database;

        public DbBookService(ApplicationDbContext database)
        {
            Database = database;
        }
        public void Create(string title)
        {
            var book = new Book { Title=title};

            Database.BooksTbl.Add(book);
            Database.SaveChanges();
        }

        public void CreateIfNotExist(string title)
        {
            Create(title);
        }

        public void Delete(Book book)
        {
            Database.BooksTbl.Remove(book);
            Database.SaveChanges();
        }

        public Book Read(string title)
        {
            return Database.BooksTbl
                .Where(book=>book.Title==title)
                .Include(book=>book.BelongsToCatgegories)
                .Include(book=>book.Borrowings)
                .ThenInclude(borrowing=>borrowing.WhoBorrowed)
                .FirstOrDefault();
        }

        public Book Read(int bookId)
        {
            return Database.BooksTbl
                .Where(book => book.Id == bookId)
                .Include(book => book.BelongsToCatgegories)
                .Include(book => book.Borrowings)
                .ThenInclude(borrowing => borrowing.WhoBorrowed)
                .FirstOrDefault(); 
        }

        public List<Book> ReadAll()
        {
            return Database.BooksTbl
                .Include(book => book.Borrowings)
                .ThenInclude(borrowing => borrowing.WhoBorrowed)
                .ToList();
        }

        public void Update(Book book)
        {
            Database.BooksTbl.Update(book);
            Database.SaveChanges();
        }
    }
}
