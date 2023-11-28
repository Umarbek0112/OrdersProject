using Microsoft.EntityFrameworkCore;
using OrdersProject.Domain.Entities;

namespace OrderProject.Data.DbContexs
{
    public class OrdersProjectDbContex : DbContext
    {
        public OrdersProjectDbContex(DbContextOptions<OrdersProjectDbContex> options) : base(options)
        {

        }

       public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<UserOrder> UserOrders { get; set; }

    }
}
