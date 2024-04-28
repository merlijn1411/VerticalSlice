using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PsyshockAttack : MonoBehaviour
{
	[Header("Attributes")]
	[SerializeField] private PokemonStats pokemonStats;
	[SerializeField] private PokemonStats target;
	[SerializeField] private Healthbar targetHealthbar;
	
	private DamageFormula Formula;
	
	[Header("PshyshockParticles")]
	public UnityEvent psyshockActivate,psyshocTake;
	public UnityEvent onMovePlayerChosen;
	
	private void Start()
	{
		Formula = GetComponent<DamageFormula>();
	}
	
	public void StartPsyshock()
	{
		StartCoroutine(DoPsyshock());
	}
	public IEnumerator DoPsyshock()
    	{
    		yield return new WaitForSeconds(2.5f);
		    
    		onMovePlayerChosen.Invoke();
		    psyshockActivate.Invoke();
    		yield return new WaitForSeconds(1.5f);
		    
		    psyshocTake.Invoke();

		    yield return new WaitForSeconds(2f);
    		target.currentHealth -= Formula.CalculateDamage(pokemonStats.attackDamage, pokemonStats.typeElement);
    		targetHealthbar.time = 0f;
    		
    		yield return new WaitForSeconds(3f);
    	}
}
