using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Databases;
using LBS2.Entities;
using Microsoft.EntityFrameworkCore;

namespace LBS2.Services.Interfaces
{
    public class DbAuthorizationLevelService : IAuthorizationLevel
    {
        private readonly ApplicationDbContext Database;

        public DbAuthorizationLevelService(ApplicationDbContext database)
        {
            Database = database;
        }
        public void Create(string levelName)
        {
            var level = new AuthorizationLevel { Name = levelName };
            Database.AuthorizationLevelsTbl.Add(level);
            Database.SaveChanges();
        }

        public void CreateIfNotExist(string levelName)
        {
            if (!Database.AuthorizationLevelsTbl.Any(x => x.Name == levelName))
            {
                Create(levelName);
            };
        }

        public bool IsInDB(string levelName)
        {
            return Database.AuthorizationLevelsTbl.Any(x=>x.Name==levelName);
        }

        public AuthorizationLevel Read(string levelName)
        {
            return 
                Database.AuthorizationLevelsTbl
                .Where(x=>x.Name==levelName)
                .Include(x=>x.AccountsOfTheLevel)
                .FirstOrDefault();
        }

        public void Update(AuthorizationLevel level)
        {
            Database.AuthorizationLevelsTbl.Update(level);
        }
    }
}
