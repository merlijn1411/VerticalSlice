using System.Collections;
using TMPro;
using UnityEngine;

public class TextAppearance : MonoBehaviour
{
	private float delay = 1f;
	public string FullText;
	private string currentText;
	// Start is called before the first frame update
	void Start()
	{
		if (FullText != null)
		{
			StartCoroutine(ShowText());
		}

	}

	public IEnumerator ShowText()
	{

		for (int i = -0; i < FullText.Length; i++)
		{
			currentText = FullText.Substring(0, i);
			this.GetComponent<TextMeshPro>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}
}
