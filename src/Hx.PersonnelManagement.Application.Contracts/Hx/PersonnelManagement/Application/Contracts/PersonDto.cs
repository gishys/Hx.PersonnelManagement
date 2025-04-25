using Hx.PersonnelManagement.Domain.Shared;

namespace Hx.PersonnelManagement.Application.Contracts
{
    /// <summary>
    /// 权利人基类
    /// </summary>
    public class PersonDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 权利人姓名
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public CertificateType CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public required string CertificateNumber { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string? Address { get; set; }
    }
}
