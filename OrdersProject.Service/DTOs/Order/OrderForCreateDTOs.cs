using System.ComponentModel.DataAnnotations;

namespace OrdersProject.Service.DTOs.Order
{
    public class OrderForCreateDTOs
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductNumber { get; set; }
        [Required]
        public decimal ProductsPrice { get; set; }
        [Required]
        public int UserOrderId { get; set; }
    }
}
