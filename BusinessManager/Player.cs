namespace BusinessManager;

public class Player
{
	public event Action<string,ColorMessage> OnBalanceChanged;
	public string Name { get; }
	public int Money { get; private set; }
	public int Income { get; private set; }
	public List<Business> Businesses { get; private set;}
	public Player(string name, int startBalanсe)
	{
		Name = name;
		Money = startBalanсe;
		Businesses = new List<Business>();
	}

	public void BuyBusiness(Business business)
	{
			Money -= business.Price;
			OnBalanceChanged($"Ваш баланс изменился: {Money}",ColorMessage.Red);
			Businesses.Add(business);
			OnBalanceChanged($"Вы приобрели новый бизнес: {business.Name}", ColorMessage.Green);
	}

	public void UpgradeBusiness(Business business, int indexGrade)
	{
		Money -= business.Upgrades[indexGrade].Cost;
		OnBalanceChanged($"Ваш баланс изменился: {Money}",ColorMessage.Red);
		business.Upgrade(indexGrade);
	}
	public void CollectIncome()
	{
		foreach (var business in Businesses) Income += business.Income;
	}

	public void GetIncome()
	{
		Money += Income;
		OnBalanceChanged($"Ваш баланс изменился: {Money}",ColorMessage.Red);
		Income = 0;
	} 
}