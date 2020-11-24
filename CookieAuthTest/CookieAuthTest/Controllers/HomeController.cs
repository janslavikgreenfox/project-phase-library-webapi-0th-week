using CookieAuthTest.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieAuthTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        public string Index()
        {
            var entity = HttpContext.User;
            return "You just discovered a terrible secret...";
        }


        public ActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var entityUser = dbContext.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

            if (entityUser is null)
            {
                return RedirectToAction("Login");
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, entityUser.Username), new Claim("FavouriteColor", entityUser.FavouriteColor) };
            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            var returnUrl = TempData["returnUrl"] as string;

            return LocalRedirect(returnUrl ?? "/");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
