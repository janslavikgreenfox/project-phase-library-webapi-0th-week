using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    public interface IBook
    {
        public void Create(string title);
        public void CreateIfNotExist(string title);
        public Book Read(string title);
        public List<Book> ReadAll();
        public void Update(Book book);
        public void Delete(Book book);

    }
}
