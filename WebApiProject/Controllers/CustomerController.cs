using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using AutoMapper;
using DatabaseProject.Models;
using DatabaseProject.Services;
using WebApiProject.Response_Models;
using WebApiProject.View_Models;

namespace WebApiProject.Controllers
{
    public class CustomerController : ApiController
    {
	    private  CustomerService customerService;

		public CustomerController()
	    {
		    customerService = new CustomerService();
	    }

		// GET: api/Customers/5
		[HttpGet]
		[Authorize]
        [Route("api/Customers/{id}")]
		public CustomerResponse Get(int id)
		{
		    var claimsPrincipal = User as ClaimsPrincipal;
		    var username = claimsPrincipal?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: praveen@gmail.com");
		   var user = claimsPrincipal.Claims.FirstOrDefault();
            Debug.WriteLine(user.Value);
            
			var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerResponse>());
	        var mapper = config.CreateMapper();
	        return mapper.Map<CustomerResponse>(customerService.Get(id));
		}

		// POST: api/Customers
		[HttpPost]
		[Route("api/Customers")]
		public bool Post([FromBody]Customer customer)
        {
	        return customerService.Add(customer);

		}

		// POST: api/Customers/address
		[HttpPost]
	    [Route("api/Customers/address")]
	    public bool PostAddress([FromBody]Address address)
	    {
		    return customerService.AddAddress(address);
	    }

		// PUT: api/Customers/5
		[HttpPut]
		[Route("api/Customers")]
		public bool Put([FromBody]Customer customer)
        {
	        return customerService.Edit(customer);
		}

		// GET: api/Customers/addresses/1
		[HttpGet]
	    [Route("api/Customers/addresses/{id}")]
	    public List<AddressResponse> GetAddresses(int id)
	    {
	        var config = new MapperConfiguration(cfg => cfg.CreateMap<Address, AddressResponse>());
	        var mapper = config.CreateMapper();

	        return mapper.Map<List<Address>, List<AddressResponse>>(customerService.GetAddresses(id));
	    }

		// PUT: api/Customers/defaultAddress/1/2
		[HttpPut]
	    [Route("api/Customers/defaultAddress/{addressId}/{customerId}")]
	    public bool PutDefaultAddress(int addressId, int customerId)
	    {
		    return customerService.SetDefaultAddress(addressId, customerId);
	    }

		// GET: api/Customers/defaultAddress/5
		[HttpGet]
	    [Route("api/Customers/defaultAddress/{id}")]
	    public AddressResponse GetDefaultAddress(int id)
	    {
	        var config = new MapperConfiguration(cfg => cfg.CreateMap<Address, AddressResponse>());
	        var mapper = config.CreateMapper();
	        return mapper.Map<AddressResponse>(customerService.GetDefaulAddress(id));
	    }

        // DELETE: api/Customers/address/1/1
        [HttpDelete]
        [Route("api/Customers/address/{customerId}/{addressId}")]
        public bool DeleteAddress(int customerId, int addressId)
        {
            return customerService.RemoveAddress(customerId, addressId);
        }


        // GET: api/Customers/reviews/5
        [HttpGet]
	    [Route("api/Customers/reviews/{id}")]
	    public List<ReviewResponse> GetReviews(int id)
	    {
	        var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewResponse>());
	        var mapper = config.CreateMapper();

	        return mapper.Map<List<Review>, List<ReviewResponse>>(customerService.GetReviews(id));
	    }

		// POST: api/Customers/purchase/{customerId}/{productId}
		[HttpPost]
	    [Route("api/Customers/purchase/{customerId}/{productId}")]
	    public bool PostPurchase(int customerId, int productId)
	    {
		    return customerService.AddPurchase(customerId, productId);
	    }


        // GET: api/Customers/purchase/5
        [HttpGet]
	    [Route("api/Customers/purchase/{id}")]
	    public List<PurchaseResponse> GetPurchases(int id)
	    {
	        var config = new MapperConfiguration(cfg => cfg.CreateMap<Purchase, PurchaseResponse>());
	        var mapper = config.CreateMapper();

	        return mapper.Map<List<Purchase>, List<PurchaseResponse>>(customerService.GetPurchases(id));
	    }


		// DELETE: api/Customers/5
		[HttpDelete]
		[Route("api/Customers/{id}")]
		public bool Delete(int id)
        {
	        return customerService.Remove(id);
		}

        // DELETE: api/Customers/Review/1/1
        [HttpDelete]
        [Route("api/Customers/review/{customerId}/{reviewId}")]
        public bool DeleteReview(int customerId, int reviewId)
        {
            return customerService.RemoveReview(customerId, reviewId);
        }


    }
}
