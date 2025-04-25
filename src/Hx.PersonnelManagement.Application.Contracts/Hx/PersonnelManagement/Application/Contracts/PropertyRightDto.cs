namespace Hx.PersonnelManagement.Application.Contracts
{
    /// <summary>
    /// 不动产权力实体
    /// </summary>
    public class PropertyRightDto
    {
        /// <summary>
        /// 权力ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 所有权性质（国有/集体所有）
        /// </summary>
        public required string OwnershipNature { get; set; }

        /// <summary>
        /// 权力类型（所有权/抵押权/地役权等）
        /// </summary>
        public required string RightType { get; set; }

        /// <summary>
        /// 权力性质（如出让/划拨）
        /// </summary>
        public required string RightNature { get; set; }

        /// <summary>
        /// 坐落（详细地址）
        /// </summary>
        public required string Location { get; set; }

        /// <summary>
        /// 国民经济行业分类代码（GB/T 4754）
        /// </summary>
        public required string IndustryCode { get; set; }

        /// <summary>
        /// 宗地代码（不动产单元代码前段）
        /// </summary>
        public required string ParcelCode { get; set; }

        /// <summary>
        /// 预编宗地代码
        /// </summary>
        public required string PreParcelCode { get; set; }

        /// <summary>
        /// 不动产单元号（国标编码）
        /// </summary>
        public required string RealEstateUnitNo { get; set; }

        /// <summary>
        /// 所在图幅号（比例尺+图幅编号）
        /// </summary>
        public required string MapSheetNo { get; set; }

        /// <summary>
        /// 北至
        /// </summary>
        public required string BoundaryNorth { get; set; }

        /// <summary>
        /// 东至
        /// </summary>
        public required string BoundaryEast { get; set; }

        /// <summary>
        /// 南至
        /// </summary>
        public required string BoundarySouth { get; set; }

        /// <summary>
        /// 西至
        /// </summary>
        public required string BoundaryWest { get; set; }

        /// <summary>
        /// 批准用途（规划用途）
        /// </summary>
        public required string ApprovedUsage { get; set; }

        /// <summary>
        /// 实际用途
        /// </summary>
        public required string ActualUsage { get; set; }

        /// <summary>
        /// 宗地面积（㎡）
        /// </summary>
        public decimal ParcelArea { get; set; }

        /// <summary>
        /// 土地使用期限起
        /// </summary>
        public DateTime? LandUseTermStart { get; set; }

        /// <summary>
        /// 土地使用期限止
        /// </summary>
        public DateTime? LandUseTermEnd { get; set; }

        /// <summary>
        /// 权利人关联
        /// </summary>
        public required virtual ICollection<RightHolderRelationDto> Holders { get; set; }
    }
}
