using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
	PokemonStats Player;

	public Button[] buttons;

	[SerializeField] private GameObject CanvasStart;
	[SerializeField] private GameObject CanvasAttack;

	public void Start()
	{
		Player = GameObject.Find("Reuniclus").GetComponent<PokemonStats>();
		InitializeButtons();
	}

	private void InitializeButtons()
	{
		int index = 0;
		for (int i = index; i < buttons.Length; i++)
		{
			int buttonValue = i;
			buttons[i].onClick.AddListener(() => { ScaleButton(buttonValue); });
		}
	} 
		 
	private void Update()
	{
		IsHealthFull();
	}

	private void IsHealthFull()
	{
		if (Player.currentHealth == Player.maxHealth)
		{
			buttons[2].interactable = false;
		}
		else if (Player.currentHealth != Player.maxHealth)
		{
			buttons[2].interactable = true;
		}
	}
	public void ButtonFight()
	{
		StartCoroutine(BattleIn());
	}

	public IEnumerator BattleIn()
	{
		yield return new WaitForSeconds(0.2f);
		CanvasStart.SetActive(false);
		CanvasAttack.SetActive(true);
	}

	public void ScaleButton(int buttonindex)
	{
		buttons[buttonindex].transform.localScale = new Vector3(1.75f, 2.35f, 0f);

		StartCoroutine(ScaleToNormal(buttonindex));
	}

	public IEnumerator ScaleToNormal(int buttonindex)
	{
		yield return new WaitForSeconds(0.1f);

		buttons[buttonindex].transform.localScale = new Vector3(2.1f, 2.9f, 0f);

	}
}
