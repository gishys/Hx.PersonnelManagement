using Hx.PersonnelManagement.Domain;
using Volo.Abp.Domain.Repositories;

namespace Hx.PropertyRightManagement.Domain
{
    public interface IForestLandSurveyRepository<RHolder>
        : IBasicRepository<ForestLandSurveyInfo<RHolder>, Guid> where RHolder : Person
    {
        Task<ForestLandSurveyInfo<RHolder>> GetByParcelCodeAsync(string code);
        Task<ForestLandSurveyInfo<RHolder>?> GetByIdAsync(Guid id);
    }
}
