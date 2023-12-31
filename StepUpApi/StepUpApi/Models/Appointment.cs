﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StepUpApi.Models.Enums;

namespace StepUpApi.Models;

public class Appointment
{
    public Guid Id { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    public Surgery? Surgery { get; set; }
    public Customer? Customer { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public ICollection<ExaminationType> ExaminationTypes { get; set; } = new List<ExaminationType>();
    public string Comment { get; set; } = string.Empty;
    public DateTime? PatientDateOfBirth { get; set; }
    public string PatientJobTitle { get; set; } = string.Empty;
    public char? PatientCategory { get; set; }
    public bool? HasAttended { get; set; }
    public ResultType? Result { get; set; }
    public DateTime? NextExamination { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public ICollection<User> PersonnelAttending { get; set; } = new List<User>();
    //public Guid AppointmentLogId { get; set; }
    public List<AppointmentLog> Log { get; set; } = new List<AppointmentLog> { };
    public bool IsDeleted { get; set; } = false;
}