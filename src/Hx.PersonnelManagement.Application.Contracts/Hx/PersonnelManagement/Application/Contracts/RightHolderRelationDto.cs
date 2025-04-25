using Hx.PersonnelManagement.Domain.Shared;

namespace Hx.PersonnelManagement.Application.Contracts
{
    public class RightHolderRelationDto<RHolder> where RHolder : PersonDto
    {
        /// <summary>
        /// 业务标识
        /// </summary>
        public required string BusinessIdentifier { get; set; }

        /// <summary>
        /// 人员Id
        /// </summary>
        public Guid HolderId { get; set; }

        /// <summary>
        /// 权利人特征
        /// </summary>
        public required string HolderRole { get; set; }

        /// <summary>
        /// 权利比例
        /// </summary>
        public required string OwnershipType { get; set; }

        /// <summary>
        /// 是否持证
        /// </summary>
        public bool IsCertificateHolder { get; set; }

        /// <summary>
        /// 权利人类型
        /// </summary>
        public RightHolderType RightHolderType { get; set; }

        /// <summary>
        /// 权利人
        /// </summary>
        public required ICollection<RHolder> RightHolders { get; set; }
    }
}