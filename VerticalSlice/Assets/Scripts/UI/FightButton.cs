using UnityEngine;

public class FightButton : MonoBehaviour
{
	public GameObject ButtonStart;
	public GameObject ButtonAttack;
	void Start()
	{
		ButtonAttack.SetActive(false);
	}

	public void Battle()
	{
		ButtonStart.SetActive(false);
		ButtonAttack.SetActive(true);
		Debug.Log("vecht mij");
	}
}
