using System.Collections;
using UnityEngine;

public class PokemonAnimations : MonoBehaviour
{
	private Animator PokemonAnimator;

	private void Start()
	{
		PokemonAnimator = GetComponent<Animator>();
	}

	public void Attack()
	{
		PokemonAnimator.SetTrigger("Attack");
	}
	
	public void GetsHit()
	{
		PokemonAnimator.SetTrigger("Hurt");
	}
	
	public void StartDie()
	{
		StartCoroutine(Die());
	}

	private IEnumerator Die()
	{
		yield return new WaitForSeconds(4f);
		PokemonAnimator.SetTrigger("Die");
	}
	
}
