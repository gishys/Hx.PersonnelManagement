using System.ComponentModel;
using System.Reflection;

namespace Hx.PersonnelManagement.Domain.Shared
{
    /// <summary>
    /// 枚举扩展方法
    /// </summary>
    public static class CertificateTypeExtensions
    {
        private static readonly Dictionary<CertificateType, string> LabelCache = [];

        static CertificateTypeExtensions()
        {
            foreach (CertificateType type in Enum.GetValues(typeof(CertificateType)))
            {
                LabelCache[type] = GetDescription(type);
            }
        }

        /// <summary>
        /// 获取枚举项的显示标签
        /// </summary>
        public static string GetLabel(this CertificateType type)
        {
            return LabelCache.TryGetValue(type, out var label) ? label : type.ToString();
        }

        private static string GetDescription(CertificateType type)
        {
            var field = type.GetType().GetField(type.ToString());
            return field?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? type.ToString();
        }
    }
}
