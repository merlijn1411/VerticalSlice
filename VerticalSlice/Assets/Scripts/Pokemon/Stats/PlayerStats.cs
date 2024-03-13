using UnityEngine;

public class PlayerStats : Healthbar
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

	[HideInInspector] public Animator PlayPsyshock;
	[HideInInspector] public Animator[] PlayPsyshockchildrenhalos;

	public void Start()
	{
		Name = PokeName;

		CurrentHealth = MaxHealth;
		STMaxH = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);

		PlayPsyshock = GameObject.Find("Psyshock").GetComponent<Animator>();
		PlayPsyshockchildrenhalos = GameObject.Find("Psyshock").GetComponentsInChildren<Animator>();
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
	public void PlayPsyshockAnim()
	{
		PlayPsyshock.SetTrigger("Psyshock");

		PlayPsyshockchildrenhalos[1].SetTrigger("Halos");
		PlayPsyshockchildrenhalos[2].SetTrigger("Halos");
		PlayPsyshockchildrenhalos[3].SetTrigger("Halos");
		PlayPsyshockchildrenhalos[4].SetTrigger("Halos");
		PlayPsyshockchildrenhalos[5].SetTrigger("Halos");
		PlayPsyshockchildrenhalos[6].SetTrigger("Halos");
		PlayPsyshockchildrenhalos[7].SetTrigger("Halos");
		PlayPsyshockchildrenhalos[8].SetTrigger("Halos");
	}
	private void Defeated()
	{
		gameObject.SetActive(false);
	}
}
