using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IExaminationTypeService
    {
        Task<ServiceResponse<IEnumerable<ExaminationType>>> GetAll();
        Task<ServiceResponse<ExaminationType>> GetById(Guid id);
        Task<ServiceResponse<ExaminationType>> Create(UpdateExaminationTypeDto dtoType);
        Task<ServiceResponse<ExaminationType>> Update(Guid id, UpdateExaminationTypeDto updatedData);
        Task<ServiceResponse<ExaminationType>> Delete(Guid id);
        
    }
}
