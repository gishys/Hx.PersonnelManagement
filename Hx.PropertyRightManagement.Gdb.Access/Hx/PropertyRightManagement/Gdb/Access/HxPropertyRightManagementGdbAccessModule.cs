using ESRI.ArcGIS.Geodatabase;
using Hx.PersonnelManagement.Domain;
using Hx.PropertyRightManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Hx.PropertyRightManagement.Gdb.Access
{
    public class HxPropertyRightManagementGdbAccessModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // 读取配置文件
            //services.AddSingleton<IConfiguration>(Configuration);

            // 注册 Workspace 工厂
            context.Services.AddSingleton<IGeoWorkspaceFactory, FileGdbWorkspaceFactory>();
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
            // 注册 IWorkspace（每请求一个实例）
            context.Services.AddScoped(provider =>
            {
                var factory = provider.GetRequiredService<IGeoWorkspaceFactory>();
                var workspace = factory.CreateWorkspace();
                provider.GetRequiredService<ComObjectDisposer>(); // 绑定生命周期
                return workspace;
            });

            // 条件注册仓储
            context.Services.AddScoped<IForestLandSurveyRepository<Person>>(provider =>
            {
                var workspace = provider.GetRequiredService<IWorkspace>();
                return new GdbForestLandSurveyRepository<Person>(workspace);
                //if (Configuration.GetValue<bool>("UseGdb"))
                //{
                //    var workspace = provider.GetRequiredService<IWorkspace>();
                //    return new GdbForestLandSurveyRepository<RHolder>(workspace);
                //}
                //else
                //{
                //    var dbContext = provider.GetRequiredService<SurveyDbContext>();
                //    return new DbForestLandSurveyRepository<RHolder>(dbContext);
                //}
            });
        }
    }
}
