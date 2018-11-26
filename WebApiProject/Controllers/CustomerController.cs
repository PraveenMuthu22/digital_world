﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DatabaseProject.Models;
using DatabaseProject.Services;
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
		[Route("api/Customers/{id}")]
		public CustomerResponse Get(int id)
        {
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
	    public List<Address> GetAddresses(int id)
	    {
		    return customerService.GetAddresses(id);
	    }

		// PUT: api/Customers/defaultAddress/1/2
		[HttpPut]
	    [Route("api/Customers/defaultAddress/{addressId}/{customerId}")]
	    public bool SetDefaultAddress(int addressId, int customerId)
	    {
		    return customerService.SetDefaultAddress(addressId, customerId);
	    }

		// GET: api/Customers/defaultAddress/5
		[HttpGet]
	    [Route("api/Customers/defaultAddress/{id}")]
	    public Address GetDefaultAddress(int id)
	    {
		    return customerService.GetDefaulAddress(id);
	    }

		// GET: api/Customers/reviews/5
		[HttpGet]
	    [Route("api/Customers/reviews/{id}")]
	    public List<Review> GetReviews(int id)
	    {
		    return customerService.GetReviews(id);
	    }

		// POST: api/Customers/purchase/{customerId}/{productId}
		[HttpPost]
	    [Route("api/Customers/purchase/{customerId}/{productId}")]
	    public bool Post(int customerId, int productId)
	    {
		    return customerService.AddPurchase(customerId, productId);
	    }

		// GET: api/Customers/purchase/5
		[HttpGet]
	    [Route("api/Customers/purchase/{id}")]
	    public List<Purchase> GetPurchases(int id)
	    {
		    return customerService.GetPurchases(id);
	    }


		// DELETE: api/Customers/5
		[HttpDelete]
		[Route("api/Customers/{id}")]
		public bool Delete(int id)
        {
	        return customerService.Remove(id);
		}


    }
}
