using Microsoft.EntityFrameworkCore;
using StepUpApi.Models;

namespace StepUpApi.Data;

public class ApiDbContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentLog> AppointmentLog { get; set; }
    public DbSet<ContactDetails> ContactDetails { get; set; }
    public DbSet<ContactPerson> ContactPersons { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EmployeeType> EmployeeTypes { get; set; }
    public DbSet<ExaminationType> ExaminationTypes { get; set; }
    public DbSet<Surgery> Locations { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<PeriodicInvoice> PeriodicInvoices { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options ) : base( options )
    {
        
    }
}