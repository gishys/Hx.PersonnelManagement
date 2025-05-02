using ESRI.ArcGIS.Geodatabase;

namespace Hx.PropertyRightManagement.Gdb.Access
{
    public interface IGeoWorkspaceFactory
    {
        IWorkspace CreateWorkspace();
    }
}
