using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBS2.DTOs.Responses;
using LBS2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBS2.Databases
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        public IAccount AccountService { get; set; }
        public IAuthorizationLevel AuthorizationLevelService { get; set; }
        public IBook BookService { get; set; }
        public IBookCategories BookCategoryService { get; set; }
        public IBorrowing BorrowingService { get; set; }
        public ICategory CategoryService { get; set; }
        public IMapper Mapper { get; set; }
        public APIController(
            IAccount accountService,
            IAuthorizationLevel authorizationLevelService,
            IBook bookService,
            IBookCategories bookCategoryService,
            IBorrowing borrowingService,
            ICategory categoryService,
            IMapper mapper
            )
        {
            AccountService = accountService;
            AuthorizationLevelService = authorizationLevelService;
            BookService = bookService;
            BookCategoryService = bookCategoryService;
            BorrowingService = borrowingService;
            CategoryService = categoryService;
            Mapper = mapper;
        }


        [HttpGet("/a")]
        public ActionResult MethodA()
        {
            return Ok();
        }
        //[HttpPost("/save-category")]
        //public ActionResult Save([FromBody] CategoryForm item)
        //{

        //}
        [HttpGet("/all-books")]
        public ActionResult<List<BookResponse>> AllBooksGet()
        {
            //var book = BookService.Read("Hector Servadac");
            //var bookResponse = Mapper.Map<BookResponse>(book);
            var allBooks = BookService.ReadAll();
            var bookResponse = Mapper.Map<IEnumerable<BookResponse>>(allBooks);
            return Ok(bookResponse);
        }

        [HttpGet("/all-accounts")]
        public ActionResult<List<AccountResponse>> AllAccountsGet()
        {
            var allAccounts = AccountService.ReadAll();
            var accountResponse = Mapper.Map<IEnumerable<AccountResponse>>(allAccounts);
            return Ok(accountResponse);
        }
    }
}
