using UnityEngine;
using UnityEngine.SceneManagement;

public class UiQuit : MonoBehaviour
{

	public void Play()
	{
		SceneManager.LoadScene("SampleScene");
	}
	public void Quit()
	{
		Application.Quit();
	}
}
