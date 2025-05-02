using System.Threading;
using System.Threading.Tasks;
using Hx.PropertyRightManagement.Application;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Hx.PersonnelManagement;

public class PersonnelManagementHostedService : IHostedService
{
    private readonly HelloWorldService _helloWorldService;
    private readonly SurveyFormAppService SurveyFormAppService;
    public PersonnelManagementHostedService(
        HelloWorldService helloWorldService,
        SurveyFormAppService surveyFormAppService)
    {
        _helloWorldService = helloWorldService;
        SurveyFormAppService = surveyFormAppService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _helloWorldService.SayHelloAsync();
        await SurveyFormAppService.GetAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
