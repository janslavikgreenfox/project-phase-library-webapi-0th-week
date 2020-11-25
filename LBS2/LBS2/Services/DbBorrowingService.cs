using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Databases;
using LBS2.Entities;
using LBS2.Services.Interfaces;

namespace LBS2.Services
{
    public class DbBorrowingService : IBorrowing
    {
        private readonly ApplicationDbContext Database;

        public DbBorrowingService(ApplicationDbContext database)
        {
            Database = database;
        }
        public void Create(string bookTitle, string accountName)
        {
            // TODO Should be dependency injection here 2x
            var dbBookService = new DbBookService(Database);
            var book = dbBookService.Read(bookTitle);

            var dbAccountService = new DbAccountService(Database);
            var account = dbAccountService.Read(accountName);

            var borrowing = new Borrowing { WhenBorrowed = DateTime.Now };

            book.Borrowings.Add(borrowing);
            account.BooksBorrowed.Add(borrowing);
            Database.SaveChanges();
        }

        public void Delete(Borrowing borrowing)
        {
            Database.BorrowingsTbl.Remove(borrowing);
            Database.SaveChanges();
        }

        public List<Borrowing> ReadAll()
        {
            return Database.BorrowingsTbl.ToList();
        }

        public Borrowing ReadByTitle(string bookTitle)
        {
            var dbBookService = new DbBookService(Database);
            var book = dbBookService.Read(bookTitle);
            return Database.BorrowingsTbl
                .Where(x=>x.BookId==book.Id).FirstOrDefault();
        }

        public void Update(Borrowing borrowing)
        {
            Database.BorrowingsTbl.Update(borrowing);
        }
    }
}
