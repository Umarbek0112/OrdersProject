using Microsoft.AspNetCore.Mvc;
using OrdersProject.Domain.Configurations;
using OrdersProject.Service.DTOs.Order;
using OrdersProject.Service.IServices;

namespace OrdersProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderForCreateDTOs[] orderForCreateDTO)
            => Ok(await _service.CreateAsync(orderForCreateDTO));

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
        public async Task<IActionResult> GetAsync(int id)
            => Ok(await _service.GetAsync(x => x.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
            => Ok(await _service.DeleteAsync(id));

    }
}
