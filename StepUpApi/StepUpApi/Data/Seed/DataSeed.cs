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

            foreach (var user in users)
            {
                var newUser = new User();
                newUser.Name = user;
                newUser.UserName = String.Concat(user.Where(c => !Char.IsWhiteSpace(c))).ToLower();
                string password = Random.Shared.Next(100000, 999999).ToString();
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                newUser.PasswordHash = passwordHash; 
                newUser.PasswordSalt = passwordSalt;
                _context.Users.Add(newUser);
                _context.SaveChanges(true);
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


    }
}
