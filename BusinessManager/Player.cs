namespace BusinessManager;

public class Player
{
	public event EventHandler even;
	public string Name { get; }
	public int Money { get; private set; }
	public int Income { get; private set; }
	public List<Business> Businesses { get; private set;}
	public Player(string name, int startBalanse)
	{
		Name = name;
		Money = startBalanse;
		Businesses = new List<Business>(){new Business("Ларек",1000,100)};
		Businesses[0].Upgrades.Add(new Upgrade("Расширение ассортимента", 100,50));
	}

	public void BuyBusiness(Business business)
	{
			Money -= business.Price;
			Businesses.Add(business);
	}

	public void UpgradeBusiness(Business business, int indexGrade)
	{
		Money -= business.Upgrades[indexGrade].Cost;
		business.Upgrade(indexGrade);
	}
	public void CollectIncome()
	{
		foreach (var business in Businesses) Income += business.Income;
	}

	public void GetIncome()
	{
		Money += Income;
		Income = 0;
	} 
}