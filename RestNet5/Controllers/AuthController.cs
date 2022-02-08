using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestNet5.Business;
using RestNet5.Data.VO;

namespace RestNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            this._loginBusiness = loginBusiness;
        }

        [HttpPost()]
        [Route("signin")]
        public IActionResult SignIn([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpPost()]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(tokenVo);

            if (token == null) return BadRequest("Invalid client request");

            return Ok(token);
        }

        [HttpGet()]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var result = _loginBusiness.RevokeToken(User.Identity.Name);

            if (!result) return BadRequest("Invalid client request");

            return NoContent();
        }
    }
}
