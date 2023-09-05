using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.ContactPerson;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ContactPersonService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<ContactPerson>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<ContactPerson>>
            {
                Data = await _context.ContactPersons
                    .Include(x => x.Customers)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<ContactPerson>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<ContactPerson>>
            {
                Data = await _context.ContactPersons
                    .Where(x => x.IsDeleted == false)
                    .Include(x => x.Customers)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactPerson>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<ContactPerson>();
            serviceResponse.Data = await _context.ContactPersons.FirstOrDefaultAsync(x => x.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactPerson>> Create(UpdateContactPersonDto dto)
        {
            var serviceResponse = new ServiceResponse<ContactPerson>();

            var contactPerson = _mapper.Map<ContactPerson>(dto);

            _context.ContactPersons.Add(contactPerson);
            await _context.SaveChangesAsync();

            serviceResponse.Data = contactPerson;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactPerson>> Update(Guid id, UpdateContactPersonDto updatedData)
        {
            var serviceResponse = new ServiceResponse<ContactPerson>();

            var contactPerson = await _context.ContactPersons.FirstOrDefaultAsync(x => x.Id == id);
            if (contactPerson == null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            _mapper.Map(updatedData, contactPerson);
            await _context.SaveChangesAsync();

            serviceResponse.Data = contactPerson;

            return serviceResponse;

        }

        public async Task<ServiceResponse<ContactPerson>> Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No contact person found";
                serviceResponse.Success = false;
                return serviceResponse;
            };

            var contactPerson = serviceResponse.Data;
            contactPerson.IsDeleted = true;
            _context.ContactPersons.Update(contactPerson);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }
    }
}
