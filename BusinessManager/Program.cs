namespace BusinessManager;

public class Program
{
	public static void Main(string[] args)
	{
		var consoleUI = new ConsoleGameUI();
		var gameManage = new Game(new Player("Valera", 33000),consoleUI);
		gameManage.Start();
	}
}