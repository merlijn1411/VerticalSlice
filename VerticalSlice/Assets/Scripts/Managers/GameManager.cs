using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public void PlayerDied()
	{
		StartCoroutine(YouLost());
	}

	public void EnemyDied()
	{
		StartCoroutine(YouWin());
	}
	
	private IEnumerator YouLost()
	{
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("YouLost");
	}

	private IEnumerator YouWin()
	{
		yield return new WaitForSeconds(6f);
		SceneManager.LoadScene("YouWin");
	}
}