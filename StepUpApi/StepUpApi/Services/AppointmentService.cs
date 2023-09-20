﻿using AutoMapper;
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

        public async Task<ServiceResponse<IEnumerable<Appointment>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Appointment>>
            {
                Data = await _context.Appointments
                    .Include(x => x.Surgery)
                    .ToListAsync()
            };
            return serviceResponse;
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
    }
}
