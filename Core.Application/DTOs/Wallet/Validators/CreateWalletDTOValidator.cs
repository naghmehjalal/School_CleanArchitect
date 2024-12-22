using FluentValidation;

namespace Core.Application.DTOs.Wallet.Validators
{
    public class CreateWalletDTOValidator : AbstractValidator<CreateWalletDTO>
    {
        public CreateWalletDTOValidator()
        {
            Include(new IWalletDTOValidator());
        }

  
    }
}
