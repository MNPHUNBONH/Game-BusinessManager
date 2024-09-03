namespace BusinessManager;

public class ConsoleGameUI : IGameUI
{
	public void DisplayMenu()
	{
		Console.WriteLine("Выберите действие:\n" +
		                  "1.Купить бизнес.\n" +
		                  "2.Выйти из игры");
		Console.WriteLine();
	}

	public string GetUserInput()
	{
		Console.Write("Введите ваш выбор:");
		return Console.ReadLine();
		
	}

	public string GetBusinessName(Business business) => business.Name;

	public double GetBusinessIncome()
	{
		throw new NotImplementedException();
	}

	public double GetBusinessUpgradeCost()
	{
		throw new NotImplementedException();
	}

	public int GetBusinessIndex(int maxIndex)
	{
		throw new NotImplementedException();
	}

	public string GetUpgradeName()
	{
		throw new NotImplementedException();
	}

	public double GetUpgradeCost()
	{
		throw new NotImplementedException();
	}

	public double GetIncomeMultiplier()
	{
		throw new NotImplementedException();
	}

	public void DisplayMessege(string message)
	{
		throw new NotImplementedException();
	}
}