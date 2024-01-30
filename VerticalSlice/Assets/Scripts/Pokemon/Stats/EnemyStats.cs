using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	public static string Name;
	public string PokeName;

	[HideInInspector] public int CurrentHealth;
	public int MaxHealth;
	public Healthbar healthbar;

	public int level;
	public int Defends;
	public int AttackDamage;
	public int Speed;

	public ElementType.ElementTypes typeElement;

	[HideInInspector] public Animator PlayPsyshockTake;

	void Start()
	{
		Name = PokeName;

		CurrentHealth = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);

		PlayPsyshockTake = GameObject.Find("PsyshockP2").GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		healthbar.GetComponent<Healthbar>().CurrentHealth(CurrentHealth, healthbar.slider.value);

		if (CurrentHealth <= 0)
		{
			Invoke("Defeated", 4.5f);
		}
	}
	public void PsyshockAnimtake()
	{
		PlayPsyshockTake.SetTrigger("Spheres");
	}

	private void Defeated()
	{
		gameObject.SetActive(false);
	}
}
