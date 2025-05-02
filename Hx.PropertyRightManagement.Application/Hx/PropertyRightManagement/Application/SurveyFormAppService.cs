using Hx.PersonnelManagement.Domain;
using Hx.PropertyRightManagement.Domain;
using Volo.Abp.Application.Services;

namespace Hx.PropertyRightManagement.Application
{
    public class SurveyFormAppService(
        IForestLandSurveyRepository<Person> forestLandSurveyRepository) : ApplicationService
    {
        private readonly IForestLandSurveyRepository<Person> ForestLandSurveyRepository = forestLandSurveyRepository;

        public async Task GetAsync()
        {
            await ForestLandSurveyRepository.GetByIdAsync(Guid.NewGuid());
        }
    }
}
