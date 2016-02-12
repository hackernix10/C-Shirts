using System;

namespace CShirtsNet.Models
{
	public class CreationTimeService
	{
		private readonly DateTime _created;
		private int _totalRequest;

		public CreationTimeService()
		{
			_created = DateTime.Now;
			_totalRequest = 0;
		}

		public DateTime GetCreationDate()
		{
			_totalRequest++;
			return _created;
		}

		public int TimesRequested()
		{
			return _totalRequest;
		}
	}
}