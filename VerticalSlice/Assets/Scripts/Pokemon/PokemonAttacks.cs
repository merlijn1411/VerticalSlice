using UnityEngine;

public class PokemonAttacks : MonoBehaviour
{
	[SerializeField] private EnemyStats opponenetHP;
	public void UseMove()
	{
		var TakeAttackVar = GetComponent<PokemonStats>();
		var damage = TakeAttackVar.AttackDamage;
		if (opponenetHP != null)
		{
			opponenetHP.TakeDamage(damage);
		}

	}
}
