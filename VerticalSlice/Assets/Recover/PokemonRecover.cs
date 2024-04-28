using System;
using System.Collections;
using UnityEngine;

public class PokemonRecover : MonoBehaviour
{
	[SerializeField] private Healthbar playerhealthbar;
	[SerializeField] private ParticleSystem recoverParticles;
	
	private PokemonStats pokemonStats;

	private void Start()
	{
		pokemonStats = GetComponent<PokemonStats>();
	}

	public void StartRecover()
	{
		StartCoroutine(Recover());
	}
	private IEnumerator Recover()
	{
		yield return new WaitForSeconds(3);
		
		if (pokemonStats.currentHealth <= pokemonStats.maxHealth)
		{
			recoverParticles.Play();
			yield return new WaitForSeconds(2.4f);

			pokemonStats.currentHealth += (pokemonStats.currentHealth / 2) + 20;

			playerhealthbar.time = 0f;
		}
		
	}
}
