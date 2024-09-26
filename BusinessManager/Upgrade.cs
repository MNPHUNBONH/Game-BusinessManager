namespace BusinessManager;

public class Upgrade
{
	public string Name { get; private set; }
	public int Cost { get; private set; }
	public int IncomeMultiplier { get; private set; }

	public Upgrade(string name, int cost, int incomeMultiplier)
	{
		Name = name;
		Cost = cost;
		IncomeMultiplier = incomeMultiplier;
	}
}