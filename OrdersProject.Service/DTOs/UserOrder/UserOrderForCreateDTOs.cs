using System.ComponentModel.DataAnnotations;

namespace OrdersProject.Service.DTOs.UserOrder
{
    public class UserOrderForCreateDTOs
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string EmailAdress { get; set; }
    }
}
