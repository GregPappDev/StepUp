﻿using StepUpApi.Models;

namespace StepUpApi.DTOs.AppointmentLog
{
    public class UpdateAppointmentLogDto
    {
        public ICollection<User> Users { get; set; } = new List<User>();
        public Guid AppointmentId { get; set; }
        public Models.Appointment? Appointment { get; set; }
    }
}
