using Microsoft.AspNetCore.Mvc;
using OrdersProject.Domain.Configurations;
using OrdersProject.Service.DTOs.UserOrder;
using OrdersProject.Service.IServices;

namespace OrdersProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        private readonly IUserOrderService _service;
        public UserOrderController(IUserOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserOrderForCreateDTOs userOrderForCreate)
            => Ok(await _service.CreateAsync(userOrderForCreate));

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams @params)
        {
            var resault = _service.GetAll(@params);
            return Ok(new
            {
                Resault = resault,
                Page = @params
            });
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await _service.GetAsync(x => x.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await _service.DeleteAsync(id));
    }
}
