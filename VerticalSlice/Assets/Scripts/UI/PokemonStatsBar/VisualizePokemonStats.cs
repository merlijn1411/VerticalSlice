using TMPro;
using UnityEngine;

public class VisualizePokemonStats : MonoBehaviour
{
	[SerializeField] private PokemonStats player;
	[SerializeField] private PokemonStats enemy;
	
	[SerializeField] private TextMeshProUGUI playerNameText;
	[SerializeField] private TextMeshProUGUI enemyNameText;
	[SerializeField] private TextMeshProUGUI playerHealthText;

	public void Update()
	{
			playerNameText.text = $"{player.PokeName}";
			enemyNameText.text = $"{enemy.PokeName}";

			playerHealthText.text = $"{player.currentHealth}" + "/" + $"{player.maxHealth}";
	}

}
