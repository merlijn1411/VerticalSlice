using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	//public static event Action<int> onDied;

	public static string Name;
	public string PokeName;

	public int CurrentHealth;
	public int MaxHealth;
	public Healthbar healthbar;

	public int Defends;
	public int AttackDamage;
	public int Speed;

	public TurnBaseManager.ElementType typeElement;

	public void Start()
	{
		CurrentHealth = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);

		Name = PokeName;
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
