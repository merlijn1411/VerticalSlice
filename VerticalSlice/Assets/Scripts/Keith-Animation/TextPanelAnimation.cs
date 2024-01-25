using System.Collections;
using UnityEngine;

public class TextPanelAnimation : MonoBehaviour
{
	[SerializeField] Dialogue dialogue;
	[SerializeField] Animator Play;

	void Start()
	{
		Play = GetComponent<Animator>();
		//Dialogue.OnFinishedDialogue += PanelDissapear;
	}
	public void PanelAnimate()
	{
		Play.SetTrigger("Appear");
		StartCoroutine(PanelDissapear());
	}

	public IEnumerator PanelDissapear()
	{
		yield return new WaitForSeconds(4f);
		Play.SetTrigger("Disapear");
	}
}
