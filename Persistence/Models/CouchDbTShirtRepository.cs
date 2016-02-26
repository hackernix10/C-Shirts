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
	using System.Threading;

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
			Task<ViewQueryResponse<TShirt>> tshirtTask;
			ViewQueryResponse<TShirt> tshirtResult;
			List<TShirt> tshirts = null;

			// TODO: inject client or replace client with store
			using (var client = new MyCouchClient("http://localhost:5984", "cshirts")) {
				var query = new QueryViewRequest("getAllTshirts");
				tshirtTask = client.Views.QueryAsync<TShirt>(query);
			}

			tshirtResult = await tshirtTask;

			foreach (var row in tshirtResult.Rows) {				
				var tshirt = new TShirt ();
				tshirt = row.Value;
				tshirts.Add (tshirt);
			}
			Console.WriteLine (tshirts);
			return tshirts;
		}

		public async Task<IEnumerable<TShirt>> GetAllMockedAsync() {
			
			Console.WriteLine ("starting some async task...");

			Thread.Sleep (100);

			var tshirt = new TShirt ();
			tshirt.Id = 5;
			tshirt.PrintTechnique = "some special technique";
			tshirt.Title = "some sophisticated title";

			var tshirt2 = new TShirt ();
			tshirt2.Id = 6;
			tshirt2.PrintTechnique = "screen print";
			tshirt2.Title = "tell your story";

			var tshirts = new List<TShirt>();
			tshirts.Add (tshirt);
			tshirts.Add (tshirt2);

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

			using (var client = new MyCouchClient("http://localhost:5984", "cshirts")) {
				var response = await client.Entities.PostAsync (tshirtStub);
				Console.WriteLine (response); // TODO: remove WriteLine
			}
		}
	}
}

