using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStats : MonoBehaviour
{
    public TextMeshProUGUI NameText; 
    private int Health;

    void Start()
    {
        
        PokemonStats health = GetComponent<PokemonStats>();
        if (health != null)
        {
            Health = health.MaxHealth;
        }
    }
    void Update()
    {
        NameText.text = PokemonStats.Name.ToString();
    
    }

}
