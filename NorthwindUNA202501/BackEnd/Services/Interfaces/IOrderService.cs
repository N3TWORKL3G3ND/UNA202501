using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDTO> GetOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO AddOrder(OrderDTO order);
        OrderDTO UpdateOrder(OrderDTO order);
        OrderDTO DeleteOrder(int id);
    }
}
