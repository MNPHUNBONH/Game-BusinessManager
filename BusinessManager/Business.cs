namespace BusinessManager;

public class Business
{
	public string Name { get;}
	public int Price { get; private set; }
	public int Income { get; private set; }

	public int Level;

	public Business(string name, int price, int income)
	{
		Name = name;
		Price = price;
		Income = income;
	}
	
	public void Upgrade(){}
	public void GetUpgradeCost(){}
	
}