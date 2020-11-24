using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication.Controllers
{
    [Authorize(AuthenticationSchemes = "BasicAuth")]
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<string>> Index()
        {
            var Userkingdom = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Kingdom")).Value;
            return Userkingdom;
        }
    }
}