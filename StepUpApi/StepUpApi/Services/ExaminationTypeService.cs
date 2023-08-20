using StepUpApi.Data;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class ExaminationTypeService : IExaminationTypeService
    {
        private readonly ApiDbContext _context;
        
        public ExaminationTypeService(ApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ExaminationType> GetAll()
        {
            return _context.ExaminationTypes;
        }

        public ExaminationType? GetById(Guid id)
        {
            return _context.ExaminationTypes.FirstOrDefault( e => e.Id == id);
        }

        public void Create(ExaminationType item)
        {
            if (_context.ExaminationTypes.Any(type => type.Type == item.Type)) return;
            _context.ExaminationTypes.Add(item);
            _context.SaveChanges();
        }

        public ExaminationType? Update(ExaminationType updatedData)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            ExaminationType? examinationType = GetById(id);
            if (examinationType == null) return;
            _context.ExaminationTypes.Remove(examinationType);
            _context.SaveChanges();
        }
    }
}
