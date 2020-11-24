
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BasicAuthentication.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("authKey")) // check if there is any key in the header in the first place
            {
                return AuthenticateResult.Fail("Key was not found");
            }

            var userValues = Request.Headers["authKey"].ToString().Split(','); // manipulate the incoming key (validate, decode, read ...)
            var userName = userValues[0];
            var userKingdom = userValues[1];

            var claims = new[] { new Claim(ClaimTypes.Name, userName), new Claim("Kingdom", userKingdom), new Claim(ClaimTypes.Role, "Teacher") }; // these may come from database, just inject dbContext
            var identity = new ClaimsIdentity(claims, "BasicAuth");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "BasicAuth");

            return AuthenticateResult.Success(ticket);
        }
    }
}