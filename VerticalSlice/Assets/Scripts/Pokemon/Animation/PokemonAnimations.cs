using System;
using UnityEngine;

public class PokemonAnimations : MonoBehaviour
{
	[SerializeField] private Animator phanAnim;
	[SerializeField] private Animator reuAnim;
	
	public void PlayerAttack()
	{
		reuAnim.SetTrigger("Attack");
	}
	
	public void EnemyAttack()
	{
		phanAnim.SetTrigger("Attack");
	}
	
	public void PlayerGetsHit()
	{
		reuAnim.SetTrigger("Hurt");
	}
	
	public void EnemyGetsHit()
	{
		phanAnim.SetTrigger("Hurt");
	}
	
	public void Playerdie()
	{
		reuAnim.SetTrigger("Die");
	}
	public void Enemydie()
	{
		phanAnim.SetTrigger("Die");
	}
}
