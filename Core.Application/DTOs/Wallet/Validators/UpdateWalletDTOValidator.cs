using Core.Application.DTOs.Course.Comment.Validators;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Wallet.Validators
{
    public class UpdateWalletDTOValidator :AbstractValidator<UpdateWalletDTO>
    {

        public UpdateWalletDTOValidator() 
        {

            Include(new IWalletDTOValidator());

            RuleFor(p => p.WalletId).NotNull()
              .WithMessage("{PropertyName} is required.");

        }

    }
}
