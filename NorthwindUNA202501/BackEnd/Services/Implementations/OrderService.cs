using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class OrderService : IOrderService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public OrderService(IUnidadDeTrabajo unidad)
        {
            _unidadDeTrabajo = unidad;
        }

        OrderDTO Convertir(Order order)
        {
            return new OrderDTO
            {
                OrderId = order.OrderId,
                ShipVia = order.ShipVia
            };
        }

        Order Convertir(OrderDTO order)
        {
            return new Order
            {
                OrderId = order.OrderId,
                ShipVia = order.ShipVia
            };
        }


        public OrderDTO AddOrder(OrderDTO order)
        {
            _unidadDeTrabajo.OrderDAL.Add(Convertir(order));
            _unidadDeTrabajo.Complete();
            return order;
        }

        public OrderDTO DeleteOrder(int id)
        {
            var Order = new Order { OrderId = id };
            _unidadDeTrabajo.OrderDAL.Remove(Order);
            _unidadDeTrabajo.Complete();
            return Convertir(Order);
        }

        public OrderDTO GetOrderById(int id)
        {
            var result = _unidadDeTrabajo.OrderDAL.FindById(id);
            return Convertir(result);
        }

        public List<OrderDTO> GetOrders()
        {
            var orders = _unidadDeTrabajo.OrderDAL.Get();
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                orderDTOs.Add(this.Convertir(order));
            }
            return orderDTOs;
        }

        public OrderDTO UpdateOrder(OrderDTO order)
        {
            var entity = Convertir(order);
            _unidadDeTrabajo.OrderDAL.Update(entity);
            _unidadDeTrabajo.Complete();
            return order;
        }
    }
}
