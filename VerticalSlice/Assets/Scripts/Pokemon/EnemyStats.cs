using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static string Name;
    public string PokeName;

    private int CurrentHealth;
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
        }
    }
}
