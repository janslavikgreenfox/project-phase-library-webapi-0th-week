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
            SaveChanges();
            var librarian = AuthorizationLevelsTable.Where(x => x.Name == "Librarian").FirstOrDefault();
            var user = AuthorizationLevelsTable.Where(x => x.Name == "User").FirstOrDefault();

            user.WhoHasTheLevel.Add(new Account { Name = "Alice" });
            user.WhoHasTheLevel.Add(new Account { Name = "Bob" });
            user.WhoHasTheLevel.Add(new Account { Name = "Cecilia" });
            SaveChanges();

            var servadac = new Book { Title = "Hector Servadac", WhenLent = DateTime.Now };
            var alice = AccountsTable.Where(x => x.Name == "Alice").FirstOrDefault();
            alice.BorrowedBooks.Add(servadac);
            SaveChanges();

            var scifi = CategoriesTable.Where(x => x.Description == "Sci-fi").FirstOrDefault();

            var now = DateTime.Now;
            var catEvent = new CategorizationEvent { When = now };
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
