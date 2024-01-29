using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
	[SerializeField] private EnemyStats enemy;
	[SerializeField] private PlayerStats player;

	private void Update()
	{
		if (player.CurrentHealth <= 0)
		{
			Debug.Log("You lost");
			SceneManager.LoadScene("You Lost");
		}
		if (enemy.CurrentHealth <= 0)
		{
			Debug.Log("You won");
			SceneManager.LoadScene("You Win");
		}
	}
}
