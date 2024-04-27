using System.Collections;
using UnityEngine;

public class PokemonRecover : MonoBehaviour
{
	[SerializeField] private PokemonStats player;
	[SerializeField] private Healthbar playerhealthbar;
	
	[SerializeField] private ParticleSystem recoverParticles;
	
	
	
	public void StartRecover()
	{
		StartCoroutine(Recover());
		
	}
	private IEnumerator Recover()
	{
		yield return new WaitForSeconds(0.2f);
		//UICanvas.SetActive(false);

		yield return new WaitForSeconds(3);
		
		if (player.currentHealth <= player.maxHealth)
		{
			recoverParticles.Play();
			yield return new WaitForSeconds(2.4f);

			player.currentHealth += (player.currentHealth / 2) + 20;

			playerhealthbar.time = 0f;
		}
		else if (player.currentHealth >= player.maxHealth)
		{
			player.currentHealth = player.maxHealth;
		}
		
	}
}
