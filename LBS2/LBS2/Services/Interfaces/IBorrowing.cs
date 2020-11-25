using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    interface IBorrowing
    {
        public void Create(string bookTitle, string accountName);
        public List<Borrowing> ReadAll();
        public void Update(Borrowing borrowing);
        public void Delete(Borrowing borrowing);
    }
}
