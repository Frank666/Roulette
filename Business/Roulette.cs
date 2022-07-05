using System;

namespace Business
{
    public class Roulette
    {
        private readonly int[] red_nums = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };
        private readonly int[] black_nums = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
		private Random rand;	

		public Roulette()
        {
			rand = new Random();
        }

		public void SkipLines(int howMany)
		{
			do
			{
				Console.WriteLine();
				howMany--;

			} while (howMany > 0);
		}

		public int GetRandomNumber()
		{
			int randNumb = rand.Next(1, 37);
			// Random number between 1 & 36
			return randNumb;
		}

		public int IntWin(int gamble, int randNumb)
		{
			if (gamble == randNumb)
			{
				Console.WriteLine("The roulette is rolling... \nIt stops on the " + randNumb + ".\nYou win, bet multiply by 35 !");
				return 35;

			}

			Console.WriteLine("The roulette is rolling... \nIt stops on the " + randNumb + ".\nYou lost, bet equals to 0 !");
			return 0;
		}

		public int ColorWin(int randNumb, int colorSelected)
		{
			var array = colorSelected == 1 ? red_nums : black_nums;
			foreach (int num in array)
			{
				if (num == randNumb)
				{
					Console.WriteLine("The roulette is rolling so fast !\nIt stops right on your color.\nCongrats, you win : bet multiply by 2");
					return 2;

				}
			}

			Console.WriteLine("You lost, it isn't the right color.\nToo bad : bet equals to 0.");
			return 0;
		}
		public int RangeWin(int randNumb, int bet, int optionSelected)
		{
			Console.WriteLine("The roulette is rolling...");
			if ((randNumb >= 1 && randNumb <= 12) && optionSelected == 1)
			{
				Console.WriteLine("Congrats you win!");
				return 3;
			}
			if ((randNumb >= 1 && randNumb <= 12) && optionSelected == 2)
			{
				Console.WriteLine("Congrats you win!");
				return 3;
			}

			if ((randNumb >= 1 && randNumb <= 12) && optionSelected == 3)
			{
				Console.WriteLine("Congrats you win!");
				return 3;
			}
			Console.WriteLine("house win! Try again!");
			return 0;
		}

		public int HighOrLow(int randNumb, int bet, int optionSelected)
		{
			Console.WriteLine("The roulette is rolling...");
			if ((randNumb >= 1 && randNumb <= 18) && optionSelected == 1)
			{
				Console.WriteLine("Congrats you win!");
				return (bet * 2);
			}
			if ((randNumb >= 19 && randNumb <= 36) && optionSelected == 2)
			{
				Console.WriteLine("Congrats you win!");
				return (bet * 2);
			}

			Console.WriteLine("house win! Try again!");
			return 0;
		}
	}
}
