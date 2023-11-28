using OrdersProject.Service.DTOs.Order;

namespace OrdersProject.Service.DTOs.UserOrder
{
    public class UserOrderForViewDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string EmailAdress { get; set; }

        public ICollection<OrderForViewDTOs> Orders { get; set; }
    }
}
