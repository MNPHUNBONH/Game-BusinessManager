using System.Diagnostics;

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
		var indexInput = Convert.ToInt32(Console.ReadLine())-1;
		return indexInput  > maxIndex || indexInput < 0 ? -1 : indexInput;
	}
	public void DisplayMessage(string message) => Console.WriteLine(message);

	public void DisplayMessage(string message, ColorMessage colorMessage)
	{
		switch (colorMessage)
		{
			case ColorMessage.Red:
				Console.ForegroundColor = ConsoleColor.Red;
				break;
			case ColorMessage.Green:
				Console.ForegroundColor = ConsoleColor.Green;
				break;
			case ColorMessage.Blue:
				Console.ForegroundColor = ConsoleColor.Blue;
				break;
			default:
				Console.ForegroundColor = ConsoleColor.White;	
				break;
		}
		
		Console.WriteLine(message);
		Console.ResetColor();
		Console.WriteLine();
	}

	public void DisplayClear() => Console.Clear();
	
}