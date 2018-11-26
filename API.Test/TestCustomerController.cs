using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiProject.Controllers;

namespace API.Test
{
    [TestClass]
    public class TestCustomerController
    {
        [TestMethod]
        public void GetCustomer()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.Get(1);

            Assert.AreEqual(res.FirstName, "Jhonny");

        }

        [TestMethod]
        public void GetReviews()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.GetReviews(1);
            Assert.IsNotNull(res.Find(r => r.Text == "Lags a bit"));

        }

        [TestMethod]
        public void GetPurchases()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.GetPurchases(1);
            Assert.IsNotNull(res.Find(p => p.CustomerId == 1));
            Assert.IsNotNull(res.Find(p => p.ProductId == 2));

        }

        [TestMethod]
        public void GetDefaultAddress()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.GetDefaultAddress(1);
            Assert.AreEqual(res.LineOne, "11G/1 ");

        }
    }
}
