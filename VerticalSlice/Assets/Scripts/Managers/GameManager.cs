using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Update()
    {
        if(PokemonStats.CurrentHealth <= 0)
        {
            Debug.Log("you lose");
        }
    }
}
