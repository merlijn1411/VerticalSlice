using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonDamage : MonoBehaviour
{

    [SerializeField] private int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UseMove()
    {
        PokemonStats stat = FindAnyObjectByType<PokemonStats>();

        GetComponent<PokemonStats>().TakeDamage(5);
    }
}
