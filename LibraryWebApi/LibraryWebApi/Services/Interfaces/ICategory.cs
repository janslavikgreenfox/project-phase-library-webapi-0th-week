using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Models.Entities;

namespace LibraryWebApi.Services.Interfaces
{
    interface ICategory
    {
        public void Create(Category item);
        public Category Read(string name);
        public Category Read(int id);
        public void Update(Category item);
        public void CreateOrUpdate(Category item);
    }
}
