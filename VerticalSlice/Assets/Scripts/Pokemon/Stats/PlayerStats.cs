using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	//public static event Action<int> onDied;

	public static string Name;
	public string PokeName;

	[HideInInspector] public int CurrentHealth;
	public int MaxHealth;
	public Healthbar healthbar;

	public static int STCurrentH;
	public static int STMaxH;

	public int level;
	public int Defends;
	public int AttackDamage;
	public int Speed;

	public ElementType.ElementTypes typeElement;

	public void Start()
	{
		Name = PokeName;

		CurrentHealth = MaxHealth;
		STMaxH = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);

	}
	private void Update()
	{
		STCurrentH = CurrentHealth;
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
