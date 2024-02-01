using UnityEngine;
using UnityEngine.UI;

public class FightButton : MonoBehaviour
{
	[SerializeField] private GameObject CanvasStart = null;
	[SerializeField] private GameObject CanvasAttack = null;

	public Button FightB;

	public void Start()
	{
		CanvasAttack.SetActive(false);

		FightB.onClick.AddListener(ScaleButton);
	}

	public void Battle()
	{
		CanvasStart.SetActive(false);
		CanvasAttack.SetActive(true);
	}

	public void ScaleButton()
	{
		FightB.transform.localScale = new Vector3(1.75f, 2.35f, 0f);

		Invoke("ScaleToNormal", 0.1f);
	}

	public void ScaleToNormal()
	{
		FightB.transform.localScale = new Vector3(2f, 2.9f, 0f);

		Invoke("Battle", 0.1f);

	}
}
