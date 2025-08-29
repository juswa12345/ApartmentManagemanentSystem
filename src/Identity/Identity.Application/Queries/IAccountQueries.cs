using Identity.Domain.Entities;

namespace Identity.Application.Queries
{
    public interface IAccountQueries
    {       
        Task<List<Account>> GetAccountsAsync();
    }
}
