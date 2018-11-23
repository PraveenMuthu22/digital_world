using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.View_Models
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int CustomerId { get; set; }
    }
}