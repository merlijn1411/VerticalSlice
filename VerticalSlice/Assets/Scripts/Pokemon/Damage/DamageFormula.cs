using UnityEngine;

public class DamageFormula : MonoBehaviour
{
	[Header("Attributes")]
	[SerializeField] private PokemonStats player;
	[SerializeField] private PokemonStats enemy;

	[SerializeField] private TurnBaseManager turnBaseManager;
	
	[Header("Elemental Power")]
	[SerializeField] private float PhysicPower;
	[SerializeField] private float GhostPower;
	[SerializeField] private float GrassPower;
	
	public int CalculateDamage(float damage, ElementType.ElementTypes elementType)
	{
		float randDmg = Random.Range(81f, 100f) / 100;
		if (turnBaseManager!.isplayerTurn)
		{
			int atkDef = enemy.attackDamage / enemy.defends;
			damage = ((2 * player.level / 5 + 2) * player.attackDamage * atkDef / 50 + 2) * 1f * 1.5f * randDmg * 1.5f;
		}
		else
		{
			int atkDef = player.attackDamage / player.defends;
			damage = ((2 * enemy.level / 5 + 2) * enemy.attackDamage * atkDef / 50 + 2) * 1f * 1.5f * randDmg * 1.5f;
		}
		float PokemonDamage = damage;

		switch (elementType)
		{
			case ElementType.ElementTypes.Physic:
				PokemonDamage = damage * PhysicPower;
				break;
			case ElementType.ElementTypes.Ghost:
				PokemonDamage = damage * GhostPower;
				break;
			case ElementType.ElementTypes.Grass:
				PokemonDamage = damage * GrassPower;
				break;
		}
		return Mathf.RoundToInt(PokemonDamage);
	}
}
