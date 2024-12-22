using Core.Domain.Entities.Ent_Order;
using Core.Application.Constants;

namespace Core.Application.Contracts.Persistence.Interface_Order
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        DiscountUseType UseDiscount(int orderId, string code);
        bool IsExistCode(string code);

    }
}
