namespace BusinessManager;

public interface IGameUI
{
	public void DisplayMenu();
	public string GetUserInput();
	public void ShowInformationAboutPlayer(Player player);
	public string GetBusinessName(Business business);
	public double GetBusinessCost(Business business);
	public double GetBusinessIncome(Business business);
	public int GetIndex(int maxIndex);
	public string GetUpgradeName(Upgrade upgrade);
	public double GetUpgradeCost(Upgrade upgrade);
	public double GetIncomeMultiplier(Upgrade upgrade);
	public void DisplayMessege(string message);
	public void DisplayClear();
}