using System;
using System.Net.Http;
using System.Web.Http;
using DatabaseProject.Models;
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
            Assert.IsNotNull(res.Find(r => r.Text == "It's a good camera"));

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
        public void AddPurchases()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.PostPurchase(1, 3);
            Assert.IsTrue(res);

        }

        [TestMethod]
        public void GetAddresses()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.GetAddresses(1);
            Assert.IsNotNull(res.Find(a => a.LineOne == "11G/1 "));

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

        [TestMethod]
        public void AddCustomer()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.Post(new Customer
            {
                Email = "mary123@gmail.com",
                FirstName = "Mary",
                LastName = "Belfort",
                Password = "674",
            });

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void AddAddress()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.PostAddress(new Address
            {
                LineOne = "12/3 ",
                LineTwo = "Stafford Road",
                City = "Colombo",
                Phone = "012345643",
                Zip = "1234",
                CustomerId = 1,
            });

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void DeleteAddress()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.DeleteAddress(1, 1);

            Assert.IsTrue(res);

            //Check if it's really delete
        }

        [TestMethod]
        public void EditCustomer()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.Put(new Customer
            {
                Id = 1,
                Email = "jhonny@gmail.com",
                FirstName = "Jhonny",
                LastName = "Balboa",
                Password = "123",
            });

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void SetDefaultAddress()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.PutDefaultAddress(1, 1);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void DeleteCustomer()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.Delete(1);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void DeleteReview()
        {
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var res = controller.DeleteReview(1, 1);
            Assert.IsTrue(res);
        }
    }
}
