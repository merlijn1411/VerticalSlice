using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DefaultAttack : MonoBehaviour
{
	[Header("Attributes")]
	[SerializeField] private PokemonStats pokemonStats;
	[SerializeField] private PokemonStats target;
	
	[SerializeField] private Healthbar targetHealthbar;
	
	private DamageFormula Formula;
	
	[Header("Player Particles")]
	[SerializeField] private ParticleSystem Attack;
	[SerializeField] private ParticleSystem TakeAttack;
	
	public UnityEvent onMovePlayerChosen;
	

	private void Start()
	{
		Formula = GetComponent<DamageFormula>();
	}

	public void StartTackle()
	{
		StartCoroutine(DoTackle());
	}
	
	public IEnumerator DoTackle()
	{
		yield return new WaitForSeconds(3f);
		onMovePlayerChosen.Invoke();
		Attack.Play();
		yield return new WaitForSeconds(2f);
		
		target.currentHealth -= Formula.CalculateDamage(pokemonStats.attackDamage, pokemonStats.typeElement);
		targetHealthbar.time = 0f;
		
		yield return new WaitForSeconds(3f);
	}
}
