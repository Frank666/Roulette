using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Sold
    {
		public int _sold { get; set; }


		public Sold(int sold)
		{
			_sold = sold;

		}

		public void ShowSold()
		{
			Console.WriteLine($"Sold: ${_sold} ");

		}

		public void Add(int bet)
		{
			_sold += bet;

		}

		public void Sub(ref int bet)
		{
			if ((_sold - bet) < 0)
			{
				bet = _sold;
				Console.WriteLine($"Bet set to {bet}.");
			}
			_sold -= bet;
		}

		public bool CheckForGameOver()
		{
			return _sold <= 0 ? true : false;
		}
	}
}
