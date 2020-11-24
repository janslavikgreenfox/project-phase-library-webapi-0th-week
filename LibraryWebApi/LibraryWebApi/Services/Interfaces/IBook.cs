using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Models.Entities;

namespace LibraryWebApi.Services.Interfaces
{
    interface IBook
    {
        public void Create(Book item);
        public Book Read(string name);
        public Book Read(int id);
        public void Update(Book item);
        public void CreateOrUpdate(Book item);
    }
}
