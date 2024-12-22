using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Order;
using Core.Domain.Entities.Ent_Order;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Repo_Order
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        //private readonly AppContext _dbcontext;
        //private readonly IMapper _mapper;

        //public OrderRepository(AppContext dbContext, IMapper mapper)
        //    : base(dbContext)
        //{
        //    _dbcontext = dbContext;
        //    _mapper = mapper;
        //}

        private readonly AppContext _dbcontext;
   
        public OrderRepository(AppContext dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;
   
        }

        public int AddOrder(string userId, int courseId)
        {
            Order order = _dbcontext.Orders
               .FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);

            var course = _dbcontext.Courses.Find(courseId);
            if (order == null)
            {
                order = new Order()
                {
                    UserId = userId,
                    IsFinaly = false,
                    CreateDate = DateTime.Now,
                    OrderSum = course.CoursePrice,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            CourseId = courseId,
                            Count = 1,
                            Price = course.CoursePrice
                        }
                    }
                };
                _dbcontext.Orders.Add(order);
                _dbcontext.SaveChanges();
            }
            else
            {
                OrderDetail detail = _dbcontext.OrderDetails
                    .FirstOrDefault(d => d.OrderId == order.OrderId && d.CourseId == courseId);
               
                if (detail != null)
                {
                    detail.Count += 1;
                    _dbcontext.OrderDetails.Update(detail);
                }
                else
                {
                    detail = new OrderDetail(order.OrderId, courseId,1,course.CoursePrice);
                    //detail = new OrderDetail()
                    //{
                    //    OrderId = order.OrderId,
                    //    Count = 1,
                    //    CourseId = courseId,
                    //    Price = ,
                    //};
                    _dbcontext.OrderDetails.Add(detail);
                }
                _dbcontext.SaveChanges();
                UpdatePriceOrder(order.OrderId);
            }
            return order.OrderId;
        }

        public bool FinalyOrder(string userId, int orderId)
        {
            //int userId = _userService.GetUserIdByUserName(userName);
            //var order = _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Course)
            //    .FirstOrDefault(o => o.OrderId == orderId && o.UserId == userId);

            //if (order == null || order.IsFinaly)
            //{
            //    return false;
            //}

            //if (_userService.BalanceUserWallet(userName) >= order.OrderSum)
            //{
            //    order.IsFinaly = true;
            //    _userService.AddWallet(new Wallet()
            //    {
            //        Amount = order.OrderSum,
            //        CreateDate = DateTime.Now,
            //        IsPay = true,
            //        Description = "فاکتور شما #" + order.OrderId,
            //        UserId = userId,
            //        TypeId = 2
            //    });
            //    _context.Orders.Update(order);

            //    foreach (var detail in order.OrderDetails)
            //    {
            //        _context.UserCourses.Add(new UserCourse()
            //        {
            //            CourseId = detail.CourseId,
            //            UserId = userId
            //        });
            //    }

            //    _context.SaveChanges();
            //    return true;
            //}

            return false;
        }

        //public Order GetOrderById(int orderId)
        //{_dbcontext
        //    throw new NotImplementedException();
        //}

        public Order GetOrderForUserPanel(string userId, int orderId)
        {
            return _dbcontext.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.CourseId)
            .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
        }

        public List<Order> GetUserOrders(string userId)
        {
            return _dbcontext.Orders.Where(o => o.UserId == userId).ToList();
        }

        public void UpdatePriceOrder(int orderId)
        {
            var order = _dbcontext.Orders.Find(orderId);
            order.OrderSum = _dbcontext.OrderDetails.Where(d => d.OrderId == orderId).Sum(d => d.Price);
            _dbcontext.Orders.Update(order);
            _dbcontext.SaveChanges();
        }
    }
}
