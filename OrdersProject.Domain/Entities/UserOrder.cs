using Microsoft.EntityFrameworkCore;
using OrdersProject.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace OrdersProject.Domain.Entities
{
    [Index(nameof(Id), Name = "Index_UserOrder", IsUnique = true)]
    public class UserOrder : Auditable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string EmailAdress { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
