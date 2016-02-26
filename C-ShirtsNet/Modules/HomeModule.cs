using System;
using Nancy;
using Nancy.ModelBinding;
using CShirts.Web.Models;
using CShirts.Persistence.Models;

namespace CShirts.Web.Modules
{
	using System.Threading.Tasks;
	using CShirts.Persistence.Models;
	using System.Collections.Generic;

	public class HomeModule : NancyModule
	{
		public HomeModule (ITShirtRepository tshirtRepository)
		{
			
			// global index view
			Get["/"] = parameters => {
				return View["Index"];
			};

			// return all tshirts
			Get["/tshirts", true] = async (x, ct) => {

				// get "domain" obj
				IEnumerable<TShirt> tshirts = await tshirtRepository.GetAllMockedAsync();


				//List<TShirt> tshirts = await getTshirtTask;

				// prepare tshirtdto list
				var tshirtdtos = new List<TShirtDTO>();

				// convert to dto
				// TOFIX: throws error:
				// Error CS1579: foreach statement cannot operate on variables
				// of type `System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<CShirts.Persistence.Models.TShirt>>'
				// because it does not contain a definition for `GetEnumerator' or is inaccessible (CS1579) (C-Shirts.Web)
				foreach (TShirt tshirt in tshirts)
				{
					var tshirtdto = new TShirtDTO();
					tshirtdto.Id = tshirt.Id; // use auto-mapper instead
					tshirtdto.PrintTechnique = tshirt.PrintTechnique;
					tshirtdto.Title = tshirt.Title;
					tshirtdtos.Add(tshirtdto);
				}

				// TODO
				// convert to json
				//var tshirtsAsJson = tshirtsdto;

				// TODO
				// return json
				return View["Index", tshirtdtos];
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