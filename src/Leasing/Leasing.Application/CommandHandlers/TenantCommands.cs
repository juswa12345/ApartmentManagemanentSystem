using ApartmentManagementSystem.SharedKernel.ValueObjects;
using AutoMapper;
using Leasing.Application.Commands;
using Leasing.Application.Queries;
using Leasing.Application.Repositories;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandlers
{
    public class TenantCommands : ITenantCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantQueries _tenantQueries;

        public TenantCommands(IUnitOfWork unitOfWork, IMapper mapper, ITenantQueries tenantQueries)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantQueries = tenantQueries;
        }
        public async Task AddTenantAsync(Guid tenantId, string firstName, string lastName, string email, string phoneNumber)
        {
            Tenant tenant = Tenant.Create(new TenantId(tenantId), new PersonName(firstName, lastName), email, phoneNumber);

            await _unitOfWork.TenantRepository.AddTenantAsync(tenant);
            await _unitOfWork.SaveChangesAsync(default);
        }

        public async Task<List<TenantReponse>> GetAllTenantsAsync()
        {
            var tenants = await _tenantQueries.GetTenantsAsync();

            if (tenants.Count == 0)
                return [];

            return _mapper.Map<List<TenantReponse>>(tenants);
        }

        public async Task<TenantReponse?> GetTenantByIdAsync(Guid tenantId)
        {
            var tenant = await _tenantQueries.GetTenantByIdAsync(tenantId);

            if (tenant is null)
                return null;

            return _mapper.Map<TenantReponse>(tenant);
        }

        public async Task RemoveTenantAsync(Guid tenantId)
        {
            var tenant = await _unitOfWork.TenantRepository.GetTenantByIdAsync(new TenantId(tenantId));

            if (tenant is null)
                throw new Exception($"tenant with id {tenantId} is not existed");

            await _unitOfWork.TenantRepository.DeleteTenantAsync(tenant);
            await _unitOfWork.SaveChangesAsync(default);
        }

        public async Task UpdateTenantAsync(Guid tenantId, string firstName, string lastName, string email, string phoneNumber)
        {
            var tenant = await _unitOfWork.TenantRepository.GetTenantByIdAsync(new TenantId(tenantId));

            if(tenant is null)
                throw new Exception($"tenant with id {tenantId} is not existed");


            var updatedFirstName = firstName == "" ? tenant.TenantName.FirstName : firstName;
            var updatedLastName = lastName == "" ? tenant.TenantName.LastName : lastName;

            var updatedPhoneNumber = phoneNumber == "" ? tenant.PhoneNumber : phoneNumber;

            var updatedEmail = email == "" ? tenant.Email : email;

            tenant.Update(new PersonName(updatedFirstName, updatedLastName), updatedPhoneNumber, updatedEmail);

            await _unitOfWork.TenantRepository.UpdateTenantAsync(tenant);
            await _unitOfWork.SaveChangesAsync(default);
        }
    }
}
