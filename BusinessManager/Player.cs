namespace BusinessManager;

public class Player
{
	public string Name { get; }
	public int Money { get; private set; }
	
	public List<Business> Businesses { get; private set;}

	public Player(string name, int startBalanse)
	{
		Name = name;
		Money = startBalanse;
		Businesses = new List<Business>(){new Business("Ларек",1000,100)};
	}

	public bool BuyBusiness(Business business)
	{
		if (Money > business.Price)
		{
			Money -= business.Price;
			Businesses.Add(business);
			return true;
		}
		else
		{
			Console.WriteLine("Недостаточно средств для покупки!");
			return false;
		}
		
	}
	

	public void UpgradeBusiness(int index){}
	public void CollectIncome(){}
	
}