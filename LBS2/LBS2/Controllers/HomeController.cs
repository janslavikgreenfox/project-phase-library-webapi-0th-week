using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBS2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LBS2.Controllers
{
    public class HomeController : Controller
    {
        public IAccount AccountService { get; set; }
        public IAuthorizationLevel AuthorizationLevelService { get; set; }
        public IBook BookService { get; set; }
        public IBookCategories BookCategoryService { get; set; }
        public IBorrowing BorrowingService { get; set; }
        public ICategory CategoryService { get; set; }
        public HomeController(
            IAccount accountService, 
            IAuthorizationLevel authorizationLevelService, 
            IBook bookService, 
            IBookCategories bookCategoryService, 
            IBorrowing borrowingService, 
            ICategory categoryService
            )
        {
            AccountService = accountService;
            AuthorizationLevelService = authorizationLevelService;
            BookService = bookService;
            BookCategoryService = bookCategoryService;
            BorrowingService = borrowingService;
            CategoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet("/test")]
        public IActionResult TestGet()
        {
            AuthorizationLevelService.Create("Admin");
            AuthorizationLevelService.Create("Librarian");
            AuthorizationLevelService.Create("Client");

            CategoryService.Create("Scifi");
            CategoryService.Create("History");
            CategoryService.Create("Politics");
            CategoryService.Create("Humor");

            AccountService.Create("Von Neumann", "0123456789abcdf", "Admin");
            AccountService.Create("Guthenberg", "1415", "Librarian");
            AccountService.Create("Marilyn Monroe", "12345", "Client");
            AccountService.Create("Elvis Presley", "01114", "Client");
            AccountService.Create("Michael Jackson", "11111", "Client");

            BookService.CreateIfNotExist("Hector Servadac");
            BookCategoryService.Create("Hector Servadac", "Scifi","Guthenberg");
            BookService.Create("Neuromancer");
            BookCategoryService.Create("Neuromancer", "Scifi","Guthenberg");
            BookService.Create("Terminator");
            BookCategoryService.Create("Terminator", "Scifi","Guthenberg");
            BookService.Create("Diplomacy");
            BookCategoryService.Create("Diplomacy", "Politics","Guthenberg");
            BookService.Create("Before Crisis");
            BookCategoryService.Create("Before Crisis", "History","Guthenberg");

            BorrowingService.Create("Hector Servadac", "Marilyn Monroe");
            BorrowingService.Create("Terminator", "Marilyn Monroe");
            BorrowingService.Create("Diplomacy", "Michael Jackson");

            var borrowing = BorrowingService.ReadByTitle("Hector Servadac");
            BorrowingService.Delete(borrowing);

            return View();
        }

    }
}
