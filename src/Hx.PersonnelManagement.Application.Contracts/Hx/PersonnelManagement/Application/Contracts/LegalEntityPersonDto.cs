using Hx.PersonnelManagement.Domain.Shared;

namespace Hx.PersonnelManagement.Application.Contracts
{
    public class LegalEntityPersonDto
    {
        /// <summary>
        /// 法人代表人姓名
        /// </summary>
        public required string LegalRepresentativeName { get; set; }
        /// <summary>
        /// 法人代表人证件类型
        /// </summary>
        public required CertificateType LegalRepresentativeCertificateType { get; set; }
        /// <summary>
        /// 法人代表人证件号码
        /// </summary>
        public required string LegalRepresentativeCertificateNumber { get; set; }
        /// <summary>
        /// 法人代表人电话
        /// </summary>
        public required string LegalRepresentativePhoneNumber { get; set; }
    }
}
