namespace Identity.Controller.Request
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string MobileNumber { get; set; }
        public string IdNumber { get; set; }
    }
}
