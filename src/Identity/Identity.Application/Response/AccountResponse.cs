using Identity.Domain.Entities;

namespace Identity.Application.Response
{
    public class AccountResponse
    {
        public string AccountId { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public int Gender { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string ContactNumber { get; set; } = "";
        public List<string> Roles { get; set; } = [];
    }
}
