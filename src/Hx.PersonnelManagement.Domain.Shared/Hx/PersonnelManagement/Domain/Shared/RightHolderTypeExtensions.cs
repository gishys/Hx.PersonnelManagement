namespace Hx.PersonnelManagement.Domain.Shared
{
    public static class RightHolderTypeExtensions
    {
        private static readonly Dictionary<int, string> _codeDescriptions = new()
        {
            { 1, "个人" },
            { 2, "企业" },
            { 21, "金融机构" },
            { 22, "非金融机构" },
            { 3, "事业单位" },
            { 4, "国家机关" },
            { 5, "家庭" },
            { 6, "土地储备机构" },
            { 99, "其他" }
        };

        public static string GetDescription(this RightHolderType type)
        {
            return _codeDescriptions.TryGetValue((int)type, out var desc)
                ? desc
                : "未知类型";
        }

        public static bool IsEnterpriseSubtype(this RightHolderType type)
        {
            return type is RightHolderType.FinancialInstitution
                   or RightHolderType.NonFinancialInstitution;
        }

        /// <summary>
        /// 判断是否为法人类型
        /// </summary>
        public static bool IsLegalEntity(this RightHolderType type)
        {
            return type switch
            {
                RightHolderType.Enterprise or
                RightHolderType.FinancialInstitution or
                RightHolderType.NonFinancialInstitution or
                RightHolderType.PublicInstitution or
                RightHolderType.GovernmentAgency or
                RightHolderType.LandReserveAgency => true,
                _ => false
            };
        }
    }
}
