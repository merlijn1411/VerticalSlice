using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PPSystem : MonoBehaviour
{
	[SerializeField] private int pp = 5;
	[SerializeField] private int ppTotal = 5;
	[SerializeField] private Button attackButton;
	[SerializeField] private TextMeshProUGUI ppText;


	private void Start()
	{
		SetPP();
	}
	public void DecreasePP()
	{
		pp -= 1;
		if (pp == 0)
		{
			attackButton.interactable = false;
		}
		SetPP();
	}

	public void SetPP()
	{
		ppText.text = pp + " / " + ppTotal;
	}
}