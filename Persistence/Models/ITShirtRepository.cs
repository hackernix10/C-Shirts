using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CShirts.Persistence.Models
{
	public interface ITShirtRepository
	{
		void DeleteAll();

		Task<IEnumerable<TShirt>> GetAll();

		void Persist(TShirt tshirt);
	}
}

