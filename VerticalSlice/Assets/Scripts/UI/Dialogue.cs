using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
	static public event Action OnFinishedDialogue;

	public TextMeshProUGUI textComponent;
	public string[] lines;
	private float textspeed;

	private int index;
	public GameObject Playing;

	public Button Attackbtn1, Attackbtn2, Attackbtn3, Attackbtn4;

	public void Start()
	{
		Playing.SetActive(true);
		textspeed = 2 * Time.deltaTime;
		textComponent.text = string.Empty;
		StartDialogue();

		EndPanelAnimation.OnPanelAnimationEndEvent += PlayText;

		Button btn1 = Attackbtn1.GetComponent<Button>();
		btn1.onClick.AddListener(delegate { ButtonChooser(Attackbtn1); });

		Button btn2 = Attackbtn2.GetComponent<Button>();
		btn2.onClick.AddListener(delegate { ButtonChooser(Attackbtn2); });

		Button btn3 = Attackbtn3.GetComponent<Button>();
		btn3.onClick.AddListener(delegate { ButtonChooser(Attackbtn3); });

		Button btn4 = Attackbtn4.GetComponent<Button>();
		btn4.onClick.AddListener(delegate { ButtonChooser(Attackbtn4); });
	}

	public void PlayText()
	{
		if (textComponent.text == lines[index])
		{
			NextLine();
		}
		else
		{
			StopAllCoroutines();
			textComponent.text = lines[index];
		}
	}

	void StartDialogue()
	{
		index = 0;
		StartCoroutine(TypeLine());
	}

	IEnumerator TypeLine()
	{
		foreach (char C in lines[index].ToCharArray())
		{
			textComponent.text += C;
			yield return new WaitForSeconds(textspeed);
		}

	}

	void NextLine()
	{
		if (index < lines.Length - 1)
		{
			index++;
			textComponent.text = string.Empty;
			StartCoroutine(TypeLine());
		}
		else
		{
			OnFinishedDialogue?.Invoke();
			index = 0;
		}
	}

	public void ButtonChooser(Button btn)
	{
		if (btn == Attackbtn1)
		{

			Debug.Log("1");
		}
		if (btn == Attackbtn2)
		{
			Debug.Log("2");
		}
		if (btn == Attackbtn3)
		{
			Debug.Log("3");
		}
		if (btn == Attackbtn4)
		{
			Debug.Log("4");
		}
	}
}
