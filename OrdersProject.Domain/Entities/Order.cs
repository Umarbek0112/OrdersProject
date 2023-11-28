using Microsoft.EntityFrameworkCore;
using OrdersProject.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OrdersProject.Domain.Entities
{
    [Index(nameof(Id), Name = "Index_Order", IsUnique = true)]
    public class Order : Auditable
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductNumber { get; set; }
        [Required]
        public decimal ProductsPrice { get; set; }
        [Required]
        public int UserOrderId { get; set; }
        public UserOrder UserOrder { get; set; }
    }
}
