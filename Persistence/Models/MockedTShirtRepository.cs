using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CShirts.Persistence.Models
{
	public class MockedTShirtRepository : ITShirtRepository
	{
		public async Task<bool> DeleteAll() {
			
			await Task.Delay(100);

			return true;
		}

		public async Task<IEnumerable<TShirt>> GetAll() {
			Console.WriteLine ("starting some async task...");

			//Thread.Sleep (100);
			await Task.Delay(100);

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

		public async Task<TShirt> Persist(TShirt tshirt) {
			
			await Task.Delay(100);

			return tshirt;	
		}
	}
}

