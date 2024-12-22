using Core.Application.Contracts.Persistence.Interface_Order;
using Core.Domain.Entities.Ent_Order;

namespace Infrastructure.Persistence.Repositories.Repo_Order
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {

        //private readonly AppContext _dbcontext;
        //private readonly IMapper _mapper;

        //public OrderDetailRepository(AppContext dbContext, IMapper mapper)
        //    : base(dbContext)
        //{
        //    _dbcontext = dbContext;
        //    _mapper = mapper;
        //}

        private readonly AppContext _dbcontext;

        public OrderDetailRepository(AppContext dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;
        }

    }
}
