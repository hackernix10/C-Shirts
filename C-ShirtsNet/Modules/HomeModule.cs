using System;
using Nancy;
using Nancy.ModelBinding;
using CShirts.Web.Models;
using CShirts.Persistence.Models;

namespace CShirts.Web.Modules
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
				tshirtsdto.Id = 1; // use auto-mapper instead
				tshirtsdto.PrintTechnique = "screen";
				tshirtsdto.Title = "demo shirt";

				// TODO
				// convert to json
				var tshirtsAsJson = tshirtsdto;

				TShirtDTO tshirt = new TShirtDTO();
				tshirt.Id = 1;
				tshirt.Title = "sample shirt";
				tshirt.PrintTechnique = "screen";

				// return json
				return View["Index", tshirt];

			};

			Get["/create/"] = parameters => {
				
				// TODO: find a solution to remove the instance, must have to do with razor..
				// stack trace: I have a create form, which should be bound to a specific model
				// but when calling @Model, I get a System.NullReferenceException
				// I can call the @Model in another view, where I pass an existing instance of the model.
				// Also, I can call the create view, once I remove all @Model statements.
				// I just figured out, passing an empty instance of the model works
				// http://www.jhovgaard.com/from-aspnet-mvc-to-nancy-part-2/
				var tshirt = new TShirtDTO();
				return View ["Create", tshirt];
			};

			Post["/create/"] = parameters => {

				// bind json to dto
				var tshirtDTO = this.Bind<TShirtDTO>();

				// write dto data to tshirt object
				var tshirt = new TShirt();
				tshirt.Id = tshirtDTO.Id;
				tshirt.PrintTechnique = tshirtDTO.PrintTechnique;
				tshirt.Title = tshirtDTO.Title;

				// persist tshirt object
				tshirtRepository.Persist(tshirt);
				
				// Redirect user to Index action with a "status" value as a querystring
				return Response.AsRedirect("");
			};

		}
		public static void Main()
		{
			Console.WriteLine("Hello, World!");
		}
	}
}