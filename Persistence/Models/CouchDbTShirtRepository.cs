using System;
using System.Collections;

namespace CShirts.Persistence.Models
{
	using Models;
	using MyCouch;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using MyCouch.Requests;
	using MyCouch.Responses;

	using System.Linq;
	using System.Security.Claims;
	//using Microsoft.AspNet.Identity;

	public class CouchDbTShirtRepository : ITShirtRepository
	{
		private readonly List<TShirt> collection;
		private readonly IMyCouchStore store;

		public CouchDbTShirtRepository (IMyCouchStore store)
		{
			// TODO:
			// move to constructor and inject it through Autofac
			this.store = store; //new MyCouchStore("http://seraya_dba:Pa$$w0rd@localhost:5984/","cshirts");
		}

		// persistence and business logic goes here

		public async void DeleteAll()
		{
			// TODO: implement working delete statement
			// example taken from https://github.com/danielwertheim/mycouch

			var deleted = await store.DeleteAsync("mySomething.Id", "mySomething.Rev");

		}

		public async Task<IEnumerable<TShirt>> GetAll()
		{
			ViewQueryResponse<TShirt[]> result;
			
			using (var client = new MyCouchClient("http://seraya_dba:password@127.0.0.1:5984/cshirts", null)) {
				var query = new QueryViewRequest("getAllTshirts");
				result = await client.Views.QueryAsync<TShirt[]>(query);
			}

			// how tf is it possible to cast mycouch.row to tshirt?
			var tshirts = new List<TShirt>();
			tshirts.Add(new TShirt ());

			Console.WriteLine ("::: ::: ::: ::: WRITING RESULT TO CONSOLE ::: ::: ::: :::");
			Console.WriteLine (result);
			Console.WriteLine ("::: ::: ::: ::: WROTE RESULT TO CONSOLE   ::: ::: ::: :::");

			return tshirts;
		}

		public async void Persist(TShirt tshirt)
		{
			//var mySomething = await store.StoreAsync(tshirt);
			var tshirtStub = new TShirt();
			tshirtStub.Id = 5;
			tshirtStub.PrintTechnique = "special technique";
			tshirtStub.Title = "stubed tshirt";

			using (var client = new MyCouchClient("http://localhost:5984/cshirts/", null)) {
				var response = await client.Entities.PostAsync (tshirtStub);
				Console.WriteLine (response);
			}


		}
	}
}

