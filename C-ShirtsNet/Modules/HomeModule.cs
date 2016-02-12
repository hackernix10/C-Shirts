using System;
using Nancy;

namespace CShirtsNet
{
	public class HomeModule : NancyModule
	{
		public HomeModule ()
		{
			Get["/"] = parameters => {
				return View["Index"];
			};
		}
		public static void Main()
		{
			Console.WriteLine("Hello, World!");
		}
	}
}

