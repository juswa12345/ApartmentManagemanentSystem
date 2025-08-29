namespace Identity.Controller.Request
{
    public class RegisterUserRequest
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public int Gender { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string ContactNumber { get; set; } = "";

        public List<string> RoleIds { get; set; } = [];
    }
}
