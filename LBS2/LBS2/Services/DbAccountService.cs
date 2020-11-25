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
    public class DbAccountService : IAccount
    {
        private readonly ApplicationDbContext Database;

        public DbAccountService(ApplicationDbContext database)
        {
            Database = database;
        }
        public void Create(string name, string password, string authLevel)
        {
            var account = new Account { Name = name, Password = password };

            var dbAuthorizationService = new DbAuthorizationLevelService(Database);
            var level = dbAuthorizationService.Read(authLevel);

            level.AccountsOfTheLevel.Add(account);
            Database.SaveChanges();
        }

        public void CreateIfNotExist(string name, string password, string authLevel)
        {
            if (!Database.AccountsTbl.Any(account => account.Name == name))
            {
                Create(name, password, authLevel);
            }
        }

        public void Delete(Account account)
        {
            Database.AccountsTbl.Remove(account);
            Database.SaveChanges();
        }

        public Account Read(string name)
        {
            return Database.AccountsTbl
                .Where(account=>account.Name==name)
                .Include(account=>account.LevelOfAuthorization)
                .FirstOrDefault();
        }

        public void Update(Account account)
        {
            Database.AccountsTbl.Update(account);
            Database.SaveChanges();
        }
    }
}
