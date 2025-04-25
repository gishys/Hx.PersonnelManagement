using Hx.PersonnelManagement.Domain.Shared;

namespace Hx.PersonnelManagement.Application.Contracts
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 权利人姓名
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 身份证件类型
        /// </summary>
        public CertificateType CertificateType { get; set; }

        /// <summary>
        /// 身份证件号码
        /// </summary>
        public required string CertificateNumber { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }

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
