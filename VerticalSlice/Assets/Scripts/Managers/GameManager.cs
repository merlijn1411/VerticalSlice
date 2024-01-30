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
		yield return new WaitForSeconds(5.5f);
		SceneManager.LoadScene("YouLose");
	}

	public IEnumerator EnemyDied()
	{
		yield return new WaitForSeconds(5.5f);
		SceneManager.LoadScene("YouWin");
	}
}