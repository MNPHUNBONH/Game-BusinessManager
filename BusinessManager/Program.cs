namespace BusinessManager;

public class Program
{
	public static void Main(string[] args)
	{
		var consoleUI = new ConsoleGameUI();
		var gameManage = new Game(new Player("Valera", 15000),consoleUI);
		gameManage.Start();

		// while (true)
		// {
		// 	gameManage.PrintInformationAboutPlayer();
		// 	Console.WriteLine("Выберите действие:\n" +
		// 	                  "1.Купить бизнес.\n" +
		// 	                  "2.Выйти из игры");
		// 	var userInput = Console.ReadLine();
		//
		// 	switch (userInput)
		// 	{
		// 		case "1":
		// 			Console.WriteLine("Выберите бизнес для покупки:");
		// 			gameManage.PrintInformationBusinesses();
		// 			Console.Write("Введите ваш выбор:");
		// 			userInput = Console.ReadLine();
		// 			break;
		//
		//
		// 	}
		// }
	}
}