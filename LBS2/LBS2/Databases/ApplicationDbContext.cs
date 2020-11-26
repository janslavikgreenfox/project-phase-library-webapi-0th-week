using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;
using Microsoft.EntityFrameworkCore;

namespace LBS2.Databases
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> BooksTbl { get; set; }
        public DbSet<Account> AccountsTbl { get; set; }
        public DbSet<Category> CategoriesTbl { get; set; }
        public DbSet<AuthorizationLevel> AuthorizationLevelsTbl { get; set; }
        public DbSet<BookCategory> BookCategoriesTbl { get; set; }

        public DbSet<Borrowing> BorrowingsTbl { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
           
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorizationLevel>()
                .HasMany<Account>(level => level.AccountsOfTheLevel)
                .WithOne(account => account.LevelOfAuthorization)
                .HasForeignKey(account => account.AuthorizationId);

            modelBuilder.Entity<Borrowing>()
                .HasOne(borrowing => borrowing.BorrowedBook)
                .WithMany(book => book.Borrowings)
                .HasForeignKey(borrowing => borrowing.BookId);
            modelBuilder.Entity<Borrowing>()
                .HasOne(borrowing => borrowing.WhoBorrowed)
                .WithMany(account => account.BooksBorrowed)
                .HasForeignKey(borrowing => borrowing.AccountId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.WhatBook)
                .WithMany(book => book.BelongsToCatgegories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.WhatCategory)
                .WithMany(cat => cat.BooksBelongsToCategory)
                .HasForeignKey(bc => bc.CategoryId);

            //#region DataSeed

            //modelBuilder.Entity<AuthorizationLevel>()
            //    .HasData(
            //    new AuthorizationLevel() { Name = "Admin", Id=1 },
            //    new AuthorizationLevel() { Name = "Librarian", Id=2 },
            //    new AuthorizationLevel() { Name = "Client", Id=3 }
            //    );

            //modelBuilder.Entity<Category>()
            //    .HasData(
            //    new Category() { Description = "Scifi", Id=1 },
            //    new Category() { Description = "History", Id=2 },
            //    new Category() { Description = "Politics", Id=3 },
            //    new Category() { Description = "Humor", Id=4 }
            //    );

            //modelBuilder.Entity<Account>()
            //    .HasData(
            //    new Account() { Name = "Von Neumann", Password = "0123", AuthorizationId = 1 }
            //    );

            //#endregion

        }
    }
}
