using ApartmentManagementSystem.Contracts.Services;
using AutoMapper;
using Identity.Application.Commands;
using Identity.Application.Repositories;
using Identity.Application.Response;
using Identity.Application.Services;
using Identity.Domain.Entities;
using Identity.Domain.Repositories;


namespace Identity.Application.CommandHandlers
{
    public class AuthenticationCommands : IAuthenticationCommands
    {
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationCommands(
            IMapper mapper,
            IPasswordService passwordService,
            ITokenService tokenService,
            IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public async Task<AuthenticationResponse> Login(string email, string password)
        {
            User? existingUser = await _unitOfWork.UserRepository.GetByEmailAsync(email);
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

        public async Task<AuthenticationResponse> RegisterAsync(string firstName, string lastName, string email, string password, List<string> roleId)
        {
            //Check if user already exists
            User? existingUser = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            if (existingUser is not null)
            {
                return new AuthenticationResponse
                {
                    IsSuccess = false,
                    Message = "User already exists with this email."
                };            }
            //Create Password Hash
            string passwordHash = _passwordService.HashPassword(email, password);

            //Add to Database
            User user = User.Create(firstName, lastName, email, passwordHash, roleId);
            await _unitOfWork.UserRepository.AddAsync(user);

            await _unitOfWork.SaveChangesAsync(default);

            //Token Generation
            string accessToken = _tokenService.GenerateToken(user);

            //Wrap to Authentication response success, access_token, "message"
            return new AuthenticationResponse
            {
                IsSuccess = true,
                Message = "User registered successfully.",
                AccessToken = accessToken,
                User = _mapper.Map<UserResponse>(user),
            };
        }
    }
}