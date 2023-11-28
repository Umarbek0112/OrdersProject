using AutoMapper;
using OrdersProject.Data.IRepository;
using OrdersProject.Domain.Configurations;
using OrdersProject.Domain.Entities;
using OrdersProject.Service.DTOs.Order;
using OrdersProject.Service.Exceptions;
using OrdersProject.Service.Extensions;
using OrdersProject.Service.IServices;
using System.Linq.Expressions;

namespace OrdersProject.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _repositoriy;
        private readonly IGenericRepository<UserOrder> _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IGenericRepository<Order> repositoriy, IMapper mapper, IGenericRepository<UserOrder> userRepository)
        {
            _repositoriy = repositoriy;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(OrderForCreateDTOs[] orderForCreatDTOs)
        {
            var userInformation = await _userRepository.GetAsync(x => x.Id == orderForCreatDTOs[0].UserOrderId);  
            
            if (userInformation == null)
                throw new OrdersProjectException(404, "User Not Found");

            foreach (var dto in orderForCreatDTOs)
            {
                var order = _mapper.Map<Order>(dto);
                order.CreateAt = DateTime.UtcNow;
                var createAt = await _repositoriy.CreateAsync(order);
            }
            
            await _repositoriy.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedOrder = await _repositoriy.GetAsync(x => x.Id == id);
            if (deletedOrder is null)
                throw new OrdersProjectException(404, "Order Not Found");

            var deletedResault = await _repositoriy.DeleteAsync(deletedOrder.Id);
            await _repositoriy.SaveChangesAsync();

            return deletedResault;
        }

        public IEnumerable<OrderForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Order, bool>> expression = null)
            => _mapper.Map<IEnumerable<OrderForViewDTOs>>(
                _repositoriy.GetAll(expression, new string[] { "UserOrder" }, isTracking: false)
                .ToPagedList(@params));

        public async Task<OrderForViewDTOs> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var order = await _repositoriy.GetAsync(expression, new string[] { "UserOrder" }, isTracking: false);
            if (order is null)
                throw new OrdersProjectException(404, "Order Not Found");

            return _mapper.Map<OrderForViewDTOs>(order);
        }
    }
}
