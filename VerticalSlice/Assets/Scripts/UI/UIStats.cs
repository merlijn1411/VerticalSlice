using TMPro;
using UnityEngine;

public class UIStats : MonoBehaviour
{
	public TextMeshProUGUI PlayerNameText, EnemyNameText = null;

	void Start()
	{

	}
	void Update()
	{
		PlayerNameText.text = PlayerStats.Name.ToString();
		EnemyNameText.text = EnemyStats.Name.ToString();

	}

}
