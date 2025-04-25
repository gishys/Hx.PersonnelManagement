using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace Hx.PropertyRightManagement.Application.Contracts
{
    [DependsOn(typeof(AbpFluentValidationModule))]
    internal class HxPropertyRightManagementApplicationContractsModule : AbpModule
    {
    }
}
