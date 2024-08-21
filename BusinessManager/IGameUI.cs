namespace BusinessManager;

public interface IGameUI
{
	public void DisplayMenu();
	public string GetUserInput();
	public string GetBusinessName();
	public double GetBusinessIncome();
	public double GetBusinessUpgradeCost();
	public int GetBusinessIndex(int maxIndex);
	public string GetUpgradeName();
	public double GetUpgradeCost();
	public double GetIncomeMultiplier();
	public void DisplayMessege(string message);
}