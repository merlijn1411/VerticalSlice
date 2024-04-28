using UnityEngine;
using Random = UnityEngine.Random;

public class DamageFormula : MonoBehaviour
{
	[Header("Attributes")]
	private PokemonStats pokemon;
	[SerializeField] private PokemonStats target;

	private void Start()
	{
		pokemon = GetComponent<PokemonStats>();
	}

	public int CalculateDamage(float pokemonDamage, ElementType.ElementTypes elementType)
	{
		float randDmg = Random.Range(81f, 100f) / 100;
		
		int atkDef = target.attackDamage / target.defends;
		pokemonDamage = ((2 * pokemon.level / 5 + 2) * pokemon.attackDamage * atkDef / 50 + 2) * 1f * 1.5f * randDmg * 1.5f;
		
		AddElement(elementType, pokemonDamage);

		return Mathf.RoundToInt(pokemonDamage);
	}

	private void AddElement(ElementType.ElementTypes elementTypes, float pokemonDamage)
	{
		switch (elementTypes)
		{
			case ElementType.ElementTypes.Physic:
				pokemonDamage *= ElementType.physicPower;
				break;
			case ElementType.ElementTypes.Ghost:
				pokemonDamage *= ElementType.ghostPower;
				break;
			case ElementType.ElementTypes.Grass:
				pokemonDamage *= ElementType.grassPower;
				break;
		}
	}
}
