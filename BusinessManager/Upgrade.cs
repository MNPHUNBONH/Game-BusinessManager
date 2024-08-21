namespace BusinessManager;

public class Upgrade
{
	private string Name;
	private int Cost;
	private int IncomeMultiplier;

	public Upgrade(string name, int cost, int incomeMultiplier)
	{
		Name = name;
		Cost = cost;
		IncomeMultiplier = incomeMultiplier;
	}
	
	public void Apply(Business business){}
}