namespace BusinessManager;

public class Business
{
	public string Name { get; private set; } 
	public int Price { get; private set; }
	public int Income { get; private set; }
	public List<Upgrade> Upgrades { get;  set; }

	public Business(string name, int price, int income)
	{
		Name = name;
		Price = price;
		Income = income;
		Upgrades = new List<Upgrade>();
	}

	public void Upgrade(int index)
	{
		Income += Upgrades[index].IncomeMultiplier;
		Upgrades.RemoveAt(index);
	} 
}