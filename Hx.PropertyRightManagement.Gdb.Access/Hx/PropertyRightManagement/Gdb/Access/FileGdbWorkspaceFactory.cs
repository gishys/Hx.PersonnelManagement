using ESRI.ArcGIS;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using Microsoft.Extensions.Configuration;
using Volo.Abp;

namespace Hx.PropertyRightManagement.Gdb.Access
{
    public class FileGdbWorkspaceFactory : IGeoWorkspaceFactory
    {
        private readonly string _gdbPath;

        public FileGdbWorkspaceFactory(IConfiguration config)
        {
            _gdbPath = config["ArcGIS:FileGdbPath"] ?? "";
            if (!RuntimeManager.Bind(ProductCode.Engine))
            {
                throw new Exception("无法绑定 ArcEngine 运行时");
            }
            IAoInitialize aoInit = new AoInitializeClass();
            aoInit.Initialize(esriLicenseProductCode.esriLicenseProductCodeEngineGeoDB);
        }

        public IWorkspace CreateWorkspace()
        {
            try
            {
#pragma warning disable CA1416 // 验证平台兼容性
                Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory") ?? throw new UserFriendlyException(message: "ArcGIS Engine 组件未正确安装");
#pragma warning restore CA1416 // 验证平台兼容性
                IWorkspaceFactory workspaceFactory = Activator.CreateInstance(factoryType) as IWorkspaceFactory ?? throw new UserFriendlyException(message: "初始化IWorkspaceFactory失败");
                if (!workspaceFactory.IsWorkspace(_gdbPath))
                {
                    throw new UserFriendlyException(message: "GDB 路径无效或不存在");
                }
                return workspaceFactory.OpenFromFile(_gdbPath, 0);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: $"打开 GDB 失败: {ex.Message}");
            }
        }
    }
}
