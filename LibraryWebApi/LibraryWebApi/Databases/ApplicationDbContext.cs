using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.Databases
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> BooksTable { get; set; }
        public DbSet<Account> AccountsTable { get; set; }
        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<AuthorizationLevel> AuthorizationLevelsTable { get; set; }
        public DbSet<CategorizationEvent> CategorizationEventsTable { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            CategoriesTable.Add(new Category { Description = "Sci-fi" });
            CategoriesTable.Add(new Category { Description = "History" });

            AuthorizationLevelsTable.Add(new AuthorizationLevel { Name = "Admin" });
            AuthorizationLevelsTable.Add(new AuthorizationLevel { Name = "Librarian" });
            AuthorizationLevelsTable.Add(new AuthorizationLevel { Name = "User" });
            var librarian = AuthorizationLevelsTable.Where(x => x.Name == "Librarian").FirstOrDefault();
            var user = AuthorizationLevelsTable.Where(x => x.Name == "User").FirstOrDefault();
            SaveChanges();

            AccountsTable.Add(new Account { Name = "Alice" });
            AccountsTable.Add(new Account { Name = "Bob" });
            AccountsTable.Add(new Account { Name = "Cecilia" });
            var alice = AccountsTable.Where(x => x.Name == "Alice").FirstOrDefault();
            user.WhoHasTheLevel.Add(alice);
            SaveChanges();

            BooksTable.Add(new Book { Title = "Hector Servadac", WhenLent = DateTime.Now });
            var servadac = BooksTable.Where(x => x.Title == "Hector Servadac").FirstOrDefault();

            CategoriesTable.Add(new Category { Description = "Scifi" });
            var scifi = CategoriesTable.Where(x => x.Description == "Scifi").FirstOrDefault();

            var now = DateTime.Now;
            CategorizationEventsTable.Add(new CategorizationEvent { When = now });
            var catEvent = CategorizationEventsTable.Where(x=>x.When.Equals(now)).FirstOrDefault();

            scifi.Events.Add(catEvent);
            servadac.Categorized.Add(catEvent);
            SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany<Book>(account => account.BorrowedBooks)
                .WithOne(book => book.WhomLent)
                .HasForeignKey(Book => Book.AccountId);

            modelBuilder.Entity<AuthorizationLevel>()
                .HasMany<Account>(authorLevel => authorLevel.WhoHasTheLevel)
                .WithOne(account => account.AuthorizationLevel)
                .HasForeignKey(account => account.AuthorizationId);

            //modelBuilder.Entity<CategorizationEvent>()
            //    .HasOne(catEvent => catEvent.What)
            //    .WithOne(book => book.CatEvent)
            //    .HasForeignKey<Book>(book => book.CatEventId);

            modelBuilder.Entity<Book>()
                .HasMany<CategorizationEvent>(book => book.Categorized)
                .WithOne(catEvent => catEvent.What)
                .HasForeignKey(catEvent => catEvent.WhatId);

            modelBuilder.Entity<Category>()
                .HasMany<CategorizationEvent>(category => category.Events)
                .WithOne(catEvent => catEvent.CategorizeAs)
                .HasForeignKey(catEvent => catEvent.CategoryId);
                
        }
    }
}
