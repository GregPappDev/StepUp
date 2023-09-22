using StepUpApi.Models;
using System.Security.Cryptography;

namespace StepUpApi.Data.Seed
{
    public class DataSeed
    {
        private readonly ApiDbContext _context;

        public DataSeed(ApiDbContext context)
        {
            _context = context;
        }

        public void CreateAll()
        {
            CreateExaminationTypes();
            CreateRoles();
            CreateUsers();
            CreateAppointments();
        }

        private void CreateExaminationTypes()
        {
            List<ExaminationType> types = new List<ExaminationType>()
            {
                new ExaminationType {Type = "Initial Examination" },
                new ExaminationType {Type = "Periodic Examination" },
                new ExaminationType {Type = "Final Examination" },
            };


            _context.ExaminationTypes.AddRange(types);
            _context.SaveChanges();
        }

        private List<User> CreateUsers()
        {
            List<string> users = new List<string>()
            {
                "Susan Smith",
                "Michael Taylor"
            };

            List<User> testUsers = new List<User>();

            var roles = _context.Roles.ToList();

            for (var i = 0; i < users.Count; i++)
            {
                var newUser = new User();
                newUser.Name = users[i];
                newUser.UserName = String.Concat(users[i].Where(c => !Char.IsWhiteSpace(c))).ToLower();
                string password = String.Concat(users[i].Where(c => !Char.IsWhiteSpace(c))).ToLower();
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                newUser.PasswordHash = passwordHash;
                newUser.PasswordSalt = passwordSalt;

                var role = roles[i];
                newUser.Roles.Add(role);

                _context.Users.Add(newUser);
                _context.SaveChanges();
                testUsers.Add(newUser);
                
            }
            return testUsers;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private void CreateRoles()
        {
            var roles = new List<Role>();

            var admin = new Role();
            admin.Type = "admin";
            roles.Add(admin);

            var nurse = new Role();
            nurse.Type = "nurse";
            roles.Add(nurse);

            _context.Roles.AddRange(roles);
            _context.SaveChanges();
        }



        private void CreateAppointments()
        {
            var Eger = new Surgery() { Name = "Eger" };
            var Abony = new Surgery() { Name = "Füzesabony" };

            List<User> users = CreateUsers();

            var startDate = new DateTime(2023,9,22,10,0,0);

            var appointments = new List<Appointment>()

            {
                new Appointment() { DateTime = startDate, Surgery = Eger, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddMinutes(10), Surgery = Eger, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddMinutes(20), Surgery = Eger, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddMinutes(30), Surgery = Eger, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddMinutes(40), Surgery = Eger, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddDays(1), Surgery = Abony, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddDays(1).AddMinutes(10), Surgery = Abony, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddDays(1).AddMinutes(20), Surgery = Abony, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddDays(1).AddMinutes(30), Surgery = Abony, PersonnelAttending = users },
                new Appointment() { DateTime = startDate.AddDays(1).AddMinutes(40), Surgery = Abony, PersonnelAttending = users },
            };

            _context.Appointments.AddRange(appointments);
            _context.SaveChanges();
        }
    }
}
