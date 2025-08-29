using Identity.Application.Response;

namespace Identity.Application.Commands
{
    public interface IAuthenticationCommands
    {
        Task<AuthenticationResponse> RegisterAsync(string firstName, string lastName, string email, string password, List<string> roleId);
        Task<AuthenticationResponse> Login(string email, string password);
    }
}