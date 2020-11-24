using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Databases;
using LibraryWebApi.Models.Entities;
using LibraryWebApi.Services.Interfaces;

namespace LibraryWebApi.Services
{
    public class CategorizationEventService : ICategorizationEvent
    {
        private readonly ApplicationDbContext database;

        public CategorizationEventService(ApplicationDbContext database)
        {
            this.database = database;
        }
        public void Create(CategorizationEvent item)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(CategorizationEvent item)
        {
            throw new NotImplementedException();
        }

        public CategorizationEvent Read(string name)
        {
            throw new NotImplementedException();
        }

        public CategorizationEvent Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategorizationEvent item)
        {
            throw new NotImplementedException();
        }
    }
}
