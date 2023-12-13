using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	public static string Name;
	public string PokeName;

	[HideInInspector] public int CurrentHealth;
	public int MaxHealth;
	public Healthbar healthbar;

	private MeshRenderer meshRenderer;
	Color originColor;

	public int AttackDamage;

	public TurnBaseManager.ElementType typeElement;

	void Start()
	{
		Name = PokeName;

		CurrentHealth = MaxHealth;
		healthbar.SetMaxHealth(MaxHealth);

		meshRenderer = GetComponent<MeshRenderer>();
		originColor = meshRenderer.material.color;
	}

	private void Update()
	{
		healthbar.GetComponent<Healthbar>().CurrentHealth(CurrentHealth, healthbar.slider.value);
		if (CurrentHealth <= 0)
		{
			Invoke("Defeated", 3);
		}
	}

	public void HitStart()
	{
		Debug.Log("ik ben bij de functie :)");
		meshRenderer.material.color = Color.red;
		Invoke("HitStop", 1);
	}
	public void HitStop()
	{
		Debug.Log("poef");
		meshRenderer.material.color = originColor;
	}

	private void Defeated()
	{
		gameObject.SetActive(false);
	}

}
