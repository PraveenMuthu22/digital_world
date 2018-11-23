using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using DatabaseProject.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiProject.Controllers;
using WebApiProject.View_Models;

namespace API.Test
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void GetProductByIdTest()
        {
            var controller = new ProductsController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //Act
            var result = controller.Get(1);

            //Assert
            Debug.WriteLine(result.Name);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "Nikon");
        }

        [TestMethod]
        public void GetProductsByCatagoryTest()
        {
            var controller = new ProductsController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //Act
            var result = controller.GetByCategory(Category.COMPUTER);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Find(p => p.Name == "Surface Pro 3"));
            Assert.IsNotNull(result.Find(p => p.Name == "Macbook pro 2"));
        }

/*        [TestMethod]
        public void GetProductByKeywordTest()
        {
            var controller = new ProductsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var result = controller.GetByKeyWord("pro");

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Find(p => p.Name == "Surface Pro 3"));
            Assert.IsNotNull(result.Find(p => p.Name == "Macbook pro 2"));
        }

        [TestMethod]
        public void GetReviews()
        {
            var controller = new ProductsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var result = controller.GetReviews(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Find(r => r.Text == "It's a good camera"));
        }*/
    }
}
