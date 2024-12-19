namespace BusinessManager;

public interface IGameUI
{
	public void DisplayMenu();
	public string GetUserInput();
	public int GetIndex(int maxIndex);
	public void DisplayMessage(string message);
	public void DisplayMessage(string message, ColorMessage colorMessage);
	public void DisplayClear();
}