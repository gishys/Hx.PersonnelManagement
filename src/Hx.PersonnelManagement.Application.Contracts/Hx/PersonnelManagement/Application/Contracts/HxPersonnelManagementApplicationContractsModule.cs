using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace Hx.PersonnelManagement.Application.Contracts
{
    [DependsOn(typeof(AbpFluentValidationModule))]
    public class HxPersonnelManagementApplicationContractsModule : AbpModule
    {
    }
}
