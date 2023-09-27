using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.Appointment;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAll()
        {
            //var response = await _context.Appointments
            //        .Include(x => x.Surgery)
            //        .Include(x => x.PersonnelAttending)
            //        .Include(x => x.Customer)
            //        .ToListAsync();
            var response = await _mapper.ProjectTo<AppointmentDto>(_context.Appointments, null).ToListAsync();

            return response;
        }

        public Task<ServiceResponse<Appointment>> Create(CreateAppointmentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Appointment>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        
        public Task<ServiceResponse<Appointment>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<Appointment>>> GetNotDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Appointment>> Update(Guid id, UpdateExaminationTypeDto updatedData)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<Appointment>>> BookAppointment(List<BookAppointmentDto> dto)
        {
            throw new NotImplementedException();
        }
    }
}
