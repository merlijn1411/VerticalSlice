using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBaseManager : MonoBehaviour
{
	public enum ElementType { Physic, Ghost, Grass }

	[SerializeField] private PlayerStats Player = null;
	[SerializeField] private EnemyStats Enemy = null;
	[SerializeField] private Button AttackBtn = null;

	//[SerializeField] private GameObject UICanvas = null;
	//[SerializeField] private GameObject ButtonCanvas = null;
	//[SerializeField] private GameObject AttackButtons = null;

	[SerializeField] private float PhysicPower;
	[SerializeField] private float GhostPower;
	[SerializeField] private float GrassPower;

	private bool isplayerTurn = true;

	private void Update()
	{
		if (Player.CurrentHealth <= 0 || Enemy.CurrentHealth <= 0)
		{
			StopAllCoroutines();
		}
	}
	private void Attack1(Component target)
	{
		if (target == Enemy)
		{
			Enemy.CurrentHealth -= CalculateDamage(Player.AttackDamage, Player.typeElement);

			Debug.Log("over gebleven health van Enemy = " + Enemy.CurrentHealth);
		}
		else
		{
			Player.CurrentHealth -= CalculateDamage(Enemy.AttackDamage, Enemy.typeElement);

			Debug.Log("over gebleven health van Player = " + Player.CurrentHealth);
		}

		ChangeTurn();
	}

	public void BtnAttack1()
	{
		Attack1(Enemy);
	}

	private void ChangeTurn()
	{
		isplayerTurn = !isplayerTurn;

		if (!isplayerTurn)
		{
			//UICanvas.SetActive(false);
			AttackBtn.interactable = false;

			StartCoroutine(EnemyTurn());
		}
		else
		{
			//ResetCanvas();
			AttackBtn.interactable = true;
		}
	}
	/*/public void ResetCanvas()
	{
		ButtonCanvas.SetActive(true);
		AttackButtons.SetActive(false);
		UICanvas.SetActive(true);
	}/*/

	public int CalculateDamage(int AttackDamage, ElementType elementType)
	{
		float PokemonDamage = AttackDamage;
		switch (elementType)
		{
			case ElementType.Physic:
				PokemonDamage = AttackDamage * PhysicPower;
				break;
			case ElementType.Ghost:
				PokemonDamage = AttackDamage * GhostPower;
				break;
			case ElementType.Grass:
				PokemonDamage = AttackDamage * GrassPower;
				break;

		}
		return Mathf.RoundToInt(PokemonDamage);
	}

	private IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(3);

		int random = 0;
		random = Random.Range(1, 3);
		Debug.Log("deze Randomizer is voor later " + random);
		Attack1(Player);
	}
}