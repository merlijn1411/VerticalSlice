using System.Collections.Generic;
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

	[HideInInspector] public Animator PlayPsyshock;
	[HideInInspector] public Animator[] halos;

	public void Start()
	{
		Name = PokeName;

		CurrentHealth = MaxHealth;
		STMaxH = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);

		PlayPsyshock = GameObject.Find("Psyshock").GetComponent<Animator>();
		halos = GameObject.Find("Psyshock").GetComponentsInChildren<Animator>();

		List<Animator> halosList = new List<Animator>(halos);
		halosList.RemoveAt(0);
		halos = halosList.ToArray();
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

		for (int i = 0; i < halos.Length; i++)
		{
			halos[i].SetTrigger("Halos");
		}
	}
	private void Defeated()
	{
		gameObject.SetActive(false);
	}
}
