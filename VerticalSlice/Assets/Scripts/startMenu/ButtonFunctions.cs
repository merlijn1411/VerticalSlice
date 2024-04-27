using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("BattleScene");
	}
	
	public void QuirGame()
	{
		Application.Quit();
	}
	
}
