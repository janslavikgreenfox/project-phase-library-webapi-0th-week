﻿using System;
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
        public void Create(string title, string categoryDescription="")
        {
            var book = new Book { Title=title};
            if (!String.IsNullOrEmpty(categoryDescription))
            {
                //TODO add to the category
            }

            Database.BooksTbl.Add(book);
            Database.SaveChanges();
        }

        public void CreateIfNotExist(string title, string categoryDescription="")
        {
            Create(title,categoryDescription);
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
                .FirstOrDefault();
        }

        public void Update(Book book)
        {
            Database.BooksTbl.Update(book);
            Database.SaveChanges();
        }
    }
}