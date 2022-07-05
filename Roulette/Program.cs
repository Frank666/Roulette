using System;


class MainClass
{
	private static readonly string ValidInputMessage = "Please type a valid message";
	private static readonly string ValidInputNumberMessage = "This is not valid input. Please enter an integer value";
	private static readonly string ValidInputOptionMessage = "Please input numbers between 1 to 4";
	public static void Main(string[] args)
	{
		Roulette();
	}

	static void Roulette()
	{
		Console.WriteLine("Hello and welcome to my roulette game.\nHope you enjoy it :).\nPlease type your initial amount: ");

		int amount;
		while (!int.TryParse(Console.ReadLine(), out amount))
		{
			Console.Write(ValidInputNumberMessage);
		}

		var roulette = new Business.Roulette();
		var player = new Business.Sold(amount);

		player.ShowSold();
		roulette.SkipLines(3);

		while (true)
		{
			Console.WriteLine("Please select an bet option: ");
			Console.WriteLine($"1) Red or black \n2) 1st 12, 2nd 12, 3rd 12 (1-12)/(13-24)/(25-36) \n3) Specific numnber\n4) high/low\n");
			roulette.SkipLines(2);
			int option = ValidateInputNumber(0, 4, ValidInputOptionMessage);

			roulette.SkipLines(1);
			player.ShowSold();

			Console.WriteLine("Bet ? ");
			int bet;
			do
			{
				Int32.TryParse(Console.ReadLine(), out bet);
				if (bet <= 0)
					Console.WriteLine("Please input a number greater than zero");
			} while (bet <= 0);

			player.Sub(ref bet);
			int mult = 0;
			int randomNumber = roulette.GetRandomNumber();
			switch (option)
			{
				case 1:
					Console.WriteLine("Option 1 selected (Red or black)\nPlease select a color: Red --> 1 and Black --> 2");
					int color = ValidateInputNumber(0, 2, ValidInputMessage);
					mult = roulette.ColorWin(randomNumber, color);
					break;

				case 2:
					Console.WriteLine("Option 2 selected\n Please select an option\n1)1-12\n2)13-24\n3)25-36");
					int range = ValidateInputNumber(0, 3, ValidInputMessage);
					mult = roulette.RangeWin(randomNumber, bet, range);
					break;

				case 3:
					Console.WriteLine("Option 3 selected (Specific numnber)");
					Console.WriteLine("Type the number please: ");
					int number = ValidateInputNumber(0, 36, ValidInputMessage);
					mult = roulette.IntWin(number, randomNumber);
					break;

				default:
					Console.WriteLine("Option 4 (High/low)");
					Console.WriteLine("Please select an option\n1)Low (1-18)\n2)High (19-36)");

					int lowOrHigh = ValidateInputNumber(0, 2, ValidInputMessage);
					mult = roulette.HighOrLow(bet, bet, lowOrHigh);
					break;
			}

			player.Add(bet * mult);
			roulette.SkipLines(3);


			if (player.CheckForGameOver())
			{
				roulette.SkipLines(2);
				Console.WriteLine("You lost, try again an other time :D");
				return;
			}
		}
	}

	static int ValidateInputNumber(int initRange, int endRange, string message)
    {
		int result;
		do
		{
			Int32.TryParse(Console.ReadLine(), out result);
			if (result <= initRange || result > endRange)
				Console.WriteLine(message);
		} while (result <= initRange || result > endRange);
		return result;
	}
}