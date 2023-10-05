using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.Appointment;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;
using System.Linq;

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

        public async Task<IEnumerable<NotAttendedDto>> GetNotAttended()
        {

            var response = await _mapper
                .ProjectTo<AppointmentDto>(_context.Appointments, null)
                .Where(appointment => appointment.HasAttended == false)
                .GroupBy(appointment => appointment.CustomerName)
                .Select(group => new NotAttendedDto
                {
                    customerName = group.Key,
                    count = group.Count()
                })
                .OrderByDescending(item => item.count)
                .ToListAsync();
                

            return response;
        }

        public async Task<ServiceResponse<Appointment>> Create(CreateAppointmentDto dto)
        {
            var response = new ServiceResponse<Appointment>();
            
            if (dto.DateTime == default(DateTime) || dto.SurgeryId == null || dto.UserIds.Count < 1) 
            {
                response.Data = null;
                response.Message = "Please, provide all necessary fields";
                response.Success = false;
                return response;
            }
            
            var appointment = new Appointment()
            {
                DateTime = (DateTime)dto.DateTime,
                Surgery = _context.Surgeries.FirstOrDefault(surgery => surgery.Id == dto.SurgeryId),
                PersonnelAttending = _context.Users.Where(user => dto.UserIds.Any(g => g == user.Id)).ToList(),
            };
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            response.Data = appointment;

            return response;
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
