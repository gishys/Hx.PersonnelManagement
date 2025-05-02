using Hx.PersonnelManagement.Application.Contracts;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace Hx.PropertyRightManagement.Application.Contracts
{
    [DependsOn(typeof(AbpFluentValidationModule))]
    [DependsOn(typeof(HxPersonnelManagementApplicationContractsModule))]
    internal class HxPropertyRightManagementApplicationContractsModule : AbpModule
    {
    }
}
