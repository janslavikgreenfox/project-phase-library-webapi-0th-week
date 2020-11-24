using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Databases;
using LibraryWebApi.Models.Entities;

namespace LibraryWebApi.Services.Interfaces
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext database;

        public CategoryService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void Create(Category item)
        {
            database.CategoriesTable.Add(item);
        }

        public void CreateOrUpdate(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Read(string name)
        {
            throw new NotImplementedException();
        }

        public Category Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
