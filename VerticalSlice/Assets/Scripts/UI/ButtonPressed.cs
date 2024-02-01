using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
	public Button button;

	public void Start()
	{
		button.onClick.AddListener(ScaleButton);
	}

	public void ScaleButton()
	{
		button.transform.localScale = new Vector3(1.75f, 2.35f, 0f);

		Invoke("ScaleToNormal", 0.1f);
	}

	public void ScaleToNormal()
	{
		button.transform.localScale = new Vector3(2f, 2.9f, 0f);

	}
}
