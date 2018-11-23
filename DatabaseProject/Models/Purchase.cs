using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
