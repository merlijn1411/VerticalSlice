using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PsyshockAttack : MonoBehaviour
{
	[Header("Attributes")]
	[SerializeField] private PokemonStats target;
	[SerializeField] private Healthbar targetHealthbar;
	
	private PokemonStats pokemonStats;
	private DamageFormula Formula;
	
	[Header("PshyshockParticles")]
	public UnityEvent psyshockActivate,psyshocTake;

	public UnityEvent onAttackGiven;
	
	private void Start()
	{
		pokemonStats = GetComponent<PokemonStats>();
		Formula = GetComponent<DamageFormula>();
	}
	
	public void StartPsyshock()
	{
		StartCoroutine(DoPsyshock());
	}
	private IEnumerator DoPsyshock()
    {
    	yield return new WaitForSeconds(2.5f);
	    
	    psyshockActivate.Invoke();
    	yield return new WaitForSeconds(1f);
	    
	    psyshocTake.Invoke();

	    yield return new WaitForSeconds(2f);
	    
	    onAttackGiven.Invoke();
    	target.currentHealth -= Formula.CalculateDamage(pokemonStats.attackDamage, pokemonStats.typeElement);
    	targetHealthbar.time = 0f;
    	
    	yield return new WaitForSeconds(3f);
    }
}
