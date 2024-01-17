using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	public static string Name;
	public string PokeName;

	[HideInInspector] public int CurrentHealth;
	public int MaxHealth;
	public Healthbar healthbar;

	public int AttackDamage;

	public ElementType.ElementTypes typeElement;

	void Start()
	{
		Name = PokeName;

		CurrentHealth = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);
	}

	private void Update()
	{
		healthbar.GetComponent<Healthbar>().CurrentHealth(CurrentHealth, healthbar.slider.value);
		if (CurrentHealth <= 0)
		{
			Invoke("Defeated", 3);
		}
	}

	private void Defeated()
	{
		gameObject.SetActive(false);
	}

}
