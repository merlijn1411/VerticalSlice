using UnityEngine;

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
