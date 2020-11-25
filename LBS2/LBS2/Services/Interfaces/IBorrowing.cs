using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Entities;

namespace LBS2.Services.Interfaces
{
    public interface IBorrowing
    {
        public void Create(string bookTitle, string accountName);
        public List<Borrowing> ReadAll();
        public Borrowing ReadByTitle(string bookTitle);
        public void Update(Borrowing borrowing);
        public void Delete(Borrowing borrowing);
    }
}
