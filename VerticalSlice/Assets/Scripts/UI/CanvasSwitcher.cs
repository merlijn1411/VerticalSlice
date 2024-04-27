using System.Collections;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
	[SerializeField] private GameObject NonDiegetic;
	[SerializeField] private GameObject CanvasStart;
	[SerializeField] private GameObject CanvasAttack;

	public void StartOff()
	{
		StartCoroutine(TurnOffCanvas());
	}
	
	public IEnumerator TurnOffCanvas()
	{
		yield return new WaitForSeconds(0.2f);
		CanvasStart.SetActive(false);
		CanvasAttack.SetActive(false);
	}
	
	public void ResetCS()
	{
		CanvasStart.SetActive(true);
		CanvasAttack.SetActive(false);
	}
}
