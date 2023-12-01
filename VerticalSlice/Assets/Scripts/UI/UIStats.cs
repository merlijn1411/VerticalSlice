using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStats : MonoBehaviour
{
    public TextMeshProUGUI PlayerNameText, EnemyNameText ; 

    void Start()
    {
        
    }
    void Update()
    {

        if(PlayerNameText != null || EnemyNameText != null)
        {
            PlayerNameText.text = PokemonStats.Name.ToString();
            EnemyNameText.text = EnemyStats.Name.ToString();
        }
    }

}
