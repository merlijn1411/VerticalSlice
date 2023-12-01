using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightButton : MonoBehaviour
{
    public GameObject ButtonStart;
    public GameObject ButtonAttack;
    void Start()
    {
        ButtonAttack.SetActive(false);
    }

    // Update is called once per frame
    public void Battle()
    {
        ButtonStart.SetActive(false);
        ButtonAttack.SetActive(true);
        Debug.Log("vecht mij");
    }
}
