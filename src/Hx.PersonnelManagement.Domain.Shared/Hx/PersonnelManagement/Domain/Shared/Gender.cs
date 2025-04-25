namespace Hx.PersonnelManagement.Domain.Shared
{
    /// <summary>
    /// 表示人员性别的枚举类型
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 未指定/未知性别（默认值）
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// 男性
        /// </summary>
        Male = 1,

        /// <summary>
        /// 女性
        /// </summary>
        Female = 2,

        /// <summary>
        /// 其他性别认同
        /// </summary>
        Other = 3
    }
}
