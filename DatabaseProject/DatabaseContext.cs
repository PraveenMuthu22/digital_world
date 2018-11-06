using System.Data.Entity;
using DatabaseProject.Models;

namespace DatabaseProject
{
    public class DatabaseContext: DbContext
    {
	    public DbSet<Customer> Customers { get; set; }
	    public DbSet<Product> Products { get; set; }
	    public DbSet<Address> Addresses { get; set; }
	    public DbSet<Review> Reviews { get; set; }		

    }
}
