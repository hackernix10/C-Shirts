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

		public async Task<TShirt> Get(int id)
		{
			// TODO: replace with actual implementation
			var tshirt = new TShirt();
			tshirt.Id = id;
			tshirt.PrintTechnique = "Print technique #" + id.ToString();
			tshirt.Title = "Tshirt #" + id.ToString ();

			await Task.Delay(100);

			return tshirt;
		}

		public async Task<TShirt> Persist(TShirt tshirt)
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

			// TODO: if successfull
			return tshirtStub;
		}

		public async Task<TShirt> Edit(TShirt tshirt)
		{
			// TODO: implement actual implementation

			await Task.Delay(100);

			// TODO: if successfull
			return tshirt;
		}

		public async Task<bool> Delete(int id)
		{
			// TODO: implement working delete statement

			await Task.Delay(100);

			// TODO: if successfull
			return true;
		}
	}
}

