using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PokemonStats : MonoBehaviour
{
	public string PokeName;
	
	[SerializeField] private Healthbar healthbar;
	
	public int maxHealth = 110;
	public int currentHealth;

	public int level;
	public int defends;
	public int attackDamage;

	public ElementType.ElementTypes typeElement;
	
	public UnityEvent isHealthZero;
	

	public void Start()
	{
		currentHealth = maxHealth;
		healthbar.SetMaxHealth(maxHealth);
		
	}
	private void Update()
	{
		Initializehealth();

		HealthChecker();
	}

	private void Initializehealth()
	{
		healthbar.GetComponent<Healthbar>().CurrentHealth(currentHealth, healthbar.slider.value);
	}

	private void HealthChecker()
	{
		if (currentHealth <= 0)
		{
			isHealthZero.Invoke();
		}
	}
}
