using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CShirts.Persistence.Models
{
	public interface ITShirtRepository
	{
		Task<bool> DeleteAll();

		Task<IEnumerable<TShirt>> GetAll();

		Task<TShirt> Persist(TShirt tshirt);
	}
}

