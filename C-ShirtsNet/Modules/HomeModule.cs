using System;
using Nancy;
using CShirtsNet.Models;

namespace CShirtsNet.Modules
{
	public class HomeModule : NancyModule
	{
		public HomeModule ()
		{
			Get["/"] = parameters => {
				TShirt tshirt = new TShirt();
				tshirt.Id = 1;
				tshirt.Title = "sample shirt";
				tshirt.PrintTechnique = "screen";

				return View["Index", tshirt];
			};
		}
		public static void Main()
		{
			Console.WriteLine("Hello, World!");
		}
	}
}