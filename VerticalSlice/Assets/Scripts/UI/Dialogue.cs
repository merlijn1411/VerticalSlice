using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
	static public event Action OnFinishedDialogue;

	public TextMeshProUGUI textComponent;
	private float textspeed;

	private int index;
	public GameObject Playing;

	//public Button Attackbtn1, Attackbtn2, Attackbtn3, Attackbtn4;
	public Button[] AttackBtn;

	public string[] buttonTexts;

	public TextPanelAnimation textPanel;

	public void Start()
	{
		Playing.SetActive(true);
		textspeed = 2 * Time.deltaTime;

		EndPanelAnimation.OnPanelAnimationEndEvent += PlayText;

		index = 0;

		for (int i = index; i < AttackBtn.Length; i++)
		{
			int Buttonvalue = i;
			AttackBtn[i].onClick.AddListener(() => ButtonChooser(Buttonvalue));
		}

	}

	public void PlayText()
	{
		if (textComponent.text != buttonTexts[index])
		{
			//Debug.LogError(textComponent.text + " is not the same a the" + buttonTexts[index]);

		}
		else
		{
			StopAllCoroutines();
			//StartCoroutine(TypeLine());
			textComponent.text = buttonTexts[index];
			index = 0;
		}
	}

	IEnumerator TypeLine(int buttonIndex)
	{

		Debug.Log(buttonIndex + " xeddw");
		foreach (char C in buttonIndex[index].ToCharArray())
		{
			textComponent.text += C;
			yield return new WaitForSeconds(textspeed);
		}
		yield return new WaitForSeconds(3f);

		TextPanelAnimation textPanelAnimation = textPanel.GetComponent<TextPanelAnimation>();
		textPanelAnimation.GetComponent<TextPanelAnimation>().PanelDissapear();
	}

	void NextLine()
	{
		if (index < buttonTexts.Length - 1)
		{
			index++;
			//StartCoroutine(TypeLine());
		}
		else
		{
			OnFinishedDialogue?.Invoke();
			index = 0;
		}
	}

	public void ButtonChooser(int buttonIndex)
	{

		if (buttonIndex == 0)
		{
			StartCoroutine(TypeLine(buttonIndex));
		}
		if (buttonIndex == 1)
		{
			StartCoroutine(TypeLine(buttonIndex));
		}
		if (buttonIndex == 2)
		{
			StartCoroutine(TypeLine(buttonIndex));
		}
		if (buttonIndex == 3)
		{
			StartCoroutine(TypeLine(buttonIndex));
		}
	}
}

