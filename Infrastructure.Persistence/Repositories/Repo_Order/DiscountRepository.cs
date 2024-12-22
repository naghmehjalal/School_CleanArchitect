using Core.Application.Contracts.Persistence.Interface_Order;
using Core.Domain.Entities.Ent_Order;
using Core.Application.Constants;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace Infrastructure.Persistence.Repositories.Repo_Order
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {

        private readonly AppContext _dbContext;
        private readonly IOrderRepository _orderRepository;

        public DiscountRepository(AppContext dbContext,IOrderRepository orderRepository)
            :base(dbContext)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
        }
         

        public bool IsExistCode(string code)
        {
            return _dbContext.Discounts.Any(d => d.DiscountCode == code);
        }

        public  DiscountUseType UseDiscount(int orderId, string code)
        {
          
        var discount = _dbContext.Discounts.SingleOrDefault(d => d.DiscountCode == code);

            if (discount == null)
                return DiscountUseType.NotFound;

            if (discount.StartDate != null && discount.StartDate < DateTime.Now)
                return DiscountUseType.ExpierDate;

            if (discount.EndDate != null && discount.EndDate >= DateTime.Now)
                return DiscountUseType.ExpierDate;


            if (discount.UsableCount != null && discount.UsableCount < 1)
                return DiscountUseType.Finished;


            var order = _orderRepository.Get(orderId);
           
            if (_dbContext.UserDiscountCodes.Any(d => d.UserId == order.UserId && d.DiscountId == discount.DiscountId))
                return DiscountUseType.UserUsed;

            int percent = (order.OrderSum * discount.DiscountPercent) / 100;
            order.OrderSum = order.OrderSum - percent;

            _orderRepository.Update(order);
          
            if (discount.UsableCount != null)
                discount.UsableCount -= 1;

            _dbContext.Discounts.Update(discount);
            _dbContext.UserDiscountCodes.Add(new UserDiscountCode()
            {
                UserId = order.UserId,
                DiscountId = discount.DiscountId
            });
            _dbContext.SaveChanges();


            return DiscountUseType.Success;
        }
    }
}
