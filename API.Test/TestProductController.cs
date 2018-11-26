using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using DatabaseProject.Enums;
using DatabaseProject.Models;
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
            var result = controller.GetByCategory(Category.Computer);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Find(p => p.Name == "Surface Pro 3"));
            Assert.IsNotNull(result.Find(p => p.Name == "Macbook pro 2015"));
        }

        [TestMethod]
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
            Assert.IsNotNull(result.Find(p => p.Name == "Macbook pro 2015"));
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
        }

        [TestMethod]
        public void DeleteProduct()
        {
            var controller = new ProductsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
           var response = controller.Delete(1);

            //Check product has been deleted successfully
            Assert.IsTrue(response);

            //Add the deleted item back
            controller.Put(new Product
            {
                Category = Category.Camera,
                Name = "Nikon",
                Price = 50000,
                Description = "Professional Camera",
                Specification = "23 MP",
            });
        }

        [TestMethod]
        public void AddProduct()
        {
            var controller = new ProductsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(new Product
            {
                Category = Category.Computer,
                Name = "Lenova Thinkpad",
                Price = 160000,
                Description = "2 in 1 computer",
                Specification = "16 GB RAM",
            });


            Assert.IsTrue(response);
        }

        [TestMethod]
        public void AddReview()
        {
            var controller = new ProductsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PostReview(new Review
            {
                CustomerId = 1,
                ProductId = 2,
                Stars = 2,
                Text = "Lags a bit",
            });
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void PutProduct()
        {
            var controller = new ProductsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Made i7
            var response = controller.Put(new Product
            {
                Id = 2,
                Category = Category.Computer,
                Name = "Surface Pro 3",
                Description = "Tablet / Laptop",
                Price = 200000,
                Specification = "i7 16 GB ram",
            });


            Assert.IsTrue(response);
        }
    }
}