using ESRI.ArcGIS.Geodatabase;
using System.Runtime.InteropServices;

namespace Hx.PropertyRightManagement.Gdb.Access
{
    public class ComObjectDisposer(IWorkspace workspace) : IDisposable
    {
        private readonly IWorkspace _workspace = workspace;

        public void Dispose()
        {
            if (_workspace != null)
            {
#pragma warning disable CA1416 // 验证平台兼容性
                Marshal.FinalReleaseComObject(_workspace);
#pragma warning restore CA1416 // 验证平台兼容性
            }
        }
    }
}
