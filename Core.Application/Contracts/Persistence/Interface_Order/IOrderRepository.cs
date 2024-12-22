using Core.Domain.Entities.Ent_Order;

namespace Core.Application.Contracts.Persistence.Interface_Order
{
    public interface IOrderRepository : IGenericRepository<Order>
    {

        int AddOrder(string userName, int courseId);
        void UpdatePriceOrder(int orderId);

        Order GetOrderForUserPanel(string userId, int orderId);
      //  Order GetOrderById(int orderId);

        bool FinalyOrder(string userId, int orderId);

        List<Order> GetUserOrders(string userId);

    }
}
