using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Models.Entities;

namespace LibraryWebApi.Services.Interfaces
{
    interface IAccount
    {
        public void Create(Account item);
        public Account Read(string name);
        public Account Read(int id);
        public void Update(Account item);
        public void CreateOrUpdate(Account item);
    }
}
