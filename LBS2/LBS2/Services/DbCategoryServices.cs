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
    public class DbCategoryServices : ICategory
    {
        private readonly ApplicationDbContext Database;

        public DbCategoryServices(ApplicationDbContext database)
        {
            Database = database;
        }
        public void Create(string description)
        {
            var category = new Category { Description = description };
            Database.CategoriesTbl.Add(category);
            Database.SaveChanges();
        }

        public void CreateIfNotExist(string description)
        {
            if (!Database.CategoriesTbl.Any(category => category.Description == description))
            {
                Create(description);
            }
        }

        public Category Read(string description)
        {
            return Database.CategoriesTbl
                .Where(category=>category.Description==description)
                .Include(category=>category.BooksBelongsToCategory)
                .FirstOrDefault();
        }

        public void Delete(Category category)
        {
            Database.CategoriesTbl.Remove(category);
            Database.SaveChanges();
        }

        public void Update(Category category)
        {
            Database.CategoriesTbl.Update(category);
            Database.SaveChanges();
        }
    }
}
