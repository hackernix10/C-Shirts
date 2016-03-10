using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CShirts.Persistence.Models
{
	public interface ITShirtRepository
	{
		Task<IEnumerable<TShirt>> GetAll();

		Task<TShirt> Get(int id);

		Task<TShirt> Persist(TShirt tshirt);

		Task<TShirt> Edit(TShirt tshirt);

		Task<bool> Delete(int id);
	}
}

