using OrdersProject.Domain.Configurations;
using OrdersProject.Domain.Entities;
using OrdersProject.Service.DTOs.Order;
using System.Linq.Expressions;

namespace OrdersProject.Service.IServices
{
    public interface IOrderService
    {
        IEnumerable<OrderForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Order, bool>> expression = null);
        Task<OrderForViewDTOs> GetAsync(Expression<Func<Order, bool>> expression);
        Task<bool> CreateAsync(OrderForCreateDTOs[] orderForCreatDTO);
        Task<bool> DeleteAsync(int id);
    }
}
