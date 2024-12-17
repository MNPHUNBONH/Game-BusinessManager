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
	
	public int GetIndex(int maxIndex)
	{
		Console.Write("Введите ваш выбор:");
		var indexInput = Convert.ToInt32(Console.ReadLine());
		return indexInput - 1 > maxIndex || indexInput - 1 < 0 ? -1 : indexInput;
	}
	public void DisplayMessage(string message) => Console.WriteLine(message);

	public void DisplayMessege(string message, ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.WriteLine(message);
		Console.ResetColor();
		Console.WriteLine();
	}

	public void DisplayClear() => Console.Clear();
}