using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private PlayerStats Player;
	private EnemyStats Enemy;

	void Start()
	{
		Player = GameObject.Find("Reuniclus").GetComponent<PlayerStats>();
		Enemy = GameObject.Find("Phantump").GetComponent<EnemyStats>();
	}
	public void Update()
	{
		if (Player.CurrentHealth <= 0)
		{
			StartCoroutine(PlayerDied());
		}

		if (Enemy.CurrentHealth <= 0)
		{
			StartCoroutine(EnemyDied());
		}
	}
	private IEnumerator PlayerDied()
	{
		Debug.Log("You Lose!");
		yield return new WaitForSeconds(5.5f);
		SceneManager.LoadScene("YouLose");
	}

	public IEnumerator EnemyDied()
	{
		Debug.Log("You Win!");
		yield return new WaitForSeconds(5.5f);
		SceneManager.LoadScene("YouWin");
	}
}