using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Databases;
using LibraryWebApi.Models.Entities;

namespace LibraryWebApi.Services.Interfaces
{
    public class AuthorizationLevelService : IAuthorizationLevel
    {
        private readonly ApplicationDbContext database;

        public AuthorizationLevelService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void Create(AuthorizationLevel item)
        {
            database.AuthorizationLevelsTable.Add(item);
        }

        public void CreateOrUpdate(AuthorizationLevel item)
        {
            throw new NotImplementedException();
        }

        public AuthorizationLevel Read(string name)
        {
            throw new NotImplementedException();
        }

        public AuthorizationLevel Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AuthorizationLevel item)
        {
            throw new NotImplementedException();
        }
    }
}
