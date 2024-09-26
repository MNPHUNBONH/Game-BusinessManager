namespace BusinessManager;

public class ConsoleGameUI : IGameUI
{
	public void DisplayMenu()
	{
		Console.WriteLine("Выберите действие:\n" +
		                  "1.Улучшить бизнес.\n" +
		                  "2.Купить бизнес.\n" +
		                  "3.Выйти из игры");
		Console.WriteLine();
	}

	public string GetUserInput()
	{
		Console.Write("Введите вашь выбор:");
		return Console.ReadLine();
	}

	public void ShowInformationAboutPlayer(Player player)
	{
		Console.WriteLine($"Владелец: {player.Name}. Денег на счету:{player.Money}$");
		if (player.Businesses != null)
		{
			Console.WriteLine($"{player.Name} имеет следующие бизнесы :");
			for (int i = 0; i < player.Businesses.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {player.Businesses[i].Name} | Доход: {player.Businesses[i].Income}$");
			}
		}
		else Console.WriteLine("У игрока нету бизнеса");
	}

	public string GetInformationAboutBusiness(Business business) => $"{business.Name} | " +
	                                                                $"Доход: {business.Income}$ |" +
	                                                                $" Цена: {business.Price}$";

	public string GetInformationAboutUpgrade(Upgrade upgrade) => $"{upgrade.Name} |" +
	                                                             $" Увеличит доход:{upgrade.IncomeMultiplier}|" +
	                                                             $" Цена:{upgrade.Cost}  ";

	public string GetBusinessName(Business business) => business.Name;
	public double GetBusinessCost(Business business) => business.Price;
	public double GetBusinessIncome(Business business) => business.Income;
	public double GetBusinessUpgradeCost(Business business)
	{
		throw new NotImplementedException();
	}
	public int GetIndex(int maxIndex)
	{
		Console.Write("Введите ваш выбор:");
		var indexInput = Convert.ToInt32(Console.ReadLine());
		return indexInput - 1 > maxIndex || indexInput - 1 < 0 ? -1 : indexInput;
	}
	public string GetUpgradeName(Upgrade upgrade) => upgrade.Name;
	public double GetUpgradeCost(Upgrade upgrade) => upgrade.Cost;
	public double GetIncomeMultiplier(Upgrade upgrade) => upgrade.IncomeMultiplier;
	public void DisplayMessege(string message) => Console.WriteLine(message);

	public void DisplayMessege(string message, ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.WriteLine(message);
		Console.ResetColor();
		Console.WriteLine();
	}

	public void DisplayClear() => Console.Clear();
}