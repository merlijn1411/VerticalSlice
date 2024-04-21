using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PokemonStats Pokemon;
	[SerializeField] private PokemonStats Enemy;
	
	public void Update()
	{
		if (Pokemon.currentHealth <= 0)
		{
			StartCoroutine(PlayerDied());
		}

		if (Enemy.currentHealth <= 0)
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