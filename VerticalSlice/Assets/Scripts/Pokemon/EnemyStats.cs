using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	public static string Name;
	public string PokeName;

	public int CurrentHealth;
	public int MaxHealth;
	public Healthbar healthbar;

	public int AttackDamage;


	void Start()
	{
		Name = PokeName;

		CurrentHealth = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);
	}

	private void Update()
	{
		healthbar.SetHealth(CurrentHealth);
		if (CurrentHealth <= 0)
		{
			Debug.Log("Enemy verslagen");
		}
	}
}
