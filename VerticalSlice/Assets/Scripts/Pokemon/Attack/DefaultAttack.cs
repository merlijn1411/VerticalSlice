using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DefaultAttack : MonoBehaviour
{
	[Header("Attributes")]
	[SerializeField] private PokemonStats target;
	[SerializeField] private Healthbar targetHealthbar;
	
	private PokemonStats pokemonStats;
	private DamageFormula Formula;
	
	[Header("Player Particles")]
	[SerializeField] private ParticleSystem Attack;
	[SerializeField] private ParticleSystem AttackGiven;
	
	public UnityEvent onMovePlayerChosen;
	public UnityEvent onAttackGiven;
	private void Start()
	{
		pokemonStats = GetComponent<PokemonStats>();
		Formula = GetComponent<DamageFormula>();
	}

	public void StartTackle()
	{
		StartCoroutine(DoTackle());
	}
	
	private IEnumerator DoTackle()
	{
		yield return new WaitForSeconds(3f);
		
		onMovePlayerChosen.Invoke();
		Attack.Play();
		
		yield return new WaitForSeconds(2f);
		
		onAttackGiven.Invoke();
		target.currentHealth -= Formula.CalculateDamage(pokemonStats.attackDamage, pokemonStats.typeElement);
		targetHealthbar.time = 0f;
		
		yield return new WaitForSeconds(3f);
	}
}
