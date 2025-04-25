using System.ComponentModel;

namespace Hx.PersonnelManagement.Domain.Shared
{
    /// <summary>
    /// 权利人类型
    /// </summary>
    public enum RightHolderType
    {
        /// <summary>
        /// 个人（代码1）
        /// </summary>
        [Description("个人")]
        Individual = 1,

        /// <summary>
        /// 企业（代码2）
        /// </summary>
        [Description("企业")]
        Enterprise = 2,

        /// <summary>
        /// 金融机构（代码21）
        /// </summary>
        [Description("金融机构")]
        FinancialInstitution = 21,

        /// <summary>
        /// 非金融机构（代码22）
        /// </summary>
        [Description("非金融机构")]
        NonFinancialInstitution = 22,

        /// <summary>
        /// 事业单位（代码3）
        /// </summary>
        [Description("事业单位")]
        PublicInstitution = 3,

        /// <summary>
        /// 国家机关（代码4）
        /// </summary>
        [Description("国家机关")]
        GovernmentAgency = 4,

        /// <summary>
        /// 家庭（代码5）
        /// </summary>
        [Description("家庭")]
        Family = 5,
        /// <summary>
        /// 土地储备机构（代码6）
        /// </summary>
        [Description("土地储备机构")]
        LandReserveAgency = 6,

        /// <summary>
        /// 其他（代码99）
        /// </summary>
        [Description("其他")]
        Other = 99
    }
}
