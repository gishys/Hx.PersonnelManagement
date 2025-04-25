using FluentValidation;
using Hx.PersonnelManagement.Domain.Shared;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Hx.PersonnelManagement.Application.Contracts
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            // 基础字段校验
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("权利人ID不能为空");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("姓名不能为空")
                .Length(2, 100).WithMessage("姓名长度需在2-100字符之间")
                .Matches(@"^[\u4e00-\u9fa5A-Za-z·’‘-]+$")
                .WithMessage("姓名格式不正确（仅支持中文、字母及常用符号）");

            RuleFor(x => x.CertificateType)
                .NotNull().WithMessage("证件类型不能为空")
                .IsInEnum().WithMessage("无效的证件类型");

            RuleFor(x => x.CertificateNumber)
                .NotEmpty().WithMessage("证件号码不能为空")
                .Must(BeValidCertificate)
                .WithMessage((dto, number) =>
                    $"{GetCertificateDescription(dto.CertificateType)}号码格式不正确");

            RuleFor(x => x.PhoneNumber)
                .Length(0, 20).WithMessage("联系电话长度不能超过20字符")
                .Matches(@"^1[3-9]\d{9}$|^(\(\+86\)|86)?1[3-9]\d{9}$")
                .WithMessage("联系电话格式不正确（示例：13800138000或+8613800138000）")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));

            RuleFor(x => x.Address)
                .Length(0, 200).WithMessage("联系地址长度不能超过200字符")
                .Matches(@"^[\u4e00-\u9fa5A-Za-z0-9（）()#－·、，。楼栋室座号铺层幢苑路街巷道村组镇乡区县省市省自治区]{2,}$")
                .WithMessage("地址格式不正确（需包含2个以上有效字符）")
                .When(x => !string.IsNullOrWhiteSpace(x.Address));
        }

        /// <summary>
        /// 证件号码格式校验核心逻辑
        /// </summary>
        private bool BeValidCertificate(PersonDto dto, string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return false;

            return dto.CertificateType switch
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

                // 组织机构代码（8位数字/大写字母 + '-' + 校验码）
                CertificateType.OrganizationCode =>
                    Regex.IsMatch(number, @"^[0-9A-Z]{8}-[0-9A-Z]$"),

                // 工商营业执照（统一社会信用代码）
                CertificateType.BusinessLicense =>
                    Regex.IsMatch(number, @"^[0-9A-Z]{18}$"),

                // 统一社会信用代码（18位）
                CertificateType.UnifiedCreditCode =>
                    Regex.IsMatch(number, @"^[0-9A-Z]{18}$"),

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
