using System.Data.Entity;
using DatabaseProject.Models;

namespace DatabaseProject
{
    public class ShopDbContext: DbContext
    {
	    public ShopDbContext():base("shoppingDatabase")
	    {
			Database.SetInitializer(new CreateDatabaseIfNotExists<ShopDbContext>());
		    //Configuration.ProxyCreationEnabled = false;
	    }
		public DbSet<Customer> Customers { get; set; }
	    public DbSet<Product> Products { get; set; }
	    public DbSet<Address> Addresses { get; set; }
	    public DbSet<Review> Reviews { get; set; }		

    }
}
