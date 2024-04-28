using UnityEngine;
using UnityEngine.Events;

public class PokemonHealth : MonoBehaviour
{
	[SerializeField] private PokemonStats pokemonStats;
	[SerializeField] private Healthbar healthbar;
	
	public UnityEvent isHealthZero;
	private void Start()
	{
		pokemonStats.currentHealth = pokemonStats.maxHealth;
		healthbar.SetMaxHealth(pokemonStats.maxHealth);
	}
	
	private void Update()
	{
		Initializehealth();

		HealthChecker();
	}
	
	private void HealthChecker()
	{
		if (pokemonStats.currentHealth <= 0)
			isHealthZero.Invoke();
		
	}

	private void Initializehealth()
	{
		healthbar.GetComponent<Healthbar>().CurrentHealth(pokemonStats.currentHealth, healthbar.slider.value);
	}
	
	private void OnValidate()
	{
		if (pokemonStats.currentHealth <= 0)
			pokemonStats.currentHealth = 0;
	}
   
}
