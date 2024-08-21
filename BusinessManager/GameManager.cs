using System.Text.Json;

namespace BusinessManager;

public class GameManager
{
	private Player _player;
	private IGameUI _gameUi;
	public static List<Business> _shop = new List<Business>();

	public GameManager(Player player)
	{
		_player = player;
	}
	
	
	public static void SaveJSON()
	{
		var jsonString = JsonSerializer.Serialize(_shop,new JsonSerializerOptions(){WriteIndented = true});
		var path = "/Users/valera/rider projects/BusinessManager/BusinessManager/businesses.json";
		File.WriteAllText(path,jsonString);
		
	}

	public static void ReadJSON()
	{
		var path = "/Users/valera/rider projects/BusinessManager/BusinessManager/businesses.json";
		var jsonString = File.ReadAllText(path);
		
		
		
	}
	
}