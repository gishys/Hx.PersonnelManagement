using FluentValidation;

namespace Hx.PersonnelManagement.Application.Contracts
{
    public class IndividualPersonDtoValidator : AbstractValidator<IndividualPersonDto>
    {
        public IndividualPersonDtoValidator()
        {
            RuleFor(x => x.Gender)
                .NotNull().WithMessage("性别不能为空")
                .IsInEnum().WithMessage("无效的性别");
        }
    }
}
