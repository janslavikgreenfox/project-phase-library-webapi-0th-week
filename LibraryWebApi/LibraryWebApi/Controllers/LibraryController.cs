using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Databases;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public LibraryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
