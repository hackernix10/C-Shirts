using System;

namespace CShirts.Persistence.Models
{
	public interface ITShirtRepository
	{
		void DeleteAll();

		IENumerable<TShirt> GetAll();

		void Persist(TShirt tshirt);
	}
}

