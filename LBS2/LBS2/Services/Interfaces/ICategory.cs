using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    public interface ICategory
    {
        public void Create(string description);
        public void CreateIfNotExist(string description);
        public Category Read(string description);
        public void Update(Category category);
        public void Delete(Category category);
    }
}
