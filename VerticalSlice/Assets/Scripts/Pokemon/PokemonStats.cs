using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonStats : MonoBehaviour
{
    public static event Action<int> onDied;

    public static string Name;
    public string PokeName;

    public static int CurrentHealth;
    public int MaxHealth;
    public Healthbar healthbar;

    public int Defends;
    public int Attack; 
    public int Speed;

    public void Start()
    {
        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);

        Name = PokeName;
    }


    public void TakeDamage(int damageAmount)
    {
        MaxHealth -= damageAmount;
        healthbar.SetHealth(MaxHealth);
        // other stuff you want to happen when enemy takes damage
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            onDied?.Invoke(100);
        }
    }
}
