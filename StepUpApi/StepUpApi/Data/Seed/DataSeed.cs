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

        private void CreateUsers()
        {
            List<string> users = new List<string>()
            {
                "Susan Smith",
                "Michael Taylor"
            };

            var roles = _context.Roles.ToList();

            for(var i = 0; i < users.Count; i++)
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
            }
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
    }
}
