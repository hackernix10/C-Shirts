using System;
using Nancy;
using Nancy.ModelBinding;
using CShirts.Web.Models;
using CShirts.Persistence.Models;
using Newtonsoft.Json;

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
				return View["Index.html"];
			};

			// return all tshirts
			Get["/tshirts", true] = async (x, ct) => {

				// get "domain" obj
				IEnumerable<TShirt> tshirts = await tshirtRepository.GetAll();

				// prepare tshirtdto list
				var tshirtdtos = new List<TShirtDTO>();

				// convert to dto
				foreach (TShirt tshirt in tshirts)
				{
					var tshirtdto = new TShirtDTO();
					tshirtdto.Id = tshirt.Id; // use auto-mapper instead
					tshirtdto.PrintTechnique = tshirt.PrintTechnique;
					tshirtdto.Title = tshirt.Title;
					tshirtdtos.Add(tshirtdto);
				}

				// convert to json
				var tshirtsAsJson = JsonConvert.SerializeObject(tshirtdtos);

				// prepare json
				var response = (Response)tshirtsAsJson;
				response.ContentType = "application/json";

				return response;
			};

			Get["/tshirt/create/"] = parameters => {
				
				// TODO: find a solution to remove the instance, must have to do with razor..
				// stack trace: I have a create form, which should be bound to a specific model
				// but when calling @Model, I get a System.NullReferenceException
				// I can call the @Model in another view, where I pass an existing instance of the model.
				// Also, I can call the create view, once I remove all @Model statements.
				// I just figured out, passing an empty instance of the model works
				// http://www.jhovgaard.com/from-aspnet-mvc-to-nancy-part-2/
				var tshirt = new TShirtDTO();

				return tshirt;
			};

			Post["/tshirt/create/", true] = async (x, ct) => {

				// bind json to dto
				var tshirtDTO = this.Bind<TShirtDTO>();

				// write dto data to tshirt object
				var tshirt = new TShirt();
				tshirt.Id = tshirtDTO.Id;
				tshirt.PrintTechnique = tshirtDTO.PrintTechnique;
				tshirt.Title = tshirtDTO.Title;

				// persist tshirt object
				var result = await tshirtRepository.Persist(tshirt);
				
				return result;
				// Redirect user to Index action with a "status" value as a querystring
				// return Response.AsRedirect("");
			};

			Get ["/tshirt/{id}", true] = async (x, ct) => {
				
				var tshirt = await tshirtRepository.Get(x.id);

				var tshirtDTO = new TShirt();
				tshirtDTO.Id = tshirt.Id;
				tshirtDTO.PrintTechnique = tshirt.PrintTechnique;
				tshirtDTO.Title = tshirt.Title;

				// convert to json
				var tshirtAsJson = JsonConvert.SerializeObject(tshirtDTO);

				// prepare json
				var response = (Response)tshirtAsJson;
				response.ContentType = "application/json";

				return response;
			};

			Post ["/tshirt/{id}/edit", true] = async (x, ct) => {
				var tshirtDTO = this.Bind<TShirtDTO>();

				var tshirt = new TShirt();
				tshirt.Id = tshirtDTO.Id;
				tshirt.PrintTechnique = tshirtDTO.PrintTechnique;
				tshirt.Title = tshirtDTO.Title;

				var response = await tshirtRepository.Edit(tshirt);
				return response;
			};

			Post ["/tshirt/{id}/delete", true] = async (x, ct) => {
				var response = await tshirtRepository.Delete(x.id);
				return response;
			};

		}
		public static void Main()
		{
			Console.WriteLine("Hello, World!");
		}
	}
}