using System;
using UnityEngine;

public class PokemonStats : MonoBehaviour
{
	public static event Action<int> onDied;

	public static string Name;
	public string PokeName;

	private int CurrentHealth;
	public int MaxHealth;
	public Healthbar healthbar;

	public int Defends;
	public int AttackDamage;
	public int Speed;

	public void Start()
	{
		CurrentHealth = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);

		Name = PokeName;
	}


	public void TakeDamage(int damageAmount)
	{
		CurrentHealth -= damageAmount;
		healthbar.SetHealth(CurrentHealth);
		// other stuff you want to happen when enemy takes damage
		if (CurrentHealth <= 0)
		{
			Destroy(gameObject);
			onDied?.Invoke(100);
		}
	}
}
