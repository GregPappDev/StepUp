using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.AppointmentLog;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class AppointmentLogService : IAppointmentLogService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentLogService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<IEnumerable<AppointmentLog>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<AppointmentLog>>
            {
                Data = await _context.AppointmentLog
                    .Include(x => x.Users)
                    //.Include(x => x.Appointment)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<AppointmentLog>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<AppointmentLog>();
            serviceResponse.Data = await _context.AppointmentLog
                .Include(x => x.Users)
                //.Include(x => x.Appointment)
                .FirstOrDefaultAsync(x => x.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<AppointmentLog>> Create(CreateAppointmentLogDto dto)
        {
            var serviceResponse = new ServiceResponse<AppointmentLog>();
            
            var appointmentLog = _mapper.Map<AppointmentLog>(dto);

            _context.AppointmentLog.Add(appointmentLog);
            await _context.SaveChangesAsync();

            serviceResponse.Data = appointmentLog;
            return serviceResponse;
        }

        public async Task<ServiceResponse<AppointmentLog>> Update(Guid id, UpdateAppointmentLogDto updatedData)
        {
            var serviceResponse = new ServiceResponse<AppointmentLog>();

            var appointmentLog = await _context.AppointmentLog.FirstOrDefaultAsync(x => x.Id == id);
            if (appointmentLog == null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            _mapper.Map(updatedData, appointmentLog);
            await _context.SaveChangesAsync();

            serviceResponse.Data = appointmentLog;

            return serviceResponse;
        }
    }
}
