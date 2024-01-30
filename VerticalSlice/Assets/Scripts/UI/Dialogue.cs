using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
	public TextMeshProUGUI textComponent;
	private float textspeed;

	private int index;
	public GameObject Playing;

	public Button[] AttackBtn;

	public string[] PlayerTexts;
	public string EnemyText;

	public TextPanelAnimation textPanel;

	public void Start()
	{
		Playing.SetActive(true);
		textspeed = 2 * Time.deltaTime;


		index = 0;

		for (int i = index; i < AttackBtn.Length; i++)
		{
			int Buttonvalue = i;
			AttackBtn[i].onClick.AddListener(() => ButtonChooser(Buttonvalue));
		}

	}

	IEnumerator TypeLine(int buttonIndex)
	{
		yield return new WaitForSeconds(1.8f);
		foreach (char C in PlayerTexts[buttonIndex].ToCharArray())
		{
			textComponent.text += C;
			yield return new WaitForSeconds(textspeed);
		}
		yield return new WaitForSeconds(6f);

		textComponent.text = string.Empty;

		TextPanelAnimation textPanelAnimation = textPanel.GetComponent<TextPanelAnimation>();
		textPanelAnimation.GetComponent<TextPanelAnimation>().PanelDissapear();
	}
	public IEnumerator EnemyDialogueLine()
	{
		yield return new WaitForSeconds(1.8f);
		foreach (char E in EnemyText.ToCharArray())
		{
			textComponent.text += E;
			yield return new WaitForSeconds(textspeed);
		}
		yield return new WaitForSeconds(6f);

		textComponent.text = string.Empty;

		TextPanelAnimation textPanelAnimation = textPanel.GetComponent<TextPanelAnimation>();
		textPanelAnimation.GetComponent<TextPanelAnimation>().PanelDissapear();
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

