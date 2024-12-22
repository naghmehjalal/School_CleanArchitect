using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Wallet;
using Core.Application.CQRS.CQRS_Wallet.Requests.Commands;
using Core.Application.DTOs.Wallet.Validators;
using Core.Domain.Entities.Ent_Wallet;
using Core.Application.Exceptions;
using MediatR;

namespace Core.Application.CQRS.CQRS_Wallet.Handlers.Commands
{
    public class CreateWalletRequestHandler : IRequestHandler<CreateWalletRequest, int>
    {

        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public CreateWalletRequestHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateWalletRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateWalletDTOValidator();
            var validationResult = await validator.ValidateAsync(request.createWalletDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var newWallet = _mapper.Map<Wallet>(request.createWalletDTO);
            newWallet = await _walletRepository.AddAsync(newWallet);
            return newWallet.WalletId;
        }
    }
}
