using System;
using Nancy;
using CShirtsNet.Models;
using Nancy.ModelBinding;

namespace CShirtsNet.Modules
{
	using CShirts.Persistence.Models;

	public class HomeModule : NancyModule
	{
		public HomeModule (ITShirtRepository tshirtRepository)
		{
			
			// global index view
			Get["/"] = parameters => {
				return View["Index"];
			};

			// return all tshirts
			Get["/tshirts"] = parameters => {

				// get "domain" obj
				var tshirts = tshirtRepository.GetAll();

				// TODO
				// convert to view model
				var tshirtsdto = new TShirtDTO();
				tshirtsdto.Id = tshirts.Id; // use auto-mapper instead

				// TODO
				// convert to json
				var tshirtsAsJson;

				// return json
				return tshirtsAsJson;
			};

			Get["/create/"] = parameters => {
				
				// TODO: find a solution to remove the instance, must have to do with razor..
				// stack trace: I have a create form, which should be bound to a specific model
				// but when calling @Model, I get a System.NullReferenceException
				// I can call the @Model in another view, where I pass an existing instance of the model.
				// Also, I can call the create view, once I remove all @Model statements.
				// I just figured out, passing an empty instance of the model works
				// http://www.jhovgaard.com/from-aspnet-mvc-to-nancy-part-2/

				return View ["Create", tshirt];
			};

			Post["/create/"] = paramters => {
				var tshirt = this.Bind<TShirt>();
				// Redirects the user to our Index action with a "status" value as a querystring.
				return Response.AsRedirect("/?status=added&title=" + tshirt.Title);
			};

		}
		public static void Main()
		{
			Console.WriteLine("Hello, World!");
		}
	}
}