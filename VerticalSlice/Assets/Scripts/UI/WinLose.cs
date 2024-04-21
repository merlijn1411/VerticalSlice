using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
	[SerializeField] private PokemonStats enemy;
	[SerializeField] private PokemonStats player;

	private void Update()
	{
		if (player.currentHealth <= 0)
		{
			Debug.Log("You lost");
			SceneManager.LoadScene("You Lost");
		}
		if (enemy.currentHealth <= 0)
		{
			Debug.Log("You won");
			SceneManager.LoadScene("You Win");
		}
	}
}
