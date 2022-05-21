using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class TokenController : Controller
    {
        [Route("/token")]
        [HttpPost]
        public IActionResult Create([FromBody] Credential credential)
        {
            if (UserValidate.IsValidUserAndPasswordCombination(credential.username,credential.password))
                return new ObjectResult(UserValidate.GenerateToken(credential.username));
            return BadRequest();
        }

        [Authorize(Roles ="admin")]
        [Route("/validate")]
        [HttpGet]
        public string validate()
        {
            return "valid user";
        }

        [Route("/anonymous")]
        [HttpGet]
        public string anonymous()
        {
            return "anonymous user";
        }

    }
}
