using AutoMapper;
using OrdersProject.Data.IRepository;
using OrdersProject.Domain.Configurations;
using OrdersProject.Domain.Entities;
using OrdersProject.Service.DTOs.UserOrder;
using OrdersProject.Service.Exceptions;
using OrdersProject.Service.Extensions;
using OrdersProject.Service.IServices;
using System.Linq.Expressions;

namespace OrdersProject.Service.Services
{
    public class UserOrderService : IUserOrderService
    {
        private readonly IGenericRepository<UserOrder> _repository;
        private readonly IMapper _mapper;

        public UserOrderService(IGenericRepository<UserOrder> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserOrderForViewDTOs> CreateAsync(UserOrderForCreateDTOs userOrderForCreateDTO)
        {
            var userOrder = _mapper.Map<UserOrder>(userOrderForCreateDTO);
            userOrder.CreateAt = DateTime.UtcNow;
            var createAt = await _repository.CreateAsync(userOrder);
            await _repository.SaveChangesAsync();

            return _mapper.Map<UserOrderForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedUserProduct = await _repository.GetAsync(x => x.Id == id);
            if (deletedUserProduct is null)
                throw new OrdersProjectException(404, "UserOrder Not Found");

            var deletedResult = await _repository.DeleteAsync(deletedUserProduct.Id);
            await _repository.SaveChangesAsync();

            return deletedResult;
        }

        public IEnumerable<UserOrderForViewDTOs> GetAll(PaginationParams @params, Expression<Func<UserOrder, bool>> expression = null)
        => _mapper.Map<IEnumerable<UserOrderForViewDTOs>>(
                _repository.GetAll(expression, new string[] { "Orders" }, isTracking: false)
                .ToPagedList(@params));

        public async Task<UserOrderForViewDTOs> GetAsync(Expression<Func<UserOrder, bool>> expression)
        {
            var userProduct = await _repository.GetAsync(expression, new string[] { "Orders" }, isTracking: false);
            if (userProduct is null)
                throw new OrdersProjectException(404, "UserOrder Not Found");

            return _mapper.Map<UserOrderForViewDTOs>(userProduct);
        }
    }
}
