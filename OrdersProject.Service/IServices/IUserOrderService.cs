using OrdersProject.Domain.Configurations;
using OrdersProject.Domain.Entities;
using OrdersProject.Service.DTOs.UserOrder;
using System.Linq.Expressions;

namespace OrdersProject.Service.IServices
{
    public interface IUserOrderService
    {
        IEnumerable<UserOrderForViewDTOs> GetAll(PaginationParams @params, Expression<Func<UserOrder, bool>> expression = null);
        Task<UserOrderForViewDTOs> GetAsync(Expression<Func<UserOrder, bool>> expression);
        Task<UserOrderForViewDTOs> CreateAsync(UserOrderForCreateDTOs userOrderForCreateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
