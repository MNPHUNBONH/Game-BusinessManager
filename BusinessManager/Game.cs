using System.Text.Json;

namespace BusinessManager
{
	public class Game
	{
		private Player _player;
		private IGameUI _gameUi;
		public static List<Business>? Shop = new List<Business>();

		public Game(Player player, IGameUI gameUi)
		{
			_player = player;
			_gameUi = gameUi;
		}

		public void Start()
		{
			ReadJson();
			while (true)
			{
				Console.Clear();
				PrintInformationAboutPlayer();
				_gameUi.DisplayMenu();
				switch (_gameUi.GetUserInput())
				{
					case "1":
						Console.WriteLine("Выберите бизнес для покупки:");
						PrintInformationBusinesses();
						PlayerBuyBussines(Convert.ToInt32(_gameUi.GetUserInput()));
						break;
					
					case "2":
						return;
					
					default:
						Console.WriteLine("Неверный ввод");
						break;
				}
			}
		}


		public void SaveJson()
		{
			var jsonString = JsonSerializer.Serialize(Shop, new JsonSerializerOptions() { WriteIndented = true });
			var path = "/Users/valera/rider projects/BusinessManager/BusinessManager/businesses.json";
			File.WriteAllText(path, jsonString);
		}

		public void ReadJson()
		{
			var path = "/Users/valera/rider projects/BusinessManager/BusinessManager/businesses.json";
			if (File.Exists(path))
			{
				var jsonString = File.ReadAllText(path);
				// Десериализация JSON-строки в список объектов Business
				Shop = JsonSerializer.Deserialize<List<Business>>(jsonString);
			}
			else
			{
				Console.WriteLine("File not found.");
			}
		}

		public void PlayerBuyBussines(int numberBussnes)
		{
			if (_player.BuyBusiness(Shop[numberBussnes - 1]))
			{
				Console.WriteLine("Покупка бизнеса прошла успешно");
				Shop.Remove(Shop[numberBussnes - 1]);
			}
			else
			{
				Console.WriteLine("Сделка провалена!");
			}
		}

		public void PrintInformationAboutPlayer()
		{
			Console.WriteLine($"Владелец: {_player.Name}. Денег на счету:{_player.Money}$");
			if (_player.Businesses != null)
			{
				Console.WriteLine($"{_player.Name} имеет следующие бизнесы :");
				for (int i = 0; i < _player.Businesses.Count; i++)
				{
					Console.WriteLine(
						$"{i + 1}. {_player.Businesses[i].Name} | Доход: {_player.Businesses[i].Income}$");
				}
			}
			else
			{
				Console.WriteLine("У игрока нету бизнеса");
			}

			Console.WriteLine();
		}

		public void PrintInformationBusinesses()
		{
			for (var i = 0; i < Shop.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {Shop[i].Name} | Доход: {Shop[i].Income}$ | Цена: {Shop[i].Price}$");
			}

			Console.WriteLine();
		}
	}
}