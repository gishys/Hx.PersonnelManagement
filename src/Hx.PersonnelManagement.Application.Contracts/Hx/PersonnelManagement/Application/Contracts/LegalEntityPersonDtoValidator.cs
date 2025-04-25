using FluentValidation;
using Hx.PersonnelManagement.Domain.Shared;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Hx.PersonnelManagement.Application.Contracts
{
    public class LegalEntityPersonDtoValidator : AbstractValidator<LegalEntityPersonDto>
    {
        public LegalEntityPersonDtoValidator()
        {
            RuleFor(x => x.LegalRepresentativeName)
                .NotEmpty().WithMessage("法人代表人姓名不能为空")
                .Length(2, 100).WithMessage("法人代表人姓名长度需在2-100字符之间")
                .Matches(@"^[\u4e00-\u9fa5A-Za-z·’‘-]+$")
                .WithMessage("法人代表人姓名格式不正确（仅支持中文、字母及常用符号）");

            RuleFor(x => x.LegalRepresentativeCertificateType)
                .NotNull().WithMessage("法人代表人证件类型不能为空")
                .IsInEnum().WithMessage("无效的法人代表人证件类型");

            RuleFor(x => x.LegalRepresentativeCertificateNumber)
                .NotEmpty().WithMessage("法人代表人证件号码不能为空")
                .Must(BeValidCertificate)
                .WithMessage((dto, number) =>
                    $"{GetCertificateDescription(dto.LegalRepresentativeCertificateType)}号码格式不正确");

            RuleFor(x => x.LegalRepresentativePhoneNumber)
                .Length(0, 20).WithMessage("法人代表人联系电话长度不能超过20字符")
                .Matches(@"^1[3-9]\d{9}$|^(\(\+86\)|86)?1[3-9]\d{9}$")
                .WithMessage("法人代表人联系电话格式不正确（示例：13800138000或+8613800138000）")
                .When(x => !string.IsNullOrWhiteSpace(x.LegalRepresentativePhoneNumber));
        }
        /// <summary>
        /// 证件号码格式校验核心逻辑
        /// </summary>
        private bool BeValidCertificate(LegalEntityPersonDto dto, string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return false;

            return dto.LegalRepresentativeCertificateType switch
            {
                // 居民身份证（18位，末位X）
                CertificateType.IDCard =>
                    Regex.IsMatch(number, @"^\d{17}[\dXx]$"),

                // 港澳台居民居住证（8位数字+1位校验码）
                CertificateType.HKMTResidentPermit =>
                    number.Length == 9 &&
                    long.TryParse(number, out _),

                // 中国护照（G+8位数字，共9位）
                CertificateType.Passport =>
                    Regex.IsMatch(number, @"^G\d{8}$", RegexOptions.IgnoreCase),

                // 居民户口簿（15位数字）
                CertificateType.HouseholdRegister =>
                    number.Length == 15 &&
                    long.TryParse(number, out _),

                // 军官证/士兵证（8-10位数字）
                CertificateType.MilitaryID =>
                    number.Length is >= 8 and <= 10 &&
                    long.TryParse(number, out _),

                // 其他证件（仅校验非空）
                CertificateType.Other =>
                    number.Length >= 2,

                _ => false
            };
        }

        /// <summary>
        /// 获取证件类型中文描述（用于错误消息）
        /// </summary>
        private static string GetCertificateDescription(CertificateType type)
        {
            var field = type.GetType().GetField(type.ToString());
            return field?.GetCustomAttribute<DescriptionAttribute>()?.Description
                   ?? type.ToString();
        }
    }
}