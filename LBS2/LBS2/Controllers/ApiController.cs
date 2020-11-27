using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBS2.DTOs.Responses;
using LBS2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [HttpGet("/book/all")]
        public ActionResult<List<BookResponse>> AllBooksGet()
        {

            var allBooks = BookService.ReadAll();
            var bookResponse = Mapper.Map<IEnumerable<BookResponse>>(allBooks);
            return Ok(bookResponse);
        }

        [HttpGet("/book")]
        public ActionResult<BookResponse> BookGet([FromQuery] string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                return NotFound("The book title is not valid.");
            }
            var book = BookService.Read(title);
            return Ok(Mapper.Map<BookResponse>(book));
        }

        [HttpGet("/account/all")]
        public ActionResult<List<AccountResponse>> AllAccountsGet()
        {
            var allAccounts = AccountService.ReadAll();
            var accountResponse = Mapper.Map<IEnumerable<AccountResponse>>(allAccounts);
            var jsonOutput = 
                JsonConvert.SerializeObject(
                    accountResponse, Formatting.Indented, 
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            return Ok(accountResponse);
        }

        [HttpGet("/account")]
        public ActionResult<AccountResponse> AccountGet([FromQuery] string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return NotFound("The account name is not valid!");
            }
            var account = AccountService.Read(name);
            var accountResponse = Mapper.Map<AccountResponse>(account);
            return Ok(Mapper.Map<AccountResponse>(account));
        }
    }
}
