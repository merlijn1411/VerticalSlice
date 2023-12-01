using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour
{
    public static event Action Ondied;

    public static string Name;
    public string PokeName;

    public static int CurrentHealth;
    public int MaxHealth;
    public Healthbar healthbar;
    void Start()
    {
        Name = PokeName;

        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }


    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        healthbar.SetHealth(CurrentHealth);
        // other stuff you want to happen when enemy takes damage
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Ondied?.Invoke();
        }
    }
}
