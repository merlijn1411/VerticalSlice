using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("BattleScene");
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Start");
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
	
}
