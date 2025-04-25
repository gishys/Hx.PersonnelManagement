namespace Hx.PersonnelManagement.Application.Contracts
{
    public class RightHolderRelationDto
    {
        /// <summary>
        /// 业务标识
        /// </summary>
        public required string BusinessIdentifier { get; set; }

        /// <summary>
        /// 人员Id
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// 权利人特征
        /// </summary>
        public required string HolderRole { get; set; }

        /// <summary>
        /// 权力比例
        /// </summary>
        public required string OwnershipType { get; set; }

        /// <summary>
        /// 是否持证
        /// </summary>
        public bool IsCertificateHolder { get; set; }
    }
}
