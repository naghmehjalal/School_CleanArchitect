using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Wallet;
using Core.Application.CQRS.CQRS_Wallet.Requests.Commands;
using Core.Application.DTOs.Wallet.Validators;
using MediatR;
using Core.Application.Exceptions;

namespace Core.Application.CQRS.CQRS_Wallet.Handlers.Commands
{
    public class UpdateWalletRequestHandler : IRequestHandler<UpdateWalletRequest,Unit>
    {

        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public UpdateWalletRequestHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWalletRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWalletDTOValidator();
            var validationResult = await validator.ValidateAsync(request.updateWalletDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var walletOBJ = await _walletRepository.GetAsync(request.updateWalletDTO.WalletId);
            _mapper.Map(request.updateWalletDTO, walletOBJ);
            await _walletRepository.UpdateAsync(walletOBJ);
            return Unit.Value;
        }
    }
}
