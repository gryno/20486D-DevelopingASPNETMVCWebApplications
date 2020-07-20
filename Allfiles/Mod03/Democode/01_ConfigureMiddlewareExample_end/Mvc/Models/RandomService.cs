using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
	public interface IRandomService
	{
		int GetNumber();
	}

	public class RandomService : IRandomService
	{
		private int _randomNumber;

		public RandomService()
		{
			Random random = new Random();
			_randomNumber = random.Next(1000000);
		}
		public int GetNumber()
		{
			return _randomNumber;
		}
	}

}
