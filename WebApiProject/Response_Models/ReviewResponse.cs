using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.View_Models
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}