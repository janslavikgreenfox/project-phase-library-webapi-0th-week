using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Models.Entities;

namespace LibraryWebApi.Services.Interfaces
{
    interface IAuthorizationLevel
    {
        public void Create(AuthorizationLevel item);
        public AuthorizationLevel Read(string name);
        public AuthorizationLevel Read(int id);
        public void Update(AuthorizationLevel item);
        public void CreateOrUpdate(AuthorizationLevel item);
    }
}
