namespace Identity.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        private Role(Guid id, string name)
        {         
            Id = id;
            Name = name;

        }

        public static Role Create(string name)
        {
            return new Role(Guid.NewGuid(), name);
        }
    }
}
