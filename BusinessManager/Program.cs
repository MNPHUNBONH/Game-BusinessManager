namespace BusinessManager;

public class Program
{
	public static void Main(string[] args)
	{
		var gameManage = new GameManager(new Player("Valera", 15000));
		
		GameManager.ReadJSON();
	}
}