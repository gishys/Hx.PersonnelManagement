using Hx.PropertyRightManagement.Domain;
using Hx.PropertyRightManagement.Gdb.Access;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Hx.PropertyRightManagement.Application
{
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(HxPropertyRightManagementDomainModule))]
    [DependsOn(typeof(HxPropertyRightManagementGdbAccessModule))]
    public class HxPropertyRightManagementApplicationModule : AbpModule
    {
    }
}
