namespace BusinessManager;

public class Player
{
	public string Name { get; }
	public int Money { get; private set; }
	
	private List<Business> Businesses;

	public Player(string name, int startBalanse)
	{
		Name = name;
		Money = startBalanse;
	}

	public void BuyBusiness(Business business)
	{
		Businesses.Add(business);
	}

	public void UpgradeBusiness(int index){}
	public void CollectIncome(){}
	
}