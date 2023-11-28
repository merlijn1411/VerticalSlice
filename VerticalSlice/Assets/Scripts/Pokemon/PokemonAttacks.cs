using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PokemonAttacks : MonoBehaviour
{
    public void UseMove()
    {
        var TakeAttackVar = GetComponent<PokemonStats>();
        var damage = TakeAttackVar.Attack;
        GetComponent<PokemonStats>().TakeDamage(damage);
    }
}
