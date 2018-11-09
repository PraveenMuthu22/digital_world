using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using DatabaseProject.Models;

namespace DatabaseProject
{
    public class ShopDbContext: DbContext
    {
	    public ShopDbContext():base("name=ShopDbContext")
	    {
			Database.SetInitializer(new CreateDatabaseIfNotExists<ShopDbContext>());
		}
		public DbSet<Customer> Customers { get; set; }
	    public DbSet<Product> Products { get; set; }
	    public DbSet<Address> Addresses { get; set; }
	    public DbSet<Review> Reviews { get; set; }		

    }
}
