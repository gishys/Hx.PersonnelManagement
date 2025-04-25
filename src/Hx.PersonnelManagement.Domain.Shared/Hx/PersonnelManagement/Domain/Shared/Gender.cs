using System.ComponentModel;

namespace Hx.PersonnelManagement.Domain.Shared
{
    /// <summary>
    /// 人员性别
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 未指定/未知性别（默认值）
        /// </summary>
        [Description("未知性别")]
        NotSpecified = 0,

        /// <summary>
        /// 男性
        /// </summary>
        [Description("男性")]
        Male = 1,

        /// <summary>
        /// 女性
        /// </summary>
        [Description("女性")]
        Female = 2,

        /// <summary>
        /// 其他性别认同
        /// </summary>
        [Description("其他")]
        Other = 3
    }
}
