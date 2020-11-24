using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Databases;
using LibraryWebApi.Models.Entities;
using LibraryWebApi.Services.Interfaces;

namespace LibraryWebApi.Services
{
    public class AccountService : IAccount
    {
        private readonly ApplicationDbContext database;

        public AccountService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void Create(string name, string authorizationName)
        {
            var authorizationLevel = 
                database.AuthorizationLevelsTable.Where(x => x.Name == authorizationName).FirstOrDefault();
            var account = new Account { Name = name };
            authorizationLevel.WhoHasTheLevel.Add(account);
            database.SaveChanges();
        }

        public void CreateOrUpdate(Account item)
        {
            throw new NotImplementedException();
        }

        public Account Read(string name)
        {
            throw new NotImplementedException();
        }

        public Account Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Account item)
        {
            throw new NotImplementedException();
        }
    }
}
