using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    interface IBook
    {
        public void Create(string title, string categoryDescription="");
        public void CreateIfNotExist(string title, string categoryDescription="");
        public Book Read(string title);
        public void Update(Book book);
        public void Delete(Book book);

    }
}
