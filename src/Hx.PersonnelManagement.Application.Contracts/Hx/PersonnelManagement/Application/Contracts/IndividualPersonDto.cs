using Hx.PersonnelManagement.Domain.Shared;

namespace Hx.PersonnelManagement.Application.Contracts
{
    public class IndividualPersonDto
    {
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 民族代码
        /// </summary>
        public string? EthnicCode { get; set; }

    }
}
