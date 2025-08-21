using Identity.Domain.ValueObjects;

namespace Identity.Domain.Entities
{
    public class Role
    {
        public RoleId Id { get; set; }

        public string RoleName { get; set; }
    }
}
