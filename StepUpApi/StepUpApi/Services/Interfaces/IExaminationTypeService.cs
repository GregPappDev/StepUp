using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IExaminationTypeService
    {
        IEnumerable<ExaminationType> GetAll();
        ExaminationType? GetById(Guid id);
        void Create(ExaminationType item);
        ExaminationType? Update(ExaminationType updatedData);
        void Delete(Guid id);
        
    }
}
