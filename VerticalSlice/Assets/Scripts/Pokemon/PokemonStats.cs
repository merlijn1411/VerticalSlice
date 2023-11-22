using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonStats : MonoBehaviour
{
    public static event Action<int> onDied;

    public static float Health;

    [SerializeField]public float MaxHealth;
    [SerializeField]public float Speed;

    void Start()
    {
        Health = MaxHealth;
        Debug.Log(Health);
    }


    public void TakeDamage(int damageAmount)
    {
        MaxHealth -= damageAmount;
        // other stuff you want to happen when enemy takes damage
        if (Health <= 0)
        {
            Destroy(gameObject);
            onDied?.Invoke(100);
        }
    }
}
