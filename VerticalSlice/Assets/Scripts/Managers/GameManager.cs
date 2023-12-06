using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PlayerStats Player = null;
	[SerializeField] private EnemyStats Enemy = null;

	public void Update()
	{
		if (Player.CurrentHealth <= 0)
		{
			PlayerDied();
		}

		if (Enemy.CurrentHealth <= 0)
		{
			EnemyDied();
		}
	}
	private void PlayerDied()
	{
		Debug.Log("You Lose!");
	}

	public void EnemyDied()
	{
		Debug.Log("You Win!");
	}
}
