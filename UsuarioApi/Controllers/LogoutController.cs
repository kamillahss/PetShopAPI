using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Models;

namespace UsuarioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {

        private SignInManager<Usuario> _signInManager;

        public LogoutController(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            var resultIdentity = _signInManager.SignOutAsync();
            if(resultIdentity.IsCompletedSuccessfully)
                return Unauthorized();

            return Ok();
        }
    }
}
