using System.ComponentModel;

namespace Hx.PropertyRightManagement.Domain.Shared
{
    /// <summary>
    /// 所有权性质
    /// </summary>
    public enum OwnershipNature
    {
        [Description("国家所有")]
        StateOwned = 1,

        [Description("集体所有")]
        CollectiveOwned = 2
    }
}
