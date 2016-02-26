using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CShirts.Persistence.Models
{
	public interface ITShirtRepository
	{
		void DeleteAll();

		Task<IEnumerable<TShirt>> GetAll();
		Task<IEnumerable<TShirt>> GetAllMockedAsync();

		void Persist(TShirt tshirt);
	}
}

