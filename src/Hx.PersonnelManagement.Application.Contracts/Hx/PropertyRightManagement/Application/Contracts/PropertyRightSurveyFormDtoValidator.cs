using FluentValidation;
using Hx.PersonnelManagement.Application.Contracts;
using Hx.PropertyRightManagement.Application.Contracts;

namespace Hx.PersonnelManagement.Application;

public class PropertyRightSurveyFormDtoValidator : AbstractValidator<PropertyRightSurveyFormDto<PersonDto>>
{
    public PropertyRightSurveyFormDtoValidator()
    {
        // 基础校验
        RuleFor(x => x.Id).NotEmpty().WithMessage("权利ID不能为空");

        RuleFor(x => x.OwnershipNature)
            .IsInEnum().WithMessage("无效的所有权性质");

        RuleFor(x => x.RightType)
            .NotEmpty().WithMessage("权利类型不能为空")
            .MaximumLength(50).WithMessage("权利类型长度不能超过50字符");

        RuleFor(x => x.RightNature)
            .NotEmpty().WithMessage("权利性质不能为空")
            .MaximumLength(100).WithMessage("权利性质长度不能超过100字符");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("坐落地址不能为空")
            .MaximumLength(200).WithMessage("地址长度不能超过200字符");

        // 行业代码校验（GB/T 4754-2017）
        RuleFor(x => x.IndustryCode)
            .NotEmpty().WithMessage("行业分类代码不能为空")
            .Matches(@"^[A-T]\d{3}$").WithMessage("行业代码格式不正确（示例：C131）");

        // 宗地代码校验（不动产单元代码前段）
        RuleFor(x => x.ParcelCode)
            .NotEmpty().WithMessage("宗地代码不能为空")
            .Length(19).WithMessage("宗地代码必须为19位")
            .Matches(@"^\d{19}$").WithMessage("宗地代码必须为纯数字");

        // 预编宗地代码校验
        RuleFor(x => x.PreParcelCode)
            .Length(19).When(x => !string.IsNullOrEmpty(x.PreParcelCode))
            .WithMessage("预编宗地代码必须为19位数字");

        // 不动产单元号校验（GB/T 37346-2019）
        RuleFor(x => x.RealEstateUnitNo)
            .NotEmpty().WithMessage("不动产单元号不能为空")
            .Length(28).WithMessage("单元号必须为28位")
            .Matches(@"^\d{28}$").WithMessage("单元号必须为纯数字");

        // 图幅号校验（示例格式：1:500 K50G001001）
        RuleFor(x => x.MapSheetNo)
            .NotEmpty().WithMessage("图幅号不能为空")
            .Matches(@"^[\d:]+ [A-Z]\d{6}[A-Z]\d{3}$").WithMessage("图幅号格式不正确");

        // 用途校验
        RuleFor(x => x.ApprovedUsage)
            .NotEmpty().WithMessage("批准用途不能为空")
            .MaximumLength(100).WithMessage("批准用途描述过长");

        RuleFor(x => x.ActualUsage)
            .NotEmpty().WithMessage("实际用途不能为空")
            .MaximumLength(100).WithMessage("实际用途描述过长");

        // 面积校验
        RuleFor(x => x.ParcelArea)
            .GreaterThan(0).WithMessage("宗地面积必须大于0");

        // 土地期限校验
        RuleFor(x => x.LandUseTermStart)
            .LessThanOrEqualTo(x => x.LandUseTermEnd)
            .When(x => x.LandUseTermEnd.HasValue)
            .WithMessage("起始日期不能晚于结束日期")
            .GreaterThan(DateTime.Now.AddYears(-70))
            .WithMessage("土地使用期限不合理");

        // 权利人关联校验
        RuleFor(x => x.Holders)
            .NotEmpty().WithMessage("必须关联至少一个权利人")
            .Must(x => x != null && x.Count > 0)
            .WithMessage("权利人列表不能为空");
    }
}