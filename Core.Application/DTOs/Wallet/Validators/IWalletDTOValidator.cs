using FluentValidation;


namespace Core.Application.DTOs.Wallet.Validators
{
    public class IWalletDTOValidator : AbstractValidator<IWalletDTO>
    {

        public IWalletDTOValidator()
        {
            RuleFor(r => r.Description)
               .MaximumLength(200).WithMessage("");

            RuleFor(r => r.UserId)
            .NotNull().WithMessage("");

            RuleFor(r => r.TypeId)
           .NotNull().WithMessage("");
        }
    }
}
