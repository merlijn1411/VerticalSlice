using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBaseManager : MonoBehaviour
{
	public enum ElementType { Physic, Ghost, Grass }

	PlayerStats Player;
	EnemyStats Enemy;

	[SerializeField] private Button AttackBtn = null;

	//[SerializeField] private GameObject UICanvas = null;
	//[SerializeField] private GameObject ButtonCanvas = null;
	//[SerializeField] private GameObject AttackButtons = null;

	[SerializeField] private float PhysicPower;
	[SerializeField] private float GhostPower;
	[SerializeField] private float GrassPower;

	[SerializeField] private Healthbar Playerhealthbar;
	[SerializeField] private Healthbar Enemyhealthbar;

	private bool isplayerTurn = true;

	Animator Phan_anim;

	void Start()
	{
		Player = GameObject.Find("Reuniclus").GetComponent<PlayerStats>();
		Enemy = GameObject.Find("Phantump").GetComponent<EnemyStats>();

		Phan_anim = GameObject.Find("Phantump").GetComponent<Animator>();
	}
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
			Enemyhealthbar.time = 0f;
		}
		else
		{
			Player.CurrentHealth -= CalculateDamage(Enemy.AttackDamage, Enemy.typeElement);
			Playerhealthbar.time = 0f;

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
		//Phan_anim.Play("Attack");
	}
}