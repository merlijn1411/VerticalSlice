using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PokemonHealth : MonoBehaviour
{
	private PokemonStats pokemonStats;
	[SerializeField] private Healthbar healthbar;
	
	public UnityEvent isHealthZero;
	private void Start()
	{
		pokemonStats = GetComponent<PokemonStats>();
		
		pokemonStats.currentHealth = pokemonStats.maxHealth;
		healthbar.SetMaxHealth(pokemonStats.maxHealth);
	}
	
	private void Update()
	{
		InitializeHealth();
		HealthChecker();
		MinAndMaxValue();
	}
	
	private void HealthChecker()
	{
		if (pokemonStats.currentHealth <= 0)
		{
			isHealthZero.Invoke();
			StartCoroutine(IsDead());
		}
			
	}

	private void InitializeHealth()
	{
		healthbar.CurrentHealth(pokemonStats.currentHealth, healthbar.slider.value);
	}

	private void MinAndMaxValue()
	{
		pokemonStats.currentHealth = Mathf.Clamp(pokemonStats.currentHealth, 0, pokemonStats.maxHealth);
	}
	
	private IEnumerator IsDead()
	{
		yield return new WaitForSeconds(5.2f);
		gameObject.SetActive(false);
	}
   
}
