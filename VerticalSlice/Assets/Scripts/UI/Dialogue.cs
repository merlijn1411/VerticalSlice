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

	public Button Attackbtn1, Attackbtn2, Attackbtn3, Attackbtn4;

	public string[] buttonTexts;

	public TextPanelAnimation textPanel;

	public void Start()
	{
		Playing.SetActive(true);
		textspeed = 2 * Time.deltaTime;

		EndPanelAnimation.OnPanelAnimationEndEvent += PlayText;


		index = 0;

		Button btn1 = Attackbtn1.GetComponent<Button>();
		btn1.onClick.AddListener(delegate { ButtonChooser(0); });

		Button btn2 = Attackbtn2.GetComponent<Button>();
		btn2.onClick.AddListener(delegate { ButtonChooser(1); });

		Button btn3 = Attackbtn3.GetComponent<Button>();
		btn3.onClick.AddListener(delegate { ButtonChooser(2); });

		Button btn4 = Attackbtn4.GetComponent<Button>();
		btn4.onClick.AddListener(delegate { ButtonChooser(3); });
	}

	public void PlayText()
	{
		if (textComponent.text == buttonTexts[index])
		{
			NextLine();
		}
		else
		{
			StopAllCoroutines();
			textComponent.text = buttonTexts[index];
		}
	}

	IEnumerator TypeLine()
	{

		foreach (char C in buttonTexts[index].ToCharArray())
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
			StartCoroutine(TypeLine());
		}
		else
		{
			OnFinishedDialogue?.Invoke();
			index = 0;
		}
	}

	public void ButtonChooser(int buttonIndex)
	{
		if (buttonIndex >= 0 && buttonIndex < buttonTexts.Length)
		{
			StopAllCoroutines();
			textComponent.text = string.Empty;
			index = buttonIndex;
			PlayText();
		}
		else
		{
			Debug.LogError("Invalid button index or buttonTexts array length insufficient.");
		}
	}
}

