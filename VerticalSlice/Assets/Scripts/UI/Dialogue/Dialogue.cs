using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textComponent;
	
	[SerializeField] private GameObject Playing;

	[SerializeField] private Button[] AttackBtn;

	[SerializeField] private string[] PlayerTexts;
	[SerializeField] private string EnemyText;

	[SerializeField] private TextPanelAnimation textPanel;
	
	private float textspeed;
	private int index;
	
	public void Start()
	{
		Playing.SetActive(true);
		textspeed = 2 * Time.deltaTime;
		
		InstantiateButtons();
	}

	private void InstantiateButtons()
	{
		index = 0;

		for (int i = index; i < AttackBtn.Length; i++)
		{
			int Buttonvalue = i;
			AttackBtn[i].onClick.AddListener(() => ButtonChooser(Buttonvalue));
		}
	}

	public void StartEnemyDialogue()
	{
		StartCoroutine(EnemyDialogueLine());
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
		
	}
	public IEnumerator EnemyDialogueLine()
	{
		yield return new WaitForSeconds(1.8f);
		foreach (char E in EnemyText.ToCharArray())
		{
			textComponent.text += E;
			yield return new WaitForSeconds(textspeed);
		}
		yield return new WaitForSeconds(5f);

		textComponent.text = string.Empty;
		
	}

	public void ButtonChooser(int buttonIndex)
	{
		StartCoroutine(TypeLine(buttonIndex));
	}
}

