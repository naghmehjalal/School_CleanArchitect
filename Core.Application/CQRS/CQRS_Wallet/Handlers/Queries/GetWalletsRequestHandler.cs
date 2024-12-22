using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Wallet;
using Core.Application.CQRS.CQRS_Wallet.Requests.Queries;
using Core.Application.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Wallet.Handlers.Queries
{
    public class GetWalletsRequestHandler : IRequestHandler<GetWalletsRequest,List<WalletDTO>>
    {


        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public GetWalletsRequestHandler(IWalletRepository walletRepository, IMapper mapper)
        {

            _walletRepository = walletRepository;
            _mapper = mapper;

        }

        public async Task<List<WalletDTO>> Handle(GetWalletsRequest request, CancellationToken cancellationToken)
        {
            var obj = await _walletRepository.GetAllAsync();

            return _mapper.Map<List<WalletDTO>>(obj);
        }
    }
}
