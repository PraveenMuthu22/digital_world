using System;
using System.Collections.Generic;
using System.Diagnostics;
using DatabaseProject.Enums;
using DatabaseProject.Models;
using DatabaseProject.Services;

namespace ConsoleAppp
{
	class Program
	{
		static void Main(string[] args)
		{
			ProductService productService = new ProductService();
			CustomerService customerService = new CustomerService();
			Console.ReadLine();
		}

		
	}
}