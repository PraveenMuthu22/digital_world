using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseProject.Models
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new List<Address>();
            Reviews = new List<Review>();
            Purchases = new List<Purchase>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Password { get; set; }
        public int? DefaultAddressId { get; set; }


        public List<Address> Addresses { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}