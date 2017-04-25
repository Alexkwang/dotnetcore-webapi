using Microsoft.EntityFrameworkCore;



namespace webapi.Models
{
    public class CustomerAPIContext:DbContext
    {
        public CustomerAPIContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
