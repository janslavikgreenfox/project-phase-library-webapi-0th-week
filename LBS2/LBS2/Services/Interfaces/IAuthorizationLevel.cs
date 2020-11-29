using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    public interface IAuthorizationLevel
    {
        public bool IsInDB(string levelName);
        public void Create(string levelName);
        public void CreateIfNotExist(string levelName);
        public AuthorizationLevel Read(string levelName);
        public void Update(AuthorizationLevel level);

    }
}
