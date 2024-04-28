using System;
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

	public int CalculateDamage(float PokemonDamage, ElementType.ElementTypes elementType)
	{
		float randDmg = Random.Range(81f, 100f) / 100;
		
		int atkDef = target.attackDamage / target.defends;
		PokemonDamage = ((2 * pokemon.level / 5 + 2) * pokemon.attackDamage * atkDef / 50 + 2) * 1f * 1.5f * randDmg * 1.5f;
		
		AddElement(elementType, PokemonDamage);

		return Mathf.RoundToInt(PokemonDamage);
	}

	private void AddElement(ElementType.ElementTypes elementTypes, float pokemonDamage)
	{
		switch (elementTypes)
		{
			case ElementType.ElementTypes.Physic:
				pokemonDamage = pokemonDamage * ElementType.physicPower;
				break;
			case ElementType.ElementTypes.Ghost:
				pokemonDamage = pokemonDamage * ElementType.ghostPower;
				break;
			case ElementType.ElementTypes.Grass:
				pokemonDamage = pokemonDamage * ElementType.grassPower;
				break;
		}
	}
}
