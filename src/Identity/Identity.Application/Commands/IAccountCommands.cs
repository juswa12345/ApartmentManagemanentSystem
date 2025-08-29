using Identity.Application.Response;

namespace Identity.Application.Commands
{
    public interface IAccountCommands
    {
        Task CreateTenantAsync(string firstName, string lastName, string email, string contactNumber, int gender, int age, string street, string city, string state, string zipCode, Guid userId);

        Task<List<AccountResponse>> GetAccountsAsync();
    }
}
