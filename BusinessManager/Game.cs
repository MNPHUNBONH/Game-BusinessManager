using System.Text.Json;

namespace BusinessManager
{
	public class Game
	{
		//private event Action<> 
		private Timer incomeTimer;
		private Player _player;
		private IGameUI _gameUi;
		private static List<Business>? _shopBusinesses = new List<Business>();

		public Game(Player player, IGameUI gameUi)
		{
			_player = player;
			_gameUi = gameUi;
			incomeTimer = new Timer(_ => _player.CollectIncome(), null, 5000, 2000);
		}

		public void Start()
		{
			LoadBussines();
			while (true)
			{
				Thread.Sleep(1000);
				_gameUi.DisplayClear();
				_gameUi.ShowInformationAboutPlayer(_player);
				_gameUi.DisplayMenu();
				switch (_gameUi.GetUserInput())
				{
					case "1":
						var businesseWithUphrades = _player.Businesses.Where(business => business.Upgrades.Count > 0).ToList();
						
						if (businesseWithUphrades.Count == 0)
						{
							_gameUi.DisplayMessege("Нету бизнесов для улучшения");
							break;
						}
						
						_gameUi.DisplayMessege("Выберите бизнес:");
						for (var index = 0; index < businesseWithUphrades.Count; index++)
						{
							_gameUi.DisplayMessege(
								$"{index + 1}. Выбрать бизнес {_gameUi.GetBusinessName(businesseWithUphrades[index])} " +
								$"| Доход: {_gameUi.GetBusinessIncome(businesseWithUphrades[index])}");
						}

						var businessIndex = _gameUi.GetIndex(businesseWithUphrades.Count) - 1; // где лучше сделать проверку в консоли или тут ?
						
						if (businessIndex >= 0 && businessIndex < businesseWithUphrades.Count) 
							UpgradeBussines(businesseWithUphrades[businessIndex]);
						
						else _gameUi.DisplayMessege("Неверный номер бизнеса");

						break;

					case "2":
						if (_shopBusinesses.Count == 0)
						{
							_gameUi.DisplayMessege("Все бизнесы проданы!");
							break;
						}

						_gameUi.DisplayMessege("Выберите бизнес для покупки:");
						for (int i = 0; i < _shopBusinesses.Count; i++)
							_gameUi.DisplayMessege($"{i + 1}. {_gameUi.GetBusinessName(_shopBusinesses[i])} " +
							                       $"| " + $"Доход: {_gameUi.GetBusinessIncome(_shopBusinesses[i])} " +
							                       $"|" + $" Цена: {_gameUi.GetBusinessCost(_shopBusinesses[i])}$");

						BuyBussines();
						break;

					case "3":
						_gameUi.DisplayMessege("Game over!");
						return;

					default:
						_gameUi.DisplayMessege("Неверный ввод");
						break;
				}
			}
		}
		private void SaveBussines()
		{
			var jsonString =
				JsonSerializer.Serialize(_shopBusinesses, new JsonSerializerOptions() { WriteIndented = true });
			var path = "/Users/valera/rider projects/BusinessManager/BusinessManager/businesses.json";
			File.WriteAllText(path, jsonString);
		}

		private void LoadBussines()
		{
			var path = "/Users/valera/rider projects/BusinessManager/BusinessManager/businesses.json";
			if (File.Exists(path))
			{
				var jsonString = File.ReadAllText(path);
				// Десериализация JSON-строки в список объектов Business
				_shopBusinesses = JsonSerializer.Deserialize<List<Business>>(jsonString);
			}
			else
			{
				_gameUi.DisplayMessege("File not found.");
			}
		}

		private void BuyBussines()
		{
			var indexBussines = _gameUi.GetIndex(_shopBusinesses.Count) - 1;

			if (_player.Money >= _shopBusinesses[indexBussines].Price)
			{
				_player.BuyBusiness(_shopBusinesses[indexBussines]);
				_gameUi.DisplayMessege("Покупка бизнеса прошла успешно.");
			}
			else _gameUi.DisplayMessege("Недостаточно средств. Сделка провалена!");
		}

		private void UpgradeBussines(Business business)
		{
			_gameUi.DisplayMessege("Выберите улучшение для бизнеса:");
			for (int i = 0; i < business.Upgrades.Count; i++)
			{
				_gameUi.DisplayMessege($"{i+1}. {_gameUi.GetUpgradeName(business.Upgrades[i])} " +
				                       $"| Увеличит доход: {_gameUi.GetIncomeMultiplier(business.Upgrades[i])} " +
				                       $"| Цена: {_gameUi.GetUpgradeCost(business.Upgrades[i])}");
			}
			
			var upgradeIndex = _gameUi.GetIndex(business.Upgrades.Count) - 1;

			if (upgradeIndex >= 0 && upgradeIndex < business.Upgrades.Count)
				_player.UpgradeBusiness(business, upgradeIndex);
			else _gameUi.DisplayMessege("Недостаточно денег!");
		}

		private void CollectIncome()
		{
			int generalIncome = 0;
			foreach (var business in _player.Businesses)
			{
				generalIncome += business.Income;
			}

			((ConsoleGameUI)_gameUi).DisplayMessege($"Бизнесы {_player.Name} принес доход: {generalIncome}",
				ConsoleColor.Red);
			_player.CollectIncome();
			((ConsoleGameUI)_gameUi).DisplayMessege($"Теперь ваш балас составляет: {_player.Money}", ConsoleColor.Red);
		}
	}
}