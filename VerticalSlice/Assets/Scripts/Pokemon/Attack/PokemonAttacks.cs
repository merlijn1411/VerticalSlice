using System;
using System.Collections;
using UnityEngine;

public class PokemonAttacks : MonoBehaviour
{
	[SerializeField] private PokemonStats pokemonStats;
	[SerializeField] private PokemonStats target;
	
	[SerializeField] private Healthbar targetHealthbar;

	private DamageFormula Formula;

	private void Start()
	{
		Formula = GameObject.FindWithTag("Manager").GetComponent<DamageFormula>();
	}

	public void StartAttack()
	{
		StartCoroutine(AttackMove());
	}
	
	public IEnumerator AttackMove()
	{
		yield return new WaitForSeconds(1.75f);
		
		target.currentHealth -= Formula.CalculateDamage(pokemonStats.attackDamage, pokemonStats.typeElement);
		targetHealthbar.time = 0f;
		
		yield return new WaitForSeconds(3f);
	}
}
