using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.ContactDetails;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class ContactDetailsService : IContactDetailsService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ContactDetailsService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<ContactDetails>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<ContactDetails>>
            {
                Data = await _context.ContactDetails
                    .Include(x => x.Customer)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<ContactDetails>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<ContactDetails>>
            {
                Data = await _context.ContactDetails
                    .Where(x => x.IsDeleted == false)
                    .Include(x => x.Customer)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactDetails>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<ContactDetails>();
            serviceResponse.Data = await _context.ContactDetails.FirstOrDefaultAsync(x => x.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactDetails>> Create(UpdateContactDetailsDto dto)
        {
            var serviceResponse = new ServiceResponse<ContactDetails>();
            
            var contactDetails = _mapper.Map<ContactDetails>(dto);

            _context.ContactDetails.Add(contactDetails);
            await _context.SaveChangesAsync();

            serviceResponse.Data = contactDetails;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactDetails>> Update(Guid id, UpdateContactDetailsDto updatedData)
        {
            var serviceResponse = new ServiceResponse<ContactDetails>();

            var contactDetails = await _context.ContactDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (contactDetails == null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            _mapper.Map(updatedData, contactDetails);
            await _context.SaveChangesAsync();

            serviceResponse.Data = contactDetails;

            return serviceResponse;

        }

        public async Task<ServiceResponse<ContactDetails>> Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No contact details found";
                serviceResponse.Success = false;
                return serviceResponse;
            };

            var contactDetails = serviceResponse.Data;
            contactDetails.IsDeleted = true;
            _context.ContactDetails.Update(contactDetails);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }
    }
}
