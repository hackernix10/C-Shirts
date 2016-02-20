using System;

namespace CShirts.Persistence.Models
{
	using Models;
	using MyCouch;
	using System.Collections.Generic;

	public class CouchDbTShirtRepository : ITShirtRepository
	{
		private readonly List<TShirt> collection;
		private readonly MyCouchStore store;

		public CouchDbTShirtRepository (MyCouchStore store)
		{
			this.store = store;
		}

		// persistence and business logic goes here

		public async void DeleteAll()
		{
			// TODO: implement working delete statement
			// example taken from https://github.com/danielwertheim/mycouch

			// var deleted = await store.DeleteAsync(mySomething.Id, mySomething.Rev);

		}

		public IENumerable<TShirt> GetAll()
		{
			var query = new MyCouch.Querying.
		}

		public void Persist(TShirt tshirt)
		{
		
		}
	}
}

