using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required] public string LineOne { get; set; }
        public string LineTwo { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Zip { get; set; }
        [Required] public string Phone { get; set; }

        [Required] public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}