using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Wallet;
using Core.Application.CQRS.CQRS_Wallet.Requests.Queries;
using Core.Application.DTOs.Course.Comment;
using Core.Application.DTOs.Wallet;
using MediatR;

namespace Core.Application.CQRS.CQRS_Wallet.Handlers.Queries
{
    public class GetWalletsByUserIdRequestHandler : IRequestHandler<GetWalletsByUserIdRequest, List<WalletDTO>>
    {

        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public GetWalletsByUserIdRequestHandler(IWalletRepository  walletRepository ,IMapper mapper)
        {
            
            _walletRepository = walletRepository;   
            _mapper = mapper;

        }

        public async Task<List<WalletDTO>> Handle(GetWalletsByUserIdRequest request, CancellationToken cancellationToken)
        {
           var obj = await _walletRepository.GetWalletUser(request.UserId);

           return _mapper.Map<List<WalletDTO>>(obj);
        }
    }
}
