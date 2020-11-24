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

        }
    }
}
