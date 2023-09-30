using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<Customer>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Customer>>
            {
                Data = await _context.Customers
                    .Where(x => x.IsDeleted == false)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public Task<ServiceResponse<Customer>> Create(CreateCustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Customer>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Customer>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }



        public Task<ServiceResponse<Customer>> Update(Guid id, CreateCustomerDto updatedData)
        {
            throw new NotImplementedException();
        }
    }
}
