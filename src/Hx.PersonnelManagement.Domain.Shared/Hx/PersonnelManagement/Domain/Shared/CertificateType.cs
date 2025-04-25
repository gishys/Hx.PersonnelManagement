using System.ComponentModel;

namespace Hx.PersonnelManagement.Domain.Shared
{
    /// <summary>
    /// 证件类型枚举（符合国家GB 11714-1997标准）
    /// </summary>
    public enum CertificateType
    {
        /// <summary>
        /// 居民身份证
        /// </summary>
        [Description("身份证")]
        IDCard = 1,

        /// <summary>
        /// 港澳台居民居住证
        /// </summary>
        [Description("港澳台身份证")]
        HKMTResidentPermit = 2,

        /// <summary>
        /// 中华人民共和国护照
        /// </summary>
        [Description("护照")]
        Passport = 3,

        /// <summary>
        /// 居民户口簿
        /// </summary>
        [Description("户口簿")]
        HouseholdRegister = 4,

        /// <summary>
        /// 军官证/士兵证
        /// </summary>
        [Description("军官证(士兵证)")]
        MilitaryID = 5,

        /// <summary>
        /// 组织机构代码证
        /// </summary>
        [Description("组织机构代码")]
        OrganizationCode = 6,

        /// <summary>
        /// 工商营业执照
        /// </summary>
        [Description("营业执照")]
        BusinessLicense = 7,

        /// <summary>
        /// 统一社会信用代码证书
        /// </summary>
        [Description("统一社会信用代码")]
        UnifiedCreditCode = 8,

        /// <summary>
        /// 其他有效证件
        /// </summary>
        [Description("其他")]
        Other = 99
    }

    
}
