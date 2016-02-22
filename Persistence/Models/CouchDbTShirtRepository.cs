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

	public class CouchDbTShirtRepository : ITShirtRepository
	{
		private readonly List<TShirt> collection;
		private readonly IMyCouchStore store;

		public CouchDbTShirtRepository (IMyCouchStore store)
		{
			this.store = store;
		}

		// (persistence and business logic goes here)

		public async void DeleteAll()
		{
			// TODO: implement working delete statement
		}

		public async Task<IEnumerable<TShirt>> GetAll()
		{
			ViewQueryResponse<TShirt> result;
			List<TShirt> tshirts = null;

			// TODO: inject client or replace client with store
			using (var client = new MyCouchClient("http://localhost:5984/cshirts", null)) {
				var query = new QueryViewRequest("getAllTshirts");
				result = await client.Views.QueryAsync<TShirt>(query);
			}

			foreach (var row in result.Rows) {				
				var tshirt = new TShirt ();
				tshirt = row.Value;
				tshirts.Add (tshirt);
			}

			return tshirts;
		}

		public async void Persist(TShirt tshirt)
		{
			// TODO:
			// replace stubed tshirt with actual one
			var tshirtStub = new TShirt();
			tshirtStub.Id = 5;
			tshirtStub.PrintTechnique = "special technique";
			tshirtStub.Title = "stubed tshirt";

			using (var client = new MyCouchClient("http://localhost:5984/cshirts/", null)) {
				var response = await client.Entities.PostAsync (tshirtStub);
				Console.WriteLine (response); // TODO: remove WriteLine
			}
		}
	}
}

