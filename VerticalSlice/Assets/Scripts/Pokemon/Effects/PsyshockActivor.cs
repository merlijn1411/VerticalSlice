using System.Collections.Generic;
using UnityEngine;

public class PsyshockActivor : MonoBehaviour
{
	[SerializeField] private Animator playPsyshock;
	[SerializeField] private Animator playPsyshockTake;
	private Animator[] halos;
	
	
    void Start()
    {
	    InitializeParticles();
	    SetHalosList();

    }

    public void InitializeParticles()
    {
	    playPsyshock = GameObject.Find("Psyshock").GetComponent<Animator>();
	    halos = GameObject.Find("Psyshock").GetComponentsInChildren<Animator>();
	    playPsyshockTake = GameObject.Find("PsyshockP2").GetComponentInChildren<Animator>();
    }

    public void SetHalosList()
    {
	    List<Animator> halosList = new List<Animator>(halos);
	    halosList.RemoveAt(0);
	    halos = halosList.ToArray();
    }
    
    public void PlayPsyshockAnim()
    {
	    playPsyshock.SetTrigger("Psyshock");

	    int HL = halos.Length;
	    for (int i = 0; i < HL; i++)
	    {
		    halos[i].SetTrigger("Halos");
	    }
    }
    public void PsyshockAnimtake()
    {
	    playPsyshockTake.SetTrigger("Spheres");
    }
}
