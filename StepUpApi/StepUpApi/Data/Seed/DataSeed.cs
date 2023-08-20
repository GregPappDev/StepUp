using StepUpApi.Models;

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
    }
}
