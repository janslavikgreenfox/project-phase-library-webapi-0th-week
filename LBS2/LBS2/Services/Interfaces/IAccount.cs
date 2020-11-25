using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    interface IAccount
    {
        public void Create(string name, string password, string authLevel);
        public void CreateIfNotExist(string name, string password, string authLevel);
        public Account Read(string name);
        public void Update(Account account);
        public void Delete(Account account);
    }
}
