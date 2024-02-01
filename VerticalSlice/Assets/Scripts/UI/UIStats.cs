using TMPro;
using UnityEngine;

public class UIStats : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI PlayerNameText, EnemyNameText = null;
	[SerializeField] private TextMeshProUGUI PlayerHealthText = null;

	public void Update()
	{
		PlayerNameText.text = PlayerStats.Name.ToString();
		EnemyNameText.text = EnemyStats.Name.ToString();

		PlayerHealthText.text = PlayerStats.STCurrentH.ToString() + "/" + PlayerStats.STMaxH.ToString();
	}

}
