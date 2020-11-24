using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Models.Entities;

namespace LibraryWebApi.Services.Interfaces
{
    interface ICategorizationEvent
    {
        public void Create(CategorizationEvent item);
        public CategorizationEvent Read(string name);
        public CategorizationEvent Read(int id);
        public void Update(CategorizationEvent item);
        public void CreateOrUpdate(CategorizationEvent item);
    }
}
