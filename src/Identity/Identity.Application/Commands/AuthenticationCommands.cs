using ApartmentManagementSystem.Contracts.Services;
using Identity.Application.Response;
using Identity.Application.Services;
using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using Identity.Domain.ValueObjects;


namespace Identity.Application.Commands
{
    public class AuthenticationCommands : IAuthenticationCommands
    {
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IDomainEventPublisher _publisher;

        public AuthenticationCommands(
            IPasswordService passwordService,
            ITokenService tokenService,
            IUserRepository userRepository,
            IDomainEventPublisher publisher)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _publisher = publisher;
            _passwordService = passwordService;
        }

        public async Task<AuthenticationResponse> Login(string email, string password)
        {
            User? existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser is null)
            {
                return new AuthenticationResponse
                {
                    IsSuccess = false,
                    Message = "Invalid email or password"
                };
            }
            bool isValid = _passwordService.ValidatePassword(email, password, existingUser.PasswordHash);
            if (!isValid)
            {
                return new AuthenticationResponse
                {
                    IsSuccess = false,
                    Message = "Invalid email or password"
                };
            }

            return new AuthenticationResponse
            {
                IsSuccess = true,
                Message = "Login Successfull",
                AccessToken = _tokenService.GenerateToken(existingUser)
            };
        }

        public async Task<AuthenticationResponse> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            //Check if user already exists
            User? existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser is not null)
            {
                return new AuthenticationResponse
                {
                    IsSuccess = false,
                    Message = "User already exists with this email."
                };
            }
            //Create Password Hash
            string passwordHash = _passwordService.HashPassword(email, password);

            Role role = new Role
            {
                Id = new RoleId(Guid.NewGuid()),
                RoleName = "Admin"
            };

            //Add to Database
            User user = User.Create(firstName, lastName, email, passwordHash);
            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync(default);

            await _publisher.PublishAsync(user.DomainEvents, default);
            //Token Generation
            string accessToken = _tokenService.GenerateToken(user);

            //Wrap to Authentication response success, access_token, "message"
            return new AuthenticationResponse
            {
                IsSuccess = true,
                Message = "User registered successfully.",
                AccessToken = accessToken
            };
        }
    }
}