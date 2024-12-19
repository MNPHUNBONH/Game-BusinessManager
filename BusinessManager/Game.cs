using System.Text.Json;

namespace BusinessManager
{
    public enum ColorMessage
    {
        Red,
        Green,
        Blue
    }
    public class Game
    {
        private Timer incomeTimer;
        private Player _player; // хранит обьект игрока
        private IGameUI _gameUi; //хранит обькт интерфейса
        private List<Business>? _shopBusinesses = new List<Business>(); // обьекты бизнесов которые можно купить
        private const string BusinessesFilePath = "../../../businesses.json";
        private int _inсome = 0;

        public Game(Player player, IGameUI gameUi)
        {
            _player = player;
            _gameUi = gameUi;
            incomeTimer = new Timer(_ => _player.CollectIncome(), null, 1000, 2000);
        }

        public void Start()
        {
            _player.OnBalanceChanged += _gameUi.DisplayMessage;
            
            LoadBusinesses(); //загружаем бизнесы из файла
            while (true)
            {
                Thread.Sleep(2000);
                _gameUi.DisplayClear(); //очищаем консоль перед каждым новым действием пользователя
                ShowPlayerInfo();
                CollectIncome();
                _gameUi.DisplayMenu(); //выводит меню игры


                switch (_gameUi.GetUserInput())
                {
                    case "1":
                        ShowUpgradeMenu();
                        break;

                    case "2":
                        ShowPurchaseMenu();
                        break;

                    case "3":
                        _gameUi.DisplayMessage("Game over!");
                        return;

                    default:
                        _gameUi.DisplayMessage("Неверный ввод");
                        break;
                }
            }
        }

        private void LoadBusinesses()
        {
            if (File.Exists(BusinessesFilePath))
            {
                var jsonString = File.ReadAllText(BusinessesFilePath);
                // Десериализация JSON-строки в список объектов Business
                _shopBusinesses = JsonSerializer.Deserialize<List<Business>>(jsonString);
            }
            else
            {
                _gameUi.DisplayMessage("File not found.");
            }
        }

        private void ShowUpgradeMenu()
        {
            var businessesWithUpgrades = _player.Businesses.Where(b => b.Upgrades.Any()).ToList();

            if (businessesWithUpgrades.Count == 0)
            {
                _gameUi.DisplayMessage("Нет доступных бизнесов для улучшения.");
                return;
            }

            _gameUi.DisplayMessage("Выберите бизнес для улучшения:");
            for (var i = 0; i < businessesWithUpgrades.Count; i++)
            {
                var business = businessesWithUpgrades[i];
                _gameUi.DisplayMessage($"{i + 1}. {business.Name} | Доход: {business.Income}$");
            }

            var businessIndex = GetValidatedIndex(businessesWithUpgrades.Count);
            if (businessIndex == -1) return;

            UpgradeBusiness(businessesWithUpgrades[businessIndex]);
        }

        private void ShowPurchaseMenu()
        {
            if (_shopBusinesses is null || _shopBusinesses.Count == 0)
            {
                _gameUi.DisplayMessage("Все бизнесы проданы.");
                return;
            }

            _gameUi.DisplayMessage("Выберите бизнес для покупки:");
            for (var i = 0; i < _shopBusinesses.Count; i++)
            {
                var business = _shopBusinesses[i];
                _gameUi.DisplayMessage(
                    $"{i + 1}. {business.Name} | Доход: {business.Income}$ | Цена: {business.Price}$");
            }

            var businessIndex = GetValidatedIndex(_shopBusinesses.Count);
            if (businessIndex == -1) return;

            BuyBusiness(businessIndex);
        }

        private void BuyBusiness(int indexBussines)
        {
            if (_player.Money < _shopBusinesses[indexBussines].Price)
            {
                _gameUi.DisplayMessage("Недостаточно средств. Сделка провалена!");
                return;
            }

            _player.BuyBusiness(_shopBusinesses[indexBussines]);
            _gameUi.DisplayMessage("Покупка бизнеса прошла успешно.");
        }

        private void UpgradeBusiness(Business business)
        {
            _gameUi.DisplayMessage("Выберите улучшение:");
            for (var i = 0; i < business.Upgrades.Count; i++)
            {
                var upgrade = business.Upgrades[i];
                _gameUi.DisplayMessage(
                    $"{i + 1}. {upgrade.Name} | Доход: {upgrade.IncomeMultiplier} | Цена: {upgrade.Cost}$");
            }

            var upgradeIndex = GetValidatedIndex(business.Upgrades.Count);
            if (upgradeIndex == -1)
            {
                _gameUi.DisplayMessage("Неверный номер улучшения.");
                return;
            }

            if (_player.Money < _shopBusinesses[upgradeIndex].Price)
            {
                _gameUi.DisplayMessage("Недостаточно средств для покупки улучшения!!");
                return;
            }

            _player.UpgradeBusiness(business, upgradeIndex);
            _gameUi.DisplayMessage("Улучшение куплено успешно!");
        }

        private void CollectIncome()
        {
            if (_player.Income == 0) return;

            _gameUi.DisplayMessage($"Бизнесы {_player.Name} принес доход: {_player.Income}", ColorMessage.Red);
            _player.GetIncome();
        }

        private void ShowPlayerInfo()
        {
            _gameUi.DisplayMessage($"Игрок: {_player.Name}. Баланс: {_player.Money}$");

            if (_player.Businesses.Count == 0)
            {
                _gameUi.DisplayMessage("У игрока нет бизнесов.");
                return;
            }

            _gameUi.DisplayMessage("Ваши бизнесы:");
            for (var i = 0; i < _player.Businesses.Count; i++)
            {
                var business = _player.Businesses[i];
                _gameUi.DisplayMessage($"{i + 1}. {business.Name} | Доход: {business.Income}$");
            }
        }

        private int GetValidatedIndex(int count)
        {
            var index = _gameUi.GetIndex(count);
            if (index < 0 || index >= count)
            {
                _gameUi.DisplayMessage("Неверный ввод.");
                return -1;
            }

            return index;
        }
    }
}