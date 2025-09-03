using Identity.Application.Commands;
using Identity.Application.Response;
using Identity.Controller.Request;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controller
{
    [Route("api/accounts")]
    [ApiController]
    public  class AccountsController : ControllerBase
    {
        private readonly IAuthenticationCommands _authenticationService;
        private readonly IAccountCommands _accountCommands;

        public AccountsController(IAuthenticationCommands authenticationService, IAccountCommands accountCommands)
        {
            _authenticationService = authenticationService;
            _accountCommands = accountCommands;
        }

        [HttpPost("registerAccount")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var response =
                await _authenticationService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password, request.RoleIds);

            var user = response.User;

            if(user is null)
            {
                return BadRequest(response);
            }

            await _accountCommands.CreateTenantAsync(request.FirstName, request.LastName, request.Email, request.ContactNumber, request.Gender, request.Age, request.Street, request.City, request.State, request.ZipCode, user.Id);

            return Ok(response);
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] Request.LoginRequest request)
        //{
        //    var response = await _authenticationService.Login(request.Email, request.Password);
        //    if (!response.IsSuccess)
        //    {
        //        return BadRequest(response);
        //    }
        //    return Ok(response);

        //}

        //[HttpGet("getAccounts")]

        //public async Task<ActionResult<List<AccountResponse>>> GetAccountsAsync()
        //{
        //    var response = await _accountCommands.GetAccountsAsync();

        //    if (response.Count == 0)
        //    {
        //        return NotFound("No accounts found.");
        //    }

        //    return Ok(response);
        //}
    }
}
