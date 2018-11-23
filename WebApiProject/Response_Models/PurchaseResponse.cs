using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Response_Models
{
    public class PurchaseResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}