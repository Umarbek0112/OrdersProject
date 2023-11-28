using OrdersProject.Service.DTOs.UserOrder;

namespace OrdersProject.Service.DTOs.Order
{
    public class OrderForViewDTOs
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductNumber { get; set; }
        public decimal ProductsPrice { get; set; }
        public int UserOrderId { get; set; }
        public UserOrderForViewDTOs UserOrder { get; set; }
    }
}
