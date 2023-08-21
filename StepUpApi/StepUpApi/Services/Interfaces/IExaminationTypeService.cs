using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IExaminationTypeService
    {
        Task<ServiceResponse<IEnumerable<ExaminationType>>> GetAll();
        Task<ServiceResponse<ExaminationType>> GetById(Guid id);
        Task<ServiceResponse<ExaminationType>> Create(ExaminationType item);
        Task<ServiceResponse<ExaminationType>> Update(ExaminationType updatedData);
        void Delete(Guid id);
        
    }
}
